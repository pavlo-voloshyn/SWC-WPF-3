using Microsoft.Data.SqlClient;
using PP.Domain.DAL.Implementations;
using PP.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PP.Domain.DAL;

public class EmployeeOrderRepository : BaseRepository<EmployeeOrder>, IEmployeeOrderRepository
{
    public EmployeeOrderRepository() : base()
    {
    //    this.entities.Add(new EmployeeOrder() { EmployeeId = 1, OrderId = 1 });
    //    this.entities.Add(new EmployeeOrder() { EmployeeId = 1, OrderId = 2 });
    //    this.entities.Add(new EmployeeOrder() { EmployeeId = 2, OrderId = 3 });
    //    this.entities.Add(new EmployeeOrder() { EmployeeId = 2, OrderId = 4 });
    }

    public async Task Create(int employeeId, int orderId)
    {
        context.Add(new EmployeeOrder() { EmployeeId = employeeId, OrderId = orderId});
        await context.SaveChangesAsync();
    }

    public async Task Delete(int employeeId, int orderId)
    {
        string queryString =
            "DELETE FROM [dbo].[EmployeeOrders] " +
            "WHERE EmployeeId=@EmployeeId AND OrderId=@OrderId;";

        using SqlConnection connection = new(connectionString);

        SqlCommand command = new(queryString, connection);
        command.Parameters.AddWithValue("@EmployeeId", employeeId);
        command.Parameters.AddWithValue("@OrderId", orderId);
        connection.Open();
        await command.ExecuteNonQueryAsync();
        connection.Close();
    }

    public async Task DeleteByEmployee(int employeeId)
    {
        string queryString =
            "DELETE FROM [dbo].[EmployeeOrders] " +
            "WHERE EmployeeId=@EmployeeId";

        using SqlConnection connection = new(connectionString);

        SqlCommand command = new(queryString, connection);
        command.Parameters.AddWithValue("@EmployeeId", employeeId);
        connection.Open();
        await command.ExecuteNonQueryAsync();
        connection.Close();
    }
}
