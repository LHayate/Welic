﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using Infra.Context;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Repositorios.Login
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(AspNetUser userDto)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userDto.NickName
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            try
            {
                var user = await _userManager.FindAsync(userName, password);

                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
