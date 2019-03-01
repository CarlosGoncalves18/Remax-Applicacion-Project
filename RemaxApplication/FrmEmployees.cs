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
    public partial class FrmEmployees : MetroFramework.Forms.MetroForm
    {
        DataTable tabEmployee;
        DataRow myRow;
        int current = 0;
        string mode;

        public FrmEmployees()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void FrmEmployees_Load(object sender, EventArgs e)
        {
            clsGlobal.mySet = new DataSet();
            clsGlobal.myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\carlo\OneDrive\Documentos\Programming\C#\RemaxApplication3\RemaxApplication3\bin\Debug\data\RealStateDataBase.mdb");
            clsGlobal.myCon.Open();
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM EMPLOYEES", clsGlobal.myCon);
            clsGlobal.adpEmployees = new OleDbDataAdapter(myCmd);
            clsGlobal.adpEmployees.Fill(clsGlobal.mySet, "EMPLOYEES");
            tabEmployee = clsGlobal.mySet.Tables["EMPLOYEES"];
            metroPanel1.Enabled = false;
            tab2txt();

            OleDbCommand myCmd2 = new OleDbCommand("SELECT * FROM Employees", clsGlobal.myCon);
            OleDbDataReader myReader = myCmd2.ExecuteReader();
            while (myReader.Read())
            {
                cbxSearchProperty.Items.Add(myReader["EmployeeNumber"].ToString());
            }
            myReader.Close();

            //var EmployeeList = from DataRow mk in tabEmployee.Rows
            //                   select new { refC = mk.Field<Int32>("EmployeeNumber"), Number = mk.Field<int>("EmployeeNumber") };

            //cbxSearchProperty.DisplayMember = "number";
            //cbxSearchProperty.ValueMember = "EmployeeNumber";
            //cbxSearchProperty.DataSource = EmployeeList.ToList();

            FillGrid();
        }
        private void tab2txt()
        {
            txtEmployeeNumber.Text = tabEmployee.Rows[current]["EmployeeNumber"].ToString();
            txtEmployeeType.Text = tabEmployee.Rows[current]["EmployeeType"].ToString();
            txtEmployeeName.Text = tabEmployee.Rows[current]["EmployeeName"].ToString();
            txtPhoneNumber.Text = tabEmployee.Rows[current]["PhoneNumber"].ToString();
            txtEmail.Text = tabEmployee.Rows[current]["Email"].ToString();
            txtAddress.Text = tabEmployee.Rows[current]["Address"].ToString();

        }

        private void tab2remove()
        {
            txtEmployeeNumber.Clear();
            txtEmployeeName.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtEmployeeType.Clear();
            metroPanel1.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tab2remove();
            mode = "Add";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            metroPanel1.Enabled = true;
            txtEmployeeNumber.Focus();
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
                myRow = tabEmployee.Rows[current];
                myRow["EmployeeNumber"] = txtEmployeeNumber.Text;
                myRow["EmployeeType"] = txtEmployeeType.Text;
                myRow["EmployeeName"] = txtEmployeeName.Text;
                myRow["PhoneNumber"] = txtPhoneNumber.Text;
                myRow["Email"] = txtEmail.Text;
                myRow["Address"] = txtAddress.Text;
                MessageBox.Show("Record edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FillGrid();
            }
            else if (mode == "Add")
            {
                myRow = tabEmployee.NewRow();
                myRow["EmployeeNumber"] = txtEmployeeNumber.Text;
                myRow["EmployeeType"] = txtEmployeeType.Text;
                myRow["EmployeeName"] = txtEmployeeName.Text;
                myRow["PhoneNumber"] = txtPhoneNumber.Text;
                myRow["Email"] = txtEmail.Text;
                myRow["Address"] = txtAddress.Text;
                tabEmployee.Rows.Add(myRow);
                current = tabEmployee.Rows.Count - 1;
                MessageBox.Show("Record added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FillGrid();
            }
            mode = "";
            OleDbCommandBuilder myBuild = new OleDbCommandBuilder(clsGlobal.adpEmployees);
            clsGlobal.adpEmployees.Update(tabEmployee);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                tabEmployee.Rows.Remove(tabEmployee.Rows[current]);
                MessageBox.Show("Delete completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                current = 0;
                tab2remove();
            }
            OleDbCommandBuilder myBuild = new OleDbCommandBuilder(clsGlobal.adpEmployees);
            clsGlobal.adpEmployees.Update(tabEmployee);
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
            if (current < (tabEmployee.Rows.Count - 1))
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
            current = tabEmployee.Rows.Count - 1;
            tab2txt();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to exit", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void FillGrid()
        {
            var EmployeeList2 = from DataRow employee in tabEmployee.Rows
                                select new
                                {
                                    EmployeeType = employee.Field<string>("EmployeeType"),
                                    EmployeeName = employee.Field<string>("EmployeeName"),
                                    PhoneNumber = employee.Field<string>("PhoneNumber"),
                                    Email = employee.Field<string>("Email"),
                                    Address = employee.Field<string>("Address"),
                                };
            metroGridEmployees.DataSource = EmployeeList2.ToList();
        }

        private void cbxSearchProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string sql = "SELECT PROPERTIES.PropertyType, PROPERTIES.PropertyName, PROPERTIES.PropertyNumber, PROPERTIES.Address, PROPERTIES.PropertyDate, PROPERTIES.NumberOfRooms, PROPERTIES.AreaSize, PROPERTIES.Price, PROPERTIES.Description, EMPLOYEES.EmployeeNumber FROM EMPLOYEES INNER JOIN PROPERTIES ON EMPLOYEES.PropertyNumber = PROPERTIES.PropertyNumber WHERE EMPLOYEES.EmployeeNumber = '" + cbxSearchProperty.SelectedItem.ToString() + "'";
            //OleDbCommand myCmd = new OleDbCommand(sql, clsGlobal. myCon);
            //OleDbDataReader myReader = myCmd.ExecuteReader();
            //DataTable tmp = new DataTable();
            //tmp.Load(myReader);
            //metroGridEmployees.DataSource = tmp;
        }
    }
}
