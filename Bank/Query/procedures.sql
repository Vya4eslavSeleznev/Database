CREATE PROCEDURE CurrencyStatistics AS
BEGIN
	WITH balanceTotalCount (Cnt)
	AS
	(	
		SELECT COUNT(*) FROM Balance
	),
	creditTotalCount (Cnt)
	AS
	(
		SELECT COUNT(*) FROM CustomerCredit
	),
	depositeTotalCount (Cnt)
	AS
	(
		SELECT COUNT(*) FROM CustomerDeposit
	)
	
	SELECT Currency.Name, Stats.Type, (CAST(Stats.Count AS DECIMAL) * 100 / 
		(
			CASE Stats.Type
				WHEN 'Balance' THEN (SELECT Cnt FROM balanceTotalCount)
				WHEN 'Deposite' THEN (SELECT Cnt FROM depositeTotalCount)
				WHEN 'Credit' THEN (SELECT Cnt FROM creditTotalCount)
			END
		)) AS [Percent]
	FROM Currency
	JOIN
	(
		SELECT Currency.CurrencyId, 'Balance' AS 'Type', COUNT(*) AS 'Count'
		FROM Currency
		JOIN Balance ON Currency.CurrencyId = Balance.CurrencyId
		GROUP BY Currency.CurrencyId
		UNION
		SELECT Currency.CurrencyId, 'Deposite' AS 'Type', COUNT(*) AS 'Count' 
		FROM CustomerDeposit
		JOIN InfoDeposit ON CustomerDeposit.InfoDepositId = InfoDeposit.InfoDepositId
		JOIN Currency ON InfoDeposit.CurrencyId = Currency.CurrencyId
		GROUP BY Currency.CurrencyId
		UNION
		SELECT Currency.CurrencyId, 'Credit' AS 'Type', COUNT(*)
		FROM CustomerCredit
		JOIN InfoCredit ON CustomerCredit.InfoCreditId = InfoCredit.InfoCreditId
		JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId
		GROUP BY Currency.CurrencyId
	) AS Stats ON Currency.CurrencyId = Stats.CurrencyId
	ORDER BY Stats.Type
END
GO

CREATE PROCEDURE MoneyTurnover AS
BEGIN
	SELECT 
	Currency.[Name],
	D.DepositAmount,
	B.BalanceAmount,
	C.CreditAmount
	FROM Currency
	JOIN
	(
		SELECT Currency.CurrencyId, ISNULL(SUM(CustomerDeposit.Amount), 0) AS DepositAmount 
		FROM CustomerDeposit
		JOIN InfoDeposit ON CustomerDeposit.InfoDepositId = InfoDeposit.InfoDepositId
		JOIN Currency ON InfoDeposit.CurrencyId = Currency.CurrencyId
		GROUP BY Currency.CurrencyId
	) AS D ON Currency.CurrencyId = D.CurrencyId
	JOIN
	(
		SELECT Currency.CurrencyId, Balance.Cash AS BalanceAmount 
		FROM Balance
		JOIN Currency ON Balance.CurrencyId = Currency.CurrencyId
		GROUP BY Currency.CurrencyId, Balance.Cash
	) AS B ON Currency.CurrencyId = B.CurrencyId
	JOIN
	(
		SELECT Currency.CurrencyId, ISNULL(SUM(Amount), 0) AS CreditAmount FROM CustomerCredit
		JOIN InfoCredit ON CustomerCredit.InfoCreditId = InfoCredit.InfoCreditId
		JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId
		GROUP BY Currency.CurrencyId
	) AS C ON Currency.CurrencyId = C.CurrencyId
END
GO

CREATE PROCEDURE OperationStatistic
	@CustomerId INT,
	@CurrencyId INT,
	@StartDate DATETIME,
	@EndDate DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Article.Name, 
	MONTH(Operation.Date) AS 'Month', 
	YEAR(Operation.Date) AS 'Year', 
	SUM(Operation.Cash) AS 'Sum'
	FROM Article
	JOIN Operation ON Article.ArticleId = Operation.ArticleId
	JOIN Balance ON Operation.BalanceId = Balance.BalanceId
	JOIN Customer ON Balance.CustomerId = Customer.CustomerId
	JOIN Currency ON Operation.CurrencyId = Currency.CurrencyId
	WHERE Balance.CustomerId = @CurrencyId AND
	Currency.CurrencyId = @CurrencyId AND
	Operation.Date >= @StartDate AND
	Operation.Date <= @EndDate
	GROUP BY Article.Name, MONTH(Operation.Date), YEAR(Operation.Date)
	ORDER BY SUM(Operation.Cash);
