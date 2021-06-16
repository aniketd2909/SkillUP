using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Models.User
{
    public class SelectedUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmailId { get; set; }
    }
}
