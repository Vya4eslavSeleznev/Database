CREATE PROCEDURE FillTables
	@CustomerId INT
AS
BEGIN
	SELECT FirstName, LastName, Birthday, PassportNum, Phone, [Login], [Password]
    FROM Customer
    JOIN[User] ON Customer.UserId = [User].Id

	SELECT Article.[Name] AS Article, Currency.[Name] AS Currency, Balance.Number, 
	Operation.Cash, Operation.[Date], Operation.WhoseBalance
    FROM Operation
    JOIN Article
    ON Operation.ArticleId = Article.ArticleId
    JOIN Currency
    ON Operation.CurrencyId = Currency.CurrencyId
    JOIN Balance
    ON Operation.BalanceId = Balance.BalanceId
    WHERE CustomerId = customerId

	SELECT Balance.Number, Balance.[Date], Currency.[Name],
    Balance.Debit, Balance.Credit, Balance.CardId
    FROM Balance
    JOIN Currency ON Balance.CurrencyId = Currency.CurrencyId
    WHERE CustomerId = customerId

	SELECT [Card].Number, CardService.[Name] AS Service
    FROM [Card]
    JOIN CardService ON [Card].CardServiceId = CardService.CardServiceId
    JOIN BalanceCards ON [Card].CardId = BalanceCards.BalanceId
    JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId
    WHERE Balance.CustomerId = customerId

	SELECT [Name], Price
    FROM CardService
END