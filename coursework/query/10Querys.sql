USE Bank;

/*1*/
SELECT *
FROM Customer
JOIN CustomerCredit ON Customer.CustomerId = CustomerCredit.CustomerId
JOIN CustomerBalances ON Customer.CustomerId = CustomerBalances.CustomerId
JOIN Balance ON CustomerBalances.BalanceId = Balance.BalanceId
WHERE EXISTS
(
	SELECT 
)

SELECT *
FROM Customer
JOIN Balance ON Customer.BalanceId = Balance.BalanceId
WHERE EXISTS
(
	SELECT *
	FROM CustomerCredit
	WHERE Customer.CustomerId = CustomerCredit.CustomerId
)

SELECT *
FROM Customer
JOIN Balance ON Customer.BalanceId = Balance.BalanceId
WHERE EXISTS
(
	SELECT *
	FROM BalanceCards
	WHERE Balance.CardId = BalanceCards.CardId
)

/*2*/
SELECT Name, SUM(CustomerSecurities.Count)
FROM CustomerSecurities
JOIN InfoSecurities
ON CustomerSecurities.InfoSecuritiesId = InfoSecurities.InfoSecuritiesId
GROUP BY Name
ORDER BY COUNT(*) DESC