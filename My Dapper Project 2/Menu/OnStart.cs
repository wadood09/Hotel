using System.Data;
using Dapper;
using My_Dapper_Project_2.Context;
using MySql.Data.MySqlClient;

namespace My_Dapper_Project_2.Menu
{
    public class OnStart
    {
        public void Check()
        {
            string connectionString = "Server=localhost;User ID=root;Password=WADOOD091201,,..";
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string query = "Create schema if not exists hoteldb";
                connection.Execute(query);
            }
            CreateUserTable();
            CreateAdminTable();
            CreateCustomerTable();
            CreateHotelTable();
            CreateRoomServiceTable();
            CreateRoomTypeTable();
            CreateRoomTable();
            CreateBookingTable();
        }

        public void CreateUserTable()
        {
            using (IDbConnection connection = HotelContext.Connection())
            {
                string query = @"Create table if not exists Users
                (
                    FirstName VARCHAR(50) NOT NULL,
                    LastName VARCHAR(50) NOT NULL,
                    Dob DATETIME,
                    Wallet DECIMAL(20, 2),
                    Email VARCHAR(100) NOT NULL,
                    Password VARCHAR(100) NOT NULL,
                    Role VARCHAR(100) NOT NULL,

                    PRIMARY KEY (Email)
                )";
                connection.Execute(query);
            }
        }

        public void CreateAdminTable()
        {
            using (IDbConnection connection = HotelContext.Connection())
            {
                string query = @"Create table if not exists Admins
                (
                    Id INT AUTO_INCREMENT,
                    UserEmail VARCHAR(100) NOT NULL,
                    
                    PRIMARY KEY (Id),
                    FOREIGN KEY (UserEmail) REFERENCES Users (Email)
                )";
                connection.Execute(query);
            }
        }

        public void CreateCustomerTable()
        {
            using (IDbConnection connection = HotelContext.Connection())
            {
                string query = @"Create table if not exists Customers
                (
                    Id INT AUTO_INCREMENT,
                    UserEmail VARCHAR(100) NOT NULL,
                    
                    PRIMARY KEY (Id),
                    FOREIGN KEY (UserEmail) REFERENCES Users (Email)
                )";
                connection.Execute(query);
            }
        }

        public void CreateBookingTable()
        {
            using (IDbConnection connection = HotelContext.Connection())
            {
                string query = @"Create table if not exists Bookings
                (
                    Id INT AUTO_INCREMENT,
                    Hotel VARCHAR(50) NOT NULL,
                    HotelId INT,
                    RoomType VARCHAR(50) NOT NULL,
                    RoomTypeId INT,
                    IsRoomService BOOL,
                    RoomService VARCHAR(225),
                    RoomNumber VARCHAR(50) NOT NULL,
                    RoomId INT,
                    CustomerId INT,
                    CustomerStatus ENUM('Active', 'Inactive', 'Passive'),
                    Nights INT,
                    CheckInDate DATETIME,
                    CheckOutDate DATETIME,
                    TotalPriceOfStay DOUBLE,
                    Rate BOOL,
                    PaidService BOOL,

                    PRIMARY KEY (Id),
                    FOREIGN KEY (HotelId) REFERENCES Hotels (Id),
                    FOREIGN KEY (RoomTypeId) REFERENCES RoomTypes (Id),
                    FOREIGN KEY (RoomId) REFERENCES Rooms (Id),
                    FOREIGN KEY (CustomerId) REFERENCES Customers (Id)
                )";
                connection.Execute(query);
            }
        }

        public void CreateHotelTable()
        {
            using (IDbConnection connection = HotelContext.Connection())
            {
                string query = @"Create table if not exists Hotels
                (
                    Id INT AUTO_INCREMENT,
                    Name VARCHAR(50) NOT NULL,
                    AdminId INT,
                    HotelStatus ENUM('Active', 'Inactive', 'Passive'),
                    Ratings DOUBLE,

                    PRIMARY KEY (Id),
                    FOREIGN KEY (AdminId) REFERENCES Admins (Id)
                )";
                connection.Execute(query);
            }
        }

        public void CreateRoomTable()
        {
            using (IDbConnection connection = HotelContext.Connection())
            {
                string query = @"Create table if not exists Rooms
                (
                    Id INT AUTO_INCREMENT,
                    RoomTypeId INT NOT NULL,
                    AdminId INT NOT NULL,
                    RoomStatus ENUM('Occupied', 'Booked', 'Vacant') NOT NULL,

                    PRIMARY KEY (Id),
                    FOREIGN KEY (RoomTypeId) REFERENCES RoomTypes (Id),
                    FOREIGN KEY (AdminId) REFERENCES Admins (Id)
                )";
                connection.Execute(query);
            }
        }

        public void CreateRoomServiceTable()
        {
            using (IDbConnection connection = HotelContext.Connection())
            {
                string query = @"Create table if not exists RoomServices
                (
                    Id INT AUTO_INCREMENT,
                    HotelId INT NOT NULL,
                    Name VARCHAR(50) NOT NULL,
                    Price DOUBLE NOT NULL,

                    PRIMARY KEY (Id),
                    FOREIGN KEY (HotelId) REFERENCES Hotels (Id)
                )";
                connection.Execute(query);
            }
        }

        public void CreateRoomTypeTable()
        {
            using (IDbConnection connection = HotelContext.Connection())
            {
                string query = @"Create table if not exists RoomTypes
                (
                    Id INT AUTO_INCREMENT,
                    HotelId INT NOT NULL,
                    Name VARCHAR(50) NOT NULL,
                    AmountOfRooms INT NOT NULL,
                    Price DOUBLE NOT NULL,
                    RoomStatus ENUM('Active', 'Inactive', 'Passive') NOT NULL,

                    PRIMARY KEY (Id),
                    FOREIGN KEY (HotelId) REFERENCES Hotels (Id)
                )";
                connection.Execute(query);
            }
        }
    }
}