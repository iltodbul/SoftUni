﻿using System.ComponentModel.DataAnnotations;
using SULS.Services;
using SULS.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        // GET /users/login
        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            //if (this.IsUserSignedIn())
            //{
            //    return this.Redirect("/");
            //}

            var userId = this.usersService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Error("Invalid username or password");
            }

            this.SignIn(userId);
            return this.Redirect("/");
        }

        // GET /users/register
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {

            if (string.IsNullOrEmpty(input.Username)
                || input.Username.Length < 5
                || input.Username.Length > 20)
            {
                return this.Error("Invalid username. The username should be between 5 and 20 characters.");
            }

            if (string.IsNullOrWhiteSpace(input.Email)
                || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email.");
            }

            if (string.IsNullOrEmpty(input.Password)
                || input.Password.Length < 6
                || input.Password.Length > 20)
            {
                return this.Error("Invalid password. The password should be between 6 and 20 characters.");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords should be the same.");
            }

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error("Username already taken.");
            }

            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error("Email already taken.");
            }

            this.usersService.Create(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            this.SignOut();
            return this.Redirect("/");

        }
    }
}

