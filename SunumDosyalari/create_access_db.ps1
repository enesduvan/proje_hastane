$dbPath = "C:\Users\enes\Desktop\ders\c#\proje_hastane\proje_hastane\SunumDosyalari\Hastane_Diyagram.accdb"
if (Test-Path $dbPath) { Remove-Item $dbPath -Force }

$catalog = New-Object -ComObject ADOX.Catalog
$connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$dbPath"
$catalog.Create($connStr)

$conn = New-Object -ComObject ADODB.Connection
$conn.Open($connStr)

$queries = @(
    "CREATE TABLE Table_poliklinik (poliklinik_id AUTOINCREMENT PRIMARY KEY, poliklinik_ad VARCHAR(100), kat_bilgisi VARCHAR(20), aktif BIT);",
    "CREATE TABLE Table_brans (brans_id AUTOINCREMENT PRIMARY KEY, brans_ad VARCHAR(100), poliklinik_id INT, aktif BIT, olusturma_tarihi DATETIME);",
    "CREATE TABLE Table_oda (oda_id AUTOINCREMENT PRIMARY KEY, oda_kodu VARCHAR(20), kat_no INT, brans_id INT, oda_durumu VARCHAR(30));",
    "CREATE TABLE Table_sekreter (sekreter_id AUTOINCREMENT PRIMARY KEY, sekreter_tc VARCHAR(11), sekreter_adsoyad VARCHAR(100), sekreter_sifre VARCHAR(30), vardiya VARCHAR(50));",
    "CREATE TABLE Table_doktor (doktor_id AUTOINCREMENT PRIMARY KEY, doktor_ad VARCHAR(50), doktor_soyad VARCHAR(50), doktor_tc VARCHAR(11), doktor_sifre VARCHAR(30), doktor_brans VARCHAR(100), brans_id INT, poliklinik_id INT, oda_id INT);",
    "CREATE TABLE Table_hasta (hasta_id AUTOINCREMENT PRIMARY KEY, hasta_ad VARCHAR(50), hasta_soyad VARCHAR(50), hasta_tc VARCHAR(11), hasta_telefon VARCHAR(20), hasta_sifre VARCHAR(30), hasta_cinsiyet VARCHAR(15), kayit_tarihi DATETIME, aktif BIT);",
    "CREATE TABLE Table_randevu (randevu_id AUTOINCREMENT PRIMARY KEY, randevu_tarih VARCHAR(10), randevu_saat VARCHAR(5), randevu_brans VARCHAR(100), randevu_doktor VARCHAR(100), randevu_durum BIT, hasta_tc VARCHAR(11), randevu_sikayet VARCHAR(255), sekreter_tc VARCHAR(11), brans_id INT, doktor_id INT, hasta_id INT, olusturma_tarihi DATETIME);",
    "CREATE TABLE Table_duyuru (duyuru_id AUTOINCREMENT PRIMARY KEY, duyuru VARCHAR(255), olusturma_tarihi DATETIME, olusturan_tc VARCHAR(11));",
    "CREATE TABLE Table_recete (recete_id AUTOINCREMENT PRIMARY KEY, randevu_id INT, hasta_id INT, doktor_id INT, recete_notu VARCHAR(255), olusturma_tarihi DATETIME);",
    "CREATE TABLE Table_ilac (ilac_id AUTOINCREMENT PRIMARY KEY, ilac_ad VARCHAR(100), kullanim_sekli VARCHAR(100));",
    "CREATE TABLE Table_recete_ilac (recete_ilac_id AUTOINCREMENT PRIMARY KEY, recete_id INT, ilac_id INT, dozaj VARCHAR(100));",
    "CREATE TABLE Table_tetkik (tetkik_id AUTOINCREMENT PRIMARY KEY, randevu_id INT, tetkik_adi VARCHAR(100), sonuc_durumu VARCHAR(100), olusturma_tarihi DATETIME);",
    "CREATE TABLE Table_odeme (odeme_id AUTOINCREMENT PRIMARY KEY, randevu_id INT, tutar CURRENCY, odeme_tipi VARCHAR(50), odeme_durumu VARCHAR(50), odeme_tarihi DATETIME);",
    "CREATE TABLE Table_kullanici_log (log_id AUTOINCREMENT PRIMARY KEY, tablo_adi VARCHAR(50), islem_turu VARCHAR(50), aciklama VARCHAR(255), islem_tarihi DATETIME, islem_yapan VARCHAR(50));",
    "CREATE TABLE Table_randevu_log (randevu_log_id AUTOINCREMENT PRIMARY KEY, randevu_id INT, onceki_durum VARCHAR(50), yeni_durum VARCHAR(50), log_mesaji VARCHAR(255), log_tarihi DATETIME);"
)

