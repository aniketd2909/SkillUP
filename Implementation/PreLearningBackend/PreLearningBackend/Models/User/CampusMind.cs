﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Models.User
{
    public class CampusMind
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string EngineeringBranch { get; set; }

        [ForeignKey("Mind")]
        public int MindId { get; set; }
        public Mind Mind { get; set; }
    }
}
