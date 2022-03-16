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

        internal MainService service = new MainService();
        public UserForm()
        {
            InitializeComponent();
        }
     

      

        private void signupButton_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            try
            {
            service.UserService.CreateUser(username, password, "100");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void signinButton_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (service.UserService.LogIn(username, password))
            {
                User user = service.UserService.GetUserByUsername(username);
                this.Hide();
                var form2 = new MainForm();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Invalid password");
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
