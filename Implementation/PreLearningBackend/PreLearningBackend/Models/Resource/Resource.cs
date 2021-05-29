using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Models.Resource
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }


        [Column(TypeName = "text")]
        public string Link { get; set; }

        [ForeignKey("Topic")]
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
