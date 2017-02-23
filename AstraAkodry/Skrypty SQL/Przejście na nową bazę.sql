USE [AstraAkordy2]

CREATE SCHEMA GAL;

CREATE TABLE GAL.GAL_Operatorzy(
	[OPR_OprId] [int] IDENTITY(1,1) NOT NULL,
	[OPR_Imie] [varchar](20) NOT NULL,
	[OPR_Nazwisko] [varchar](20) NOT NULL,
	[OPR_Haslo] [varchar](20) NOT NULL,
	[OPR_Uprwnienia] [int] NOT NULL,
	[OPR_Archiwalny] [int] NOT NULL,
	PRIMARY KEY ([OPR_OprId])
)

insert into GAL.GAL_Operatorzy select [OPR_Imie],[OPR_Nazwisko],[OPR_Haslo],[OPR_Uprwnienia],[OPR_Archiwalny] from Astra_Akordy.dbo.GAL_Operatorzy

CREATE TABLE GAL.GAL_Pracownicy(
	[PRA_PracId] [int] IDENTITY(1,1) NOT NULL,
	[PRA_Imie] [varchar](20) NOT NULL,
	[PRA_Nazwisko] [varchar](20) NOT NULL,
	[PRA_DataZatrudnienia] [datetime] NOT NULL,
	[PRA_Archiwalny] [int] NOT NULL,
	PRIMARY KEY ([PRA_PracId])
)

insert into GAL.GAL_Pracownicy select [PRA_Imie],[PRA_Nazwisko],[PRA_DataZatrudnienia],[PRA_Archiwalny] from Astra_Akordy.dbo.GAL_Pracownicy

CREATE TABLE GAL.[GAL_Akordy](
	[AKR_Id] [int] IDENTITY(1,1) NOT NULL,
	[AKR_AkrId] [int] NOT NULL,
	[AKR_Nazwa] [varchar](100) NOT NULL,
	[AKR_Norma] [float] NOT NULL,
	[AKR_DataDodania] [datetime] NOT NULL,
	[AKR_Archiwalny] [int] NOT NULL
	PRIMARY KEY ([AKR_Id])
)

insert into GAL.[GAL_Akordy] select [AKR_AkrId],[AKR_Nazwa],[AKR_Norma],[AKR_DataDodania],[AKR_Archiwalny] from Astra_Akordy.dbo.[GAL_Akordy]

CREATE TABLE GAL.[GAL_AkordyCena](
	[AKC_Id] [int] IDENTITY(1,1) NOT NULL,
	[AKC_Akr_Id] [int] NOT NULL,
	[AKC_AkrId] [int] NOT NULL,
	[AKC_Cena] [float] NOT NULL,
	PRIMARY KEY ([AKC_Id]),
	FOREIGN KEY ([AKC_Akr_Id]) REFERENCES GAL.[GAL_Akordy]([AKR_Id])
)

insert into GAL.[GAL_AkordyCena] select [AKC_Id],[AKC_AkrId],[AKC_Cena] from Astra_Akordy.dbo.[GAL_AkordyCena]

CREATE TABLE GAL.[GAL_Parametry](
	[PAR_Id] [int] IDENTITY(1,1) NOT NULL,
	[PAR_PracId] [int] NOT NULL,
	[PAR_NAZWA] [varchar](100) NOT NULL,
	[PAR_Wartosc] [varchar](100) NOT NULL,
	[PAR_DataDodania] [datetime] NOT NULL,
	PRIMARY KEY ([PAR_Id]),
	FOREIGN KEY ([PAR_PracId]) REFERENCES GAL.GAL_Operatorzy([OPR_OprId])
)

insert into GAL.[GAL_Parametry] select par_pracid,[PAR_NAZWA],[PAR_Wartosc],[PAR_DataDodania] from Astra_Akordy.dbo.[GAL_Parametry]

CREATE TABLE GAL.[GAL_Ustawienia](
	[UST_Id] [int] IDENTITY(1,1) NOT NULL,
	[UST_Wpis] [varchar](1000) NOT NULL,
	[UST_ZalogowanyOper] [varchar](20) NOT NULL,
	[UST_DataDodania] [datetime] NOT NULL,
	[UST_KomputerOperator] [varchar](20) NOT NULL,
	PRIMARY KEY ([UST_Id])
)

insert into GAL.[GAL_Ustawienia] select [UST_Wpis],[UST_ZalogowanyOper],[UST_DataDodania],[UST_KomputerOperator] from Astra_Akordy.dbo.[GAL_Ustawienia]

