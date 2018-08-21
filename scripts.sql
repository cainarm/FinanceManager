    create database financeiro;

    use financeiro;

    create table source(
	   id int not null auto_increment primary key, 
        name varchar(45)
    );
    
    create table classifications(
	   id int not null auto_increment primary key, 
        name varchar(45)
    );

    
    create table expenses(
		id int not null auto_increment primary key, 
        value double, 
        date date, 
        source int, 
        classification int, 
        foreign key(source) references source(id), 
        foreign key(classification) references classifications(id)
    );