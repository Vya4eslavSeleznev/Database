--Authentication
SELECT CustomerId 
FROM Customer
WHERE UserId =
(
	SELECT UserId
	FROM [User]
	WHERE Login = 'login' AND Password = 'pwd'
)

SELECT CustomerId 
FROM Customer
JOIN [User] ON Customer.UserId = [User].Id
WHERE Login = 'login' AND Password = 'pwd'

--my Operation
SELECT *
FROM Operation
WHERE BalanceId =
(
	SELECT BalanceId
	FROM Balance
	WHERE CustomerId = 1
)

SELECT Article.[Name], Currency.[Name], Balance.Number, Operation.Cash, Operation.[Date], Operation.WhoseBalance
FROM Operation
JOIN Article ON Operation.ArticleId = Article.ArticleId
JOIN Currency ON Operation.CurrencyId = Currency.CurrencyId
JOIN Balance ON Operation.BalanceId = Balance.BalanceId
WHERE CustomerId = 1

--my Balance
SELECT BalanceId AS Id, Number, [Date], CurrencyId, Debit, Credit, CardId
FROM Balance
WHERE CustomerId = 1

SELECT Balance.Number, Balance.[Date], Currency.[Name], Balance.Debit, Balance.Credit, Balance.CardId
FROM Balance
JOIN Currency ON Balance.CurrencyId = Currency.CurrencyId
WHERE CustomerId = 1

--my Cards
SELECT [Card].Number, CardService.[Name] AS Service
FROM [Card]
JOIN CardService ON [Card].CardServiceId = CardService.CardServiceId
JOIN BalanceCards ON [Card].CardId = BalanceCards.BalanceId
JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId
WHERE Balance.CustomerId = 1

--CardService
SELECT [Name], Price
FROM CardService

--My Credit
SELECT CustomerCredit.Info, CustomerCredit.Amount, Currency.[Name] AS Currency, InfoCredit.Term, InfoCredit.[Percent]
FROM CustomerCredit
JOIN InfoCredit ON CustomerCredit.InfoCreditId = InfoCredit.InfoCreditId
JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId
WHERE CustomerId = 1

--Credit Info
SELECT InfoCredit.[Name] AS NameOfCredit, Currency.[Name] AS Currency, InfoCredit.[Percent], InfoCredit.Term, InfoCredit.Date
FROM InfoCredit
JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId

--Deposit info
SELECT InfoDeposit.Term, InfoDeposit.Amount, Currency.[Name] AS Currency, InfoDeposit.[Percent], InfoDeposit.DepositName
FROM InfoDeposit
JOIN Currency ON InfoDeposit.CurrencyId = Currency.CurrencyId

--My Deposit
SELECT InfoDeposit.DepositName, CustomerDeposit.Amount
FROM CustomerDeposit
JOIN InfoDeposit ON CustomerDeposit.InfoDepositId = InfoDeposit.InfoDepositId
WHERE CustomerId = 1

--My Securities
SELECT InfoSecurities.[Name], CustomerSecurities.Count
FROM CustomerSecurities
JOIN InfoSecurities ON CustomerSecurities.InfoSecuritiesId = InfoSecurities.InfoSecuritiesId
WHERE CustomerId = 1

--Security Info
SELECT InfoSecurities.[Name], InfoSecurities.Price, Currency.[Name] AS Currency, InfoSecurities.[Percent rate]
FROM InfoSecurities
JOIN Currency ON InfoSecurities.CurrencyId = Currency.CurrencyId

--Profile
SELECT FirstName, LastName, Birthday, PassportNum, Phone, [Login], [Password]
FROM Customer
JOIN [User] ON Customer.UserId = [User].Id