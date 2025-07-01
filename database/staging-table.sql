CREATE TABLE staging_sentiment (
    TradeDate DATE NULL,
    SentimentClassification NVARCHAR(50) NULL
);
GO

CREATE TABLE staging_marketcap (
    TradeDate DATE NULL,
    Symbol NVARCHAR(20) NULL,
    MarketCap DECIMAL(28, 2) NULL
);
GO