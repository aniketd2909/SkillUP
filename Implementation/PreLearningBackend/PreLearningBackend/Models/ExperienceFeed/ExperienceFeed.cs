using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Models.ExperienceFeed
{
    public class ExperienceFeed
    {
        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "text")]
        public string Comment { get; set; }

        public DateTime PostedAt { get; set; }
    }
}
