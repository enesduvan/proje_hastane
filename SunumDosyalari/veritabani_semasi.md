# Hastane Otomasyonu — Veritabanı Şeması

> **15 ilişkili tablo** · **SQL Server LocalDB** · Dönem Projesi

---

## İlişkisel Şema (Yazı Formatı)

Aşağıda MS Access ve standart ilişkisel veritabanı gösterim dillerine uygun biçimde projeye ait tablolar, nitelikleri (sütunlar), **Birincil Anahtarlar (PK - Altı Çizili/Koyu)** ve *Yabancı Anahtarlar (FK - İtalik)* metin formatında listelenmiştir.

1. **Table_poliklinik** ( **<u>poliklinik_id</u>**, poliklinik_ad, kat_bilgisi, aktif )
2. **Table_brans** ( **<u>brans_id</u>**, brans_ad, *poliklinik_id*, aktif, olusturma_tarihi )
3. **Table_oda** ( **<u>oda_id</u>**, oda_kodu, kat_no, *brans_id*, oda_durumu )
4. **Table_sekreter** ( **<u>sekreter_id</u>**, sekreter_tc, sekreter_adsoyad, sekreter_sifre, vardiya )
5. **Table_doktor** ( **<u>doktor_id</u>**, doktor_ad, doktor_soyad, doktor_tc, doktor_sifre, doktor_brans, *brans_id*, *poliklinik_id*, *oda_id* )
6. **Table_hasta** ( **<u>hasta_id</u>**, hasta_ad, hasta_soyad, hasta_tc, hasta_telefon, hasta_sifre, hasta_cinsiyet, kayit_tarihi, aktif )
7. **Table_randevu** ( **<u>randevu_id</u>**, randevu_tarih, randevu_saat, randevu_brans, randevu_doktor, randevu_durum, hasta_tc, randevu_sikayet, sekreter_tc, *brans_id*, *doktor_id*, *hasta_id*, olusturma_tarihi )
8. **Table_duyuru** ( **<u>duyuru_id</u>**, duyuru, olusturma_tarihi, olusturan_tc )
9. **Table_recete** ( **<u>recete_id</u>**, *randevu_id*, *hasta_id*, *doktor_id*, recete_notu, olusturma_tarihi )
10. **Table_ilac** ( **<u>ilac_id</u>**, ilac_ad, kullanim_sekli )
11. **Table_recete_ilac** ( **<u>recete_ilac_id</u>**, *recete_id*, *ilac_id*, dozaj )
12. **Table_tetkik** ( **<u>tetkik_id</u>**, *randevu_id*, tetkik_adi, sonuc_durumu, olusturma_tarihi )
13. **Table_odeme** ( **<u>odeme_id</u>**, *randevu_id*, tutar, odeme_tipi, odeme_durumu, odeme_tarihi )
14. **Table_kullanici_log** ( **<u>log_id</u>**, tablo_adi, islem_turu, aciklama, islem_tarihi, islem_yapan )
15. **Table_randevu_log** ( **<u>randevu_log_id</u>**, randevu_id, onceki_durum, yeni_durum, log_mesaji, log_tarihi )

---

## Tablolar Özeti

| # | Tablo | Sütun Sayısı | Açıklama |
|---|-------|-------------|----------|
| 1 | `Table_poliklinik` | 4 | Klinik bölümleri (Dahiliye, Cerrahi vb.) |
| 2 | `Table_brans` | 5 | Uzmanlık alanları |
| 3 | `Table_oda` | 5 | Muayene odaları |
| 4 | `Table_doktor` | 9 | Doktor profilleri |
| 5 | `Table_sekreter` | 5 | Sekreter kullanıcıları |
| 6 | `Table_hasta` | 9 | Hasta kayıtları |
| 7 | `Table_randevu` | 13 | Randevu slotları |
| 8 | `Table_duyuru` | 4 | İdari duyurular |
| 9 | `Table_recete` | 6 | Reçete başlıkları |
| 10 | `Table_ilac` | 3 | İlaç kataloğu |
| 11 | `Table_recete_ilac` | 4 | Reçete–İlaç bağlantısı (ara tablo) |
| 12 | `Table_tetkik` | 5 | Tetkik/Lab istekleri |
| 13 | `Table_odeme` | 6 | Ödeme kayıtları |
| 14 | `Table_kullanici_log` | 6 | Genel işlem logları (trigger kaynağı) |
| 15 | `Table_randevu_log` | 6 | Randevu değişim logları |

---

## Yabancı Anahtar İlişkileri (15 FK Özeti)

Yazı dilinde tanımlanmış ilişkiler:

*   **Table_brans**, bağlı olduğu polikliniği referans alır (`poliklinik_id`).
*   **Table_oda**, bağlı olduğu branşı referans alır (`brans_id`).
*   **Table_doktor**; atandığı poliklinik (`poliklinik_id`), uzmanlık alanı (`brans_id`) ve odasını (`oda_id`) referans alır.
*   **Table_randevu**; randevunun oluşturulduğu branşı (`brans_id`), seçilen doktoru (`doktor_id`) ve randevuyu alan hastayı (`hasta_id`) referans alır.
*   **Table_recete**; hangi randevuda yazıldığını (`randevu_id`), hangi hastaya ait olduğunu (`hasta_id`) ve yazan doktoru (`doktor_id`) referans alır.
*   **Table_recete_ilac**; Çoka-Çok ilişki kurar. Reçete (`recete_id`) ve ilgili İlacı (`ilac_id`) referans alarak bağlar.
*   **Table_tetkik** ve **Table_odeme** tabloları direkt olarak ilgili randevuyu referans alır (`randevu_id`).
