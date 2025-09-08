using System;
using Domain.Entities;
using Infrastructure.APIResponces;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/user")]
public class UserController
{
    private readonly IUserService userService = new UserService();

    [HttpPost]
    public async Task<Responce<string>> CreateUser(User user)
    {
        return await userService.CreateUser(user);
    }

    [HttpGet]
    public async Task<Responce<List<User>>> GetUsers()
    {
        return await userService.GetUsers();
    }

    [HttpPut]
    public async Task<Responce<string>> UpdateUser(User user)
    {
        return await userService.UpdateUser(user);
    }

    [HttpDelete("{id}")]
    public async Task<Responce<string>> DeleteUser(int id)
    {
        return await userService.DeleteUser(id);
    }
}
