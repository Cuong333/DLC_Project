using DLC_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DLC_Project.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "First name is required")]
        public string Firstname { get; set; } = null!;

        public string? Lastname { get; set; }

        public DateOnly? Birthday { get; set; }

        public byte? Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;

        [Phone(ErrorMessage = "Invalid phone number format")]
        public string? Phonenumber { get; set; }

        public string? Address { get; set; }

        public string? Photo { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}