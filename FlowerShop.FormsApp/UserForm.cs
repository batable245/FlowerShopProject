using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShop.FormsApp
{
    using FlowerShop.Models;
    using Services;
    public partial class UserForm : Form
    {
        public static User? user;
        internal MainService service = new MainService();
        public UserForm()
        {
            InitializeComponent();
        }

        public void NavigateToMainForm()
        {          
            //Its like this because normally it would close both of the forms
            this.Hide();
            var form2 = new MainForm();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;
            try
            {
                service.UserService.CreateUser(username, password, "100");
                MessageBox.Show("Registered new user!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;
            try
            {
                if (service.UserService.LogIn(username, password))
                {
                    //User user = service.UserService.GetUserByUsername(username);
                    user = service.UserService.GetUserByUsername(username);                   
                    MessageBox.Show("Login Successfull!");
                    NavigateToMainForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MainForm();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

    }
}
