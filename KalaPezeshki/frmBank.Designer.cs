namespace KalaPezeshki
{
    partial class frmBank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBank));
            this.btnS = new DevComponents.DotNetBar.ButtonX();
            this.txtTozih = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.txtAcctNum = new System.Windows.Forms.TextBox();
            this.labe4 = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameAcct = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdite = new DevComponents.DotNetBar.ButtonX();
            this.btnList = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel4.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnS
            // 
            this.btnS.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnS.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnS.Location = new System.Drawing.Point(321, 10);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(31, 26);
            this.btnS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnS.TabIndex = 1;
            this.btnS.Text = "+";
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // txtTozih
            // 
            this.txtTozih.Location = new System.Drawing.Point(23, 171);
            this.txtTozih.Multiline = true;
            this.txtTozih.Name = "txtTozih";
            this.txtTozih.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTozih.Size = new System.Drawing.Size(442, 148);
            this.txtTozih.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(471, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "توضیحات";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(286, 139);
            this.txtBalance.MaxLength = 50;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(179, 26);
            this.txtBalance.TabIndex = 5;
            this.txtBalance.TextChanged += new System.EventHandler(this.txtBalance_TextChanged);
            // 
            // txtAcctNum
            // 
            this.txtAcctNum.Location = new System.Drawing.Point(178, 107);
            this.txtAcctNum.MaxLength = 20;
            this.txtAcctNum.Name = "txtAcctNum";
            this.txtAcctNum.Size = new System.Drawing.Size(287, 26);
            this.txtAcctNum.TabIndex = 4;
            this.txtAcctNum.TextChanged += new System.EventHandler(this.txtAcctNum_TextChanged);
            // 
            // labe4
            // 
            this.labe4.AutoSize = true;
            this.labe4.Location = new System.Drawing.Point(471, 142);
            this.labe4.Name = "labe4";
            this.labe4.Size = new System.Drawing.Size(60, 18);
            this.labe4.TabIndex = 0;
            this.labe4.Text = "موجودی";
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(178, 75);
            this.txtBankName.MaxLength = 30;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(287, 26);
            this.txtBankName.TabIndex = 3;
            this.txtBankName.TextChanged += new System.EventHandler(this.txtBankName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(471, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "شماره حساب";
            // 
            // txtNameAcct
            // 
            this.txtNameAcct.Location = new System.Drawing.Point(178, 43);
            this.txtNameAcct.MaxLength = 30;
            this.txtNameAcct.Name = "txtNameAcct";
            this.txtNameAcct.Size = new System.Drawing.Size(287, 26);
            this.txtNameAcct.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(471, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "نام بانک";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(358, 10);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(107, 26);
            this.txtCode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(471, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "به نام";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "کد";
            // 
            // btnEdite
            // 
            this.btnEdite.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdite.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEdite.Image = ((System.Drawing.Image)(resources.GetObject("btnEdite.Image")));
            this.btnEdite.Location = new System.Drawing.Point(187, 3);
            this.btnEdite.Name = "btnEdite";
            this.btnEdite.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 8, 8, 2);
            this.btnEdite.Size = new System.Drawing.Size(109, 47);
            this.btnEdite.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEdite.TabIndex = 2;
            this.btnEdite.Text = "ویرایش";
            this.btnEdite.Click += new System.EventHandler(this.btnEdite_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnList.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnList.Image = ((System.Drawing.Image)(resources.GetObject("btnList.Image")));
            this.btnList.Location = new System.Drawing.Point(54, 3);
            this.btnList.Name = "btnList";
            this.btnList.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 8, 8, 2);
            this.btnList.Size = new System.Drawing.Size(109, 47);
            this.btnList.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnList.TabIndex = 3;
            this.btnList.Text = "لیست";
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(321, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 8, 8, 2);
            this.btnDelete.Size = new System.Drawing.Size(109, 47);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "حذف";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(454, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 8, 8, 2);
            this.btnSave.Size = new System.Drawing.Size(109, 47);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupPanel4
            // 
            this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.btnEdite);
            this.groupPanel4.Controls.Add(this.btnList);
            this.groupPanel4.Controls.Add(this.btnDelete);
            this.groupPanel4.Controls.Add(this.btnSave);
            this.groupPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel4.Location = new System.Drawing.Point(9, 342);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(575, 60);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 1;
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnClear);
            this.groupPanel2.Controls.Add(this.btnS);
            this.groupPanel2.Controls.Add(this.txtTozih);
            this.groupPanel2.Controls.Add(this.label7);
            this.groupPanel2.Controls.Add(this.txtBalance);
            this.groupPanel2.Controls.Add(this.txtAcctNum);
            this.groupPanel2.Controls.Add(this.labe4);
            this.groupPanel2.Controls.Add(this.txtBankName);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Controls.Add(this.txtNameAcct);
            this.groupPanel2.Controls.Add(this.label3);
            this.groupPanel2.Controls.Add(this.txtCode);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(9, 3);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(574, 333);
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
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(23, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 8, 8, 2);
            this.btnClear.Size = new System.Drawing.Size(109, 33);
            this.btnClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "پاک کردن\t";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.groupPanel4);
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(593, 411);
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
            this.groupPanel1.TabIndex = 1;
            // 
            // frmBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 411);
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MinimizeBox = false;
            this.Name = "frmBank";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعریف حساب های بانکی";
            this.Load += new System.EventHandler(this.frmBank_Load);
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnS;
        private System.Windows.Forms.TextBox txtTozih;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.TextBox txtAcctNum;
        private System.Windows.Forms.Label labe4;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNameAcct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnEdite;
        private DevComponents.DotNetBar.ButtonX btnList;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.ButtonX btnClear;
    }
}