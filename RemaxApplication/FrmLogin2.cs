using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Dapper;

namespace RemaxApplication
{
    public partial class FrmLogin2 : MetroFramework.Forms.MetroForm
    {
        public FrmLogin2()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void FrmLogin2_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter your Username.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
            try
            {
                clsGlobal.myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\carlo\OneDrive\Documentos\Programming\C#\RemaxApplication3\RemaxApplication3\bin\Debug\data\RealStateDataBase.mdb");
                clsGlobal.myCon.Open();
                User obj = clsGlobal.myCon.Query<User>($"SELECT * FROM USERS WHERE Username = '{txtUserName.Text}'", commandType: CommandType.Text).SingleOrDefault();
                if (obj != null)
                {
                    if (obj.Password == txtPassword.Text)
                    {
                        using (FrmMain frmain = new FrmMain())
                        {
                            this.Hide();
                            frmain.ShowDialog();
                        }
                    }
                    else
                        MetroFramework.MetroMessageBox.Show(this, "Your Username and Password do not match", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MetroFramework.MetroMessageBox.Show(this, "Your Username and Password do not match", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }
    }
}
