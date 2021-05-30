using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Models.Blocker
{
    public class Blocker
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<ExperieneFeed> BlockerSolutions { get; set; }


    }
}
