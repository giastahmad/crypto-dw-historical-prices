CREATE TABLE dimensi_waktu (
    date_id INT PRIMARY KEY NOT NULL,
    [date] DATE NOT NULL,
    [day] TINYINT NULL,
    [month] TINYINT NULL,
    [year] SMALLINT NULL,
    isWeekend BIT NULL,
    nama_hari NVARCHAR(15) NULL
);
GO

CREATE TABLE dimensi_bursa (
    exchange_id INT PRIMARY KEY NOT NULL,
    [name] NVARCHAR(100) NOT NULL,
    [type] NVARCHAR(50) NULL,
    country_of_origin NVARCHAR(100) NULL
);
GO

CREATE TABLE dimensi_cryptocurrency (
    crypto_id INT PRIMARY KEY NOT NULL,
    [name] NVARCHAR(100) NOT NULL,
    symbol NVARCHAR(20) NULL,
    category NVARCHAR(100) NULL,
    founder NVARCHAR(150) NULL,
    release_year SMALLINT NULL
);
GO

CREATE TABLE dimensi_sentimen_pasar (
    sentiment_id INT PRIMARY KEY NOT NULL,
    sentiment NVARCHAR(50) NULL,
    type_source NVARCHAR(100) NULL
);
GO

CREATE TABLE dimensi_indikator_teknikal (
    indicator_id INT PRIMARY KEY NOT NULL,
    rsi_category NVARCHAR(50) NULL,
    price_vs_ma7d NVARCHAR(50) NULL
);
GO

-- =============================================
-- Create Fact Table
-- =============================================

CREATE TABLE fact_table (
    fact_id BIGINT PRIMARY KEY NOT NULL,
    date_id INT NULL,
    crypto_id INT NULL,
    exchange_id INT NULL,
    sentiment_id INT NULL,
    indicator_id INT NULL,
    market_cap DECIMAL(28, 2) NULL,
    volume DECIMAL(28, 2) NULL,
    price DECIMAL(18, 8) NOT NULL,

    CONSTRAINT FK_fact_table_dimensi_waktu FOREIGN KEY (date_id) REFERENCES dbo.dimensi_waktu(date_id),
    CONSTRAINT FK_fact_table_dimensi_cryptocurrency FOREIGN KEY (crypto_id) REFERENCES dbo.dimensi_cryptocurrency(crypto_id),
    CONSTRAINT FK_fact_table_dimensi_bursa FOREIGN KEY (exchange_id) REFERENCES dbo.dimensi_bursa(exchange_id),
    CONSTRAINT FK_fact_table_dimensi_sentimen_pasar FOREIGN KEY (sentiment_id) REFERENCES dbo.dimensi_sentimen_pasar(sentiment_id),
    CONSTRAINT FK_fact_table_dimensi_indikator_teknikal FOREIGN KEY (indicator_id) REFERENCES dbo.dimensi_indikator_teknikal(indicator_id)
);
GO