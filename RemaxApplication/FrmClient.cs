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
using System.IO;

namespace RemaxApplication
{
    public partial class FrmClient : MetroFramework.Forms.MetroForm
    {
        DataTable tabClient;
        DataRow myRow;
        int current = 0;
        string mode;

        public FrmClient()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            clsGlobal.mySet = new DataSet();
            clsGlobal.myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\carlo\OneDrive\Documentos\Programming\C#\RemaxApplication3\RemaxApplication3\bin\Debug\data\RealStateDataBase.mdb");
            clsGlobal.myCon.Open();
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM CLIENTS", clsGlobal.myCon);
            clsGlobal.adpClients = new OleDbDataAdapter(myCmd);
            clsGlobal.adpClients.Fill(clsGlobal.mySet, "CLIENTS");
            tabClient = clsGlobal.mySet.Tables["CLIENTS"];
            metroPanel1.Enabled = false;
            tab2txt();

            var ClientList = from DataRow mk in tabClient.Rows
                             select new { refC = mk.Field<Int32>("ClientNumber"), Number = mk.Field<int>("ClientNumber") };

            cbxSearchClient.DisplayMember = "number";
            cbxSearchClient.ValueMember = "clientNumber";
            cbxSearchClient.DataSource = ClientList.ToList();

            //OleDbCommand myCmd2 = new OleDbCommand("SELECT * FROM CLIENTS", clsGlobal.myCon);
            //OleDbDataReader myReader = myCmd2.ExecuteReader();
            //while (myReader.Read())
            //{
            //    cbxSearchClient.Items.Add(myReader["ClientNumber"].ToString());
            //}
            //myReader.Close();