END
GO

CREATE PROCEDURE ServiceStatistic
	@ServiceName VARCHAR
AS
BEGIN
	SET NOCOUNT ON;

	SELECT FirstName, LastName, PassportNum, Birthday, Phone
	FROM Customer
	JOIN Balance ON Customer.CustomerId = Balance.CustomerId
	JOIN BalanceCards ON Balance.BalanceId = BalanceCards.BalanceId
	JOIN [Card] ON BalanceCards.CardId = [Card].CardId
	JOIN CardServices ON [Card].CardId = CardServices.CardId
	JOIN CardService on CardServices.ServiceId = CardService.CardServiceId
	WHERE CardService.[Name] = @ServiceName
END
GO

CREATE PROCEDURE InactiveCustomers AS
BEGIN
	SELECT Customer.FirstName, Customer.LastName, Customer.Phone
	FROM Customer
	LEFT JOIN
	(
		SELECT CustomerId
		FROM Balance
		WHERE Balance.Date >= DATEADD(MONTH, -2, GETDATE())
		GROUP BY CustomerId
	) AS ActiveCustomerBalance
	ON Customer.CustomerId = ActiveCustomerBalance.CustomerId
	WHERE ActiveCustomerBalance.CustomerId IS NULL;
END
GO

CREATE PROCEDURE RichestCustomers AS
BEGIN
	SELECT TOP(10)
	Info.FirstName,
	Info.LastName,
	SUM(Total) AS Total,
	Currency.[Name]
	FROM
	(
		SELECT
		Customer.CustomerId,
		Balance.CurrencyId,
		Customer.FirstName,
		Customer.LastName, 
		SUM(Balance.Cash) AS Total
		FROM Customer
		JOIN Balance ON Customer.CustomerId = Balance.CustomerId
		GROUP BY Customer.CustomerId, Balance.CurrencyId, Customer.FirstName, Customer.LastName
		UNION
		SELECT
		Customer.CustomerId,
		InfoSecurities.CurrencyId,
		Customer.FirstName,
		Customer.LastName,
		SUM(CustomerSecurities.Count * InfoSecurities.Price) AS Total
		FROM Customer
		JOIN CustomerSecurities ON Customer.CustomerId = CustomerSecurities.CustomerId
		JOIN InfoSecurities ON CustomerSecurities.InfoSecuritiesId = InfoSecurities.InfoSecuritiesId
		GROUP BY Customer.CustomerId, InfoSecurities.CurrencyId, Customer.FirstName, Customer.LastName
		UNION
		SELECT
		Customer.CustomerId,
		InfoDeposit.CurrencyId,
		Customer.FirstName,
		Customer.LastName,
		SUM(CustomerDeposit.Amount * ((CAST(InfoDeposit.[Percent] AS DECIMAL) / 100) + 1)) AS Total
		FROM Customer
		JOIN CustomerDeposit ON Customer.CustomerId = CustomerDeposit.CustomerId
		JOIN InfoDeposit ON CustomerDeposit.InfoDepositId = InfoDeposit.InfoDepositId
		GROUP BY Customer.CustomerId, InfoDeposit.CurrencyId, Customer.FirstName, Customer.LastName
	) AS Info
	JOIN Currency ON Info.CurrencyId = Currency.CurrencyId
	GROUP BY Info.CustomerId, Info.FirstName, Info.LastName, Currency.Name
	ORDER BY Currency.Name, Total DESC
END
GO

CREATE PROCEDURE PoorestCustomers AS
BEGIN
	SELECT 
	Customer.FirstName, Customer.LastName, Customer.Phone
	FROM Customer
	WHERE 
	EXISTS
	(
		SELECT *
		FROM Balance
		WHERE Balance.CustomerId = Customer.CustomerId
		GROUP BY Balance.CustomerId
		HAVING SUM(Balance.Cash) <= 0
	)
	AND EXISTS
	(
		SELECT *
		FROM CustomerCredit
		WHERE CustomerCredit.CustomerId = Customer.CustomerId
	)
END
GO