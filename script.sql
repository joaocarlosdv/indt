create table proposta (
	Id int NOT NULL AUTO_INCREMENT,
	Cliente varchar(50) not null,
	Valor numeric(17,2) not null,
	Status int not null,
	constraint pk_proposta primary key (Id)
);

create table contratacao (
	Id int NOT NULL AUTO_INCREMENT,
	PropostaId int not null,
	DataContratacao DateTime not null,
	constraint pk_contratacao primary key (Id),
	constraint uk_contratacao unique (PropostaId)
);