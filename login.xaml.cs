using System;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Interop;

namespace Mymoniter
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        string mainAppData; 
        public login()
        {
            InitializeComponent();

           StringBuilder sb = new StringBuilder();
           sb.Append("prakki");
            for (int i = 0; i < 10; i++)
            {
                sb.Append("prakki");
            }
            MessageBox.Show(sb.ToString());

            object num = 10;
            num = "Welcome";

            if(num is int)
            {
                int num1 = Convert.ToInt32(num);
            }
            if(num is string) // what is type
            {
                string num1 = Convert.ToString(num);
            }
            int k = 123;
            num = k;

            //dynamic 

        


            mainAppData = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            mainAppData = Path.Combine(mainAppData, "MyMoniter");

            if (!Directory.Exists(mainAppData))
            {
                Directory.CreateDirectory(mainAppData);
            }
        }
        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            //  string welcome = "Hi Mr" + txtuser.Text + " Welcome to" + pwpassword.Password;
            string welcome = string.Format("Hi Mr{0} Welcome to {1}", txtuser.Text, pwpassword.Password);
            MessageBox.Show(welcome);
            if (!string.IsNullOrWhiteSpace(txtuser.Text))
            {
                string filename = Path.Combine(mainAppData, txtuser.Text + ".txt");
                if (File.Exists(filename))
                {
                    string content = File.ReadAllText(filename);
                    string[] splitcontent = content.Split("|");
                    if (splitcontent[0] == txtuser.Text && splitcontent[1] == pwpassword.Password) 
                    {
                        MessageBox.Show("Login Success");
                    }
                    else
                    {
                        MessageBox.Show(".Invalid username and password");
                    }
                }
                else
                {
                    MessageBox.Show("Login Success");
                }
            }
        }
        private void btnreg_Click(object sender, RoutedEventArgs e)
        {

            string username = txtreguser.Text.Trim();
            string password = pwregpassword.Password;
            string age = txtage.Text.Trim();
            string email = txtemail.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                erroruser.Text = "Please enter username";
                return;
            }
            else
            {
                erroruser.Text = "";
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                erroruser.Text = "Please enter password";
                return;
            }
            else
            {
                erroruser.Text = "";
            }
            if (string.IsNullOrWhiteSpace(age))
            {
                erroruser.Text = "Please enter age";
                return;
            }
            else
            {
                erroruser.Text = "";
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                erroruser.Text = "Please enter email";
                return;
            }
            else
            {
                erroruser.Text = "";
            }
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(age) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Invalid username and password.");
                return;
            }

            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Mymoniter");
            Directory.CreateDirectory(folder);

            string filename = Path.Combine(folder, username + ".txt");

            if (File.Exists(filename))
            {
                MessageBox.Show("Username already exists.");
                return;
            }

            string content = username + "|" + password + "|" + age + "|" + email;

            File.WriteAllText(filename, content);

            MessageBox.Show("Register Success!");

            txtreguser.Clear();
            pwregpassword.Clear();
            txtage.Clear();
            txtemail.Clear();
        }
    
    
    }
}



      
