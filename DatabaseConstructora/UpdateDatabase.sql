﻿--ACTUALIZAR
/*
ALTER TABLE SEC_ROLE ADD REMOVED BIT NOT NULL;
ALTER TABLE SEC_ROLE ADD DESCRIPTION NVARCHAR(200) NULL;


ALTER TABLE SEC_SESSION ADD LOGOUT_DATE DATETIME NULL;


ALTER TABLE SEC_USER ADD REMOVED BIT NOT NULL;
ALTER TABLE SEC_USER ADD REMOVE_DATE DATETIME NULL;
ALTER TABLE SEC_USER ADD CREATE_DATE DATETIME NOT NULL;
ALTER TABLE SEC_USER ADD UPDATE_DATE DATETIME NULL;
ALTER TABLE SEC_USER ADD REMOVE_USER_ID INT  NULL;
ALTER TABLE SEC_USER ADD CREATE_USER_ID INT NULL;
ALTER TABLE SEC_USER ADD UPDATE_USER_ID INT NULL;*/

-------------------------------------------------------

CREATE TABLE PARAM_COUNTRY(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
CODE NVARCHAR(40) NOT NULL,
NAME NVARCHAR(50) NOT NULL
)

CREATE TABLE PARAM_CITY(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
CODE NVARCHAR(40) NOT NULL,
NAME NVARCHAR(50) NOT NULL,
COUNTRYID INT NOT NULL,
FOREIGN KEY (COUNTRYID) REFERENCES PARAM_COUNTRY,
)

CREATE TABLE PARAM_FINANCIAL(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
NAME_JOB NVARCHAR(50) NOT NULL,
PHONE_JOB NVARCHAR(30) NOT NULL,
TOTAL_IN_COME INT NOT NULL,
TIME_CURRENT_WORK DATETIME NOT NULL,
NAME_FAMILY_REF NVARCHAR(50) NOT NULL,
CELLPHONE_FAMILY_REF NVARCHAR(30) NOT NULL,
NAME_PERSONAL_REF NVARCHAR(50) NOT NULL,
CELLPHONE_PERSONAL_REF NVARCHAR(30) NOT NULL
)

CREATE TABLE PARAM_CUSTOMER(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
DOCUMENT NVARCHAR(40) NOT NULL,
NAME NVARCHAR(50) NOT NULL,
LASTNAMEN VARCHAR(100) NOT NULL,
DATE_BIRTH DATETIME NOT NULL,
PICTURE NVARCHAR(MAX),
CELLPHONE NVARCHAR(30) NOT NULL,
EMAIL NVARCHAR(100) NOT NULL,
ADRESS NVARCHAR(50) NOT NULL,
CITYID INT NOT NULL,
FINANCIALID INT NOT NULL,
FOREIGN KEY (CITYID) REFERENCES PARAM_CITY,
FOREIGN KEY (FINANCIALID) REFERENCES PARAM_FINANCIAL
)

CREATE TABLE PARAM_PROJECT(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
CODE NVARCHAR(40) NOT NULL,
NAME NVARCHAR(50) NOT NULL,
DESCRIPTION NVARCHAR(MAX) NOT NULL,
PICTURE NVARCHAR(MAX),
CITYID INT NOT NULL,
FOREIGN KEY (CITYID) REFERENCES PARAM_CITY,
)

CREATE TABLE PARAM_BLOCK(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
CODE NVARCHAR(40) NOT NULL,
NAME NVARCHAR(50) NOT NULL,
DESCRIPTION NVARCHAR(MAX) NOT NULL,
PROJECTID INT NOT NULL,
FOREIGN KEY (PROJECTID) REFERENCES PARAM_PROJECT,
)

CREATE TABLE PARAM_PROPERTY(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
CODE NVARCHAR(40) NOT NULL,
IDENTIFIER NVARCHAR(50) NOT NULL,
BLOCKID INT NOT NULL,
VALOR INT NOT NULL,
FOREIGN KEY (BLOCKID) REFERENCES PARAM_BLOCK
)

CREATE TABLE PARAM_REQUEST_STATUS(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
NAME NVARCHAR(50) NOT NULL,
STATUS_DESCRIPTION NVARCHAR(MAX) NOT NULL,
)

CREATE TABLE PARAM_REQUEST(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
DELIVERY_DATE DATETIME NOT NULL,
APPROVED_DATE DATETIME NOT NULL,
ECONOMIC_OFFER INT NOT NULL,
CONSIGNMENT INT NOT NULL,
CUSTOMERID INT NOT NULL,
PROPERTYID INT NOT NULL,
REQUEST_STATUSID INT NOT NULL,
FOREIGN KEY (CUSTOMERID) REFERENCES PARAM_CUSTOMER,
FOREIGN KEY (PROPERTYID) REFERENCES PARAM_PROPERTY,
FOREIGN KEY (REQUEST_STATUSID) REFERENCES PARAM_REQUEST_STATUS
)

CREATE TABLE PARAM_PAYMENTS(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
NAME NVARCHAR(50) NOT NULL,
PAYMENT_DESCRIPTION NVARCHAR(MAX) NOT NULL,
PAYMENT_DATE DATETIME NOT NULL,
REQUESTID INT NOT NULL
FOREIGN KEY (REQUESTID) REFERENCES PARAM_REQUEST
)

-------------------------------------------------------------------

CREATE TABLE SEC_FORM(
ID INT IDENTITY NOT NULL PRIMARY KEY,
NAME NVARCHAR(100),
URL NVARCHAR(100)
)

CREATE TABLE SEC_FORMS_ROLE(
ID INT IDENTITY PRIMARY KEY NOT NULL,
ROLE_ID INT NOT NULL,
FORM_ID INT NOT NULL,
FOREIGN KEY(ROLE_ID) REFERENCES SEC_ROLE,
FOREIGN KEY (FORM_ID) REFERENCES SEC_FORM
)