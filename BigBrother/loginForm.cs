using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using MaterialSkin;
using MaterialSkin.Controls;
using Firebase.Auth;
using Firebase.Database;

namespace BigBrother
{
    public partial class LoginForm : MaterialForm
    {
        public FirebaseClient firebase { get; private set; }
        public FirebaseAuthLink auth { get; private set; }
        public LoginForm()
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
        
        public bool IsValidMail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private async void initFirebase(string action) {
            var email = emailField.Text;
            var password = passwordField.Text;
            if (IsValidMail(email) && password.Length >= 6)
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyDOZxvEjrGF2CC5d99aPETZXKGLgRHaKAg"));
                if (action == "login")
                {
                    auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                }
                else auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password); ;

                firebase = new FirebaseClient(
                  "https://bigbrother-ab109.firebaseio.com",
                  new FirebaseOptions
                  {
                      AuthTokenAsyncFactory = () => Task.FromResult(auth.FirebaseToken)
                  });
                if (auth.User.Email == email) {
                    this.DialogResult = DialogResult.OK;
                }

            }
            else MessageBox.Show("Invalid mail or password");
        }
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            initFirebase("login");
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            initFirebase("create");
        }
    }
}
