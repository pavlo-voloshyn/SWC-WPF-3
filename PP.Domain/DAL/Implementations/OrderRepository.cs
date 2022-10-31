using Microsoft.Data.SqlClient;
using PP.Domain.DAL.Implementations;
using PP.Domain.Models;
using PP.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PP.Domain.DAL;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository()
    {
        //entities.Add(new Order { Id = 1, DateCreated = DateTime.Now, IsUrgent = false, ServiceType = ServiceType.CreatePassport, PassportId = 124123 });
        //entities.Add(new Order { Id = 2, DateCreated = DateTime.Now, IsUrgent = true, ServiceType = ServiceType.ChangePassport, PassportId = 2354123 });
        //entities.Add(new Order { Id = 3, DateCreated = DateTime.Now, IsUrgent = false, ServiceType = ServiceType.CreateForeignPassport, PassportId = 8765123 });
        //entities.Add(new Order { Id = 4, DateCreated = DateTime.Now, IsUrgent = false, ServiceType = ServiceType.ChangeForeignPassport, PassportId = 34734123 });
    }

    public override async Task Update(Order entity)
    {
        string queryString =
            "UPDATE [dbo].[Orders]" +
            "SET ServiceType=@ServiceType," +
            "IsUrgent=@IsUrgent," +
            "Status=@Status," +
            "PassportId=@PassportId " +
            "WHERE Id=@Id";

        using SqlConnection connection = new(connectionString);

        SqlCommand command = new(queryString, connection);
        command.Parameters.AddWithValue("@ServiceType", entity.ServiceType);
        command.Parameters.AddWithValue("@IsUrgent", entity.IsUrgent);
        command.Parameters.AddWithValue("@Status", entity.Status);
        command.Parameters.AddWithValue("@PassportId", entity.PassportId);
        command.Parameters.AddWithValue("@Id", entity.Id);
        connection.Open();
        await command.ExecuteNonQueryAsync();
        connection.Close();
    }
}