$fks = @(
    "ALTER TABLE Table_brans ADD CONSTRAINT FK_brans_poliklinik FOREIGN KEY (poliklinik_id) REFERENCES Table_poliklinik (poliklinik_id);",
    "ALTER TABLE Table_oda ADD CONSTRAINT FK_oda_brans FOREIGN KEY (brans_id) REFERENCES Table_brans (brans_id);",
    "ALTER TABLE Table_doktor ADD CONSTRAINT FK_doktor_brans FOREIGN KEY (brans_id) REFERENCES Table_brans (brans_id);",
    "ALTER TABLE Table_doktor ADD CONSTRAINT FK_doktor_poliklinik FOREIGN KEY (poliklinik_id) REFERENCES Table_poliklinik (poliklinik_id);",
    "ALTER TABLE Table_doktor ADD CONSTRAINT FK_doktor_oda FOREIGN KEY (oda_id) REFERENCES Table_oda (oda_id);",
    "ALTER TABLE Table_randevu ADD CONSTRAINT FK_randevu_brans FOREIGN KEY (brans_id) REFERENCES Table_brans (brans_id);",
    "ALTER TABLE Table_randevu ADD CONSTRAINT FK_randevu_doktor FOREIGN KEY (doktor_id) REFERENCES Table_doktor (doktor_id);",
    "ALTER TABLE Table_randevu ADD CONSTRAINT FK_randevu_hasta FOREIGN KEY (hasta_id) REFERENCES Table_hasta (hasta_id);",
    "ALTER TABLE Table_recete ADD CONSTRAINT FK_recete_randevu FOREIGN KEY (randevu_id) REFERENCES Table_randevu (randevu_id);",
    "ALTER TABLE Table_recete ADD CONSTRAINT FK_recete_hasta FOREIGN KEY (hasta_id) REFERENCES Table_hasta (hasta_id);",
    "ALTER TABLE Table_recete ADD CONSTRAINT FK_recete_doktor FOREIGN KEY (doktor_id) REFERENCES Table_doktor (doktor_id);",
    "ALTER TABLE Table_recete_ilac ADD CONSTRAINT FK_ri_recete FOREIGN KEY (recete_id) REFERENCES Table_recete (recete_id);",
    "ALTER TABLE Table_recete_ilac ADD CONSTRAINT FK_ri_ilac FOREIGN KEY (ilac_id) REFERENCES Table_ilac (ilac_id);",
    "ALTER TABLE Table_tetkik ADD CONSTRAINT FK_tetkik_randevu FOREIGN KEY (randevu_id) REFERENCES Table_randevu (randevu_id);",
    "ALTER TABLE Table_odeme ADD CONSTRAINT FK_odeme_randevu FOREIGN KEY (randevu_id) REFERENCES Table_randevu (randevu_id);"
)

foreach ($q in $queries) {
    try { $conn.Execute($q) | Out-Null } catch { Write-Host "Error creating table: $($_.Exception.Message)" }
}

foreach ($q in $fks) {
    try { $conn.Execute($q) | Out-Null } catch { Write-Host "Error creating FK: $($_.Exception.Message)" }
}

$conn.Close()
[System.Runtime.Interopservices.Marshal]::ReleaseComObject($conn) | Out-Null
Write-Host "Access DB created successfully at $dbPath"
