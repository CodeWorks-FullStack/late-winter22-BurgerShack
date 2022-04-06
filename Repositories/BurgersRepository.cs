using System.Collections.Generic;
using System.Data;
using System.Linq;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class BurgersRepository
  {
    private readonly IDbConnection _db;

    public BurgersRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Burger> Get()
    {
      string sql = "SELECT * FROM burgers;";
      return _db.Query<Burger>(sql).ToList();
    }
    internal Burger Get(int id)
    {
      // the '@' allows dapper to inject an object and its properties
      // the '@' is used in place of the object and properties can be accessed from it
      string sql = "SELECT * FROM burgers WHERE id = @id;";
      return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }

    internal Burger Create(Burger burgerData)
    {
      string sql = @"
        INSERT INTO burgers
        (name, description, price)
        VALUES
        (@Name, @Description, @Price);
        SELECT LAST_INSERT_ID();";
      // ^^ this method returns the ID of the last object created;
      // vv This runs Two Command sequentially
      int id = _db.ExecuteScalar<int>(sql, burgerData);
      burgerData.Id = id;
      return burgerData;
    }

    internal void Update(Burger original)
    {
      string sql = @"
      UPDATE burgers
      SET
       description = @Description,
       name = @Name,
       price = @Price
      WHERE id = @Id;";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM burgers WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}