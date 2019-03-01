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

namespace RemaxApplication
{
    public partial class FrmMain : MetroFramework.Forms.MetroForm
    {
        FrmEmployees employeesform = new FrmEmployees();
        FrmProperties propertiesform = new FrmProperties();
        FrmClient clientfrom = new FrmClient();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
            clsGlobal.myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\carlo\OneDrive\Documentos\Programming\C#\RemaxApplication3\RemaxApplication3\bin\Debug\data\RealStateDataBase.mdb");
            clsGlobal.myCon.Open();
        }

        private void metroTileClients_Click(object sender, EventArgs e)
        {
            clientfrom.MdiParent = this;
            propertiesform.Hide();
            employeesform.Hide();
            clientfrom.Show();        
        }

        private void metroTileEmployees_Click(object sender, EventArgs e)
        {
            employeesform.MdiParent = this;
            clientfrom.Hide();
            propertiesform.Hide();
            employeesform.Show();
        }

        private void metroTileProperty_Click(object sender, EventArgs e)
        {
            propertiesform.MdiParent = this;
            clientfrom.Hide();
            employeesform.Hide();
            propertiesform.Show();
        }

        private void metroTileHome_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to return to Login", "Confirmation?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                FrmLogin frmlogin1 = new FrmLogin();
                frmlogin1.Show();
                this.Close();
            }       
        }
    }
}
