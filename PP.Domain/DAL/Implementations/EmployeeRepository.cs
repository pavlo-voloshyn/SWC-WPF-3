using Microsoft.Data.SqlClient;
using PP.Domain.DAL.Implementations;
using PP.Domain.Models;
using PP.Domain.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PP.Domain.DAL;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository() : base()
    {
        //entities.Add(new Employee() { Id = 1, FirstName = "Slavik", LastName = "Zozuk", Office = "Lviv DSMU", Role = Role.Officer });
        //entities.Add(new Employee() { Id = 2, FirstName = "Dmytro", LastName = "Melnyk", Office = "Lviv DSMU", Role = Role.SeniorOfficer });
    }

    public override async Task Update(Employee entity)
    {
        string queryString =
            "UPDATE [dbo].[Employees]" +
            "SET FirstName=@FirstName," +
            "Surname=@Surname," +
            "ERole=@ERole," +
            "Office=@Office " +
            "WHERE Id=@Id";

        using SqlConnection connection = new(connectionString);

        SqlCommand command = new(queryString, connection);
        command.Parameters.AddWithValue("@FirstName", entity.FirstName);
        command.Parameters.AddWithValue("@Surname", entity.Surname);
        command.Parameters.AddWithValue("@ERole", entity.ERole);
        command.Parameters.AddWithValue("@Office", entity.Office);
        command.Parameters.AddWithValue("@Id", entity.Id);
        connection.Open();
        await command.ExecuteNonQueryAsync();
        connection.Close();
    }
}
