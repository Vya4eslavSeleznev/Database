USE [Bank]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[ArticleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Balance]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Balance](
	[BalanceId] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[CustomerId] [int] NULL,
	[Cash] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Balance] PRIMARY KEY CLUSTERED 
(
	[BalanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BalanceCards]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BalanceCards](
	[BalanceId] [int] NOT NULL,
	[CardId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[CardId] [int] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CardService]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardService](
	[CardServiceId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_CardService] PRIMARY KEY CLUSTERED 
(
	[CardServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CardServices]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardServices](
	[CardId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[CurrencyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[PassportNum] [int] NOT NULL,
	[Birthday] [date] NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerCredit]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerCredit](
	[CustomerCreditId] [int] IDENTITY(1,1) NOT NULL,
	[InfoCreditId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Info] [varchar](50) NULL,
	[Amount] [int] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_Credit] PRIMARY KEY CLUSTERED 
(
	[CustomerCreditId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerDeposit]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDeposit](
	[CustomerDepositId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[InfoDepositId] [int] NOT NULL,
	[Amount] [int] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_CustomerDeposit] PRIMARY KEY CLUSTERED 
(
	[CustomerDepositId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerSecurities]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerSecurities](
	[SecuritiesId] [int] IDENTITY(1,1) NOT NULL,
	[InfoSecuritiesId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_CustomerSecurities] PRIMARY KEY CLUSTERED 
(
	[SecuritiesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfoCredit]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfoCredit](
	[InfoCreditId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[Percent] [int] NOT NULL,
	[Term] [int] NOT NULL,
 CONSTRAINT [PK_InfoCreditId] PRIMARY KEY CLUSTERED 
(
	[InfoCreditId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfoDeposit]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfoDeposit](
	[InfoDepositId] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[Term] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Percent] [int] NOT NULL,
	[DepositName] [varchar](50) NULL,
 CONSTRAINT [PK_InfoDeposit] PRIMARY KEY CLUSTERED 
(
	[InfoDepositId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfoSecurities]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfoSecurities](
	[InfoSecuritiesId] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Percent rate] [int] NOT NULL,
 CONSTRAINT [PK_InfoSecurities] PRIMARY KEY CLUSTERED 
(
	[InfoSecuritiesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operation]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operation](
	[OperationId] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[BalanceId] [int] NOT NULL,
	[Cash] [money] NOT NULL,
	[Date] [date] NOT NULL,
	[WhoseBalance] [int] NOT NULL,
 CONSTRAINT [PK_Operation] PRIMARY KEY CLUSTERED 
(
	[OperationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [nvarchar](44) NOT NULL,
	[Role] [int] NOT NULL,
	[Salt] [nvarchar](44) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_User_Login] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Balance]  WITH CHECK ADD  CONSTRAINT [FK_Balance_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([CurrencyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Balance] CHECK CONSTRAINT [FK_Balance_Currency]
GO
ALTER TABLE [dbo].[Balance]  WITH CHECK ADD  CONSTRAINT [FK_Balance_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Balance] CHECK CONSTRAINT [FK_Balance_Customer]
GO
ALTER TABLE [dbo].[BalanceCards]  WITH CHECK ADD  CONSTRAINT [FK_BalanceCards_Balance] FOREIGN KEY([BalanceId])
REFERENCES [dbo].[Balance] ([BalanceId])
GO
ALTER TABLE [dbo].[BalanceCards] CHECK CONSTRAINT [FK_BalanceCards_Balance]
GO
ALTER TABLE [dbo].[BalanceCards]  WITH CHECK ADD  CONSTRAINT [FK_BalanceCards_Card] FOREIGN KEY([CardId])
REFERENCES [dbo].[Card] ([CardId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BalanceCards] CHECK CONSTRAINT [FK_BalanceCards_Card]
GO
ALTER TABLE [dbo].[CardServices]  WITH CHECK ADD  CONSTRAINT [FK_CardServices_Card] FOREIGN KEY([CardId])
REFERENCES [dbo].[Card] ([CardId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CardServices] CHECK CONSTRAINT [FK_CardServices_Card]
GO
ALTER TABLE [dbo].[CardServices]  WITH CHECK ADD  CONSTRAINT [FK_CardServices_CardService] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[CardService] ([CardServiceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CardServices] CHECK CONSTRAINT [FK_CardServices_CardService]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_User]
GO
ALTER TABLE [dbo].[CustomerCredit]  WITH CHECK ADD  CONSTRAINT [FK_CustomerCredit_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerCredit] CHECK CONSTRAINT [FK_CustomerCredit_Customer]
GO
ALTER TABLE [dbo].[CustomerCredit]  WITH CHECK ADD  CONSTRAINT [FK_CustomerCredit_InfoCredit] FOREIGN KEY([InfoCreditId])
REFERENCES [dbo].[InfoCredit] ([InfoCreditId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerCredit] CHECK CONSTRAINT [FK_CustomerCredit_InfoCredit]
GO
ALTER TABLE [dbo].[CustomerDeposit]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDeposit_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerDeposit] CHECK CONSTRAINT [FK_CustomerDeposit_Customer]
GO
ALTER TABLE [dbo].[CustomerDeposit]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDeposit_InfoDeposit] FOREIGN KEY([InfoDepositId])
REFERENCES [dbo].[InfoDeposit] ([InfoDepositId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerDeposit] CHECK CONSTRAINT [FK_CustomerDeposit_InfoDeposit]
GO
ALTER TABLE [dbo].[CustomerSecurities]  WITH CHECK ADD  CONSTRAINT [FK_CustomerSecurities_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerSecurities] CHECK CONSTRAINT [FK_CustomerSecurities_Customer]
GO
ALTER TABLE [dbo].[CustomerSecurities]  WITH CHECK ADD  CONSTRAINT [FK_CustomerSecurities_InfoSecurities] FOREIGN KEY([InfoSecuritiesId])
REFERENCES [dbo].[InfoSecurities] ([InfoSecuritiesId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerSecurities] CHECK CONSTRAINT [FK_CustomerSecurities_InfoSecurities]
GO
ALTER TABLE [dbo].[InfoCredit]  WITH CHECK ADD  CONSTRAINT [FK_InfoCredit_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([CurrencyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InfoCredit] CHECK CONSTRAINT [FK_InfoCredit_Currency]
GO
ALTER TABLE [dbo].[InfoDeposit]  WITH CHECK ADD  CONSTRAINT [FK_InfoDeposit_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([CurrencyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InfoDeposit] CHECK CONSTRAINT [FK_InfoDeposit_Currency]
GO
ALTER TABLE [dbo].[InfoSecurities]  WITH CHECK ADD  CONSTRAINT [FK_InfoSecurities_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([CurrencyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InfoSecurities] CHECK CONSTRAINT [FK_InfoSecurities_Currency]
GO
ALTER TABLE [dbo].[Operation]  WITH CHECK ADD  CONSTRAINT [FK_Operation_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([ArticleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Operation] CHECK CONSTRAINT [FK_Operation_Article]
GO
ALTER TABLE [dbo].[Operation]  WITH CHECK ADD  CONSTRAINT [FK_Operation_Balance] FOREIGN KEY([BalanceId])
REFERENCES [dbo].[Balance] ([BalanceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Operation] CHECK CONSTRAINT [FK_Operation_Balance]
GO
ALTER TABLE [dbo].[Operation]  WITH CHECK ADD  CONSTRAINT [FK_Operation_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([CurrencyId])
GO
ALTER TABLE [dbo].[Operation] CHECK CONSTRAINT [FK_Operation_Currency]
GO
/****** Object:  StoredProcedure [dbo].[CurrencyStatistics]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CurrencyStatistics] AS
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
/****** Object:  StoredProcedure [dbo].[InactiveCustomers]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InactiveCustomers] AS
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
/****** Object:  StoredProcedure [dbo].[MoneyTurnover]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MoneyTurnover] AS
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
/****** Object:  StoredProcedure [dbo].[OperationStatistic]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[OperationStatistic]
	-- Add the parameters for the stored procedure here
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
	WHERE Balance.CustomerId = @CustomerId AND
	Currency.CurrencyId = @CurrencyId AND
	Operation.Date >= @StartDate AND
	Operation.Date <= @EndDate
	GROUP BY Article.Name, MONTH(Operation.Date), YEAR(Operation.Date)
	ORDER BY SUM(Operation.Cash);
END
GO
/****** Object:  StoredProcedure [dbo].[PoorestCustomers]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PoorestCustomers] AS
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
/****** Object:  StoredProcedure [dbo].[RichestCustomers]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RichestCustomers] AS
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
/****** Object:  StoredProcedure [dbo].[ServiceStatistic]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ServiceStatistic]
	@ServiceId INT
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
	WHERE CardService.CardServiceId = @ServiceId
END
GO
/****** Object:  Trigger [dbo].[BalancePositiveCash]    Script Date: 12.12.2020 5:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[BalancePositiveCash] 
ON [dbo].[Balance] AFTER UPDATE
AS
	IF EXISTS(SELECT * FROM inserted WHERE inserted.Cash < 0)
	BEGIN
		RAISERROR ('Negative balance', 16, 1);
		ROLLBACK TRANSACTION;
		RETURN;
	END
GO
ALTER TABLE [dbo].[Balance] ENABLE TRIGGER [BalancePositiveCash]
GO
/****** Object:  Trigger [dbo].[CardServiceWriteOff]    Script Date: 12.12.2020 5:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[CardServiceWriteOff]
ON [dbo].[CardServices] AFTER INSERT
AS
	DECLARE @article_id INT = 8;
	
	INSERT INTO Operation (ArticleId, CurrencyId, BalanceId, Cash, Date, WhoseBalance)
	SELECT @article_id, BC.CurrencyId, BC.BalanceId, -CardService.Price, GETDATE(), 00001
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
ALTER TABLE [dbo].[CardServices] ENABLE TRIGGER [CardServiceWriteOff]
GO
/****** Object:  Trigger [dbo].[BalanceWriteOff]    Script Date: 12.12.2020 5:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[BalanceWriteOff] 
ON [dbo].[Operation] AFTER INSERT
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
ALTER TABLE [dbo].[Operation] ENABLE TRIGGER [BalanceWriteOff]
GO
