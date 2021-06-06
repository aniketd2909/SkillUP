using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Context;
using PreLearningBackend.Models.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Practice
{
    public class McqService : IMcqService
    {
        private readonly AppDbContext _context;

        public McqService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddQuestion(CompleteQuestion completeQuestion)
        {
            await _context.Questions.AddAsync(completeQuestion.Question);
            await _context.SaveChangesAsync();
            foreach (Option option in completeQuestion.Options)
            {
                option.QuestionId = completeQuestion.Question.Id;
                await _context.Options.AddAsync(option);
            }
            await _context.SaveChangesAsync();
            completeQuestion.Answer.QuestionId = completeQuestion.Question.Id;
            await _context.Answers.AddAsync(completeQuestion.Answer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteQuestion(int id)
        {
            Question question = await _context.Questions.FindAsync(id);
            if (question is null)
                return false;
            Answer answer = await _context.Answers.SingleOrDefaultAsync(a => a.QuestionId == id);
            _context.Answers.Remove(answer);

            var options = _context.Options.Where(o => o.QuestionId == id).ToList();
            foreach (Option option in options)
                _context.Options.Remove(option);

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
            throw new NotImplementedException();
        }

        public async Task<CompleteQuestion> GetQuestionById(int id)
        {
            CompleteQuestion completeQuestion = new();
            completeQuestion.Question = await _context.Questions.FindAsync(id);
            var options = _context.Options.Where(o => o.QuestionId == id).ToList();
            completeQuestion.Options = options;
            return completeQuestion;
            throw new NotImplementedException();
        }

        public async Task<List<Question>> GetQuestionIds()
        {
            var questions = await _context.Questions.ToListAsync();
            return questions;
        }


        public async Task<bool> SubmitAnswer(int id, AnswerResource answerResource)
        {
            Answer answer = await _context.Answers.SingleOrDefaultAsync(a => a.QuestionId == id);
            if (answerResource.OptionId == answer.OptionId)
                return true;
            return false;
            throw new NotImplementedException();
        }
    }
}
