using System.Linq;
using AutoMapper;
using Console;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppi.Entities;
using WebAppi.Models;

namespace WebAppi.Sevices
{
    public class UserService(SuperDBContext superDBContext, IMapper mapper)
    {
        public async Task<JsonResult> AddUserAsync(AddUserDTO addUserDTO)
        {
            if (await superDBContext.SuperUsers.AnyAsync(x => x.Login == addUserDTO.Login))
                return new(new
                {
                    ErrorMessage = "Пользователь с таким логином уже существует"
                });

            var user = mapper.Map<UserDB>(addUserDTO);

            await superDBContext.SuperUsers.AddAsync(user);
            await superDBContext.SaveChangesAsync();

            return new(new
            {
                User = user,
            });
        }

        public async Task<JsonResult> AuthorizeUserAsync(AuthUserDTO authUserDTO)
        {
            var user = await superDBContext.SuperUsers
                .FirstOrDefaultAsync(x => x.Login == authUserDTO.Login);

            if (user == null)
            {
                return new(new
                {
                    ErrorMessage = "Такого пользователя не существует"
                });
            }

            if (user.Password != authUserDTO.Password) 
            {
                return new(new
                {
                    ErrorMessage = "Неверный пароль"
                });
            }

            return new(new
            {
                User = user
            });
        }
    }    
}
