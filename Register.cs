
namespace Assignment3
{
    public partial class Register : Form
    {
        private readonly Authmanager authenticationManager;
        public Register()
        {
            InitializeComponent();
            authenticationManager = new Authmanager();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text;
            string password = txtpass.Text;
            if (!ValidateInput())
            {
                return;
            }

            if (authenticationManager.RegisterUser(username, password))
            {
                MessageBox.Show("User registered successfully!");
                
                Form login = new Login();
                login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Failed to register user. Please try again.");
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

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
            Form login = new Login();
            login.ShowDialog();
        }
    }
}
