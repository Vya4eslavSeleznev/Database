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

CREATE PROCEDURE MoneyTurnOver AS
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