using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{
  public class BurgersService
  {
    private readonly BurgersRepository _repo;

    public BurgersService(BurgersRepository repo)
    {
      _repo = repo;
    }

    internal List<Burger> Get()
    {
      return _repo.Get();
    }

    internal Burger Get(int id)
    {
      Burger found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Burger Create(Burger burgerData)
    {
      return _repo.Create(burgerData);
    }

    internal Burger Update(Burger burgerData)
    {
      Burger original = Get(burgerData.Id);
      original.Description = burgerData.Description ?? original.Description;
      original.Price = burgerData.Price;
      original.Name = burgerData.Name ?? original.Name;
      _repo.Update(original);
      return original;
    }

    internal void Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
    }
  }
}