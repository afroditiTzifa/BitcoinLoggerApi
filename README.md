# BitcoinLoggerApi
This is a REST API using ASP.NET Core 3.1 that fetches Bitcoin price by two popular crypto exchanges; Bitstamp and GDAX for 4 different Currency Pairs: BTC/USD, BTC/EUR, BTC-GBP and BTC/PAX.<br />
Data are stored locally in SQL Server database.<br />
You will find a pushished version in ```https://bitcoin-logger-api.herokuapp.com```.<br />
In published version data are stored in PostgreSQL database.
 


## Getting Started

In order to run this sample locally, the BitcoinLogger database is needed. Install BitcoinLogger sample database:
```
    dotnet ef migrations add InitialCreate
    dotnet ef database update
```

Make sure you have .NET Core 3.1 SDK installed on your machine. Clone this repo in a directory on your computer and then configure the connection string in appsettings.json.
To run and test the REST API locally, just run
```
dotnet run
```
.NET will start the HTTP server and when everything is up and running you'll see something like
```
Now listening on: https://localhost:5001
```


Using a REST Client (like Insomnia, Postman or curl), you can now call your API, for example:
```
curl -k -X GET http://localhost:5001/CurrencyPairData
```
and you'll get all available Currency Pairs
```
[
    {
        "id": 1,
        "description": "BTC-USD"
    },
    {
        "id": 2,
        "description": "BTC-EUR"
    },
    {
        "id": 3,
        "description": "BTC-GBP"
    },
    {
        "id": 4,
        "description": "BTC-PAX"
    }
]
```
```
curl -k -X GET http://localhosts:5001/LiveData/1
```
and you'll get Bitcoin real time price by two popular crypto exchanges; Bitstamp and GDAX for BTC/USD CurrencyPair.
```
[
    {
        "sourceId": 1,
        "source": "Bitstamp",
        "userId": 0,
        "currencyPairId": 1,
        "currencyPair": "BTC-USD",
        "timestamp": "2020-09-28T12:03:07Z",
        "lastPrice": 10872.15,
        "highPrice": 10950,
        "lowPrice": 10593.58,
        "openPrice": 10779.99,
        "bid": 10869.05,
        "ask": 10873.57,
        "volume": 3103.25861279
    },
    {
        "sourceId": 2,
        "source": "GDAX",
        "userId": 0,
        "currencyPairId": 1,
        "currencyPair": "BTC-USD",
        "timestamp": "2020-09-28T12:03:06.730285Z",
        "lastPrice": 10870.12,
        "highPrice": null,
        "lowPrice": null,
        "openPrice": null,
        "bid": 10870.11,
        "ask": 10870.12,
        "volume": 4741.64994635
    }
]
```

## Authors

* **Afroditi Tzifa** - (https://github.com/afroditiTzifa)

