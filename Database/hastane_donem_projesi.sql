IF OBJECT_ID('dbo.Table_poliklinik', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_poliklinik
    (
        poliklinik_id INT IDENTITY(1,1) PRIMARY KEY,
        poliklinik_ad NVARCHAR(100) NOT NULL,
        kat_bilgisi NVARCHAR(20) NULL,
        aktif BIT NOT NULL CONSTRAINT DF_Table_poliklinik_aktif DEFAULT (1)
    );
END;
GO

IF OBJECT_ID('dbo.Table_brans', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_brans
    (
        brans_id INT IDENTITY(1,1) PRIMARY KEY,
        brans_ad NVARCHAR(100) NOT NULL,
        poliklinik_id INT NULL,
        aktif BIT NOT NULL CONSTRAINT DF_Table_brans_aktif DEFAULT (1),
        olusturma_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_brans_olusturma DEFAULT (GETDATE())
    );
END;
GO

IF COL_LENGTH('dbo.Table_brans', 'poliklinik_id') IS NULL
    ALTER TABLE dbo.Table_brans ADD poliklinik_id INT NULL;
GO

IF COL_LENGTH('dbo.Table_brans', 'aktif') IS NULL
    ALTER TABLE dbo.Table_brans ADD aktif BIT NOT NULL CONSTRAINT DF_Table_brans_aktif_ek DEFAULT (1);
GO

IF COL_LENGTH('dbo.Table_brans', 'olusturma_tarihi') IS NULL
    ALTER TABLE dbo.Table_brans ADD olusturma_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_brans_olusturma_ek DEFAULT (GETDATE());
GO

IF OBJECT_ID('dbo.Table_oda', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_oda
    (
        oda_id INT IDENTITY(1,1) PRIMARY KEY,
        oda_kodu NVARCHAR(20) NOT NULL,
        kat_no INT NOT NULL,
        brans_id INT NULL,
        oda_durumu NVARCHAR(30) NOT NULL CONSTRAINT DF_Table_oda_durum DEFAULT ('Hazir')
    );
END;
GO

IF OBJECT_ID('dbo.Table_hasta', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_hasta
    (
        hasta_id INT IDENTITY(1,1) PRIMARY KEY,
        hasta_ad NVARCHAR(50) NOT NULL,
        hasta_soyad NVARCHAR(50) NOT NULL,
        hasta_tc CHAR(11) NOT NULL,
        hasta_telefon NVARCHAR(20) NULL,
        hasta_sifre NVARCHAR(30) NOT NULL,
        hasta_cinsiyet NVARCHAR(15) NULL,
        kayit_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_hasta_kayit DEFAULT (GETDATE()),
        aktif BIT NOT NULL CONSTRAINT DF_Table_hasta_aktif DEFAULT (1)
    );
END;
GO

IF COL_LENGTH('dbo.Table_hasta', 'kayit_tarihi') IS NULL
    ALTER TABLE dbo.Table_hasta ADD kayit_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_hasta_kayit_ek DEFAULT (GETDATE());
GO

IF COL_LENGTH('dbo.Table_hasta', 'aktif') IS NULL
    ALTER TABLE dbo.Table_hasta ADD aktif BIT NOT NULL CONSTRAINT DF_Table_hasta_aktif_ek DEFAULT (1);
GO

IF OBJECT_ID('dbo.Table_sekreter', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_sekreter
    (
        sekreter_id INT IDENTITY(1,1) PRIMARY KEY,
        sekreter_tc CHAR(11) NOT NULL,
        sekreter_adsoyad NVARCHAR(100) NOT NULL,
        sekreter_sifre NVARCHAR(30) NOT NULL,
        vardiya NVARCHAR(50) NULL
    );
END;
GO

IF COL_LENGTH('dbo.Table_sekreter', 'vardiya') IS NULL
    ALTER TABLE dbo.Table_sekreter ADD vardiya NVARCHAR(50) NULL;
GO

IF OBJECT_ID('dbo.Table_doktor', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_doktor
    (
        doktor_id INT IDENTITY(1,1) PRIMARY KEY,
        doktor_ad NVARCHAR(50) NOT NULL,
        doktor_soyad NVARCHAR(50) NOT NULL,
        doktor_brans NVARCHAR(100) NOT NULL,
        doktor_tc CHAR(11) NOT NULL,
        doktor_sifre NVARCHAR(30) NOT NULL,
        brans_id INT NULL,
        poliklinik_id INT NULL,
        oda_id INT NULL
    );
END;
GO

IF COL_LENGTH('dbo.Table_doktor', 'brans_id') IS NULL
    ALTER TABLE dbo.Table_doktor ADD brans_id INT NULL;
GO

IF COL_LENGTH('dbo.Table_doktor', 'poliklinik_id') IS NULL
    ALTER TABLE dbo.Table_doktor ADD poliklinik_id INT NULL;
GO

IF COL_LENGTH('dbo.Table_doktor', 'oda_id') IS NULL
    ALTER TABLE dbo.Table_doktor ADD oda_id INT NULL;
GO

IF OBJECT_ID('dbo.Table_randevu', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_randevu
    (
        randevu_id INT IDENTITY(1,1) PRIMARY KEY,
        randevu_tarih NVARCHAR(10) NOT NULL,
        randevu_saat NVARCHAR(5) NOT NULL,
        randevu_brans NVARCHAR(100) NOT NULL,
        randevu_doktor NVARCHAR(100) NOT NULL,
        randevu_durum BIT NOT NULL CONSTRAINT DF_Table_randevu_durum DEFAULT (0),
        hasta_tc CHAR(11) NULL,
        randevu_sikayet NVARCHAR(500) NULL,
        sekreter_tc CHAR(11) NULL,
        brans_id INT NULL,
        doktor_id INT NULL,
        hasta_id INT NULL,
        olusturma_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_randevu_olusturma DEFAULT (GETDATE())
    );
END;
GO

IF COL_LENGTH('dbo.Table_randevu', 'randevu_sikayet') IS NULL
    ALTER TABLE dbo.Table_randevu ADD randevu_sikayet NVARCHAR(500) NULL;
GO

IF COL_LENGTH('dbo.Table_randevu', 'sekreter_tc') IS NULL
    ALTER TABLE dbo.Table_randevu ADD sekreter_tc CHAR(11) NULL;
GO

IF COL_LENGTH('dbo.Table_randevu', 'brans_id') IS NULL
    ALTER TABLE dbo.Table_randevu ADD brans_id INT NULL;
GO

IF COL_LENGTH('dbo.Table_randevu', 'doktor_id') IS NULL
    ALTER TABLE dbo.Table_randevu ADD doktor_id INT NULL;
GO

IF COL_LENGTH('dbo.Table_randevu', 'hasta_id') IS NULL
    ALTER TABLE dbo.Table_randevu ADD hasta_id INT NULL;
GO

IF COL_LENGTH('dbo.Table_randevu', 'olusturma_tarihi') IS NULL
    ALTER TABLE dbo.Table_randevu ADD olusturma_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_randevu_olusturma_ek DEFAULT (GETDATE());
GO

IF OBJECT_ID('dbo.Table_duyuru', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_duyuru
    (
        duyuru_id INT IDENTITY(1,1) PRIMARY KEY,
        duyuru NVARCHAR(500) NOT NULL,
        olusturma_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_duyuru_olusturma DEFAULT (GETDATE()),
        olusturan_tc CHAR(11) NULL
    );
END;
GO

IF COL_LENGTH('dbo.Table_duyuru', 'olusturma_tarihi') IS NULL
    ALTER TABLE dbo.Table_duyuru ADD olusturma_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_duyuru_olusturma_ek DEFAULT (GETDATE());
GO

IF COL_LENGTH('dbo.Table_duyuru', 'olusturan_tc') IS NULL
    ALTER TABLE dbo.Table_duyuru ADD olusturan_tc CHAR(11) NULL;
GO

IF OBJECT_ID('dbo.Table_recete', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_recete
    (
        recete_id INT IDENTITY(1,1) PRIMARY KEY,
        randevu_id INT NOT NULL,
        hasta_id INT NULL,
        doktor_id INT NULL,
        recete_notu NVARCHAR(500) NULL,
        olusturma_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_recete_olusturma DEFAULT (GETDATE())
    );
END;
GO

IF OBJECT_ID('dbo.Table_ilac', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_ilac
    (
        ilac_id INT IDENTITY(1,1) PRIMARY KEY,
        ilac_ad NVARCHAR(100) NOT NULL,
        kullanim_sekli NVARCHAR(250) NULL
    );
END;
GO

IF OBJECT_ID('dbo.Table_recete_ilac', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_recete_ilac
    (
        recete_ilac_id INT IDENTITY(1,1) PRIMARY KEY,
        recete_id INT NOT NULL,
        ilac_id INT NOT NULL,
        dozaj NVARCHAR(100) NULL
    );
END;
GO

IF OBJECT_ID('dbo.Table_tetkik', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_tetkik
    (
        tetkik_id INT IDENTITY(1,1) PRIMARY KEY,
        randevu_id INT NOT NULL,
        tetkik_adi NVARCHAR(150) NOT NULL,
        sonuc_durumu NVARCHAR(100) NOT NULL CONSTRAINT DF_Table_tetkik_sonuc DEFAULT ('Bekliyor'),
        olusturma_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_tetkik_olusturma DEFAULT (GETDATE())
    );
END;
GO

IF OBJECT_ID('dbo.Table_odeme', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_odeme
    (
        odeme_id INT IDENTITY(1,1) PRIMARY KEY,
        randevu_id INT NOT NULL,
        tutar DECIMAL(10,2) NOT NULL,
        odeme_tipi NVARCHAR(30) NOT NULL CONSTRAINT DF_Table_odeme_tipi DEFAULT ('Nakit'),
        odeme_durumu NVARCHAR(30) NOT NULL CONSTRAINT DF_Table_odeme_durum DEFAULT ('Beklemede'),
        odeme_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_odeme_tarih DEFAULT (GETDATE())
    );
END;
GO

IF OBJECT_ID('dbo.Table_kullanici_log', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_kullanici_log
    (
        log_id INT IDENTITY(1,1) PRIMARY KEY,
        tablo_adi NVARCHAR(100) NOT NULL,
        islem_turu NVARCHAR(30) NOT NULL,
        aciklama NVARCHAR(500) NOT NULL,
        islem_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_kullanici_log_tarih DEFAULT (GETDATE()),
        islem_yapan NVARCHAR(100) NULL
    );
END;
GO

IF OBJECT_ID('dbo.Table_randevu_log', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_randevu_log
    (
        randevu_log_id INT IDENTITY(1,1) PRIMARY KEY,
        randevu_id INT NOT NULL,
        onceki_durum NVARCHAR(30) NULL,
        yeni_durum NVARCHAR(30) NULL,
        log_mesaji NVARCHAR(500) NOT NULL,
        log_tarihi DATETIME NOT NULL CONSTRAINT DF_Table_randevu_log_tarih DEFAULT (GETDATE())
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Table_poliklinik)
BEGIN
    INSERT INTO dbo.Table_poliklinik (poliklinik_ad, kat_bilgisi)
    VALUES
    (N'Dahiliye Merkezi', N'2. Kat'),
    (N'Cerrahi Merkezi', N'3. Kat'),
    (N'Tani ve Goruntuleme', N'1. Kat');
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Table_brans)
BEGIN
    INSERT INTO dbo.Table_brans (brans_ad, poliklinik_id)
    SELECT N'Kardiyoloji', poliklinik_id FROM dbo.Table_poliklinik WHERE poliklinik_ad = N'Dahiliye Merkezi'
    UNION ALL
    SELECT N'Noroloji', poliklinik_id FROM dbo.Table_poliklinik WHERE poliklinik_ad = N'Dahiliye Merkezi'
    UNION ALL
    SELECT N'Ortopedi', poliklinik_id FROM dbo.Table_poliklinik WHERE poliklinik_ad = N'Cerrahi Merkezi'
    UNION ALL
    SELECT N'Goz Hastaliklari', poliklinik_id FROM dbo.Table_poliklinik WHERE poliklinik_ad = N'Tani ve Goruntuleme';
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Table_oda)
BEGIN
    INSERT INTO dbo.Table_oda (oda_kodu, kat_no, brans_id, oda_durumu)
    SELECT N'A201', 2, brans_id, N'Hazir' FROM dbo.Table_brans WHERE brans_ad = N'Kardiyoloji'
    UNION ALL
    SELECT N'A202', 2, brans_id, N'Hazir' FROM dbo.Table_brans WHERE brans_ad = N'Noroloji'
    UNION ALL
    SELECT N'B301', 3, brans_id, N'Dolu' FROM dbo.Table_brans WHERE brans_ad = N'Ortopedi';
END;
GO

UPDATE d
SET d.brans_id = b.brans_id,
    d.poliklinik_id = b.poliklinik_id
FROM dbo.Table_doktor d
INNER JOIN dbo.Table_brans b ON b.brans_ad = d.doktor_brans
WHERE d.brans_id IS NULL OR d.poliklinik_id IS NULL;
GO

UPDATE r
SET r.brans_id = b.brans_id
FROM dbo.Table_randevu r
INNER JOIN dbo.Table_brans b ON b.brans_ad = r.randevu_brans
WHERE r.brans_id IS NULL;
GO

UPDATE r
SET r.doktor_id = d.doktor_id
FROM dbo.Table_randevu r
INNER JOIN dbo.Table_doktor d
    ON CONCAT(d.doktor_ad, N' ', d.doktor_soyad) = r.randevu_doktor
WHERE r.doktor_id IS NULL;
GO

UPDATE r
SET r.hasta_id = h.hasta_id
FROM dbo.Table_randevu r
INNER JOIN dbo.Table_hasta h ON h.hasta_tc = r.hasta_tc
WHERE r.hasta_id IS NULL AND r.hasta_tc IS NOT NULL;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Table_sekreter)
BEGIN
    INSERT INTO dbo.Table_sekreter (sekreter_tc, sekreter_adsoyad, sekreter_sifre, vardiya)
    VALUES (N'33333333333', N'Sistem Sekreteri', N'1234', N'Gunduz');
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Table_doktor)
BEGIN
    INSERT INTO dbo.Table_doktor (doktor_ad, doktor_soyad, doktor_brans, doktor_tc, doktor_sifre, brans_id, poliklinik_id, oda_id)
    SELECT N'Ayse', N'Yilmaz', N'Kardiyoloji', N'11111111111', N'1234', b.brans_id, b.poliklinik_id, o.oda_id
    FROM dbo.Table_brans b
    LEFT JOIN dbo.Table_oda o ON o.brans_id = b.brans_id
    WHERE b.brans_ad = N'Kardiyoloji';

    INSERT INTO dbo.Table_doktor (doktor_ad, doktor_soyad, doktor_brans, doktor_tc, doktor_sifre, brans_id, poliklinik_id, oda_id)
    SELECT N'Mehmet', N'Demir', N'Ortopedi', N'11111111112', N'1234', b.brans_id, b.poliklinik_id, o.oda_id
    FROM dbo.Table_brans b
    LEFT JOIN dbo.Table_oda o ON o.brans_id = b.brans_id
    WHERE b.brans_ad = N'Ortopedi';

    INSERT INTO dbo.Table_doktor (doktor_ad, doktor_soyad, doktor_brans, doktor_tc, doktor_sifre, brans_id, poliklinik_id, oda_id)
    SELECT N'Zeynep', N'Çelik', N'Noroloji', N'11111111113', N'1234', b.brans_id, b.poliklinik_id, o.oda_id
    FROM dbo.Table_brans b
    LEFT JOIN dbo.Table_oda o ON o.brans_id = b.brans_id
    WHERE b.brans_ad = N'Noroloji';

    INSERT INTO dbo.Table_doktor (doktor_ad, doktor_soyad, doktor_brans, doktor_tc, doktor_sifre, brans_id, poliklinik_id, oda_id)
    SELECT N'Kemal', N'Sarý', N'Goz Hastaliklari', N'11111111114', N'1234', b.brans_id, b.poliklinik_id, o.oda_id
    FROM dbo.Table_brans b
    LEFT JOIN dbo.Table_oda o ON o.brans_id = b.brans_id
    WHERE b.brans_ad = N'Goz Hastaliklari';

    INSERT INTO dbo.Table_doktor (doktor_ad, doktor_soyad, doktor_brans, doktor_tc, doktor_sifre, brans_id, poliklinik_id, oda_id)
    SELECT N'Serkan', N'Güneþ', N'Kardiyoloji', N'11111111115', N'1234', b.brans_id, b.poliklinik_id, o.oda_id
    FROM dbo.Table_brans b
    LEFT JOIN dbo.Table_oda o ON o.brans_id = b.brans_id
    WHERE b.brans_ad = N'Kardiyoloji';

    INSERT INTO dbo.Table_doktor (doktor_ad, doktor_soyad, doktor_brans, doktor_tc, doktor_sifre, brans_id, poliklinik_id, oda_id)
    SELECT N'Melis', N'Aydýn', N'Ortopedi', N'11111111116', N'1234', b.brans_id, b.poliklinik_id, o.oda_id
    FROM dbo.Table_brans b
    LEFT JOIN dbo.Table_oda o ON o.brans_id = b.brans_id
    WHERE b.brans_ad = N'Ortopedi';

    INSERT INTO dbo.Table_doktor (doktor_ad, doktor_soyad, doktor_brans, doktor_tc, doktor_sifre, brans_id, poliklinik_id, oda_id)
    SELECT N'Oðuz', N'Gültekin', N'Noroloji', N'11111111117', N'1234', b.brans_id, b.poliklinik_id, o.oda_id
    FROM dbo.Table_brans b
    LEFT JOIN dbo.Table_oda o ON o.brans_id = b.brans_id
    WHERE b.brans_ad = N'Noroloji';

    INSERT INTO dbo.Table_doktor (doktor_ad, doktor_soyad, doktor_brans, doktor_tc, doktor_sifre, brans_id, poliklinik_id, oda_id)
    SELECT N'Burak', N'Kýlýç', N'Goz Hastaliklari', N'11111111118', N'1234', b.brans_id, b.poliklinik_id, o.oda_id
    FROM dbo.Table_brans b
    LEFT JOIN dbo.Table_oda o ON o.brans_id = b.brans_id
    WHERE b.brans_ad = N'Goz Hastaliklari';

    INSERT INTO dbo.Table_doktor (doktor_ad, doktor_soyad, doktor_brans, doktor_tc, doktor_sifre, brans_id, poliklinik_id, oda_id)
    SELECT N'Elif', N'Cemre', N'Kardiyoloji', N'11111111119', N'1234', b.brans_id, b.poliklinik_id, o.oda_id
    FROM dbo.Table_brans b
    LEFT JOIN dbo.Table_oda o ON o.brans_id = b.brans_id
    WHERE b.brans_ad = N'Kardiyoloji';

    INSERT INTO dbo.Table_doktor (doktor_ad, doktor_soyad, doktor_brans, doktor_tc, doktor_sifre, brans_id, poliklinik_id, oda_id)
    SELECT N'Gökhan', N'Kaya', N'Ortopedi', N'11111111120', N'1234', b.brans_id, b.poliklinik_id, o.oda_id
    FROM dbo.Table_brans b
    LEFT JOIN dbo.Table_oda o ON o.brans_id = b.brans_id
    WHERE b.brans_ad = N'Ortopedi';
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Table_hasta)
BEGIN
    INSERT INTO dbo.Table_hasta (hasta_ad, hasta_soyad, hasta_tc, hasta_telefon, hasta_sifre, hasta_cinsiyet)
    VALUES (N'Ali', N'Kaya', N'22222222222', N'05550000000', N'1234', N'Erkek'),
           (N'Fatma', N'Yilmaz', N'22222222223', N'05550000001', N'1234', N'Kadýn'),
           (N'Veli', N'Demir', N'22222222224', N'05550000002', N'1234', N'Erkek'),
           (N'Ayþe', N'Korkmaz', N'22222222225', N'05550000003', N'1234', N'Kadýn'),
           (N'Hasan', N'Çelik', N'22222222226', N'05550000004', N'1234', N'Erkek'),
           (N'Hüseyin', N'Þahin', N'22222222227', N'05550000005', N'1234', N'Erkek'),
           (N'Emine', N'Yýldýz', N'22222222228', N'05550000006', N'1234', N'Kadýn'),
           (N'Zeynep', N'Öztürk', N'22222222229', N'05550000007', N'1234', N'Kadýn');
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Table_randevu)
BEGIN
    INSERT INTO dbo.Table_randevu
    (
        randevu_tarih, randevu_saat, randevu_brans, randevu_doktor,
        randevu_durum, hasta_tc, sekreter_tc, brans_id, doktor_id, hasta_id
    )
    SELECT N'12.05.2026', N'09:00', N'Kardiyoloji', CONCAT(d.doktor_ad, N' ', d.doktor_soyad),
           0, NULL, N'33333333333', b.brans_id, d.doktor_id, NULL
    FROM dbo.Table_doktor d
    INNER JOIN dbo.Table_brans b ON b.brans_id = d.brans_id
    WHERE d.doktor_tc = N'11111111111';

    INSERT INTO dbo.Table_randevu
    (
        randevu_tarih, randevu_saat, randevu_brans, randevu_doktor,
        randevu_durum, hasta_tc, sekreter_tc, brans_id, doktor_id, hasta_id
    )
    SELECT N'12.05.2026', N'10:00', N'Kardiyoloji', CONCAT(d.doktor_ad, N' ', d.doktor_soyad),
           0, NULL, N'33333333333', b.brans_id, d.doktor_id, NULL
    FROM dbo.Table_doktor d
    INNER JOIN dbo.Table_brans b ON b.brans_id = d.brans_id
    WHERE d.doktor_tc = N'11111111111';

    INSERT INTO dbo.Table_randevu
    (
        randevu_tarih, randevu_saat, randevu_brans, randevu_doktor,
        randevu_durum, hasta_tc, sekreter_tc, brans_id, doktor_id, hasta_id
    )
    SELECT N'13.05.2026', N'14:00', N'Ortopedi', CONCAT(d.doktor_ad, N' ', d.doktor_soyad),
           1, N'22222222222', N'33333333333', b.brans_id, d.doktor_id, 1
    FROM dbo.Table_doktor d
    INNER JOIN dbo.Table_brans b ON b.brans_id = d.brans_id
    WHERE d.doktor_tc = N'11111111112';

    INSERT INTO dbo.Table_randevu
    (
        randevu_tarih, randevu_saat, randevu_brans, randevu_doktor,
        randevu_durum, hasta_tc, sekreter_tc, brans_id, doktor_id, hasta_id
    )
    SELECT N'13.05.2026', N'14:30', N'Ortopedi', CONCAT(d.doktor_ad, N' ', d.doktor_soyad),
           0, NULL, N'33333333333', b.brans_id, d.doktor_id, NULL
    FROM dbo.Table_doktor d
    INNER JOIN dbo.Table_brans b ON b.brans_id = d.brans_id
    WHERE d.doktor_tc = N'11111111112';
END;
GO

IF OBJECT_ID('dbo.FK_Table_brans_poliklinik', 'F') IS NULL
    ALTER TABLE dbo.Table_brans WITH NOCHECK ADD CONSTRAINT FK_Table_brans_poliklinik FOREIGN KEY (poliklinik_id) REFERENCES dbo.Table_poliklinik (poliklinik_id);
GO

IF OBJECT_ID('dbo.FK_Table_oda_brans', 'F') IS NULL
    ALTER TABLE dbo.Table_oda WITH NOCHECK ADD CONSTRAINT FK_Table_oda_brans FOREIGN KEY (brans_id) REFERENCES dbo.Table_brans (brans_id);
GO

IF OBJECT_ID('dbo.FK_Table_doktor_brans', 'F') IS NULL
    ALTER TABLE dbo.Table_doktor WITH NOCHECK ADD CONSTRAINT FK_Table_doktor_brans FOREIGN KEY (brans_id) REFERENCES dbo.Table_brans (brans_id);
GO

IF OBJECT_ID('dbo.FK_Table_doktor_poliklinik', 'F') IS NULL
    ALTER TABLE dbo.Table_doktor WITH NOCHECK ADD CONSTRAINT FK_Table_doktor_poliklinik FOREIGN KEY (poliklinik_id) REFERENCES dbo.Table_poliklinik (poliklinik_id);
GO

IF OBJECT_ID('dbo.FK_Table_doktor_oda', 'F') IS NULL
    ALTER TABLE dbo.Table_doktor WITH NOCHECK ADD CONSTRAINT FK_Table_doktor_oda FOREIGN KEY (oda_id) REFERENCES dbo.Table_oda (oda_id);
GO

IF OBJECT_ID('dbo.FK_Table_randevu_brans', 'F') IS NULL
    ALTER TABLE dbo.Table_randevu WITH NOCHECK ADD CONSTRAINT FK_Table_randevu_brans FOREIGN KEY (brans_id) REFERENCES dbo.Table_brans (brans_id);
GO

IF OBJECT_ID('dbo.FK_Table_randevu_doktor', 'F') IS NULL
    ALTER TABLE dbo.Table_randevu WITH NOCHECK ADD CONSTRAINT FK_Table_randevu_doktor FOREIGN KEY (doktor_id) REFERENCES dbo.Table_doktor (doktor_id);
GO

IF OBJECT_ID('dbo.FK_Table_randevu_hasta', 'F') IS NULL
    ALTER TABLE dbo.Table_randevu WITH NOCHECK ADD CONSTRAINT FK_Table_randevu_hasta FOREIGN KEY (hasta_id) REFERENCES dbo.Table_hasta (hasta_id);
GO

IF OBJECT_ID('dbo.FK_Table_recete_randevu', 'F') IS NULL
    ALTER TABLE dbo.Table_recete WITH NOCHECK ADD CONSTRAINT FK_Table_recete_randevu FOREIGN KEY (randevu_id) REFERENCES dbo.Table_randevu (randevu_id);
GO

IF OBJECT_ID('dbo.FK_Table_recete_hasta', 'F') IS NULL
    ALTER TABLE dbo.Table_recete WITH NOCHECK ADD CONSTRAINT FK_Table_recete_hasta FOREIGN KEY (hasta_id) REFERENCES dbo.Table_hasta (hasta_id);
GO

IF OBJECT_ID('dbo.FK_Table_recete_doktor', 'F') IS NULL
    ALTER TABLE dbo.Table_recete WITH NOCHECK ADD CONSTRAINT FK_Table_recete_doktor FOREIGN KEY (doktor_id) REFERENCES dbo.Table_doktor (doktor_id);
GO

IF OBJECT_ID('dbo.FK_Table_recete_ilac_recete', 'F') IS NULL
    ALTER TABLE dbo.Table_recete_ilac WITH NOCHECK ADD CONSTRAINT FK_Table_recete_ilac_recete FOREIGN KEY (recete_id) REFERENCES dbo.Table_recete (recete_id);
GO

IF OBJECT_ID('dbo.FK_Table_recete_ilac_ilac', 'F') IS NULL
    ALTER TABLE dbo.Table_recete_ilac WITH NOCHECK ADD CONSTRAINT FK_Table_recete_ilac_ilac FOREIGN KEY (ilac_id) REFERENCES dbo.Table_ilac (ilac_id);
GO

IF OBJECT_ID('dbo.FK_Table_tetkik_randevu', 'F') IS NULL
    ALTER TABLE dbo.Table_tetkik WITH NOCHECK ADD CONSTRAINT FK_Table_tetkik_randevu FOREIGN KEY (randevu_id) REFERENCES dbo.Table_randevu (randevu_id);
GO

IF OBJECT_ID('dbo.FK_Table_odeme_randevu', 'F') IS NULL
    ALTER TABLE dbo.Table_odeme WITH NOCHECK ADD CONSTRAINT FK_Table_odeme_randevu FOREIGN KEY (randevu_id) REFERENCES dbo.Table_randevu (randevu_id);
GO

IF OBJECT_ID('dbo.fn_HastaRandevuSayisi', 'FN') IS NOT NULL
    DROP FUNCTION dbo.fn_HastaRandevuSayisi;
GO

CREATE FUNCTION dbo.fn_HastaRandevuSayisi
(
    @hastaTc CHAR(11)
)
RETURNS INT
AS
BEGIN
    DECLARE @sonuc INT;

    SELECT @sonuc = COUNT(*)
    FROM dbo.Table_randevu
    WHERE hasta_tc = @hastaTc;

    RETURN ISNULL(@sonuc, 0);
END;
GO

IF OBJECT_ID('dbo.fn_DoktorRandevuSayisi', 'FN') IS NOT NULL
    DROP FUNCTION dbo.fn_DoktorRandevuSayisi;
GO

CREATE FUNCTION dbo.fn_DoktorRandevuSayisi
(
    @doktorId INT
)
RETURNS INT
AS
BEGIN
    DECLARE @sonuc INT;

    SELECT @sonuc = COUNT(*)
    FROM dbo.Table_randevu
    WHERE doktor_id = @doktorId;

    RETURN ISNULL(@sonuc, 0);
END;
GO

IF OBJECT_ID('dbo.vw_DoktorBransListesi', 'V') IS NOT NULL
    DROP VIEW dbo.vw_DoktorBransListesi;
GO

CREATE VIEW dbo.vw_DoktorBransListesi
AS
SELECT
    d.doktor_id,
    d.doktor_ad,
    d.doktor_soyad,
    d.doktor_brans,
    d.doktor_tc,
    d.doktor_sifre,
    p.poliklinik_ad,
    o.oda_kodu,
    dbo.fn_DoktorRandevuSayisi(d.doktor_id) AS toplam_randevu
FROM dbo.Table_doktor d
LEFT JOIN dbo.Table_brans b ON b.brans_id = d.brans_id
LEFT JOIN dbo.Table_poliklinik p ON p.poliklinik_id = b.poliklinik_id
LEFT JOIN dbo.Table_oda o ON o.oda_id = d.oda_id;
GO

IF OBJECT_ID('dbo.vw_RandevuSunum', 'V') IS NOT NULL
    DROP VIEW dbo.vw_RandevuSunum;
GO

CREATE VIEW dbo.vw_RandevuSunum
AS
SELECT
    r.randevu_id,
    r.randevu_tarih,
    r.randevu_saat,
    r.randevu_brans,
    r.randevu_doktor,
    ISNULL(h.hasta_ad + N' ' + h.hasta_soyad, N'Bos Kontenjan') AS hasta_adsoyad,
    ISNULL(r.hasta_tc, N'-') AS hasta_tc,
    CASE WHEN r.randevu_durum = 1 THEN N'Dolu' ELSE N'Bos' END AS randevu_durum,
    ISNULL(r.randevu_sikayet, N'-') AS randevu_sikayet,
    ISNULL(s.sekreter_adsoyad, N'Sistem') AS olusturan
FROM dbo.Table_randevu r
LEFT JOIN dbo.Table_hasta h ON h.hasta_id = r.hasta_id
LEFT JOIN dbo.Table_sekreter s ON s.sekreter_tc = r.sekreter_tc;
GO

IF OBJECT_ID('dbo.vw_HastaRandevuGecmisi', 'V') IS NOT NULL
    DROP VIEW dbo.vw_HastaRandevuGecmisi;
GO

CREATE VIEW dbo.vw_HastaRandevuGecmisi
AS
SELECT
    h.hasta_tc,
    h.hasta_ad + N' ' + h.hasta_soyad AS hasta_adsoyad,
    dbo.fn_HastaRandevuSayisi(h.hasta_tc) AS toplam_randevu,
    r.randevu_id,
    r.randevu_tarih,
    r.randevu_saat,
    r.randevu_brans,
    r.randevu_doktor,
    CASE WHEN r.randevu_durum = 1 THEN N'Dolu' ELSE N'Bos' END AS randevu_durum
FROM dbo.Table_hasta h
LEFT JOIN dbo.Table_randevu r ON r.hasta_tc = h.hasta_tc;
GO

IF OBJECT_ID('dbo.vw_YonetimOzeti', 'V') IS NOT NULL
    DROP VIEW dbo.vw_YonetimOzeti;
GO

CREATE VIEW dbo.vw_YonetimOzeti
AS
SELECT
    (SELECT COUNT(*) FROM dbo.Table_hasta) AS toplam_hasta,
    (SELECT COUNT(*) FROM dbo.Table_doktor) AS toplam_doktor,
    (SELECT COUNT(*) FROM dbo.Table_brans) AS toplam_brans,
    (SELECT COUNT(*) FROM dbo.Table_randevu WHERE randevu_durum = 0) AS bos_randevu,
    (SELECT COUNT(*) FROM dbo.Table_randevu WHERE randevu_durum = 1) AS dolu_randevu,
    (SELECT COUNT(*) FROM dbo.Table_duyuru) AS toplam_duyuru,
    (SELECT COUNT(*) FROM dbo.Table_kullanici_log) AS toplam_log;
GO

IF OBJECT_ID('dbo.sp_HastaKaydet', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_HastaKaydet;
GO

CREATE PROCEDURE dbo.sp_HastaKaydet
    @hasta_ad NVARCHAR(50),
    @hasta_soyad NVARCHAR(50),
    @hasta_tc CHAR(11),
    @hasta_telefon NVARCHAR(20),
    @hasta_sifre NVARCHAR(30),
    @hasta_cinsiyet NVARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Table_hasta
    (
        hasta_ad,
        hasta_soyad,
        hasta_tc,
        hasta_telefon,
        hasta_sifre,
        hasta_cinsiyet
    )
    VALUES
    (
        @hasta_ad,
        @hasta_soyad,
        @hasta_tc,
        @hasta_telefon,
        @hasta_sifre,
        @hasta_cinsiyet
    );
END;
GO

IF OBJECT_ID('dbo.sp_HastaGuncelle', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_HastaGuncelle;
GO

CREATE PROCEDURE dbo.sp_HastaGuncelle
    @hasta_ad NVARCHAR(50),
    @hasta_soyad NVARCHAR(50),
    @hasta_tc CHAR(11),
    @hasta_telefon NVARCHAR(20),
    @hasta_sifre NVARCHAR(30),
    @hasta_cinsiyet NVARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Table_hasta
    SET
        hasta_ad = @hasta_ad,
        hasta_soyad = @hasta_soyad,
        hasta_telefon = @hasta_telefon,
        hasta_sifre = @hasta_sifre,
        hasta_cinsiyet = @hasta_cinsiyet
    WHERE hasta_tc = @hasta_tc;
END;
GO

IF OBJECT_ID('dbo.sp_DoktorKaydet', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DoktorKaydet;
GO

CREATE PROCEDURE dbo.sp_DoktorKaydet
    @doktor_ad NVARCHAR(50),
    @doktor_soyad NVARCHAR(50),
    @doktor_tc CHAR(11),
    @doktor_sifre NVARCHAR(30),
    @doktor_brans NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @bransId INT = (SELECT TOP 1 brans_id FROM dbo.Table_brans WHERE brans_ad = @doktor_brans);
    DECLARE @poliklinikId INT = (SELECT TOP 1 poliklinik_id FROM dbo.Table_brans WHERE brans_ad = @doktor_brans);
    DECLARE @odaId INT = (SELECT TOP 1 oda_id FROM dbo.Table_oda WHERE brans_id = @bransId ORDER BY oda_id);

    INSERT INTO dbo.Table_doktor
    (
        doktor_ad,
        doktor_soyad,
        doktor_brans,
        doktor_tc,
        doktor_sifre,
        brans_id,
        poliklinik_id,
        oda_id
    )
    VALUES
    (
        @doktor_ad,
        @doktor_soyad,
        @doktor_brans,
        @doktor_tc,
        @doktor_sifre,
        @bransId,
        @poliklinikId,
        @odaId
    );
END;
GO

IF OBJECT_ID('dbo.sp_DoktorGuncelle', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DoktorGuncelle;
GO

CREATE PROCEDURE dbo.sp_DoktorGuncelle
    @doktor_ad NVARCHAR(50),
    @doktor_soyad NVARCHAR(50),
    @doktor_tc CHAR(11),
    @doktor_sifre NVARCHAR(30),
    @doktor_brans NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @bransId INT = (SELECT TOP 1 brans_id FROM dbo.Table_brans WHERE brans_ad = @doktor_brans);
    DECLARE @poliklinikId INT = (SELECT TOP 1 poliklinik_id FROM dbo.Table_brans WHERE brans_ad = @doktor_brans);

    UPDATE dbo.Table_doktor
    SET
        doktor_ad = @doktor_ad,
        doktor_soyad = @doktor_soyad,
        doktor_brans = @doktor_brans,
        doktor_sifre = @doktor_sifre,
        brans_id = @bransId,
        poliklinik_id = @poliklinikId
    WHERE doktor_tc = @doktor_tc;
END;
GO

IF OBJECT_ID('dbo.sp_DoktorSil', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DoktorSil;
GO

CREATE PROCEDURE dbo.sp_DoktorSil
    @doktor_tc CHAR(11)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Table_doktor WHERE doktor_tc = @doktor_tc;
END;
GO

IF OBJECT_ID('dbo.sp_BransKaydet', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_BransKaydet;
GO

CREATE PROCEDURE dbo.sp_BransKaydet
    @brans_ad NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @poliklinikId INT = (SELECT TOP 1 poliklinik_id FROM dbo.Table_poliklinik ORDER BY poliklinik_id);

    INSERT INTO dbo.Table_brans (brans_ad, poliklinik_id)
    VALUES (@brans_ad, @poliklinikId);
END;
GO

IF OBJECT_ID('dbo.sp_BransGuncelle', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_BransGuncelle;
GO

CREATE PROCEDURE dbo.sp_BransGuncelle
    @brans_id INT,
    @brans_ad NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Table_brans
    SET brans_ad = @brans_ad
    WHERE brans_id = @brans_id;
END;
GO

IF OBJECT_ID('dbo.sp_BransSil', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_BransSil;
GO

CREATE PROCEDURE dbo.sp_BransSil
    @brans_ad NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Table_brans
    WHERE brans_ad = @brans_ad;
END;
GO

IF OBJECT_ID('dbo.sp_DuyuruOlustur', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DuyuruOlustur;
GO

CREATE PROCEDURE dbo.sp_DuyuruOlustur
    @duyuru NVARCHAR(500),
    @olusturan_tc CHAR(11)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Table_duyuru (duyuru, olusturan_tc)
    VALUES (@duyuru, @olusturan_tc);
END;
GO

IF OBJECT_ID('dbo.sp_RandevuOlustur', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_RandevuOlustur;
GO

CREATE PROCEDURE dbo.sp_RandevuOlustur
    @randevu_tarih NVARCHAR(10),
    @randevu_saat NVARCHAR(5),
    @randevu_brans NVARCHAR(100),
    @randevu_doktor NVARCHAR(100),
    @randevu_durum BIT,
    @hasta_tc CHAR(11),
    @sekreter_tc CHAR(11)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    BEGIN TRY
        DECLARE @bransId INT = (SELECT TOP 1 brans_id FROM dbo.Table_brans WHERE brans_ad = @randevu_brans);
        DECLARE @doktorId INT = (SELECT TOP 1 doktor_id FROM dbo.Table_doktor WHERE CONCAT(doktor_ad, N' ', doktor_soyad) = @randevu_doktor);
        DECLARE @hastaId INT = (SELECT TOP 1 hasta_id FROM dbo.Table_hasta WHERE hasta_tc = NULLIF(@hasta_tc, ''));

        INSERT INTO dbo.Table_randevu
        (
            randevu_tarih, randevu_saat, randevu_brans, randevu_doktor,
            randevu_durum, hasta_tc, sekreter_tc, brans_id, doktor_id, hasta_id
        )
        VALUES
        (
            @randevu_tarih, @randevu_saat, @randevu_brans, @randevu_doktor,
            @randevu_durum, NULLIF(@hasta_tc, ''), @sekreter_tc, @bransId, @doktorId, @hastaId
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

IF OBJECT_ID('dbo.sp_HastaRandevuAl', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_HastaRandevuAl;
GO

CREATE PROCEDURE dbo.sp_HastaRandevuAl
    @randevu_id INT,
    @hasta_tc CHAR(11),
    @randevu_sikayet NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    BEGIN TRY
        DECLARE @hastaId INT = (SELECT TOP 1 hasta_id FROM dbo.Table_hasta WHERE hasta_tc = @hasta_tc);

        IF EXISTS (SELECT 1 FROM dbo.Table_randevu WHERE randevu_id = @randevu_id AND randevu_durum = 1)
        BEGIN
            RAISERROR(N'Secilen randevu dolu.', 16, 1);
        END;

        UPDATE dbo.Table_randevu
        SET
            hasta_tc = @hasta_tc,
            hasta_id = @hastaId,
            randevu_sikayet = @randevu_sikayet,
            randevu_durum = 1
        WHERE randevu_id = @randevu_id;

        IF NOT EXISTS (SELECT 1 FROM dbo.Table_odeme WHERE randevu_id = @randevu_id)
        BEGIN
            INSERT INTO dbo.Table_odeme (randevu_id, tutar, odeme_tipi, odeme_durumu)
            VALUES (@randevu_id, 250.00, N'Kart', N'Olusturuldu');
        END;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

IF OBJECT_ID('dbo.trg_Doktor_Log', 'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_Doktor_Log;
GO

CREATE TRIGGER dbo.trg_Doktor_Log
ON dbo.Table_doktor
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Table_kullanici_log (tablo_adi, islem_turu, aciklama, islem_yapan)
    SELECT
        N'Table_doktor',
        CASE
            WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN N'UPDATE'
            WHEN EXISTS (SELECT 1 FROM inserted) THEN N'INSERT'
            ELSE N'DELETE'
        END,
        N'Doktor tablosunda degisiklik yapildi.',
        SYSTEM_USER;
END;
GO

IF OBJECT_ID('dbo.trg_Randevu_Log', 'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_Randevu_Log;
GO

CREATE TRIGGER dbo.trg_Randevu_Log
ON dbo.Table_randevu
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Table_randevu_log (randevu_id, onceki_durum, yeni_durum, log_mesaji)
    SELECT
        i.randevu_id,
        CASE WHEN d.randevu_durum = 1 THEN N'Dolu' WHEN d.randevu_durum = 0 THEN N'Bos' ELSE N'-' END,
        CASE WHEN i.randevu_durum = 1 THEN N'Dolu' WHEN i.randevu_durum = 0 THEN N'Bos' ELSE N'-' END,
        CASE
            WHEN d.randevu_id IS NULL THEN N'Yeni randevu kaydi olusturuldu.'
            ELSE N'Randevu kaydi guncellendi.'
        END
    FROM inserted i
    LEFT JOIN deleted d ON d.randevu_id = i.randevu_id;

    INSERT INTO dbo.Table_kullanici_log (tablo_adi, islem_turu, aciklama, islem_yapan)
    SELECT
        N'Table_randevu',
        CASE WHEN d.randevu_id IS NULL THEN N'INSERT' ELSE N'UPDATE' END,
        N'Randevu kaydi eklendi veya guncellendi.',
        SYSTEM_USER
    FROM inserted i
    LEFT JOIN deleted d ON d.randevu_id = i.randevu_id;
END;
GO
