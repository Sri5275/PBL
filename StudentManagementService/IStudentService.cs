using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementService
{
    public interface IStudentService
    {
        public Task<List<StudentClass>> GetAllStudents();
        public Task<StudentClass> GetByStudentId(int id);
        public Task<int> InsertStudent(StudentClass student);
        public Task<bool> UpdateStudent(StudentClass student);
        public Task<bool> DeleteStudent(int id);

        public Task<List<StudentClass2>> GetAllStudentData();

    }
}
