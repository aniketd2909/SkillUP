﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Models.User
{
    public class Mind
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]

        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string ContactNo { get; set; }
        [Required]
        public string ProfilePicture { get; set; }
        [Required]
        [MaxLength(8)]

        public string Gender { get; set; }
        [Required]
        [MaxLength(16)]
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
