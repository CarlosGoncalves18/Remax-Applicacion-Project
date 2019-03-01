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
    public partial class FrmProperties : MetroFramework.Forms.MetroForm
    {
        DataTable tabProperty;
        DataRow myRow;
        int current = 0;
        string mode;

        public FrmProperties()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void FrmProperties_Load(object sender, EventArgs e)
        {    
            clsGlobal.mySet = new DataSet();
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM PROPERTIES", clsGlobal.myCon);
            clsGlobal.adpProperties = new OleDbDataAdapter(myCmd);
            clsGlobal.adpProperties.Fill(clsGlobal.mySet, "PROPERTIES");
            tabProperty = clsGlobal.mySet.Tables["PROPERTIES"];
            metroPanel1.Enabled = false;
            tab2txt();

            var PropertyList = from DataRow mk in tabProperty.Rows
                             select new { refC = mk.Field<Int32>("PropertyNumber"), Number = mk.Field<int>("PropertyNumber") };

            cbxSearchProperty.DisplayMember = "number";
            cbxSearchProperty.ValueMember = "propertyNumber";
            cbxSearchProperty.DataSource = PropertyList.ToList();

            FillGrid();
        }

        private void tab2txt()
        {
            txtPropertyNumber.Text = tabProperty.Rows[current]["PropertyNumber"].ToString();
            txtPropertyName.Text = tabProperty.Rows[current]["PropertyName"].ToString();
            txtPropertyType.Text = tabProperty.Rows[current]["PropertyType"].ToString();
            txtAddress.Text = tabProperty.Rows[current]["Address"].ToString();
            metroDateTimeProperty.Text = tabProperty.Rows[current]["PropertyDate"].ToString();
            txtNumberRooms.Text = tabProperty.Rows[current]["NumberOfRooms"].ToString();
            txtAreaSize.Text = tabProperty.Rows[current]["AreaSize"].ToString();
            txtPrice.Text = tabProperty.Rows[current]["Price"].ToString();
            txtDescription.Text = tabProperty.Rows[current]["Description"].ToString();

        }
        private void tab2remove()
        {
            txtPropertyNumber.Clear();
            txtPropertyType.Clear();
            txtPropertyName.Clear();
            txtAddress.Clear();
            metroDateTimeProperty.ResetText();
            txtNumberRooms.Clear();
            txtAreaSize.Clear();
            txtPrice.Clear();
            txtDescription.Clear();
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
            txtPropertyNumber.Focus();
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
                myRow = tabProperty.Rows[current];
                myRow["PropertyNumber"] = txtPropertyNumber.Text;
                myRow["PropertyName"] = txtPropertyName.Text;
                myRow["PropertyType"] = txtPropertyType.Text;
                myRow["Address"] = txtAddress.Text;
                myRow["PropertyDate"] = metroDateTimeProperty.Text;
                myRow["NumberOfRooms"] = txtNumberRooms.Text;
                myRow["AreaSize"] = txtAreaSize.Text;
                myRow["Price"] = txtPrice.Text;
                myRow["Description"] = txtDescription.Text;
                MessageBox.Show("Record edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGrid();
            }
            else if (mode == "Add")
            {
                myRow = tabProperty.NewRow();
                myRow["PropertyNumber"] = txtPropertyNumber.Text;
                myRow["PropertyName"] = txtPropertyName.Text;
                myRow["PropertyType"] = txtPropertyType.Text;
                myRow["Address"] = txtAddress.Text;
                myRow["PropertyDate"] = metroDateTimeProperty.Text;
                myRow["NumberOfRooms"] = txtNumberRooms.Text;
                myRow["AreaSize"] = txtAreaSize.Text;
                myRow["Price"] = txtPrice.Text;
                myRow["Description"] = txtDescription.Text;
                tabProperty.Rows.Add(myRow);
                current = tabProperty.Rows.Count - 1;
                MessageBox.Show("Record added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGrid();
            }
            mode = "";
            OleDbCommandBuilder myBuild = new OleDbCommandBuilder(clsGlobal.adpProperties);
            clsGlobal.adpProperties.Update(tabProperty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                tabProperty.Rows.Remove(tabProperty.Rows[current]);
                MessageBox.Show("Record deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                current = 0;
                tab2remove();
            }
            OleDbCommandBuilder myBuild = new OleDbCommandBuilder(clsGlobal.adpProperties);
            clsGlobal.adpProperties.Update(tabProperty);
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
            if (current < (tabProperty.Rows.Count - 1))
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
            current = tabProperty.Rows.Count - 1;
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
            var PropertyList2 = from DataRow property in tabProperty.Rows
                                select new
                                {

                                    PropertyType = property.Field<string>("PropertyType"),
                                    PropertyName = property.Field<string>("PropertyName"),
                                    PropertyAddress = property.Field<string>("Address"),
                                    PropertyDate = property.Field<DateTime>("PropertyDate"),
                                    NumberOfRooms = property.Field<int>("NumberOfRooms"),
                                    AreaSize = property.Field<string>("AreaSize"),
                                    Price = property.Field<int>("Price"),
                                    Description = property.Field<string>("Description"),
                                    Photo = property.Field<Image>("Photo")
                              };
            metroGridProperty.DataSource = PropertyList2.ToList();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                picProperty.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
