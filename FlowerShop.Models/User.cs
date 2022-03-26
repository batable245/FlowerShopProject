using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FlowerShop.Models
{
    public class User
    {
        [Required, Key]
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }

        [Required, MaxLength(40)]
        public string Username { get; set; }

        [Required, MinLength(4)]
        public string Password { get; set; }
        public double Balance { get; set; }


    }

}
