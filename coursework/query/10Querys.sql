USE Bank;

/*1*/
SELECT DISTINCT FirstName, LastName, PassportNum, Birthday, Phone
FROM Customer
JOIN Balance ON Customer.BalanceId = Balance.BalanceId
JOIN BalanceCards ON Balance.CardId = BalanceCards.CardId
JOIN CardServices ON BalanceCards.CardId = CardServices.CardId
WHERE EXISTS
(
	SELECT ServiceId
	FROM CardServices
	WHERE ServiceId =
	(
		SELECT CardServiceId
		FROM CardService
		WHERE NAME = 'SMS'
	)
)
--=======================================================
SELECT DISTINCT FirstName, LastName, PassportNum, Birthday, Phone
FROM Customer
JOIN Balance ON Customer.BalanceId = Balance.BalanceId
JOIN BalanceCards ON Balance.CardId = BalanceCards.CardId
JOIN CardServices ON BalanceCards.CardId = CardServices.CardId
WHERE EXISTS
(
	SELECT ServiceId
	FROM CardServices
	WHERE ServiceId = 1
)

/*2*/
SELECT Name, SUM(CustomerSecurities.Count), [Percent rate]
FROM CustomerSecurities
JOIN InfoSecurities ON CustomerSecurities.InfoSecuritiesId = InfoSecurities.InfoSecuritiesId
GROUP BY Name, [Percent rate]
ORDER BY COUNT(*) DESC