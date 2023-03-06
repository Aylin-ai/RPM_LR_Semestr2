﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        [Unique]
        public string Login { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public User(string login, string password, string dateOfBirth, string telephonenumber,
            string email, string role)
        {
            Id = App.DB.GetCount(0) + 1;
            Login = login;
            Password = password;
            DateOfBirth = dateOfBirth;
            TelephoneNumber = telephonenumber;
            Email = email;
            Role = role;
        }
        public User() { }
    }
}
