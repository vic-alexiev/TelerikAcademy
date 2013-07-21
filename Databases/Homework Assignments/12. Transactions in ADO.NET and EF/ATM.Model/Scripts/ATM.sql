USE master
GO

CREATE DATABASE ATM
GO

USE ATM
GO

CREATE TABLE CardAccounts(
  CardId int IDENTITY NOT NULL,
  CardNumber char(10) NOT NULL,
  CardPIN char(4) NOT NULL,
  CardCash money NOT NULL,
  CONSTRAINT PK_CardAccounts PRIMARY KEY CLUSTERED(CardId ASC),
  CONSTRAINT UC_CardAccounts UNIQUE NONCLUSTERED (CardNumber)
)
GO

CREATE TABLE TransactionsHistory(
  TransactionId int IDENTITY NOT NULL,
  CardNumber char(10) NOT NULL,
  TransactionDate datetime NOT NULL,
  Amount money NOT NULL,
  CONSTRAINT PK_TransactionsHistory PRIMARY KEY CLUSTERED(TransactionId ASC)
)
GO

INSERT INTO CardAccounts(CardNumber, CardPIN, CardCash) VALUES
('5633009602', '9871', 20000),
('5982378912', '9812', 30000),
('9273412345', '8356', 10000)