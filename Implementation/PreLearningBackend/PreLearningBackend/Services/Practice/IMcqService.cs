using PreLearningBackend.Models.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Practice
{
    public interface IMcqService
    {
        Task<bool> AddQuestion(CompleteQuestion completeQuestion);
        Task<bool> DeleteQuestion(int id);
        Task<CompleteQuestion> GetQuestionById(int id);
        Task<bool> SubmitAnswer(int id, AnswerResource answerResource);
    }
}
