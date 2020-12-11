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
SELECT Currency.[Name] AS Currency, InfoDeposit.Term, InfoDeposit.Amount, InfoDeposit.[Percent], InfoDeposit.DepositName
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

--Update profile

UPDATE Customer
SET
	FirstName = 'TEST_UPDATE',
	LastName = 'TEST',
	Birthday = '2020-01-01',
	PassportNum = 00000000,
	Phone = 777777

WHERE CustomerId = 10

--Add operation
INSERT INTO Operation (ArticleId, CurrencyId, BalanceId, Cash, [Date], WhoseBalance) 
VALUES (1, 1, 2, 777, '2020-01-01', 2123123)

--ComboBox

SELECT InfoCreditId, [Name]
FROM InfoCredit

--Profile

UPDATE [User]
SET [Login] = 'login', [Password] = 'pwd'
FROM [User]
JOIN Customer ON [User].Id = Customer.UserId
WHERE CustomerId = 1

--incert credit
INSERT INTO CustomerCredit(InfoCreditId, CustomerId, Info, Amount) 
VALUES (1, 1, 'TEST', 777)

--Accountant
SELECT [Role]
FROM [User]
WHERE Login = 'login1' AND Password = 'pwd1'

--Accountant Customer Debit
SELECT Customer.FirstName, Customer.LastName, Customer.Phone, Balance.Cash, Balance.Number AS BalanceNumber, [Card].Number AS CardNumber
FROM Customer
JOIN Balance ON Customer.CustomerId = Balance.CustomerId
JOIN BalanceCards ON Balance.BalanceId = BalanceCards.BalanceId
JOIN [Card] ON BalanceCards.CardId = [Card].CardId

--Customer credits
SELECT Customer.FirstName, Customer.LastName, Customer.Phone, InfoCredit.[Name], Currency.[Name], CustomerCredit.Amount, InfoCredit.[Percent]
FROM Customer
JOIN CustomerCredit ON Customer.CustomerId = CustomerCredit.CustomerId
JOIN InfoCredit ON CustomerCredit.InfoCreditId = InfoCredit.InfoCreditId
JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId

--Customer deposits
SELECT Customer.FirstName, Customer.LastName, Customer.Phone, InfoDeposit.DepositName, Currency.[Name], CustomerDeposit.Amount, InfoDeposit.[Percent]
FROM Customer
JOIN CustomerDeposit ON Customer.CustomerId = CustomerDeposit.CustomerId
JOIN InfoDeposit ON CustomerDeposit.InfoDepositId = InfoDeposit.InfoDepositId
JOIN Currency ON InfoDeposit.CurrencyId = Currency.CurrencyId



SELECT Balance.BalanceId, Balance.Number
FROM Balance
JOIN BalanceCards ON Balance.BalanceId = BalanceCards.BalanceId
WHERE BalanceCards.CardId = 9

SELECT [Card].Number--, CardService.[Name] AS Service 
FROM [Card] 
--JOIN CardServices ON [Card].CardId = CardServices.CardId 
--JOIN CardService ON CardServices.ServiceId = CardService.CardServiceId 
JOIN BalanceCards ON [Card].CardId = BalanceCards.CardId 
JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId 
WHERE Balance.CustomerId = 1

SELECT [Card].Number, CardService.[Name]
FROM CardService
JOIN CardServices ON CardService.CardServiceId = CardServices.ServiceId
JOIN [Card] ON CardServices.CardId = [Card].CardId
JOIN BalanceCards ON [Card].CardId = BalanceCards.CardId
JOIN Balance ON Balance.BalanceId = BalanceCards.BalanceId
WHERE Balance.CustomerId = 1

SELECT *
FROM Balance
JOIN BalanceCards ON Balance.BalanceId = BalanceCards.BalanceId
JOIN [Card] ON BalanceCards.CardId = [Card].CardId
JOIN CardServices ON [Card].CardId = CardServices.CardId
JOIN CardService ON CardServices.ServiceId = CardService.CardServiceId
WHERE Balance.CustomerId = 1

INSERT INTO CardServices (CardId, ServiceId) 
VALUES (1, 1)

SELECT [Card].Number
FROM [Card]
JOIN BalanceCards ON [Card].CardId = BalanceCards.CardId
JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId
WHERE Balance.CustomerId = 1

SELECT [Card].Number
FROM [Card]
JOIN BalanceCards ON [Card].CardId = BalanceCards.CardId
JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId
WHERE Balance.CustomerId = 1

SELECT [Card].Number, CardService.[Name]
FROM [Card]
JOIN CardServices ON [Card].CardId = CardServices.CardId
JOIN CardService ON CardServices.ServiceId = CardService.CardServiceId
JOIN BalanceCards ON [Card].CardId = BalanceCards.CardId
JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId
WHERE Balance.CustomerId = 1

SELECT 
Customer.FirstName, 
Customer.LastName, 
Customer.PassportNum, 
Customer.Birthday, 
Customer.Phone, 
[User].Login, 
[User].Password 
FROM Customer 
JOIN [User] ON Customer.UserId = [User].Id