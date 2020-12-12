CREATE TABLE [dbo].[Article](
	[ArticleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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

CREATE TABLE [dbo].[BalanceCards](
	[BalanceId] [int] NOT NULL,
	[CardId] [int] NOT NULL
) ON [PRIMARY]
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

CREATE TABLE [dbo].[CardServices](
	[CardId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL
) ON [PRIMARY]
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


