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
    public partial class StudentAddorEdit : Form
    {
        private readonly StudManager studentManager;
        private readonly Student studentToUpdate;
        public StudentAddorEdit(StudManager manager, Student student = null)
        {
            InitializeComponent();
            studentManager = manager;
            studentToUpdate = student;
            if (studentToUpdate != null)
            {
                // If studentToUpdate is not null, it means we are editing an existing student record
                lbltitle.Text = "Edit Student";
                btn_AddorEdit.Text = "Save Changes";
                PopulateFields();
            }
            else
            {
                // If studentToUpdate is null, it means we are adding a new student record
                lbltitle.Text = "Add Student";
                btn_AddorEdit.Text = "Add Student";
            }
        }

        private void PopulateFields()
        {
            if (studentToUpdate != null)
            {
                txtstdid.Text = studentToUpdate.StudentID.ToString();
                txtfname.Text = studentToUpdate.FirstName;
                txtlname.Text = studentToUpdate.LastName;
                txtage.Text = studentToUpdate.Age.ToString();
                txtgender.Text = studentToUpdate.Gender;
                txtclassname.Text = studentToUpdate.ClassName;
                txtgrade.Text = studentToUpdate.Grade.ToString();
            }
        }


        private void btn_AddorEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            // Create or update student object
            Student student = new Student
            {
                StudentID = int.Parse(txtstdid.Text),
                FirstName = txtfname.Text,
                LastName = txtlname.Text,
                Age = int.Parse(txtage.Text),
                Gender = txtgender.Text,
                ClassName = txtclassname.Text,
                Grade = double.Parse(txtgrade.Text)
            };

            // Add or update student record
            if (studentToUpdate != null)
            {
                // Update existing student record
                if (studentManager.UpdateStudent(student))
                {
                    MessageBox.Show("Student record updated successfully!");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update student record. Please try again.");
                }
            }
            else
            {
                // Add new student record
                if (studentManager.AddStudent(student))
                {
                    MessageBox.Show("Student added successfully!");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add student. Please try again.");
                }
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtfname.Text) &&
                 !string.IsNullOrWhiteSpace(txtlname.Text) &&
                 !string.IsNullOrWhiteSpace(txtage.Text) &&
                 !string.IsNullOrWhiteSpace(txtgender.Text) &&
                 !string.IsNullOrWhiteSpace(txtclassname.Text) &&
                 !string.IsNullOrWhiteSpace(txtgrade.Text))
            {
                MessageBox.Show("Please Fill all filed");
                return false;
            }
            if (!int.TryParse(txtstdid.Text, out int studentID) || studentID <= 0)
            {
                MessageBox.Show("Please enter a valid student ID.");
                return false;
            }


            if (!int.TryParse(txtage.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Please enter a valid age.");
                return false;
            }

            if (studentToUpdate == null && studentManager.GetStudents().Any(s => s.StudentID == studentID || s.FirstName == txtfname.Text))
            {
                MessageBox.Show("A student already exists.");
                return false;
            }
            if (!double.TryParse(txtgrade.Text, out double grade) || grade < 0 || grade > 100)
            {
                MessageBox.Show("Please enter a valid grade between 0 and 100.");
                return false;
            }
          
            return true;
        }

        private void StudentAddorEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
