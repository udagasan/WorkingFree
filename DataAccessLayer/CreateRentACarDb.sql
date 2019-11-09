
CREATE SCHEMA Rent


CREATE TABLE [Rent].[Rezervation] (
    [RezervationId]   INT          IDENTITY (1, 1) NOT NULL,
    [Identity]        BIGINT       NOT NULL,
    [PlateNumber]     VARCHAR (50) NOT NULL,
    [BeginDate]       DATETIME     NULL,
    [EndDate]         DATETIME     NULL,
    [Amount]          DECIMAL (18) NULL,
    [RezervationType] VARCHAR (50) NULL,
    [InsertUserName]  VARCHAR (50) NULL,
    [insertDate]      DATETIME     NULL,
    [UpdateUserName]  VARCHAR (50) NULL,
    [UpdateDate]      DATETIME     NULL,
    [CompaignId]      INT          NULL,
    CONSTRAINT [PK_Rezervasyon_id] PRIMARY KEY CLUSTERED ([RezervationId] ASC, [Identity] ASC, [PlateNumber] ASC),
    CONSTRAINT [FK_Rezervation_CompaignId] FOREIGN KEY ([CompaignId]) REFERENCES [Rent].[Campaign] ([id]),
    CONSTRAINT [FK_Rezervation_Identity] FOREIGN KEY ([Identity]) REFERENCES [Rent].[Customer] ([Identity]),
    CONSTRAINT [FK_Rezervation_PlateNumber] FOREIGN KEY ([PlateNumber]) REFERENCES [Rent].[Car] ([PlateNumber])
);




CREATE TABLE [Rent].[Campaign] (
    [id]             INT          IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (50) NULL,
    [Type]           VARCHAR (50) NULL,
    [Rate]           DECIMAL (18) NULL,
    [BeginDate]      DATETIME     NULL,
    [EndDate]        DATETIME     NULL,
    [InsertUserName] VARCHAR (50) NULL,
    [InsertDate]     DATETIME     NULL,
    [UpdateUserName] VARCHAR (50) NULL,
    [UpdateDate]     DATETIME     NULL,
    CONSTRAINT [PK_Kampanya_id] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Yapilan kampanya bilgileri tutulur', @level0type = N'SCHEMA', @level0name = N'Rent', @level1type = N'TABLE', @level1name = N'Campaign';



CREATE TABLE [Rent].[Car] (
    [PlateNumber]    VARCHAR (50)  NOT NULL,
    [Marka]          VARCHAR (500) NULL,
    [Model]          INT           NOT NULL,
    [KasaTipi]       VARCHAR (50)  NULL,
    [Yakıt]          VARCHAR (50)  NULL,
    [Vites]          VARCHAR (50)  NULL,
    [Amount]         DECIMAL (18)  NULL,
    [InsertUserName] VARCHAR (50)  NULL,
    [InsertDate]     DATETIME      NULL,
    [UpdateUserName] VARCHAR (50)  NULL,
    [UpdateDate]     DATETIME      NULL,
    CONSTRAINT [PK_Car_PlakaNumarası] PRIMARY KEY CLUSTERED ([PlateNumber] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Araç bilgileri tutulur', @level0type = N'SCHEMA', @level0name = N'Rent', @level1type = N'TABLE', @level1name = N'Car';





CREATE TABLE [Rent].[Customer] (
    [Identity]       BIGINT       NOT NULL,
    [Name]           VARCHAR (50) NULL,
    [Surname]        VARCHAR (50) NULL,
    [Age]            INT          NULL,
    [InsertUserName] VARCHAR (50) NULL,
    [InsertDate]     DATETIME     NULL,
    [UpdateUserName] VARCHAR (50) NULL,
    [UpdateDate]     DATETIME     NULL,
    CONSTRAINT [PK_Müşteri_Tckn] PRIMARY KEY CLUSTERED ([Identity] ASC)
);

