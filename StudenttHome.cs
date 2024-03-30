using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class StudenttHome : Form
    {
        private readonly StudManager studentManager;
        private List<Student> allStudents;
        public StudenttHome()
        {
            InitializeComponent();
            studentManager = new StudManager();
            LoadStudents();
        }

        private void LoadStudents()
        {
            allStudents = studentManager.GetStudents();
            dgv_student.DataSource = allStudents;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StudentAddorEdit addoredit = new StudentAddorEdit(studentManager);
            addoredit.ShowDialog();
            LoadStudents();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_student.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            // Get the selected student
            Student student = (Student)dgv_student.SelectedRows[0].DataBoundItem;

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Delete the student
                studentManager.DeleteStudent(student);
                LoadStudents(); // Reload data after deletion
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgv_student.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to edit.");
                return;
            }

            // Get the selected student
            Student student = (Student)dgv_student.SelectedRows[0].DataBoundItem;

            // Open EditStudentForm for editing
            StudentAddorEdit editStudentForm = new StudentAddorEdit(studentManager, student);
            editStudentForm.ShowDialog();
            LoadStudents();
        }

        private void StudenttHome_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtsearch.Text.ToLower().Trim();
            List<Student> filteredStudents = new List<Student>();

            if (!string.IsNullOrEmpty(query))
            {
                // Search by ID, firstname, or lastname using LINQ
                filteredStudents = allStudents.Where(student =>
                    student.StudentID.ToString().Contains(query) ||
                    student.FirstName.ToLower().Contains(query) ||
                    student.LastName.ToLower().Contains(query)
                ).ToList();
            }
            else
            {
                // If search query is empty, show all students
                filteredStudents = allStudents;
            }

            dgv_student.DataSource = filteredStudents;
        }
    }
}
