using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLRepository
{
    public interface IStudentData
    {
        Task<List<StudentClass>> GetAllStudentsAsync();
        Task<StudentClass> GetByStudentIdAsync(int id);
        Task<bool> UpdateStudentAsync(StudentClass student);
        Task<int> InsertStudentAsync(StudentClass student);
        Task<bool> DeleteStudentAsync(int id);
        Task<List<StudentClass2>> GetAllStudentDataAsync();
    }
}
