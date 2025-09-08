using System;
using Domain.Entities;
using Infrastructure.APIResponces;

namespace Infrastructure.Interfaces;

public interface IUserService
{
    Task<Responce<List<User>>> GetUsers();
    Task<Responce<User>> GetById(int id);

    Task<Responce<string>> CreateUser(User user);
    Task<Responce<string>> UpdateUser(User user);
    Task<Responce<string>> DeleteUser(int id);
}
