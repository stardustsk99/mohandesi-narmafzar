namespace KalaPezeshki
{
    partial class frmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnEdite = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.cmbRole = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.ChkPassword = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtPassRep = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.Controls.Add(this.groupPanel3);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(976, 422);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnEdite);
            this.groupPanel2.Controls.Add(this.btnDelete);
            this.groupPanel2.Controls.Add(this.cmbRole);
            this.groupPanel2.Controls.Add(this.btnSave);
            this.groupPanel2.Controls.Add(this.ChkPassword);
            this.groupPanel2.Controls.Add(this.label3);
            this.groupPanel2.Controls.Add(this.txtPhoneNumber);
            this.groupPanel2.Controls.Add(this.txtPassRep);
            this.groupPanel2.Controls.Add(this.txtPass);
            this.groupPanel2.Controls.Add(this.txtUName);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.label5);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(556, 6);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(408, 401);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 0;
            this.groupPanel2.Click += new System.EventHandler(this.groupPanel2_Click);
            // 
            // btnEdite
            // 
            this.btnEdite.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdite.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEdite.Image = ((System.Drawing.Image)(resources.GetObject("btnEdite.Image")));
            this.btnEdite.Location = new System.Drawing.Point(14, 345);
            this.btnEdite.Name = "btnEdite";
            this.btnEdite.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 8, 8, 2);
            this.btnEdite.Size = new System.Drawing.Size(109, 47);
            this.btnEdite.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEdite.TabIndex = 8;
            this.btnEdite.Text = "ویرایش";
            this.btnEdite.Click += new System.EventHandler(this.btnEdite_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(147, 345);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 8, 8, 2);
            this.btnDelete.Size = new System.Drawing.Size(109, 47);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "حذف";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbRole
            // 
            this.cmbRole.DisplayMember = "Text";
            this.cmbRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.ItemHeight = 21;
            this.cmbRole.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cmbRole.Location = new System.Drawing.Point(103, 20);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(181, 27);
            this.cmbRole.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbRole.TabIndex = 0;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "User";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "Admin";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(276, 345);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 8, 8, 2);
            this.btnSave.Size = new System.Drawing.Size(109, 47);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ChkPassword
            // 
            this.ChkPassword.AutoSize = true;
            this.ChkPassword.Location = new System.Drawing.Point(130, 233);
            this.ChkPassword.Name = "ChkPassword";
            this.ChkPassword.Size = new System.Drawing.Size(154, 22);
            this.ChkPassword.TabIndex = 5;
            this.ChkPassword.Text = "نمایش کلمه ی عبور";
            this.ChkPassword.UseVisualStyleBackColor = true;
            this.ChkPassword.CheckedChanged += new System.EventHandler(this.ChkPassword_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "شماره تماس";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(14, 103);
            this.txtPhoneNumber.MaxLength = 11;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(270, 26);
            this.txtPhoneNumber.TabIndex = 2;
            this.txtPhoneNumber.TextChanged += new System.EventHandler(this.txtPhoneNumber_TextChanged);
            // 
            // txtPassRep
            // 
            this.txtPassRep.Location = new System.Drawing.Point(14, 191);
            this.txtPassRep.MaxLength = 30;
            this.txtPassRep.Name = "txtPassRep";
            this.txtPassRep.PasswordChar = '*';
            this.txtPassRep.Size = new System.Drawing.Size(270, 26);
            this.txtPassRep.TabIndex = 4;
            this.txtPassRep.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(14, 146);
            this.txtPass.MaxLength = 30;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(270, 26);
            this.txtPass.TabIndex = 3;
            this.txtPass.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtUName
            // 
            this.txtUName.Location = new System.Drawing.Point(14, 62);
            this.txtUName.MaxLength = 30;
            this.txtUName.Name = "txtUName";
            this.txtUName.Size = new System.Drawing.Size(270, 26);
            this.txtUName.TabIndex = 1;
            this.txtUName.TextChanged += new System.EventHandler(this.txtUName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "تکرار کلمه عبور";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "کلمه عبور";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "نقش";
            this.label5.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام کاربری";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.dgvUser);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(3, 3);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(547, 407);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 2;
            this.groupPanel3.Click += new System.EventHandler(this.groupPanel3_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.BackgroundColor = System.Drawing.Color.White;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.Location = new System.Drawing.Point(0, 0);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersWidth = 51;
            this.dgvUser.RowTemplate.Height = 24;
            this.dgvUser.Size = new System.Drawing.Size(541, 401);
            this.dgvUser.TabIndex = 0;
            this.dgvUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellContentClick);
            this.dgvUser.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvUser_MouseUp);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 422);
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "frmUser";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "تعریف کاربران سیستم";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnEdite;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUName;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.CheckBox ChkPassword;
        private System.Windows.Forms.TextBox txtPassRep;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbRole;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private System.Windows.Forms.Label label5;
    }
}