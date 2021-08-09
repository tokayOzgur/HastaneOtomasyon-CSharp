CREATE TABLE [dbo].[Sekreterler]
(
	[SekreterId] TINYINT NOT NULL PRIMARY KEY identity, 
    [SekreterAdSoyad] VARCHAR(20) NULL, 
    [SekreterTC] CHAR(11) NULL, 
    [SekreterSifre] VARCHAR(16) NULL
)