            FillGrid();

        }
        private void tab2txt()
        {
            txtClientNumber.Text = tabClient.Rows[current]["ClientNumber"].ToString();
            txtClientName.Text = tabClient.Rows[current]["ClientName"].ToString();
            txtPhoneNumber.Text = tabClient.Rows[current]["PhoneNumber"].ToString();
            txtEmail.Text = tabClient.Rows[current]["Email"].ToString();
            txtAddress.Text = tabClient.Rows[current]["Address"].ToString();
            txtMinBudget.Text = tabClient.Rows[current]["MinBudget"].ToString();
            txtMaxBudget.Text = tabClient.Rows[current]["MaxBudget"].ToString();

        }
        private void tab2remove()
        {
            txtClientNumber.Clear();
            txtClientName.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtMinBudget.Clear();
            txtMaxBudget.Clear();       
            metroPanel1.Enabled = true;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            metroPanel1.Enabled = true;
            txtClientNumber.Focus();
            mode = "Edit";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            metroPanel1.Enabled = false;
            tab2txt();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode == "Edit")
            {
                myRow = tabClient.Rows[current];
                myRow["ClientNumber"] = txtClientNumber.Text;
                myRow["ClientName"] = txtClientName.Text;
                myRow["PhoneNumber"] = txtPhoneNumber.Text;
                myRow["Email"] = txtEmail.Text;
                myRow["Address"] = txtAddress.Text;
                myRow["MinBudget"] = txtMinBudget.Text;
                myRow["MaxBudget"] = txtMaxBudget.Text;
                MessageBox.Show("Record edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGrid();
            }
            else if (mode == "Add")
            {
                myRow = tabClient.NewRow();
                myRow["ClientNumber"] = txtClientNumber.Text;
                myRow["ClientName"] = txtClientName.Text;
                myRow["PhoneNumber"] = txtPhoneNumber.Text;
                myRow["Email"] = txtEmail.Text;
                myRow["Address"] = txtAddress.Text;
                myRow["MinBudget"] = txtMinBudget.Text;
                myRow["MaxBudget"] = txtMaxBudget.Text;
                tabClient.Rows.Add(myRow);
                current = tabClient.Rows.Count - 1;
                MessageBox.Show("Record added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGrid();
            }
            mode = "";
            OleDbCommandBuilder myBuild = new OleDbCommandBuilder(clsGlobal.adpClients);
            clsGlobal.adpClients.Update(tabClient);
        }

    
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                tabClient.Rows.Remove(tabClient.Rows[current]);
                MessageBox.Show("Record deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                current = 0;
                tab2remove();
            }
            OleDbCommandBuilder myBuild = new OleDbCommandBuilder(clsGlobal.adpClients);
            clsGlobal.adpClients.Update(tabClient);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to exit", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                this.Close();
    
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tab2remove();
            mode = "Add";
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {      
            current = 0;
            tab2txt();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (current > 0)
            {
                current = current - 1;
                tab2txt();
            }
            else
            {
                MessageBox.Show("Sorry, this is the first record!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (current < (tabClient.Rows.Count - 1))
            {
                current = current + 1;
                tab2txt();
            }
            else
            {
                MessageBox.Show("Sorry, this is the last record!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            current = tabClient.Rows.Count - 1;
            tab2txt();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image Files | *.jpg; *.jpeg; *.png;", ValidateNames = true, Multiselect = false })
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string picloc = ofd.FileName.ToString();
                    picClient.ImageLocation = picloc;
                }
        }

        private void cbxSearchClient_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string sql = "SELECT ClientName, PhoneNumber, Email, Address, MinBudget, MaxBudget FROM CLIENTS WHERE ClientNumber = '" + cbxSearchClient.SelectedItem + "'";
            //OleDbCommand myCmd = new OleDbCommand(sql, clsGlobal.myCon);
            //OleDbDataReader myReader = myCmd.ExecuteReader();
            //DataTable tmp = new DataTable();
            //tmp.Load(myReader);
            //metroGridClient.DataSource = tmp;

            //Int32 num = 0;
            //DataRow[] myRow = tabClient.Select("ClientNumber=" + Convert.ToInt32(cbxSearchClient.SelectedValue));
            ////txtClientNumber.Text = myRow.ToList()[0]["ClientNumber"].ToString();
            //txtClientName.Text = myRow.ToList()[0]["ClientName"].ToString();
            //txtPhoneNumber.Text = myRow.ToList()[0]["PhoneNumber"].ToString();
            //txtEmail.Text = myRow.ToList()[0]["Email"].ToString();
            //txtAddress.Text = myRow.ToList()[0]["Address"].ToString();
            //txtMinBudget.Text = myRow.ToList()[0]["MinBudget"].ToString();
            //txtMaxBudget.Text = myRow.ToList()[0]["MaxBudget"].ToString();
            //if (cbxSearchClient.SelectedValue.ToString() != "")
            //{
            //    num = Convert.ToInt32(cbxSearchClient.SelectedValue);
            //}
            //metroGridClient.DataSource = (from DataRow client in clsGlobal.mySet.Tables["CLIENTS"].Rows
            //                          where (client.Field<Int32>("ClientNumber") == num)
            //                          select new {
            //                              ClientName = client.Field<string>("ClientName"),
            //                              PhoneNumber = client.Field<string>("PhoneNumber"),
            //                              Email = client.Field<string>("Email"),
            //                              Address = client.Field<string>("Address"),
            //                              MinBudget = client.Field<int>("MinBudget"),
            //                              MaxBudget = client.Field<int>("MaxBudget"),
            //                          }).ToList();

            //    var ClientList3 = from DataRow client in tabClient.Rows
            //                      where cbxSearchClient.SelectedValue.ToString() == client.Field<Int32>("ClientNumber").ToString()
            //                      select new
            //                      {                       
            //                          ClientName = client.Field<string>("ClientName"),
            //                          PhoneNumber = client.Field<string>("PhoneNumber"),
            //                          Email = client.Field<string>("Email"),
            //                          Address = client.Field<string>("Address"),
            //                          MinBudget = client.Field<int>("MinBudget"),
            //                          MaxBudget = client.Field<int>("MaxBudget"),
            //                      };
            //    metroGridClient.DataSource = ClientList3.ToList();
        }

        private void FillGrid()
        {
            var ClientList2 = from DataRow client in tabClient.Rows
                              select new
                              {
                                  ClientName = client.Field<string>("ClientName"),
                                  PhoneNumber = client.Field<string>("PhoneNumber"),
                                  Email = client.Field<string>("Email"),
                                  Address = client.Field<string>("Address"),
                                  MinBudget = client.Field<int>("MinBudget"),
                                  MaxBudget = client.Field<int>("MaxBudget"),
                              };
            metroGridClient.DataSource = ClientList2.ToList();
        }
    }
}