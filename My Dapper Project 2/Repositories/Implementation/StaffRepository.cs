using Dapper;
using System.Data;
using My_Dapper_Project_2.Context;
using My_Dapper_Project_2.Models.Entities;
using My_Dapper_Project_2.Repositories.Interface;

namespace My_Dapper_Project_2.Repositories.Implementation
{
    public class StaffRepository : IRepository<Staff>
    {
        public void Add(Staff staff)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Insert into Staffs 
                (OrganizationId, AccessLevel) 
                values(@OrganizationId, @AccessLevel)";
                dbConnection.Execute(query, staff);
            }
        }

        public IDbConnection Connection()
        {
            return HotelContext.Connection();
        }

        public IEnumerable<Staff> GetAll()
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Select * from Staffs";

                return dbConnection.Query<Staff>(query);
            }
        }

        public void Remove(Staff staff)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Delete from Staffs where Id = @Id";
                dbConnection.Execute(query, staff);
            }
        }

        public void Update(Staff Staff)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Update Staffs
                Set OrganizationId = @OrganizationId,
                AccessLevel = @AccessLevel
                where Id = @Id";
                dbConnection.Execute(query, Staff);
            }
        }
    }
}