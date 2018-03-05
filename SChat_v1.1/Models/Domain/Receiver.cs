using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SChat.Models.Domain
{
    public class Receiver
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}