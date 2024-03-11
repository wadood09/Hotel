using System.Data;
using Dapper;
using My_Dapper_Project_2.Context;
using My_Dapper_Project_2.Models.Entities;
using My_Dapper_Project_2.Repositories.Interface;

namespace My_Dapper_Project_2.Repositories.Implementation
{
    public class OrganizationRepository : IRepository<Organization>
    {
        public void Add(Organization organization)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Insert into Organizations 
                (Name, WalletId) 
                values(@Name, @WalletId)";
                dbConnection.Execute(query, organization);
            }
        }

        public IDbConnection Connection()
        {
            return HotelContext.Connection();
        }

        public IEnumerable<Organization> GetAll()
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Select * from Organizations";

                return dbConnection.Query<Organization>(query);
            }
        }

        public void Remove(Organization organization)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Delete from Organizations where Id = @Id";
                dbConnection.Execute(query, organization);
            }
        }

        public void Update(Organization organization)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Update Organizations
                Set Name = @Name,
                WalletId = @WalletId
                where Id = @Id";
                dbConnection.Execute(query, organization);
            }
        }
    }
}