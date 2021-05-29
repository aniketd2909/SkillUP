using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Models.Blocker
{
    public class BlockerSolution
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string Solution { get; set; }

        public DateTime PostedAt { get; set; }

        [Required]
        [ForeignKey("Blocker")]
        public int BlockerId { get; set; }

        public Blocker Blocker { get; set; }


    }
}
