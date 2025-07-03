import pandas as pd

df = pd.read_csv("ETHUSDT-1d-2020-02.csv")

df["symbol"] = "ETH"

df.to_csv("ETH2020-02.csv", index=False)
