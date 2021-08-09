CREATE TABLE [dbo].[Doktor]
(
	[DoktorId] TINYINT NOT NULL PRIMARY KEY identity, 
    [DoktorAd] VARCHAR(20) NULL, 
    [DoktorSoyad] VARCHAR(50) NULL, 
    [DoktorBrans] VARCHAR(50) NULL, 
    [DoktorTC] CHAR(11) NULL, 
    [DoktorSifre] VARCHAR(16) NULL
)
