CREATE DATABASE dbcustomer;

USE dbcustomer;

DROP TABLE IF EXISTS CUSTOMERS;

CREATE TABLE Customers(

Id INT AUTO_INCREMENT PRIMARY KEY,
NameCustomer VARCHAR(250) NOT NULL,
EmailCustomer VARCHAR(100) NOT NULL UNIQUE,
BirthdayCustomer DATE NOT NULL,
PhoneCustomer VARCHAR(15) NULL,
CellPhoneCustomer VARCHAR(15) NOT NULL,
Address VARCHAR(250) NOT NULL,
Status_Register int(2) NOT NULL DEFAULT 1
        
);
        
INSERT INTO Customers values(null, 'Teste 01', 'teste01@gmail.com','2014-01-24', '1144142212', '11986287921','Rua tal - são paulo - sp - cep 129584 - bairro tal',1);    
INSERT INTO Customers values(null, 'Teste 02', 'teste02@gmail.com','2014-01-24', '1144142212', '11986287988','Rua tal - são paulo - sp - cep 129584 - bairro tal02',1);  
INSERT INTO Customers values(null, 'Teste 03', 'teste03@gmail.com','2014-01-24', '1144142212', '11986287999','Rua tal - são paulo - sp - cep 129584 - bairro tal03',1);
INSERT INTO Customers values(null, 'Teste 04', 'teste04@gmail.com','2000-01-24', '1144142212', '11986287999','Rua tal - são paulo - sp - cep 129584 - bairro tal04',1);  
       
SELECT * FROM CUSTOMERS;


        
        
        