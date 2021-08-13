use master
create database HastaneOtomasyon
go
use HastaneOtomasyon
go
CREATE TABLE Branslar
(
    BransId INT NOT NULL PRIMARY KEY identity,
    BransAd VARCHAR(50) NULL
)
go
CREATE TABLE Doktor
(
    DoktorId TINYINT NOT NULL PRIMARY KEY identity,
    DoktorAd VARCHAR(20) NULL,
    DoktorSoyad VARCHAR(50) NULL,
    DoktorBrans VARCHAR(50) NULL,
    DoktorTC CHAR(11) NULL,
    DoktorSifre VARCHAR(16) NULL
)
go
CREATE TABLE Hastalar
(
    HastaId SMALLINT NOT NULL PRIMARY KEY identity,
    HastaAd VARCHAR(20) NULL,
    HastaSoyad VARCHAR(50) NULL,
    HastaTC CHAR(11) NULL,
    HastaTelefon VARCHAR(15) NULL,
    HastaSifre VARCHAR(16) NULL,
    HastaCinsiyet varchar(5) NULL
)
go
CREATE TABLE Randevular
(
    RandevuId INT NOT NULL PRIMARY KEY identity,
    RandevuTarih VARCHAR(50) NULL,
    RandevuSaat VARCHAR(5) NULL,
    RandevuBrans VARCHAR(50) NULL,
    RandevuDoktor VARCHAR(50) NULL,
    RandevuDurum BIT NULL DEFAULT 0,
    HastaTc CHAR(11) NULL
)
go
CREATE TABLE Sekreterler
(
    SekreterId TINYINT NOT NULL PRIMARY KEY identity,
    SekreterAdSoyad VARCHAR(20) NULL,
    SekreterTC CHAR(11) NULL,
    SekreterSifre VARCHAR(16) NULL
)

GO


-- Duyuru Tablosu
CREATE TABLE Duyurular
(
    DuyuruId TINYINT NOT NULL PRIMARY KEY identity,
    Duyuru VARCHAR(200) NULL
)


go

-- insert sample values

-- Branşlar Tablosu
INSERT INTO Branslar
    (BransAd)
VALUES
    ('Cildiye');

INSERT INTO Branslar
    (BransAd)
VALUES
    ('Dahiliye');

INSERT INTO Branslar
    (BransAd)
VALUES
    ('Kulak Burun Boğaz');

INSERT INTO Branslar
    (BransAd)
VALUES
    ('Fizik Tedavi');

GO

-- Doktor Tablosu
INSERT INTO Doktor
    (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre)
VALUES
    ('Özgür', 'Tokay', 'Kulak Burun Boğaz', '10000000000', '1111');

INSERT INTO Doktor
    (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre)
VALUES
    ('Harry', 'Potter', 'Cildiye', '20000000000', '1111');


INSERT INTO Doktor
    (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre)
VALUES
    ('Sirius', 'Black', 'Dahiliye', '30000000000', '1111');

INSERT INTO Doktor
    (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre)
VALUES
    ('Jim', 'Carry', 'Fizik Tedavi', '40000000000', '1111');

GO

-- Hastalar Tablosu
INSERT INTO Hastalar
    (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet)
VALUES
    ('Silvestre', 'Stallon', '10000000001', '5555555555', '1111', 'Erkek');

INSERT INTO Hastalar
    (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet)
VALUES
    ('Cristian', 'Bale', '10000000002', '5555555555', '1111', 'Erkek');

INSERT INTO Hastalar
    (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet)
VALUES
    ('Cüneyt', 'Arkın', '10000000003', '5555555555', '1111', 'Erkek');

INSERT INTO Hastalar
    (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet)
VALUES
    ('Jason', 'Mamoa', '10000000004', '5555555555', '1111', 'Erkek');

INSERT INTO Hastalar
    (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet)
VALUES
    ('Ali', 'Erbilen', '10000000005', '5555555555', '1111', 'Erkek');


GO

-- Randevular Tablosu
-- bu kısım otomasyon üzerinden eklenilecektir.

-- Sekreterler Tablosu
INSERT INTO Sekreterler
    (SekreterAdSoyad,SekreterTC,SekreterSifre)
VALUES
    ('Barbara Palvin', '20000000001', '1111');
INSERT INTO Sekreterler
    (SekreterAdSoyad,SekreterTC,SekreterSifre)
VALUES
    ('Scarlet Johanson', '20000000002', '1111');
INSERT INTO Sekreterler
    (SekreterAdSoyad,SekreterTC,SekreterSifre)
VALUES
    ('Nurgül Yeşilçay', '20000000003', '1111');
INSERT INTO Sekreterler
    (SekreterAdSoyad,SekreterTC,SekreterSifre)
VALUES
    ('Türkan Şoray', '20000000004', '1111');





/* USE master ;  
GO
DROP DATABASE HastaneOtomasyon;  
GO */