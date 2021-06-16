using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Models.Resource
{
    public class Topic
    {
        [Key]
        //its a key
        public int Id { get; set; }
        [StringLength(100)]

        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
        public ICollection<Resource> Resources { get; set; }
    }
}
