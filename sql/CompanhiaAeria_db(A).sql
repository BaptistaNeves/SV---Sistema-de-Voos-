create database CompanhiaAeraea
go
create table Cidade
(
	Id uniqueidentifier not null,
	Nome varchar(50) null,
	Pais varchar(30) null,
	constraint[CidadeChavePrimaria] primary key(Id)
)
go
create table Aeroporto
(
	Id uniqueidentifier not null,
	Nome varchar(50) null,
	CidadeId uniqueidentifier null,
	Activo bit null,
	constraint[AeroportoChavePrimaria] primary key(Id)
)
go 
alter table Aeroporto
	add constraint[AeroportoCidadeChaveEstrangeira] foreign key(CidadeId)
	references Cidade(Id)
go
create table Aeronave
(
	Id uniqueidentifier not null,
	Modelo varchar(100) null,
	Fabricante varchar(100) null,
	TotalDeAssentos int null,
	Estado bit null,
	constraint[AeronaveChavePrimaria] primary key(Id)
)
go
create table Classe
(
	Id uniqueidentifier not null,
	Descricao varchar(50) null,
	constraint[ClasseChavePrimaria] primary key(Id)
)
go
create table Assento
(
	Id uniqueidentifier not null,
	Numero int null,
	AeronaveId uniqueidentifier null,
	ClasseId uniqueidentifier null,
	constraint[AssentoPrimaryKey] primary key(Id)
)
go
alter table Assento
	add constraint[AssentoAeronaveChaveEstrangeira] foreign key(AeronaveId) 
	references Aeronave(Id)
go
alter table Assento
	add constraint[AssentoClasseChaveEstrangeira] foreign key(ClasseId) 
	references Classe(Id)
go
create table Piloto
(
	Id uniqueidentifier not null,
	Nome varchar(100) null,
	Activo bit null,
	constraint[PilotoChavePrimaria] primary key(Id)
)
go
create table TipoVoo /*O Voo pode ser Doméstico ou internacional*/
(
	Id uniqueidentifier not null,
	Nome varchar(50) null,
	Descricao varchar(max) null,
	constraint[TipoVooChavePrimaria] primary key(Id)
)
go
create table Voo
(
	Id uniqueidentifier not null,
	Descricao varchar(max) null,
	HoraDePartida datetime null,
	PrevisaoDeChegada datetime null,
	PrevisaoDeChegadaAoDestino datetime null,
	TipoVooId uniqueidentifier null,
	AeroportoDeOrigemId uniqueidentifier null,
	AeroportoDestinoId uniqueidentifier null,
	AeronaveId uniqueidentifier null,
	Estado bit null, /*LIBERADO OU NÃO PARA RESERVAS*/
	constraint[VooChavePrimaria] primary key(Id)
)
go
alter table Voo
	add constraint[VooAeronaveChaveEstrangeira] foreign key(AeronaveId)
	references Aeronave(Id)
go
alter table Voo 
	add constraint[VooPilotoChaveEstrangeira] foreign key(PilotoId) 
	references Piloto(Id)
go
alter table Voo 
	add constraint[VooAeroportoOrigemChaveEstrangeira] foreign key(AeroportoOrigemId) 
	references Aeroporto(Id)
go
alter table Voo 
	add constraint[VooAeroportoDestinoChaveEstrangeira] foreign key(AeroportoDestinoId) 
	references Aeroporto(Id)
go
alter table Voo 
	add constraint[VooTipoVooChaveEstrangeira] foreign key(TipoVooId) 
	references TipoVoo(Id)
go
create table FuncionariosDoVoo
(
	Id uniqueidentifier not null,
	Nome varchar(100) null,
	Funcao varchar(100) null
)
go
create table Lugar
(
	Id uniqueidentifier not null,
	AssentoId uniqueidentifier null,
	VooId uniqueIdentifier null,
	Fumante bit null,
	Estado bit null,/*Ocupado ou não*/
	constraint[LugarChavePrimaria] primary key(Id)
)
go
alter table Lugar
	add constraint[LugarAssentoChaveEstrangeira] foreign key(AssentoId)
	references Assento(Id)
go
alter table Lugar
	add constraint[LugarVooChaveEstrangeira] foreign key(VooId)
	references Voo(Id)
go
create table Cliente
(
	Id uniqueidentifier not null,
	NomeCompleto varchar(255) null,
	Telefone varchar(30) null,
	Email varchar(255) null,
	DataNascimento datetime null,
	Nacionalidade varchar(30) null,
	Documento varchar(30) null,
	NumeroDocumento varchar(50) null,
	constraint[ClienteChavePrimaria] primary key(Id)
)
go
create table Reserva
(
	Id uniqueidentifier not null,
	ClienteId uniqueidentifier null,
	Estado varchar(30) null, /*Estado da Reserva (Cancelado,Prorrogado)*/
	PrazoDeValidade datetime null,
	DataDaReserva datetime null,
	constraint[ReservaChavePrimaria] primary key(Id)
)
go
alter table Reserva
	add constraint[ReservaClienteChaveEstrangeira] foreign key(ClienteId)
	references Cliente(Id)
go
create table ReservaItem
(
	Id uniqueidentifier not null,
	VooId uniqueidentifier null,
	LugarId uniqueidentifier null,
	constraint[ReservaItemChavePrimaria] primary key(Id)
)
go
alter table ReservaItem
	add constraint[ReservaItemVooChaveEstrangeira] foreign key(VooId)
	references Voo(Id)
go
alter table ReservaItem
	add constraint[ReservaItemLugarChaveEstrangeira] foreign key(LugarId)
	references Lugar(Id)
go

create table Bilhete
(
	Id uniqueidentifier not null,
	ClienteId uniqueidentifier null,
	AssentoId uniqueidentifier  null,
	PrecoCusto decimal(8,2) null,
)
go


Cada aeronave pode possuir mais de uma cabine
Uma cabine para classe Executiva
E outra cabine para classe Economica
Na classe economica a cabine pode ser distribuida por fileiras
Na classe executiva não é distribuida por fileiras, mas por assentos individuais 