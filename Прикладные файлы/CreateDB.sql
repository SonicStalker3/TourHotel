	-- �������� ���� ������ Hotel
CREATE DATABASE Hotel;
GO

-- ������������� ���� ������ Hotel
USE Hotel;
GO

-- �������� ������� ������
CREATE TABLE ������ (
    CountryID INT PRIMARY KEY IDENTITY(1,1),
    ��������� VARCHAR(255) NOT NULL,
    ��� VARCHAR(10) NOT NULL UNIQUE
);

-- �������� ������� ������������
CREATE TABLE ������������(
    UserID INT PRIMARY KEY IDENTITY(1,1),
    ��������������� VARCHAR(255) NOT NULL,
    ������ VARCHAR(255) NOT NULL,
    ���� VARCHAR(50) NOT NULL,
    Email VARCHAR(255) NOT NULL
);

-- �������� ������� �����
CREATE TABLE ����� (
    HotelID INT PRIMARY KEY IDENTITY(1,1),
    �������� VARCHAR(255) NOT NULL,
    ����� VARCHAR(255) NOT NULL,
    ������� INT,
    CountryID INT NOT NULL,
    FOREIGN KEY (CountryID) REFERENCES ������(CountryID)
);

-- �������� ������� ����
CREATE TABLE ���� (
    TourID INT PRIMARY KEY IDENTITY(1,1),
    �������� VARCHAR(255) NOT NULL,
    �������� TEXT,
    ���������� DATE NOT NULL,
    ������������� DATE NOT NULL,
    ���� DECIMAL(10,2) NOT NULL,
    HotelID INT NOT NULL,
    FOREIGN KEY (HotelID) REFERENCES �����(HotelID)
);

-- �������� ������� �������
CREATE TABLE ������� (
    ClientID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES ������������(UserID)
);

-- �������� ������� ������
CREATE TABLE ������ (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    ClientID INT NOT NULL,
    TourID INT NOT NULL,
	������������ TEXT,
    �������������������� TEXT,
    ������ VARCHAR(50) NOT NULL,
    FOREIGN KEY (ClientID) REFERENCES �������(ClientID),
    FOREIGN KEY (TourID) REFERENCES ����(TourID)
);

-- �������� ������� ������
CREATE TABLE ������ (
    ReviewID INT PRIMARY KEY IDENTITY(1,1),
    ClientID INT NOT NULL,
    HotelID INT NOT NULL,
    ������ INT NOT NULL,
    ����� TEXT,
    ������������ DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ClientID) REFERENCES �������(ClientID),
    FOREIGN KEY (HotelID) REFERENCES �����(HotelID)
);