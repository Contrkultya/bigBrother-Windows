using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Firebase.Auth;
using Firebase.Database;

namespace BigBrother
{
    public partial class MainForm : MaterialForm
    {
        public FirebaseAuthLink authLink { get; set; }
        public FirebaseClient firebase { get; set; }
        public MainForm()
        {
            InitializeComponent();
            
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red400, Primary.Red500,
                Primary.Red500, Accent.Red200,
                TextShade.WHITE
            );
        }
        private void Form_Closing(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            if (loginForm.ShowDialog(this) == DialogResult.OK)
            {
                authLink = loginForm.auth;
                firebase = loginForm.firebase;
                ContinueAfterLogin();
            }
            else
            {
                MessageBox.Show("Fuck you");
                ActiveForm.Close();
            }
            loginForm.Dispose();
        }
        public void ContinueAfterLogin() { 
            userGreetLabel.Text = "Добро пожаловать, " + authLink.User.Email;
        }
    }
}
