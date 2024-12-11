	-- Создание базы данных Hotel
CREATE DATABASE Hotel;
GO

-- Использование базы данных Hotel
USE Hotel;
GO

-- Создание таблицы Страны
CREATE TABLE Страны (
    CountryID INT PRIMARY KEY IDENTITY(1,1),
    ИмяСтраны VARCHAR(255) NOT NULL,
    Код VARCHAR(10) NOT NULL UNIQUE
);

-- Создание таблицы Пользователи
CREATE TABLE Пользователи(
    UserID INT PRIMARY KEY IDENTITY(1,1),
    ИмяПользователя VARCHAR(255) NOT NULL,
    Пароль VARCHAR(255) NOT NULL,
    Роль VARCHAR(50) NOT NULL,
    Email VARCHAR(255) NOT NULL
);

-- Создание таблицы Отели
CREATE TABLE Отели (
    HotelID INT PRIMARY KEY IDENTITY(1,1),
    Название VARCHAR(255) NOT NULL,
    Адрес VARCHAR(255) NOT NULL,
    Рейтинг INT,
    CountryID INT NOT NULL,
    FOREIGN KEY (CountryID) REFERENCES Страны(CountryID)
);

-- Создание таблицы Туры
CREATE TABLE Туры (
    TourID INT PRIMARY KEY IDENTITY(1,1),
    Название VARCHAR(255) NOT NULL,
    Описание TEXT,
    ДатаНачала DATE NOT NULL,
    ДатаОкончания DATE NOT NULL,
    Цена DECIMAL(10,2) NOT NULL,
    HotelID INT NOT NULL,
    FOREIGN KEY (HotelID) REFERENCES Отели(HotelID)
);

-- Создание таблицы Клиенты
CREATE TABLE Клиенты (
    ClientID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Пользователи(UserID)
);

-- Создание таблицы Заявки
CREATE TABLE Заявки (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    ClientID INT NOT NULL,
    TourID INT NOT NULL,
	Предпочтения TEXT,
    ДополнительныеУслуги TEXT,
    Статус VARCHAR(50) NOT NULL,
    FOREIGN KEY (ClientID) REFERENCES Клиенты(ClientID),
    FOREIGN KEY (TourID) REFERENCES Туры(TourID)
);

-- Создание таблицы Отзывы
CREATE TABLE Отзывы (
    ReviewID INT PRIMARY KEY IDENTITY(1,1),
    ClientID INT NOT NULL,
    HotelID INT NOT NULL,
    Оценка INT NOT NULL,
    Текст TEXT,
    ДатаСоздания DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ClientID) REFERENCES Клиенты(ClientID),
    FOREIGN KEY (HotelID) REFERENCES Отели(HotelID)
);