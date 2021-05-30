using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Models.Practice
{
    public class BestPractice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
