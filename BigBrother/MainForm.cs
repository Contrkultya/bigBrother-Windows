﻿using System;
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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Automation;
using Newtonsoft.Json;
using Firebase.Database.Query;

namespace BigBrother
{

    public partial class MainForm : MaterialForm
    {

        public FirebaseAuthLink AuthLink { get; set; }
        public FirebaseClient Firebase { get; set; }
        public MainForm()
        {
            InitializeComponent();
            
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

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
                AuthLink = loginForm.auth;
                Firebase = loginForm.firebase;
                ContinueAfterLogin();
                loginForm.Dispose();
            }
            else
            {
                MessageBox.Show("Fuck you");
                loginForm.Dispose();
                Process.GetCurrentProcess().Kill();
            }
        }
        public void ContinueAfterLogin()
        {
            userGreetLabel.Text = "Добро пожаловать, " + AuthLink.User.Email;
           

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            AutomationFocusChangedEventHandler focusHandler = OnFocusChanged;
            Automation.AddAutomationFocusChangedEventHandler(focusHandler);
            if (ActivityLog.Count > 0)
            {
               foreach (appLog log in ActivityLog) log.makeTime();
                richTextBox1.Text = JsonConvert.SerializeObject(ActivityLog, Formatting.Indented);
                sendShitToFirebase();
            }
        }
        private async void sendShitToFirebase() {
            await Firebase
                .Child("users")
                .Child("1")
                .Child("logs")
                .Child("1")
                .PutAsync(JsonConvert.SerializeObject(ActivityLog, Formatting.Indented));
        }
        private List<appLog> ActivityLog = new List<appLog>();

        private void OnFocusChanged(object sender, AutomationFocusChangedEventArgs e)
        {
            if (ActivityLog.Count > 0)foreach (appLog log in ActivityLog) log.StopStopwatch();
            AutomationElement focusedElement = sender as AutomationElement;
            if (focusedElement != null)
            {
                
                int processId = focusedElement.Current.ProcessId ;
                using (Process process = Process.GetProcessById(processId))
                {
                    if (ActivityLog.Count > 0)
                    {
                        bool goingFurther = true;
                        foreach (appLog log in ActivityLog.ToArray())
                        {
                            if (log.name == process.ProcessName)
                            {
                                log.StartStopwatch();
                                goingFurther = false;
                            }
                        }
                        if (goingFurther) {
                            appLog newAppLog = new appLog(process.ProcessName);
                            ActivityLog.Add(newAppLog);
                        }
                    }
                    else
                    {
                        appLog newAppLog = new appLog(process.ProcessName);
                        ActivityLog.Add(newAppLog);
                    }
                }
            }
        }

    }
}
