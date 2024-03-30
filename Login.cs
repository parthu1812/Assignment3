using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class Login : Form
    {
        private readonly Authmanager authenticationManager;
        public Login()
        {
            InitializeComponent();
            authenticationManager = new Authmanager();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text;
            string password = txtpass.Text;

            if (!ValidateInput())
            {
                return;
            }

            if (authenticationManager.AuthenticateUser(username, password))
            {
                MessageBox.Show("Login successful!");

                this.Close();
                Form std = new StudenttHome();
                std.ShowDialog();
                // Proceed to main application logic
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtpass.Text) ||
                 string.IsNullOrWhiteSpace(txtuser.Text))

            {
                MessageBox.Show("Please Fill all filed");
                return false;
            }


            return true;
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
