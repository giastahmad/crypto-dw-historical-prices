# 📁 Dataset: Cryptocurrency Historical Prices (Jan–Mar 2020)

Folder ini berisi dataset yang digunakan dalam proyek *crypto-dw-historical-prices*, dengan fokus pada harga historis cryptocurrency dari beberapa sumber tepercaya, khususnya untuk periode Januari hingga Maret 2020.

Dataset ini akan digunakan dalam pipeline ETL (Extract, Transform, Load) sebelum dimuat ke dalam Data Warehouse, dan kemudian divisualisasikan menggunakan Power BI.

---

## 🔗 Sumber Data

Dataset dikumpulkan dari tiga sumber berikut:

1. **[Kaggle - Cryptocurrency Price History](https://www.kaggle.com/datasets/sudalairajkumar/cryptocurrencypricehistory)**  
   - File contoh: `coin_Ethereum.csv`  
   - Berisi harga historis Ethereum dari berbagai exchange secara harian.

2. **[Binance Monthly Klines CSV](https://data.binance.vision/?prefix=data/spot/monthly/klines/)**  
   - File mentah: `ETHUSDT-1d-2020-02.csv`  
   - Menyediakan data candlestick harian (1d) untuk pasangan ETH/USDT.  
   - Format: OHLCV (Open, High, Low, Close, Volume) dalam satu bulan penuh.

3. **[Alternative.me – Fear & Greed Index API](https://api.alternative.me/fng/?limit=0)**  
   - Memberikan data indeks sentimen pasar kripto (greed/fear) untuk periode tertentu.

---

## 📁 Struktur File

| File                     | Asal Sumber | Deskripsi                                                                 |
|--------------------------|-------------|---------------------------------------------------------------------------|
| `coin_Ethereum.csv`      | Kaggle      | Harga historis ETH dari berbagai sumber                                   |
| `ETHUSDT-1d-2020-02.csv` | Binance     | Data mentah ETH/USDT harian untuk Februari 2020                           |
| `ETH2020-02.csv`         | Internal    | Data hasil preprocessing dari file Binance                                |
| `edit.py`                | Internal    | Script Python sederhana untuk preprocessing file Binance                  |

---

## ⚙️ Proses Preprocessing

File `ETHUSDT-1d-2020-02.csv` diproses menggunakan script Python `edit.py` untuk disederhanakan dan dipersiapkan keperluan ETL.

---

## 📅 Scope dan Pembatasan

- Rentang Waktu: Januari – Maret 2020
- Exchange: Hanya menggunakan data dari Binance
- Pembatasan: Dilakukan karena keterbatasan waktu dalam pengumpulan dan pemrosesan data

---

## 🧠 Catatan

- Data dari API (Fear and Greed Index) tidak disimpan sebagai file CSV, namun dapat diakses langsung saat proses ETL atau visualisasi.
- File edit.py merupakan contoh script untuk transformasi awal. Dalam implementasi sesungguhnya, proses ETL dilakukan menggunakan tools seperti SSIS dan SQL Server.