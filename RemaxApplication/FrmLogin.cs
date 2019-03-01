using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemaxApplication
{
   
    public partial class FrmLogin : MetroFramework.Forms.MetroForm
    {

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmLogin2 frmlogin2 = new FrmLogin2();
            frmlogin2.Show();
            this.Hide();
        }

        public void pictureBox2_Click(object sender, EventArgs e)
        {        
            FrmMain frm = new FrmMain();
            frm.Show();
            this.Hide();
            
        }
       
    }
}

    
