namespace RemaxApplication
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroTileHome = new MetroFramework.Controls.MetroTile();
            this.metroTileClients = new MetroFramework.Controls.MetroTile();
            this.metroTileEmployees = new MetroFramework.Controls.MetroTile();
            this.metroTileProperty = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // metroTileHome
            // 
            this.metroTileHome.ActiveControl = null;
            this.metroTileHome.BackColor = System.Drawing.Color.Maroon;
            this.metroTileHome.Location = new System.Drawing.Point(23, 11);
            this.metroTileHome.Name = "metroTileHome";
            this.metroTileHome.Size = new System.Drawing.Size(286, 61);
            this.metroTileHome.TabIndex = 1;
            this.metroTileHome.Text = "Home";
            this.metroTileHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTileHome.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTileHome.UseSelectable = true;
            this.metroTileHome.Click += new System.EventHandler(this.metroTileHome_Click);
            // 
            // metroTileClients
            // 
            this.metroTileClients.ActiveControl = null;
            this.metroTileClients.BackColor = System.Drawing.Color.Maroon;
            this.metroTileClients.Location = new System.Drawing.Point(951, 11);
            this.metroTileClients.Name = "metroTileClients";
            this.metroTileClients.Size = new System.Drawing.Size(286, 61);
            this.metroTileClients.TabIndex = 2;
            this.metroTileClients.Text = "Clients";
            this.metroTileClients.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTileClients.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTileClients.UseSelectable = true;
            this.metroTileClients.Click += new System.EventHandler(this.metroTileClients_Click);
            // 
            // metroTileEmployees
            // 
            this.metroTileEmployees.ActiveControl = null;
            this.metroTileEmployees.BackColor = System.Drawing.Color.Maroon;
            this.metroTileEmployees.Location = new System.Drawing.Point(643, 11);
            this.metroTileEmployees.Name = "metroTileEmployees";
            this.metroTileEmployees.Size = new System.Drawing.Size(286, 61);
            this.metroTileEmployees.TabIndex = 3;
            this.metroTileEmployees.Text = "Employees";
            this.metroTileEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTileEmployees.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTileEmployees.UseSelectable = true;
            this.metroTileEmployees.Click += new System.EventHandler(this.metroTileEmployees_Click);
            // 
            // metroTileProperty
            // 
            this.metroTileProperty.ActiveControl = null;
            this.metroTileProperty.BackColor = System.Drawing.Color.Maroon;
            this.metroTileProperty.Location = new System.Drawing.Point(333, 11);
            this.metroTileProperty.Name = "metroTileProperty";
            this.metroTileProperty.Size = new System.Drawing.Size(286, 61);
            this.metroTileProperty.TabIndex = 4;
            this.metroTileProperty.Text = "Properties";
            this.metroTileProperty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTileProperty.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTileProperty.UseSelectable = true;
            this.metroTileProperty.Click += new System.EventHandler(this.metroTileProperty_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1277, 544);
            this.Controls.Add(this.metroTileProperty);
            this.Controls.Add(this.metroTileEmployees);
            this.Controls.Add(this.metroTileClients);
            this.Controls.Add(this.metroTileHome);
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile metroTileHome;
        private MetroFramework.Controls.MetroTile metroTileClients;
        private MetroFramework.Controls.MetroTile metroTileEmployees;
        private MetroFramework.Controls.MetroTile metroTileProperty;
    }
}