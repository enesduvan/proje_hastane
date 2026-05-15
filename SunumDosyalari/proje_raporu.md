# HASTANE OTOMASYONu — VERİTABANI DÖNEMi PROJESİ RAPORU

**Öğrenci:** *(Adınızı Yazın)*  
**Danışman:** Arş. Gör. Safa Enes TÜRKOĞLU (Oda: 308)  
**Ders:** Veritabanı 2  
**Tarih:** Mayıs 2026

---

## 1. Proje Özeti

Bu proje, gerçek bir hastane otomasyonunu modelleyen, C# WinForms teknolojisiyle geliştirilmiş masaüstü bir yönetim uygulamasıdır. Sistem, **hasta**, **doktor** ve **sekreter** olmak üzere üç farklı kullanıcı rolü üzerine inşa edilmiştir. Veritabanı olarak **SQL Server LocalDB** kullanılmış; veriler ADO.NET ile yönetilmektedir.

Projenin temel hedefleri:
- Hastane verilerini düzenli tutmak ve yönetmek
- CRUD işlemlerini anlamlı bir senaryo üzerinden göstermek
- View, Trigger, Transaction, Function, Stored Procedure ve Log gibi ileri SQL yapılarını üretim benzeri bir uygulamada kullanmak
- En az 10 ilişkili tablodan oluşan bir veritabanı şeması tasarlamak

---

## 2. Sistem Mimarisi

```
┌─────────────────────────────────────────────────────┐
│              C# WinForms Uygulaması                 │
│  ┌──────────┐  ┌──────────┐  ┌────────────────────┐ │
│  │  Hasta   │  │  Doktor  │  │    Sekreter         │ │
│  │  Paneli  │  │  Paneli  │  │    Yönetim Paneli   │ │
│  └──────────┘  └──────────┘  └────────────────────┘ │
│              ADO.NET / SqlClient                    │
└─────────────────────────────────────────────────────┘
                        │
                        ▼
┌─────────────────────────────────────────────────────┐
│        SQL Server LocalDB — hastane_proje           │
│  15 Tablo · 4 View · 11 SP · 2 Function · 3 Trigger │
└─────────────────────────────────────────────────────┘
```

---

## 3. Veritabanı Tasarımı — 15 İlişkili Tablo

Proje veritabanı, **15 ilişkili tablo** içermekte olup tüm tablolar yabancı anahtar kısıtlamalarıyla birbirine bağlanmıştır.

| # | Tablo | Açıklama |
|---|-------|----------|
| 1 | `Table_poliklinik` | Hastane bölümleri (Dahiliye, Cerrahi vb.) |
| 2 | `Table_brans` | Uzmanlık alanları |
| 3 | `Table_oda` | Muayene odaları |
| 4 | `Table_doktor` | Doktor profilleri ve branş atamaları |
| 5 | `Table_sekreter` | Sekreter kullanıcıları |
| 6 | `Table_hasta` | Hasta kayıtları |
| 7 | `Table_randevu` | Randevu slotları |
| 8 | `Table_duyuru` | İdari duyurular |
| 9 | `Table_recete` | Reçete başlıkları |
| 10 | `Table_ilac` | İlaç kataloğu |
| 11 | `Table_recete_ilac` | Reçete–İlaç bağlantı tablosu (M:N ara tablo) |
| 12 | `Table_tetkik` | Tetkik/Laboratuvar istekleri |
| 13 | `Table_odeme` | Muayene ödeme kayıtları |
| 14 | `Table_kullanici_log` | Genel işlem logları |
| 15 | `Table_randevu_log` | Randevu değişim logları |

**Temel ilişkiler:** Poliklinik → Branş → Oda → Doktor → Randevu → Reçete → İlaç zinciri oluşturulmaktadır. Bu sayede hiyerarşik bir veri modeli kurulmuştur.

---

## 4. CRUD İşlemleri

| İşlem | Kapsam |
|-------|--------|
| **CREATE** | Hasta kayıt, Doktor ekleme, Branş ekleme, Randevu oluşturma, Duyuru ekleme |
| **READ** | Hasta randevu geçmişi, Doktor listesi, Randevu listesi, Branş listesi, Duyuru listesi, Yönetim özeti |
| **UPDATE** | Hasta bilgi güncelleme, Doktor bilgi güncelleme, Branş adı güncelleme |
| **DELETE** | Doktor silme, Branş silme, Randevu silme (sekreter yetkili) |

Her CRUD işlemi hem **Stored Procedure** üzerinden hem de SP bulunamazsa doğrudan SQL sorgusuyla (fallback) çalışmaktadır.

---

## 5. İleri SQL Yapıları

### 5.1 View (4 Adet)

