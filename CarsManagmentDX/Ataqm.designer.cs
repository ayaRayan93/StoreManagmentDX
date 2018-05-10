namespace StoresManagmentDX
{
    partial class Ataqm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ataqm));
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dataGridView1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tLPanProductsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tLPanSearch = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new Bunifu.Framework.UI.BunifuFlatButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnUpdate = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnDelete = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnReport = new Bunifu.Framework.UI.BunifuTileButton();
            this.tLPanFilter = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSetsID = new System.Windows.Forms.TextBox();
            this.comSets = new System.Windows.Forms.ComboBox();
            this.comGroup = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFactory = new System.Windows.Forms.TextBox();
            this.comFactory = new System.Windows.Forms.ComboBox();
            this.comType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tLPanProductsContainer.SuspendLayout();
            this.tLPanSearch.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tLPanFilter.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.dataGridView1;
            this.gridView3.Name = "gridView3";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MainView = this.gridView1;
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel7.SetRowSpan(this.dataGridView1, 2);
            this.dataGridView1.Size = new System.Drawing.Size(911, 344);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView3});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dataGridView1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsPrint.PrintDetails = true;
            this.gridView1.OptionsPrint.PrintFooter = false;
            this.gridView1.OptionsPrint.PrintPreview = true;
            // 
            // tLPanProductsContainer
            // 
            this.tLPanProductsContainer.BackColor = System.Drawing.Color.White;
            this.tLPanProductsContainer.ColumnCount = 3;
            this.tLPanProductsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPanProductsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tLPanProductsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tLPanProductsContainer.Controls.Add(this.tLPanSearch, 0, 1);
            this.tLPanProductsContainer.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tLPanProductsContainer.Controls.Add(this.tLPanFilter, 1, 1);
            this.tLPanProductsContainer.Controls.Add(this.tableLayoutPanel7, 0, 2);
            this.tLPanProductsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanProductsContainer.Location = new System.Drawing.Point(0, 0);
            this.tLPanProductsContainer.Name = "tLPanProductsContainer";
            this.tLPanProductsContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tLPanProductsContainer.RowCount = 4;
            this.tLPanProductsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tLPanProductsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tLPanProductsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tLPanProductsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tLPanProductsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tLPanProductsContainer.Size = new System.Drawing.Size(917, 501);
            this.tLPanProductsContainer.TabIndex = 2;
            // 
            // tLPanSearch
            // 
            this.tLPanSearch.ColumnCount = 3;
            this.tLPanSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPanSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tLPanSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPanSearch.Controls.Add(this.btnSearch, 1, 1);
            this.tLPanSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanSearch.Location = new System.Drawing.Point(3, 28);
            this.tLPanSearch.Name = "tLPanSearch";
            this.tLPanSearch.RowCount = 3;
            this.tLPanSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPanSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPanSearch.Size = new System.Drawing.Size(223, 69);
            this.tLPanSearch.TabIndex = 12;
            // 
            // btnSearch
            // 
            this.btnSearch.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.BorderRadius = 0;
            this.btnSearch.ButtonText = "بحث";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.DisabledColor = System.Drawing.Color.Gray;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Font = new System.Drawing.Font("Neo Sans Arabic", 11F);
            this.btnSearch.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSearch.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSearch.Iconimage")));
            this.btnSearch.Iconimage_right = null;
            this.btnSearch.Iconimage_right_Selected = null;
            this.btnSearch.Iconimage_Selected = null;
            this.btnSearch.IconMarginLeft = 0;
            this.btnSearch.IconMarginRight = 0;
            this.btnSearch.IconRightVisible = true;
            this.btnSearch.IconRightZoom = 0D;
            this.btnSearch.IconVisible = false;
            this.btnSearch.IconZoom = 90D;
            this.btnSearch.IsTab = false;
            this.btnSearch.Location = new System.Drawing.Point(49, 22);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnSearch.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnSearch.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSearch.selected = false;
            this.btnSearch.Size = new System.Drawing.Size(123, 24);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "بحث";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSearch.Textcolor = System.Drawing.Color.White;
            this.btnSearch.TextFont = new System.Drawing.Font("Neo Sans Arabic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.tableLayoutPanel4.ColumnCount = 7;
            this.tLPanProductsContainer.SetColumnSpan(this.tableLayoutPanel4, 3);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.btnAdd, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnUpdate, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnDelete, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnReport, 4, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 450);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(917, 51);
            this.tableLayoutPanel4.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.btnAdd.color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.btnAdd.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Font = new System.Drawing.Font("Neo Sans Arabic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::StoresManagmentDX.Properties.Resources.File_321;
            this.btnAdd.ImagePosition = 1;
            this.btnAdd.ImageZoom = 20;
            this.btnAdd.LabelPosition = 18;
            this.btnAdd.LabelText = "اضافة";
            this.btnAdd.Location = new System.Drawing.Point(600, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 43);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.btnUpdate.color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.btnUpdate.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.Font = new System.Drawing.Font("Neo Sans Arabic", 9.75F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Image = global::StoresManagmentDX.Properties.Resources.Edit_321;
            this.btnUpdate.ImagePosition = 1;
            this.btnUpdate.ImageZoom = 20;
            this.btnUpdate.LabelPosition = 18;
            this.btnUpdate.LabelText = "تعديل";
            this.btnUpdate.Location = new System.Drawing.Point(509, 4);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 43);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.btnDelete.color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.btnDelete.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Font = new System.Drawing.Font("Neo Sans Arabic", 9.75F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::StoresManagmentDX.Properties.Resources.Delete_321;
            this.btnDelete.ImagePosition = 1;
            this.btnDelete.ImageZoom = 20;
            this.btnDelete.LabelPosition = 18;
            this.btnDelete.LabelText = "حذف";
            this.btnDelete.Location = new System.Drawing.Point(418, 4);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 43);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.btnReport.color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.btnReport.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(146)))));
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReport.Font = new System.Drawing.Font("Neo Sans Arabic", 9.75F);
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Image = global::StoresManagmentDX.Properties.Resources.Print_321;
            this.btnReport.ImagePosition = 1;
            this.btnReport.ImageZoom = 20;
            this.btnReport.LabelPosition = 18;
            this.btnReport.LabelText = "تقرير";
            this.btnReport.Location = new System.Drawing.Point(327, 4);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(85, 43);
            this.btnReport.TabIndex = 3;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // tLPanFilter
            // 
            this.tLPanFilter.ColumnCount = 1;
            this.tLPanFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanFilter.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tLPanFilter.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tLPanFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanFilter.Location = new System.Drawing.Point(229, 25);
            this.tLPanFilter.Margin = new System.Windows.Forms.Padding(0);
            this.tLPanFilter.Name = "tLPanFilter";
            this.tLPanFilter.RowCount = 2;
            this.tLPanFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanFilter.Size = new System.Drawing.Size(641, 75);
            this.tLPanFilter.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Controls.Add(this.txtSetsID, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.comSets, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.comGroup, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtGroup, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 37);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(641, 38);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // txtSetsID
            // 
            this.txtSetsID.BackColor = System.Drawing.Color.White;
            this.txtSetsID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSetsID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSetsID.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSetsID.Location = new System.Drawing.Point(3, 10);
            this.txtSetsID.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtSetsID.Name = "txtSetsID";
            this.txtSetsID.Size = new System.Drawing.Size(58, 24);
            this.txtSetsID.TabIndex = 12;
            this.txtSetsID.TabStop = false;
            this.txtSetsID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // comSets
            // 
            this.comSets.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comSets.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comSets.BackColor = System.Drawing.Color.White;
            this.comSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSets.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comSets.FormattingEnabled = true;
            this.comSets.Location = new System.Drawing.Point(67, 10);
            this.comSets.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comSets.Name = "comSets";
            this.comSets.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comSets.Size = new System.Drawing.Size(186, 24);
            this.comSets.TabIndex = 10;
            this.comSets.SelectedValueChanged += new System.EventHandler(this.comBox_SelectedValueChanged);
            // 
            // comGroup
            // 
            this.comGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comGroup.BackColor = System.Drawing.Color.White;
            this.comGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comGroup.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comGroup.FormattingEnabled = true;
            this.comGroup.Location = new System.Drawing.Point(387, 10);
            this.comGroup.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comGroup.Name = "comGroup";
            this.comGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comGroup.Size = new System.Drawing.Size(186, 24);
            this.comGroup.TabIndex = 7;
            this.comGroup.SelectedValueChanged += new System.EventHandler(this.comBox_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Neo Sans Arabic", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.label5.Location = new System.Drawing.Point(576, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "المجوعة";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Neo Sans Arabic", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.label4.Location = new System.Drawing.Point(256, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "الطقم";
            // 
            // txtGroup
            // 
            this.txtGroup.BackColor = System.Drawing.Color.White;
            this.txtGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGroup.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtGroup.Location = new System.Drawing.Point(323, 10);
            this.txtGroup.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(58, 24);
            this.txtGroup.TabIndex = 11;
            this.txtGroup.TabStop = false;
            this.txtGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.txtFactory, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comFactory, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.comType, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtType, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(641, 37);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtFactory
            // 
            this.txtFactory.BackColor = System.Drawing.Color.White;
            this.txtFactory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFactory.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFactory.Location = new System.Drawing.Point(3, 10);
            this.txtFactory.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.Size = new System.Drawing.Size(58, 24);
            this.txtFactory.TabIndex = 10;
            this.txtFactory.TabStop = false;
            this.txtFactory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // comFactory
            // 
            this.comFactory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comFactory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comFactory.BackColor = System.Drawing.Color.White;
            this.comFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comFactory.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comFactory.FormattingEnabled = true;
            this.comFactory.Location = new System.Drawing.Point(67, 10);
            this.comFactory.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comFactory.Name = "comFactory";
            this.comFactory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comFactory.Size = new System.Drawing.Size(186, 24);
            this.comFactory.TabIndex = 8;
            this.comFactory.SelectedValueChanged += new System.EventHandler(this.comBox_SelectedValueChanged);
            // 
            // comType
            // 
            this.comType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comType.BackColor = System.Drawing.Color.White;
            this.comType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comType.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comType.FormattingEnabled = true;
            this.comType.Location = new System.Drawing.Point(387, 10);
            this.comType.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comType.Name = "comType";
            this.comType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comType.Size = new System.Drawing.Size(186, 24);
            this.comType.TabIndex = 1;
            this.comType.SelectedValueChanged += new System.EventHandler(this.comBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Neo Sans Arabic", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.label2.Location = new System.Drawing.Point(256, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 1);
            this.label2.TabIndex = 7;
            this.label2.Text = "المصنع";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Neo Sans Arabic", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.label3.Location = new System.Drawing.Point(576, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 1);
            this.label3.TabIndex = 6;
            this.label3.Text = "النوع ";
            // 
            // txtType
            // 
            this.txtType.BackColor = System.Drawing.Color.White;
            this.txtType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtType.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtType.Location = new System.Drawing.Point(323, 10);
            this.txtType.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(58, 24);
            this.txtType.TabIndex = 9;
            this.txtType.TabStop = false;
            this.txtType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Neo Sans Arabic", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.label6.Location = new System.Drawing.Point(576, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "النوع";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Neo Sans Arabic", 10F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.label7.Location = new System.Drawing.Point(256, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "المصنع";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tLPanProductsContainer.SetColumnSpan(this.tableLayoutPanel7, 3);
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(911, 344);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // Ataqm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 501);
            this.Controls.Add(this.tLPanProductsContainer);
            this.Name = "Ataqm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "Ataqm";
            this.Load += new System.EventHandler(this.Ataqm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tLPanProductsContainer.ResumeLayout(false);
            this.tLPanSearch.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tLPanFilter.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLPanProductsContainer;
        private System.Windows.Forms.TableLayoutPanel tLPanFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtSetsID;
        private System.Windows.Forms.ComboBox comSets;
        private System.Windows.Forms.ComboBox comGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtFactory;
        private System.Windows.Forms.ComboBox comFactory;
        private System.Windows.Forms.ComboBox comType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Bunifu.Framework.UI.BunifuTileButton btnReport;
        private Bunifu.Framework.UI.BunifuTileButton btnAdd;
        private Bunifu.Framework.UI.BunifuTileButton btnUpdate;
        private Bunifu.Framework.UI.BunifuTileButton btnDelete;
        private System.Windows.Forms.TableLayoutPanel tLPanSearch;
        private Bunifu.Framework.UI.BunifuFlatButton btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.GridControl dataGridView1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}