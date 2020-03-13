# BitcoinLogger
The application is a web platform that fetches Bitcoin price (BTC/USD) from multiple sources and presents them to the user.
It consumes 2 BTC/USD price sources:
1. Bitstamp: https://www.bitstamp.net/api/ticker/ 
2. GDAX: https://api.gdax.com/products/BTC-USD/ticker 
This application is a simple startup project using ASP.NET Core 3.0 for backend implementatin and Angular 8 for frontend implementation 


## Getting Started

The easiest way to use these samples without using Git is to download the zip file containing the current version. You can then unzip the entire archive and use the Web application in Visual Studio.
Application uses a local sql server db to store bitcoin prices using windows authentication. 
The following script creates database and tables 
 ```
create database BitcoinLogger;
use BitcoinLogger;

create table dbo.BitcoinPrice
(Id bigint identity(1,1) primary key,
SourceId int not null,
Price float not null,
Timestamp datetime not null)
go

create table dbo.BitcoinSource
(Id int primary key,
Description nvarchar(100) not null,
Uri nvarchar(100) not null)
go

alter table dbo.BitcoinPrice
ADD CONSTRAINT FK_SourceId
FOREIGN KEY (SourceId) REFERENCES dbo.BitcoinSource(Id)
go

insert into dbo.BitcoinPrice
values (),
()

```

## Authors

* **Afroditi Tzifa** - (https://github.com/afroditiTzifa)

