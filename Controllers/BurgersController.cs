using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BurgersController : ControllerBase
  {
    private readonly BurgersService _bs;

    public BurgersController(BurgersService bs)
    {
      _bs = bs;
    }

    // GetAll
    [HttpGet]
    public ActionResult<List<Burger>> Get()
    {
      try
      {
        List<Burger> burgers = _bs.Get();
        return Ok(burgers);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GetById
    [HttpGet("{id}")]
    public ActionResult<Burger> Get(int id)
    {
      try
      {
        Burger burger = _bs.Get(id);
        return Ok(burger);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Post
    [HttpPost]
    public ActionResult<Burger> Create([FromBody] Burger burgerData)
    {
      try
      {
        Burger burger = _bs.Create(burgerData);
        // return Ok(burger);
        return Created($"api/burgers/{burger.Id}", burger);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Put
    [HttpPut("{id}")]
    public ActionResult<Burger> Update(int id, [FromBody] Burger burgerData)
    {
      try
      {
        burgerData.Id = id;
        Burger burger = _bs.Update(burgerData);
        return Ok(burger);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Delete
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        _bs.Delete(id);
        return Ok("Delorted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}