-- Filip Mularski 18731 Projekt 'Account Manager' w ramach przedmiotu Aplikacje Internetowe II
-- skrypt generujacy i wypelniajacy baze danych

use Account_Manager_Test;

DROP TABLE IF EXISTS Accounts;
DROP TABLE IF EXISTS Users;

CREATE TABLE Users (
  Id INTEGER  NOT NULL IDENTITY(1,1),
  Login TEXT  NOT NULL,
  Email TEXT  NOT NULL,
  Pasword TEXT  NOT NULL,
  Pin TEXT  NOT NULL,
PRIMARY KEY(Id));



CREATE TABLE Accounts (
  Id INTEGER  NOT NULL IDENTITY(1,1),
  Users_Id INTEGER  NOT NULL,
  Title TEXT  NOT NULL,
  Login TEXT  NOT NULL,
  Email TEXT  NOT NULL,
  Pasword TEXT  NOT NULL,
PRIMARY KEY(Id)  ,
  FOREIGN KEY(Users_Id)
    REFERENCES Users(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX Accounts_FKIndex1 ON Accounts (Users_Id);


INSERT INTO Users (Login, Email, Pasword, Pin) VALUES ('Filip18731', '18731@student.pwsz.elblag.pl', '123345678', '12345');
INSERT INTO Users (Login, Email, Pasword, Pin) VALUES ('Adam33', 'adam33@mail.com', 'abcdefhgi', 'tajny_pin');
INSERT INTO Users (Login, Email, Pasword, Pin) VALUES ('JanNowak2000', 'jan2000@mail.com', 'tajne_haslo', 'qqqqqqqqq');
INSERT INTO Users (Login, Email, Pasword, Pin) VALUES ('kokokowalski', 'koko@mail.com', 'niemamhasla', 'pinuteznie');
INSERT INTO Users (Login, Email, Pasword, Pin) VALUES ('secretuser', 'secret@mail.com', 'alamakota', 'akotmaale');


INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('gmail', 'filipgmail', 'filip@mail.com', '12345678', 1);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('outlook', 'adamoutlook', 'adam@mail.com', '12345678', 2);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('moodle', 'filipmoodle', 'filip@mail.com', '12345678', 1);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('pwsz', 'filippwsz', 'filip@mail.com', '12345678', 1);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('wp', 'adamwp', 'adam@mail.com', '12345678', 2);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('gra online 1', 'filipgra1', 'filip@mail.com', '12345678', 1);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('gra online 2', 'filipgra2', 'filip@mail.com', '12345678', 1);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('bank', 'janbank', 'jan@mail.com', '12345678', 3);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('gmail', 'jangmail', 'jan@mail.com', '12345678', 3);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('poczta o2', 'jano2', 'jan@mail.com', '12345678', 3);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('kurnik.pl', 'kowalkurnik', 'jan@mail.com', '12345678', 4);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('moodle', 'kowalmoodle', 'jan@mail.com', '12345678', 4);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('udemy', 'filipudemy', 'filip@mail.com', '12345678', 1);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('webinar', 'filipwebinar', 'filip@mail.com', '12345678', 1);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('konto oracle', 'filiporacle', 'filip@mail.com', '12345678', 1);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('do banku', 'kowalbank', 'jan@mail.com', '12345678', 4);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('przychodnia', 'kowalprzychodnia', 'jan@mail.com', '12345678', 4);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('forum internetowe', 'filipforum', 'filip@mail.com', '12345678', 1);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('facebook', 'userfb', 'user@mail.com', '12345678', 5);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('instagram', 'filipinsta', 'filip@mail.com', '12345678', 1);
INSERT INTO Accounts (Title, Login, Email, Pasword, Users_Id) VALUES ('twitter', 'usertwitter', 'user@mail.com', '12345678', 5);
