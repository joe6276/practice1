﻿using System.ComponentModel.DataAnnotations;

namespace ProductAPIDB.Models.DTOS
{
    public class RegisterUser
    {

        [Required]
        public string Name { get; set; }=string.Empty;


        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required]
        public string Password { get; set; } = string.Empty;


        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
