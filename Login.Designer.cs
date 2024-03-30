namespace Assignment3
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_login = new Button();
            txtpass = new TextBox();
            txtuser = new TextBox();
            lblPass = new Label();
            lblusername = new Label();
            lbltitle = new Label();
            SuspendLayout();
            // 
            // btn_login
            // 
            btn_login.Location = new Point(253, 264);
            btn_login.Margin = new Padding(2, 2, 2, 2);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(112, 45);
            btn_login.TabIndex = 11;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // txtpass
            // 
            txtpass.Location = new Point(320, 183);
            txtpass.Margin = new Padding(2, 2, 2, 2);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(121, 27);
            txtpass.TabIndex = 10;
            // 
            // txtuser
            // 
            txtuser.Location = new Point(320, 123);
            txtuser.Margin = new Padding(2, 2, 2, 2);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(121, 27);
            txtuser.TabIndex = 9;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(210, 188);
            lblPass.Margin = new Padding(2, 0, 2, 0);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(73, 20);
            lblPass.TabIndex = 8;
            lblPass.Text = "Password:";
            // 
            // lblusername
            // 
            lblusername.AutoSize = true;
            lblusername.Location = new Point(201, 120);
            lblusername.Margin = new Padding(2, 0, 2, 0);
            lblusername.Name = "lblusername";
            lblusername.Size = new Size(85, 20);
            lblusername.TabIndex = 7;
            lblusername.Text = "User Name:";
            // 
            // lbltitle
            // 
            lbltitle.AutoSize = true;
            lbltitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbltitle.Location = new Point(264, 42);
            lbltitle.Margin = new Padding(2, 0, 2, 0);
            lbltitle.Name = "lbltitle";
            lbltitle.Size = new Size(105, 41);
            lbltitle.TabIndex = 6;
            lbltitle.Text = "LOGIN";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(btn_login);
            Controls.Add(txtpass);
            Controls.Add(txtuser);
            Controls.Add(lblPass);
            Controls.Add(lblusername);
            Controls.Add(lbltitle);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_login;
        private TextBox txtpass;
        private TextBox txtuser;
        private Label lblPass;
        private Label lblusername;
        private Label lbltitle;
    }
}