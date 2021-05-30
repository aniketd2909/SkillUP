using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Models.Practice
{
    public class CompleteQuestion
    {
        public Question Question { get; set; }
        public List<Option> Options { get; set; }
        public Answer Answer { get; set; }
    }
}
