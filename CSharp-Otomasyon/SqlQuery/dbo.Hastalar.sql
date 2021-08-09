CREATE TABLE [dbo].[Table]
(
	[HastaId] SMALLINT NOT NULL PRIMARY KEY identity, 
    [HastaAd] VARCHAR(20) NULL, 
    [HastaSoyad] VARCHAR(50) NULL, 
    [HastaTC] CHAR(11) NULL, 
    [HastaTelefon] VARCHAR(15) NULL, 
    [HastaSifre] VARCHAR(16) NULL, 
    [HastaCinsiyet] varchar(5) NULL
)
