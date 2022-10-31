using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PP.Domain.DatabaseFirstPattern;
using PP.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Domain.DAL.Implementations;

public abstract class BaseRepository<T> where T : EntityBase
{
    protected IList<T> entities;
    protected PassportPointDbContext context;
    protected string connectionString = "Server=DESKTOP-T6L0BBU;Database=PassportPointDb;Trusted_Connection=True;";

    public BaseRepository()
    {
        context = new PassportPointDbContext();
        entities = new List<T>();
    }

    public virtual async Task<IList<T>> GetAll()
    {
        context = new PassportPointDbContext();
        return await context.Set<T>().AsNoTracking().ToListAsync();
    }
    
    public virtual async Task<T> Get(int id)
    {
        context = new PassportPointDbContext();
        return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task Update(T entity)
    {
        context = new PassportPointDbContext();
        var result = context.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
        if (result != null)
        {
            context.Update(entity);
        }
        await context.SaveChangesAsync();
    }

    public virtual async Task Delete(int id)
    {
        context = new PassportPointDbContext();
        var entity = context.Set<T>().FirstOrDefault(x => x.Id == id);
        if (entity != null)
        {
            context.Remove(entity);
        }
        await context.SaveChangesAsync();
    }

    public virtual async Task Create(T entity)
    {
        context = new PassportPointDbContext();
        context.Add(entity);
        await context.SaveChangesAsync();
    }

    public void SaveAll()
    {
        
    }

    public void ReadAll()
    {
    }
}