| View Adı | Kullanım Amacı |
|----------|---------------|
| `vw_DoktorBransListesi` | Doktor–branş–poliklinik–oda–randevu sayısı birleşik görünümü |
| `vw_RandevuSunum` | Randevu sunum ekranı için hazır görünüm |
| `vw_HastaRandevuGecmisi` | Hastanın tüm randevularını tek sorguda sunar |
| `vw_YonetimOzeti` | Özet istatistikler: hasta, doktor, boş randevu, log sayısı |
| `vw_OdemeRaporu` | Ödeme–randevu–hasta birleşik finans raporu |

### 5.2 Stored Procedure (11 Adet)

| Stored Procedure | İşlev |
|-----------------|-------|
| `sp_HastaKaydet` | Yeni hasta ekleme |
| `sp_HastaGuncelle` | Hasta bilgisi güncelleme |
| `sp_HastaSil` | Soft-delete ile hasta pasifleştirme |
| `sp_DoktorKaydet` | Yeni doktor ekleme (branş ID otomatik atanır) |
| `sp_DoktorGuncelle` | Doktor bilgisi güncelleme |
| `sp_DoktorSil` | Doktor silme |
| `sp_BransKaydet` | Yeni branş ekleme |
| `sp_BransGuncelle` | Branş adı güncelleme |
| `sp_BransSil` | Branş silme |
| `sp_DuyuruOlustur` | Yeni duyuru oluşturma |
| `sp_RandevuOlustur` | Transaction korumalı randevu oluşturma |
| `sp_HastaRandevuAl` | Transaction korumalı hasta randevu alma |
| `sp_RandevuSil` | Randevu ve ilişkili ödeme silme |

### 5.3 Transaction (2 Adet)

`sp_RandevuOlustur` ve `sp_HastaRandevuAl` stored procedure'leri **BEGIN TRANSACTION / COMMIT / ROLLBACK** bloğu içermektedir. Hata durumunda tüm değişiklikler geri alınarak veri bütünlüğü korunmaktadır.

```sql
BEGIN TRANSACTION;
BEGIN TRY
    -- Kritik işlemler...
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH
```

### 5.4 Function (2 Adet)

| Fonksiyon | Dönüş | Kullanım |
|-----------|-------|---------|
| `fn_HastaRandevuSayisi(@hastaTc)` | INT | Bir hastanın toplam randevu sayısı |
| `fn_DoktorRandevuSayisi(@doktorId)` | INT | Bir doktorun toplam randevu sayısı |

Bu fonksiyonlar view'lar ve özet ekranlarda hesaplama için kullanılmaktadır.

### 5.5 Trigger (3 Adet)

| Trigger | Tetiklenme | Aksiyon |
|---------|-----------|---------|
| `trg_Doktor_Log` | `Table_doktor` INSERT/UPDATE/DELETE | `Table_kullanici_log`'a kayıt yazar |
| `trg_Randevu_Log` | `Table_randevu` INSERT/UPDATE | `Table_randevu_log` + `Table_kullanici_log`'a kayıt yazar |
| `trg_Hasta_Log` | `Table_hasta` INSERT/UPDATE/DELETE | `Table_kullanici_log`'a kayıt yazar |

### 5.6 Log Tabloları (2 Adet)

- **`Table_kullanici_log`**: Tablo adı, işlem türü, açıklama, tarih ve `SYSTEM_USER` bilgisi ile tüm kritik değişiklikler kaydedilir.
- **`Table_randevu_log`**: Randevu durumunun önceki ve yeni değeri, değişim mesajı ve tarihi kaydedilir.

---

## 6. Arayüz Özellikleri

- **3 Kullanıcı Rolü**: Hasta / Doktor / Sekreter — ayrı giriş ekranları
- **ModernTheme**: Tüm formlarda tutarlı koyu renk teması
- **Stat Kartları**: Sekreter ve hasta panelinde canlı güncellenen özet metrikler
- **DataGridView**: Doktor, branş, randevu ve log listelerinde kullanılan tablo bileşeni
- **Dinamik Layout**: Form yeniden boyutlandırıldığında arayüz otomatik uyum sağlar

---

## 7. Demo Kullanıcıları

| Rol | TC No | Şifre |
|-----|-------|-------|
| Sekreter | `33333333333` | `1234` |
| Doktor (Kardiyoloji) | `11111111111` | `1234` |
| Hasta | `22222222222` | `1234` |

---

## 8. Gereksinimler Kontrol Listesi

| Kriter | Durum |
|--------|-------|
| CRUD (Ekleme, Silme, Güncelleme, Arama) | ✅ Tam |
| View | ✅ 5 adet |
| Trigger | ✅ 3 adet |
| Transaction | ✅ 2 adet |
| Function | ✅ 2 adet |
| Stored Procedure | ✅ 13 adet |
| Log Tabloları | ✅ 2 adet |
| En az 10 ilişkili tablo | ✅ 15 tablo |
| Veritabanı Şeması | ✅ ER Diyagramı hazır |
| Bağımsız Rapor (max 5 sayfa) | ✅ Bu belge |
