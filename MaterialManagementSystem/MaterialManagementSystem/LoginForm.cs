using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginEmpID_txt.Text == "" || LoginEmpPassword_txt.Text == "")
            {
                MessageBox.Show("帳號或密碼不可為空");
            }
            else
            {
                int EmpID = Convert.ToInt32(LoginEmpID_txt.Text.Trim());
                string EmpPwd = LoginEmpPassword_txt.Text.Trim();

                Employee empinfo = EmployeeUtility.FindEmployeeByIDandPassword(EmpID, EmpPwd);
                if (empinfo != null)
                {
                    LoginInfo.EmpID = empinfo.EmployeeID;
                    LoginInfo.Name = empinfo.Name;
                    LoginInfo.Authority = empinfo.Authority;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("帳號或密碼輸入錯誤");
                }
            }
        }

        private void LoginEmpID_txt_TextChanged(object sender, EventArgs e)
        {
            if (LoginEmpID_txt.Text != "")
            {
                loginidword_lab.Visible = false;
            }
            else
            {
                loginidword_lab.Visible = true;
            }
        }

        private void LoginEmpPassword_txt_TextChanged(object sender, EventArgs e)
        {
            if (LoginEmpPassword_txt.Text != "")
            {
                loginpwword_lab.Visible = false;
            }
            else
            {
                loginpwword_lab.Visible = true;
            }
        }
    }
}
