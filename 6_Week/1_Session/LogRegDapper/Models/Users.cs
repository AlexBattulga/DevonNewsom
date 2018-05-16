using System;
using System.ComponentModel.DataAnnotations;

namespace LoginReg.Models
{
    public class RegisterUser
    {
        [Required]
        public string FirstName {get;set;}
        [Required]
        
        public string LastName {get;set;}
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        
        public string Password {get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public DateTime CreatedAt {get;set;}
        public string ConfirmPass {get;set;}
        
    }
    public class LogUser
    {
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}
    }
}