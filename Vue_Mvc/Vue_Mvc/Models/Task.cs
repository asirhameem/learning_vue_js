using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vue_Mvc.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string TaskName { get; set; }

        [Required]
        public string TaskDeadline { get; set; }

        public string TaskStatus { get; set; }
    }
}
