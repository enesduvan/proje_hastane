# HASTANE OTOMASYONU DONEM PROJESI RAPORU

## 1. Proje Ozeti
Bu proje, bir hastane otomasyonunun hasta, doktor ve sekreter rollerine gore calisan masaustu uygulamasidir. Uygulama WinForms ile gelistirilmistir ve veritabani olarak SQL Server LocalDB kullanir. Projede temel hedef; hastane verilerini duzenli sekilde tutmak, CRUD islemlerini gostermek ve ileri SQL yapilarini uygulama uzerinden anlamli bir senaryoda kullanmaktir.

## 2. Kullanilan Moduller
- Hasta girisi, kayit ve profil guncelleme
- Hasta randevu gecmisi ve uygun randevu secimi
- Doktor CRUD paneli
- Brans CRUD paneli
- Sekreter yonetim paneli
- Duyuru olusturma ve listeleme
- Randevu listeleme
- Yonetim ozeti ve log goruntuleme

## 3. Veritabani Tasarimi
Projede 10'dan fazla iliskili tablo bulunmaktadir. Ana tablolar:
- `Table_hasta`
- `Table_doktor`
- `Table_sekreter`
- `Table_brans`
- `Table_poliklinik`
- `Table_oda`
- `Table_randevu`
- `Table_duyuru`
- `Table_recete`
- `Table_ilac`
- `Table_recete_ilac`
- `Table_tetkik`
- `Table_odeme`
- `Table_kullanici_log`
- `Table_randevu_log`

Bu yapida doktor-brans-poliklinik-oda, hasta-randevu-odeme, randevu-recete-ilac ve randevu-log iliskileri tanimlanmistir. Bu sayede hem gercek bir sistem yapisi kurulmus hem de sunumda iliski mantigi gosterilebilir hale getirilmistir.

## 4. Gerceklestirilen CRUD Islemleri
- Hasta kaydi ekleme
- Hasta bilgi guncelleme
- Doktor ekleme, silme, guncelleme
- Brans ekleme, silme, guncelleme
- Randevu olusturma
- Hasta tarafindan randevu alma
- Duyuru ekleme
- Randevu, doktor, brans ve duyuru listeleme

## 5. Kullanilan Ileri SQL Yapilari
### View
- `vw_DoktorBransListesi`
- `vw_RandevuSunum`
- `vw_HastaRandevuGecmisi`
- `vw_YonetimOzeti`

View yapilari sayesinde sunum ekranlarinda ham tablo yerine daha anlamli ve birlestirilmis veriler gosterilmektedir.

### Stored Procedure
- `sp_HastaKaydet`
- `sp_HastaGuncelle`
- `sp_DoktorKaydet`
- `sp_DoktorGuncelle`
- `sp_DoktorSil`
- `sp_BransKaydet`
- `sp_BransGuncelle`
- `sp_BransSil`
- `sp_DuyuruOlustur`
- `sp_RandevuOlustur`
- `sp_HastaRandevuAl`

Stored procedure yapilari ile veri ekleme ve guncelleme islemleri daha duzenli ve tekrar kullanilabilir hale getirilmistir.

### Function
- `fn_HastaRandevuSayisi`
- `fn_DoktorRandevuSayisi`

Fonksiyonlar, raporlama ve ozet ekranlarinda kullanilan sayisal degerleri hesaplamak icin kullanilmistir.

### Trigger
- `trg_Doktor_Log`
- `trg_Randevu_Log`

Trigger yapilari sayesinde kritik tablo degisiklikleri otomatik olarak log tablolarina yazilmaktadir.

### Transaction
- `sp_RandevuOlustur`
- `sp_HastaRandevuAl`

Randevu islemlerinde transaction kullanilarak veri butunlugu korunmustur. Islem sirasinda hata olursa tum degisiklikler geri alinmaktadir.

### Log Tablolari
- `Table_kullanici_log`
- `Table_randevu_log`

Bu tablolar sistemde yapilan ekleme ve guncelleme hareketlerini izlemek icin kullanilmistir.

## 6. Arayuz Iyilestirmeleri
Projede WinForms arayuzu daha profesyonel gorunecek sekilde guncellenmistir:
- Tum ana formlarda ortak tema uygulanmistir.
- Ust bilgi alani ve kart tabanli ozet metrikler eklenmistir.
- DataGrid gorunumu modernlestirilmistir.
- Sekreter ekranina yonetim ozeti ve log ekranlari eklenmistir.
- Hasta ekraninda randevu alma akisi tamamlanmistir.

## 7. Sonuc
Bu proje ile hem temel veritabani islemleri hem de ileri SQL yapilari tek bir senaryoda birlestirilmistir. Uygulama; veritabani tasarimi, CRUD islemleri, transaction mantigi, trigger ve loglama konularini pratik olarak gostermektedir. Sunum sirasinda sekreter paneli, hasta randevu akisi, doktor CRUD paneli ve yonetim ozeti ekrani uzerinden tum teknik beklentiler adim adim gosterilebilir.

## 8. Demo Bilgileri
Temiz veritabani kurulumu sonrasinda ornek kullanicilar:
- Sekreter TC: `33333333333` Sifre: `1234`
- Doktor TC: `11111111111` Sifre: `1234`
- Hasta TC: `22222222222` Sifre: `1234`
