CREATE TRIGGER BalanceWriteOff 
ON Operation AFTER INSERT
AS
	IF (SELECT Balance.Cash + inserted.Cash FROM Balance JOIN inserted ON Balance.BalanceId = inserted.BalanceId) < 0
	BEGIN
		RAISERROR ('Negative balance', 16, 1);
		ROLLBACK TRANSACTION;
		RETURN;
	END

	UPDATE Balance SET Balance.Cash = Balance.Cash + inserted.Cash
	FROM Balance
	JOIN inserted ON Balance.BalanceId = inserted.BalanceId
GO

CREATE TRIGGER CardServiceWriteOff
ON CardServices AFTER INSERT
AS
	DECLARE @article_id INT = 8;
	
	INSERT INTO Operation (ArticleId, CurrencyId, BalanceId, Cash, Date, WhoseBalance)
	SELECT @article_id, BC.CurrencyId, BC.BalanceId, CardService.Price, GETDATE(), 00001
	FROM inserted
	JOIN CardService ON inserted.ServiceId = CardService.CardServiceId
	JOIN
	(
		SELECT TOP(1) inserted.CardId, Balance.BalanceId, Currency.CurrencyId
		FROM inserted
		JOIN BalanceCards ON inserted.CardId = BalanceCards.CardId
		JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId
		JOIN Currency ON Balance.CurrencyId = Currency.CurrencyId
	) AS BC ON inserted.CardId = BC.CardId
GO 

CREATE TRIGGER AddCredit
ON CustomerCredit AFTER INSERT
AS
	DECLARE @article_id INT = 8;

	INSERT INTO Operation (ArticleId, CurrencyId, BalanceId, Cash, Date, WhoseBalance)
	SELECT @article_id, InfoCredit.CurrencyId, (SELECT TOP(1) BalanceId FROM Balance WHERE Balance.CustomerId = inserted.CustomerId), inserted.Amount, GETDATE(), 00001
	FROM inserted
	JOIN InfoCredit ON inserted.InfoCreditId = InfoCredit.InfoCreditId
GO