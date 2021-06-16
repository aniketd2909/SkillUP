using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using PreLearningBackend.Context;
using PreLearningBackend.Models.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.User
{
    public class SelectedUserService : ISelectedUserService
    {
        private readonly AppDbContext _context;
        public SelectedUserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUser(IFormFile file)
        
        {
           
            using (var stream = new MemoryStream())
            {
                if (file.FileName.EndsWith(".xlsx"))
                {

                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            await _context.SelectedUsers.AddAsync(new SelectedUser
                            {
                                //Id = (int)worksheet.Cells[row, 1].Value,
                                EmailId = worksheet.Cells[row, 1].Value.ToString().Trim()
                            });
                        }
                    }
                }
                else
                {
                    //throw new Exception("This file format is not supported");
                    return false;
                }
            }
           
            int check = await  _context.SaveChangesAsync();
            if (check > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async  Task<bool> DeleteUser(int Id)
        {
            bool flag = true;
            SelectedUser user = await _context.SelectedUsers.FindAsync(Id);
            if (user == null)
            {
                throw new UserNotFoundException("Selected User Not Present To Delete");
            }
            else
            {
                _context.SelectedUsers.Remove(user);
                int check =  await _context.SaveChangesAsync();
                if (check <= 0)
                {
                    flag = false;
                }

            }
            return flag;

        }

        public async Task<SelectedUser> GetUserById(int Id)
        {
            SelectedUser user = await _context.SelectedUsers.FindAsync(Id);
            if (user == null)
            {
                throw new UserNotFoundException("User Not Found");
            }
            else
            {
                return user;
            }
        }

        public async Task<bool> UpdateUser(SelectedUser selectedUser)
        {

            _context.SelectedUsers.Update(selectedUser);
            int check = await _context.SaveChangesAsync();
            if (check > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
