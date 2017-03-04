using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataLayer.Entities
{
    public enum Roll
    {
        Player = 0,
        Admin = 1
    }

    public class User
    {
    

        [Key]
        public int Id { get; set; }
        public Roll Roll { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }

        // Lazy loadig Properties
        public virtual List<Question> Questions { get; set; }
    }
}