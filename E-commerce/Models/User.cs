﻿using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
     public abstract class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ProfilePicture { get; set; }

        public DateTime? AccCreationDate { get; set; }
    }
}
