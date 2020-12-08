USE Bank;

/*1*/
--Клиенты, у которых есть счет(баланс) с карточкой и с услугой SMS
SELECT FirstName, LastName, PassportNum, Birthday, Phone
FROM Customer
JOIN Balance ON Customer.CustomerId = Balance.CustomerId
JOIN BalanceCards ON Balance.BalanceId = BalanceCards.BalanceId
JOIN [Card] ON BalanceCards.CardId = [Card].CardId
JOIN CardServices ON [Card].CardId = CardServices.CardId
JOIN CardService on CardServices.ServiceId = CardService.CardServiceId
WHERE CardService.[Name] = 'Call';

/*2*/
--Топ акций: количество купленных, процентная ставка
SELECT Name, SUM(CustomerSecurities.Count), [Percent rate]
FROM CustomerSecurities
JOIN InfoSecurities ON CustomerSecurities.InfoSecuritiesId = InfoSecurities.InfoSecuritiesId
GROUP BY Name, [Percent rate]
ORDER BY COUNT(*) DESC

SELECT Name, SUM(CustomerSecurities.Count), [Percent rate]
FROM CustomerSecurities
JOIN InfoSecurities ON CustomerSecurities.InfoSecuritiesId = InfoSecurities.InfoSecuritiesId
GROUP BY Name, [Percent rate]
ORDER BY SUM(CustomerSecurities.Count) DESC

/*3*/
--Самые популярные вклады
SELECT TOP(10)
InfoDeposit.DepositName,
COUNT(*) AS DepositCount
FROM InfoDeposit
JOIN CustomerDeposit ON InfoDeposit.InfoDepositId = CustomerDeposit.InfoDepositId
GROUP BY InfoDeposit.DepositName
HAVING COUNT(*) > 10
ORDER BY COUNT(*)

SELECT TOP(10)
InfoCredit.[Name],
COUNT(*) AS CreditCount
FROM InfoCredit
JOIN CustomerCredit ON InfoCredit.InfoCreditId = CustomerCredit.InfoCreditId
GROUP BY InfoCredit.[Name]
HAVING COUNT(*) > 10
ORDER BY COUNT(*)

/*4*/
--Сколько было выплачено людям по вкладам
SELECT Currency.[Name], InfoDeposit.DepositName, SUM(CustomerDeposit.Amount) * InfoDeposit.[Percent]
FROM InfoDeposit
JOIN CustomerDeposit ON InfoDeposit.InfoDepositId = CustomerDeposit.InfoDepositId
JOIN Currency ON InfoDeposit.CurrencyId = Currency.CurrencyId
GROUP BY Currency.[Name], InfoDeposit.DepositName, InfoDeposit.[Percent]

/*5*/
-- Клиенты которые не совершали операций в банке в последние два месяца
SELECT Customer.FirstName, Customer.LastName, Customer.Phone
FROM Customer
LEFT JOIN
(
	SELECT CustomerBalances.CustomerId
	FROM Balance
	JOIN CustomerBalances ON Balance.BalanceId = CustomerBalances.BalanceId
	WHERE Balance.Date >= DATEADD(MONTH, -2, GETDATE())
	GROUP BY CustomerBalances.CustomerId
) AS ActiveCustomerBalances
ON Customer.CustomerId = ActiveCustomerBalances.CustomerId
WHERE ActiveCustomerBalances.CustomerId IS NULL;

/*6*/
-- Расходы/доходы по категориям для клиента за период времени
SELECT Article.Name, 
MONTH(Operation.Date) AS 'Month', 
YEAR(Operation.Date) AS 'Year', 
SUM(Operation.Cash) AS 'Sum'
FROM Article
JOIN Operation ON Article.ArticleId = Operation.ArticleId
JOIN Balance ON Operation.BalanceId = Balance.BalanceId
JOIN Customer ON Balance.CustomerId = Customer.CustomerId
JOIN Currency ON Operation.CurrencyId = Currency.CurrencyId
WHERE Balance.CustomerId = 1 AND
Currency.CurrencyId = 1
AND Operation.Date >= '2020-01-01' AND Operation.Date <= '2020-12-12'
GROUP BY Article.Name, MONTH(Operation.Date), YEAR(Operation.Date)
ORDER BY SUM(Operation.Cash);

/*7*/
-- Денежный оборот внутри банка
-- Количество денег на депозитах
-- Количество денег на карточках(баланс)
-- Количество денег отдано в кредит
SELECT 
Currency.Name,
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
	SELECT Currency.CurrencyId, (SUM(Debit) + SUM(Credit)) AS BalanceAmount 
	FROM Balance
	JOIN Currency ON Balance.CurrencyId = Currency.CurrencyId
	GROUP BY Currency.CurrencyId
) AS B ON Currency.CurrencyId = B.CurrencyId
JOIN
(
	SELECT Currency.CurrencyId, ISNULL(SUM(Amount), 0) AS CreditAmount FROM CustomerCredit
	JOIN InfoCredit ON CustomerCredit.InfoCreditId = InfoCredit.InfoCreditId
	JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId
	GROUP BY Currency.CurrencyId
) AS C ON Currency.CurrencyId = C.CurrencyId

/*8*/
-- Доля валютных операций
-- Какая валюта доминирует?
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

/*9*/
-- Клиенты с кредитами и с 0 на счету
-- Предположительные должники
SELECT 
Customer.FirstName, Customer.LastName, Customer.Phone
FROM Customer
WHERE 
EXISTS
(
	SELECT *
	FROM Balance
	JOIN CustomerBalances ON Balance.BalanceId = CustomerBalances.BalanceId
	WHERE CustomerBalances.CustomerId = Customer.CustomerId
	GROUP BY CustomerBalances.CustomerId
	HAVING SUM(Balance.Debit) + SUM(Balance.Credit) = 0
)
AND EXISTS
(
	SELECT *
	FROM CustomerCredit
	WHERE CustomerCredit.CustomerId = Customer.CustomerId
)

/*10*/
-- Самые богатые клиенты: Максимальное количество денег на балансе + есть акции + есть вклады
SELECT TOP(10)
Info.FirstName,
Info.LastName,
Currency.Name,
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
	JOIN CustomerBalances ON Customer.CustomerId = CustomerBalances.CustomerId
	JOIN Balance ON CustomerBalances.BalanceId = Balance.BalanceId
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