using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class StudFileManager
    {
        private const string FilePath = "C:\\Users\\PARTHU\\OneDrive\\Desktop\\c#Assignment-3\\Student.txt";

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    Student student = new Student
                    {
                        StudentID = int.Parse(parts[0]),
                        FirstName = parts[1],
                        LastName = parts[2],
                        Age = int.Parse(parts[3]),
                        Gender = parts[4],
                        ClassName = parts[5],
                        Grade = double.Parse(parts[6])
                    };
                    students.Add(student);
                }
            }
            catch (Exception)
            {
                // Handle file read error
            }
            return students;
        }

        public bool AddStudent(Student student)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(FilePath))
                {
                    writer.WriteLine($"{student.StudentID},{student.FirstName},{student.LastName},{student.Age},{student.Gender},{student.ClassName},{student.Grade}\n");
                }
                return true;
            }
            catch (Exception)
            {
               
                return false;
            }
        }

        public bool UpdateStudent(Student student)
        {
            List<Student> students = GetStudents();
            Student existingStudent = students.FirstOrDefault(s => s.StudentID == student.StudentID);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Age = student.Age;
                existingStudent.Gender = student.Gender;
                existingStudent.ClassName = student.ClassName;
                existingStudent.Grade = student.Grade;

                try
                {
                    File.WriteAllLines(FilePath, students.Select(s => $"{s.StudentID},{s.FirstName},{s.LastName},{s.Age},{s.Gender},{s.ClassName},{s.Grade}"));
                    return true;
                }
                catch (Exception)
                {
                    // Handle file write error
                    return false;
                }
            }
            return false;
        }

        public bool DeleteStudent(Student student)
        {
            List<Student> students = GetStudents();
            Student existingStudent = students.FirstOrDefault(s => s.StudentID == student.StudentID);
            if (existingStudent != null)
            {
                students.Remove(existingStudent);
                try
                {
                    File.WriteAllLines(FilePath, students.Select(s => $"{s.StudentID},{s.FirstName},{s.LastName},{s.Age},{s.Gender},{s.ClassName},{s.Grade}"));
                    return true;
                }
                catch (Exception)
                {
                    // Handle file write error
                    return false;
                }
            }
            return false;
        }
    }
}
