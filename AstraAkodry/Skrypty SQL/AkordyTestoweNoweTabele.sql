USE [Astra_Akordy]

drop table [dbo].[GAL_AkordyTestowe];

CREATE TABLE [dbo].[GAL_AkordyTestowe](
	[AKT_Id] [int] IDENTITY(1,1) NOT NULL,
	[AKT_AkrId] [int] NOT NULL,
	[AKT_Nazwa] [varchar](100) NOT NULL,
	[AKT_DataDodania] [datetime] NOT NULL,
	[AKT_Archiwalny] [int] NOT NULL,
	PRIMARY KEY ([AKT_Id])
);

drop table [dbo].[GAL_WartAkorduTestowego];

CREATE TABLE [dbo].[GAL_WartAkorduTestowego](
	[WAT_WatId] [int] IDENTITY(1,1) NOT NULL,
	[WAT_OprId] [int] NOT NULL,
	[WAT_PracId] [int] NOT NULL,
	[WAT_AkrId] [int] NOT NULL,
	[WAT_datawykonania] [datetime] NOT NULL,
	[WAT_DataModyfikacji] [datetime] NOT NULL,
	[WAT_Wartosc] [float] NOT NULL,
	[WAT_Czas] [float] NOT NULL,
	PRIMARY KEY ([WAT_WatId])
)


insert into GAL_AkordyTestowe values((select isnull(max(AKT_AkrID),0)+1 from GAL_AkordyTestowe), 'test', Getdate(),1)
insert into GAL_Akordy values(2, 'test', '2017-02-24 11:23:38',0)









