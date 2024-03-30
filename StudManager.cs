using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class StudManager
    {
        private readonly StudFileManager sfm;

        public StudManager()
        {
            sfm = new StudFileManager();
        }

        public List<Student> GetStudents()
        {
            return sfm.GetStudents();
        }

        public bool AddStudent(Student student)
        {
            return sfm.AddStudent(student);
        }

        public bool UpdateStudent(Student student)
        {
            return sfm.UpdateStudent(student);
        }

        public bool DeleteStudent(Student student)
        {
            return sfm.DeleteStudent(student);
        }
    }
}
