CREATE TABLE [dbo].[Randevular]
(
	[RandevuId] INT NOT NULL PRIMARY KEY, 
    [RandevuTarih] VARCHAR(50) NULL, 
    [RandevuSaat] VARCHAR(5) NULL, 
    [RandevuBrans] VARCHAR(50) NULL, 
    [RandevuDoktor] VARCHAR(50) NULL, 
    [RandevuDurum] BIT NULL DEFAULT 0, 
    [HastaTc] CHAR(11) NULL
)
