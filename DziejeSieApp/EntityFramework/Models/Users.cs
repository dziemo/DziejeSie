﻿using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace EntityFramework.Models
{

    public class Users
    {
        [Key]
        [Required]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "Login jest wymagany")]
        [MinLength(10)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is required")]

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please confirm your password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public void PasswordHash()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(Password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            Password = Convert.ToBase64String(hashBytes);

        }

        public Boolean VerifyUser(string _passwordHash)
        {
            byte[] _hashBytes = Convert.FromBase64String(_passwordHash);
            byte[] _salt = new byte[16];
            Array.Copy(_hashBytes, 0, _salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(Password, _salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (_hashBytes[i + 16] != hash[i])
                    return false;


            return true;
        }


    }
}