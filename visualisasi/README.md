# 📈 Visualisasi Harga Historis Cryptocurrency

Proyek ini merupakan dashboard interaktif yang dibuat dengan Power BI untuk memvisualisasikan data historis harga dan kapitalisasi pasar dari beberapa cryptocurrency populer, seperti Bitcoin (BTC), Ethereum (ETH), Binance Coin (BNB), dan Ripple (XRP). Dashboard ini bertujuan untuk membantu pengguna dalam menganalisis tren harga, volume perdagangan, dan kapitalisasi pasar guna mendukung pengambilan keputusan investasi yang berbasis data.

## 🔍 Fitur Utama

### 1. **Aggregated Price**
- Grafik garis yang menunjukkan agregasi harga berbagai cryptocurrency dari waktu ke waktu.
- Filter interaktif berdasarkan nama koin (BTC, ETH, XRP, BNB) dan bulan.

### 2. **Analisis Pasar**
- **Volume vs Market Cap Overview**: Menampilkan perbandingan antara volume perdagangan dan kapitalisasi pasar.
- **Volume Distribution by Cryptocurrency**: Menunjukkan distribusi volume berdasarkan jenis cryptocurrency dalam bentuk diagram donat.
- **Market Capitalization by Symbol**: Visualisasi perbandingan kapitalisasi pasar dari masing-masing koin.
- **Kartu Ringkasan (KPI)**:
  - Total Volume: 13.40 Triliun
  - Total Transactions: 364
  - Average Price: 2.12K

## 📂 Struktur Proyek

- `cryptocurrency-historical-prices-visualization.pbix`: File utama Power BI yang memuat seluruh visualisasi dan transformasi data.

## 🧾 Sumber Data

Dataset dikumpulkan dari tiga sumber utama berikut:

1. **[Kaggle – Cryptocurrency Price History](https://www.kaggle.com/datasets)**
   - Contoh file: `coin_Ethereum.csv`
   - Berisi data harga historis Ethereum dari berbagai exchange secara harian.

2. **[Binance – Monthly Klines CSV](https://data.binance.vision/)**
   - Contoh file: `ETHUSDT-1d-2020-02.csv`
   - Data candlestick harian (1d) untuk pasangan ETH/USDT, berformat OHLCV (Open, High, Low, Close, Volume).

3. **[Alternative.me – Fear & Greed Index API](https://alternative.me/crypto/fear-and-greed-index/)**
   - Menyediakan indeks sentimen pasar kripto (Greed/Fear) untuk periode tertentu.

## 📝 Catatan

- Dashboard ini bersifat **statis**, artinya data tidak ter-update otomatis secara real-time.
- Jika ingin memperbarui isi dataset, pengguna harus menambahkan file data baru secara manual dan memperbarui transformasi di Power BI.
- Cocok digunakan untuk:
  - Edukasi dan eksplorasi data pasar kripto
  - Visualisasi dalam presentasi akademik atau profesional
  - Portofolio data analysis dan business intelligence