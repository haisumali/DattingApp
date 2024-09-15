using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controller;

[ApiController]
[Route("api/{controller}")]// controller ka name single rehna chaiye
 // api/users

public class UsersController(DataContext context) : ControllerBase //UserController ka name singluar hona chaiye plural nhi
{


    [HttpGet]
    // api/users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();



        return users;
    }

// api/users/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null) return NotFound();

        return user;
    }
}
