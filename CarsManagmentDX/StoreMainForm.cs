using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraGrid;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraNavBar;

namespace StoresManagmentDX
{
    public partial class StoreMainForm : DevExpress.XtraEditors.XtraForm
    {
        XtraTabPage StoreTP;
        bool flag = false;

        public StoreMainForm()
        {
            try
            {
                InitializeComponent();
                StoreTP = xtraTabPageStores;
                xtraTabControlMainContainer.TabPages.Remove(xtraTabPageStores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnStores_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                if (flag == false)
                {
                    xtraTabControlMainContainer.TabPages.Insert(1, StoreTP);
                    flag = true;
                }
                xtraTabControlMainContainer.SelectedTabPage = xtraTabControlMainContainer.TabPages[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //stores
        private void btnStoreRecord_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                restForeColorOfNavBarItem();
                NavBarItem navBarItem = (NavBarItem)sender;
                navBarItem.Appearance.ForeColor = Color.Blue;

                if (!xtraTabControlStoresContent.Visible)
                xtraTabControlStoresContent.Visible = true;
                
                XtraTabPage xtraTabPage = getTabPage("عرض المخازن");
                if (xtraTabPage == null)
                {
                    xtraTabControlStoresContent.TabPages.Add("عرض المخازن");
                    xtraTabPage = getTabPage("عرض المخازن");
                }
                xtraTabPage.Controls.Clear();

                xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                bindDisplayStoresForm(xtraTabPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        //ProductItems
        private void btnProductItems_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                restForeColorOfNavBarItem();
                NavBarItem navBarItem = (NavBarItem)sender;
                navBarItem.Appearance.ForeColor = Color.Blue; 

                if (!xtraTabControlStoresContent.Visible)
                    xtraTabControlStoresContent.Visible = true;
                
               
                XtraTabPage xtraTabPage = getTabPage("عناصر البند");
                if (xtraTabPage == null)
                {
                    xtraTabControlStoresContent.TabPages.Add("عناصر البند");
                    xtraTabPage = getTabPage("عناصر البند");
                }
                xtraTabPage.Controls.Clear();
                xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                ProductItems objForm = new ProductItems();

                objForm.TopLevel = false;
                xtraTabPage.Controls.Add(objForm);
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Products
        private void btnProducts_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                restForeColorOfNavBarItem();
                NavBarItem navBarItem = (NavBarItem)sender;
                navBarItem.Appearance.ForeColor = Color.Blue;

                if (!xtraTabControlStoresContent.Visible)
                    xtraTabControlStoresContent.Visible = true;


                
                XtraTabPage xtraTabPage = getTabPage("عرض البنود");
                if (xtraTabPage == null)
                {
                    xtraTabControlStoresContent.TabPages.Add("عرض البنود");
                    xtraTabPage = getTabPage("عرض البنود");
                }
                xtraTabPage.Controls.Clear();
                xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;

                Products objForm = new Products(this);

                objForm.TopLevel = false;
                xtraTabPage.Controls.Add(objForm);
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.displayProducts();
                objForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Ataqm
            //Ataqm CURD
            private void btnAtaqm_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                try
                {
                    restForeColorOfNavBarItem();
                    NavBarItem navBarItem = (NavBarItem)sender;
                    navBarItem.Appearance.ForeColor = Color.Blue;
                    if (!xtraTabControlStoresContent.Visible)
                        xtraTabControlStoresContent.Visible = true;

                    XtraTabPage xtraTabPage = getTabPage("عرض الأطقم");
                    if (xtraTabPage == null)
                    {
                        xtraTabControlStoresContent.TabPages.Add("عرض الأطقم");
                        xtraTabPage = getTabPage("عرض الأطقم");
                    }

                    xtraTabPage.Controls.Clear();
                    xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;

                    Ataqm objForm = new Ataqm(this);

                    objForm.TopLevel = false;
                    xtraTabPage.Controls.Add(objForm);
                    objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    objForm.Dock = DockStyle.Fill;
                    //objForm.DisplayAtaqm();
                    objForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //Ataqm Tagame3
            private void navBarItem3_LinkClicked(object sender, NavBarLinkEventArgs e)
            {
                try
                {
                    restForeColorOfNavBarItem();
                    NavBarItem navBarItem = (NavBarItem)sender;
                    navBarItem.Appearance.ForeColor = Color.Blue;
                    if (!xtraTabControlStoresContent.Visible)
                        xtraTabControlStoresContent.Visible = true;

                    XtraTabPage xtraTabPage = getTabPage("تجميع الأطقم");
                    if (xtraTabPage == null)
                    {
                        xtraTabControlStoresContent.TabPages.Add("تجميع الأطقم");
                        xtraTabPage = getTabPage("تجميع الأطقم");
                    }

                    xtraTabPage.Controls.Clear();
                    xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;

                    SetTagame3 objForm = new SetTagame3();

                    objForm.TopLevel = false;
                    xtraTabPage.Controls.Add(objForm);
                    objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    objForm.Dock = DockStyle.Fill;
                    //objForm.DisplayAtaqm();
                    objForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
            //Ataqm Fak
            private void navBarItem4_LinkClicked(object sender, NavBarLinkEventArgs e)
            {
                try
                {
                    restForeColorOfNavBarItem();
                    NavBarItem navBarItem = (NavBarItem)sender;
                    navBarItem.Appearance.ForeColor = Color.Blue;
                    if (!xtraTabControlStoresContent.Visible)
                        xtraTabControlStoresContent.Visible = true;

                    XtraTabPage xtraTabPage = getTabPage("فك الأطقم");
                    if (xtraTabPage == null)
                    {
                        xtraTabControlStoresContent.TabPages.Add("فك الأطقم");
                        xtraTabPage = getTabPage("فك الأطقم");
                    }

                    xtraTabPage.Controls.Clear();
                    xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;

                    SetFak objForm = new SetFak();

                    objForm.TopLevel = false;
                    xtraTabPage.Controls.Add(objForm);
                    objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    objForm.Dock = DockStyle.Fill;
                    //objForm.DisplayAtaqm();
                    objForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        } 
        #endregion

        //storage
        private void navBarItem1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                restForeColorOfNavBarItem();
                NavBarItem navBarItem = (NavBarItem)sender;
                navBarItem.Appearance.ForeColor = Color.Blue;
                if (!xtraTabControlStoresContent.Visible)
                    xtraTabControlStoresContent.Visible = true;

                XtraTabPage xtraTabPage = getTabPage(" كميات البنود");
                if (xtraTabPage == null)
                {
                    xtraTabControlStoresContent.TabPages.Add(" كميات البنود");
                    xtraTabPage = getTabPage(" كميات البنود");
                }

                xtraTabPage.Controls.Clear();
                xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;

                Storage objForm = new Storage(this);

                objForm.TopLevel = false;
                xtraTabPage.Controls.Add(objForm);
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                //objForm.DisplayAtaqm();
                objForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControlStoresContent_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
                XtraTabPage xtraTabPage = (XtraTabPage)arg.Page;
                if (xtraTabPage.ImageOptions.Image != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to Close this page without save?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        xtraTabControlStoresContent.TabPages.Remove(arg.Page as XtraTabPage);
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }
                else
                {
                    xtraTabControlStoresContent.TabPages.Remove(arg.Page as XtraTabPage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void xtraTabControlMainContainer_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
                XtraTabPage xtraTabPage = (XtraTabPage)arg.Page;
                if (!IsTabPageSave())
                {
                    DialogResult dialogResult = MessageBox.Show("There are unsave Pages To you wound close anyway?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        xtraTabControlMainContainer.TabPages.Remove(arg.Page as XtraTabPage);
                        flag = false;
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }
                else
                {
                    xtraTabControlMainContainer.TabPages.Remove(arg.Page as XtraTabPage);
                    flag = false;
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void StoreMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {        
                if (!IsTabPageSave())
                {
                    DialogResult dialogResult = MessageBox.Show("There are unsave Pages To you wound close anyway?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Environment.Exit(0);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        e.Cancel = (dialogResult == DialogResult.No);
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //functions
        //stores
        public void bindDisplayStoresForm(XtraTabPage xtraTabPage)
        {
            Stores objForm = new Stores(this);
            objForm.TopLevel = false;
            
            xtraTabPage.Controls.Add(objForm);
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
        public void bindRecordStoresForm(Stores stores)
        {
            Store_Record objForm = new Store_Record(stores,xtraTabControlStoresContent);

            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("أضافة مخزن");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("أضافة مخزن");
                xtraTabPage = getTabPage("أضافة مخزن");
               
            }
            xtraTabPage.Controls.Clear();
            xtraTabPage.Controls.Add(objForm);
            xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;

            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
          
        }
        public void bindUpdateStoresForm(DataRowView selRow,Stores stores)
        {
            int id =Convert.ToInt16(selRow[0].ToString());

            Store_Update objForm = new Store_Update(id, stores, xtraTabControlStoresContent);
            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("تعديل مخزن");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("تعديل مخزن");
                xtraTabPage = getTabPage("تعديل مخزن");
                xtraTabPage.Controls.Clear();
                xtraTabPage.Controls.Add(objForm);
                xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.Show();
            }
            else if (xtraTabPage.ImageOptions.Image != null)
            {
                DialogResult dialogResult = MessageBox.Show("There is unsave data To you wound override it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    xtraTabPage.Controls.Clear();
                    xtraTabPage.Controls.Add(objForm);
                    xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                    objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    objForm.Dock = DockStyle.Fill;
                    objForm.Show();
                }
                else if (dialogResult == DialogResult.No)
                {
                    xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                }
            }
            else
            {
                xtraTabPage.Controls.Clear();
                xtraTabPage.Controls.Add(objForm);
                xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.Show();
            }

}
        public void bindReportStoresForm(GridControl gridControl)
        {
            Store_Report objForm = new Store_Report(gridControl);
            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("تقرير المخازن");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("تقرير المخازن");
                xtraTabPage = getTabPage("تقرير المخازن");
            }
            xtraTabPage.Controls.Clear();
            xtraTabPage.Controls.Add(objForm);
            xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
        public void bindStorePlacesForm(DataRowView storeRow)
        {
            DataRowView storeRow1 = storeRow;
            StorePlaces objForm = new StorePlaces(storeRow1);
            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("أماكن التخزين");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("أماكن التخزين");
                xtraTabPage = getTabPage("أماكن التخزين");
            }
            xtraTabPage.Controls.Clear();
            xtraTabPage.Controls.Add(objForm);
            xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
        //Products
        public void bindDisplayProductsForm(XtraTabPage xtraTabPage)
        {
            Products objForm = new Products(this);
            objForm.TopLevel = false;

            xtraTabPage.Controls.Add(objForm);
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
        public void bindRecordProductForm(Products products)
        {
            Product_Record objForm = new Product_Record(products, xtraTabControlStoresContent);

            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("أضافة بند");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("أضافة بند");
                xtraTabPage = getTabPage("أضافة بند");
            }
            xtraTabPage.Controls.Clear();
            xtraTabPage.Controls.Add(objForm);
            xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;

            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();

        }
        public void bindUpdateProductForm(DataRowView prodRow,Products products)
        {
            Product_Update objForm = new Product_Update(prodRow, products, xtraTabControlStoresContent);
            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("تعديل بند");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("تعديل بند");
                xtraTabPage = getTabPage("تعديل بند");
                xtraTabPage.Controls.Clear();
                xtraTabPage.Controls.Add(objForm);
                xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.Show();
            }
            else if (xtraTabPage.ImageOptions.Image != null)
            {
                DialogResult dialogResult = MessageBox.Show("There is unsave data To you wound override it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    xtraTabPage.Controls.Clear();
                    xtraTabPage.Controls.Add(objForm);
                    xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                    objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    objForm.Dock = DockStyle.Fill;
                    objForm.Show();
                }
                else if (dialogResult == DialogResult.No)
                {
                    xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                }
            }
            else
            {
                xtraTabPage.Controls.Clear();
                xtraTabPage.Controls.Add(objForm);
                xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.Show();
            }

        }
        public void bindReportProductForm(GridControl gridControl)
        {
            Product_Report objForm = new Product_Report(gridControl, "تقرير البنود");
            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("تقرير البنود");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("تقرير البنود");
                xtraTabPage = getTabPage("تقرير البنود");
            }
            xtraTabPage.Controls.Clear();
            xtraTabPage.Controls.Add(objForm);
            xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
        //Sets
        public void bindDisplaySetsForm(XtraTabPage xtraTabPage)
        {
            Ataqm objForm = new Ataqm(this);
            objForm.TopLevel = false;

            xtraTabPage.Controls.Add(objForm);
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
        public void bindRecordSetForm(Ataqm ataqm)
        {
            SetRecord objForm = new SetRecord(ataqm, xtraTabControlStoresContent);

            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("أضافة طقم");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("أضافة طقم");
                xtraTabPage = getTabPage("أضافة طقم");
            }
            xtraTabPage.Controls.Clear();
            xtraTabPage.Controls.Add(objForm);
            xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;

            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();

        }
        public void bindUpdateSetForm(DataRowView prodRow,Ataqm ataqm)
        {
            SetUpdate objForm = new SetUpdate(prodRow,ataqm,xtraTabControlStoresContent);
            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("تعديل طقم");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("تعديل طقم");
                xtraTabPage = getTabPage("تعديل طقم");
                xtraTabPage.Controls.Clear();
                xtraTabPage.Controls.Add(objForm);
                xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.Show();
            }
            else if (xtraTabPage.ImageOptions.Image != null)
            {
                DialogResult dialogResult = MessageBox.Show("There is unsave data To you wound override it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    xtraTabPage.Controls.Clear();
                    xtraTabPage.Controls.Add(objForm);
                    xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                    objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    objForm.Dock = DockStyle.Fill;
                    objForm.Show();
                }
                else if (dialogResult == DialogResult.No)
                {
                    xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                }
            }
            else
            {
                xtraTabPage.Controls.Clear();
                xtraTabPage.Controls.Add(objForm);
                xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.Show();
            }

        }
        public void bindReportSetForm(GridControl gridControl)
        {
            SetReport objForm = new SetReport(gridControl);
            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("تقرير أطقم");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("تقرير أطقم");
                xtraTabPage = getTabPage("تقرير أطقم");
            }
            xtraTabPage.Controls.Clear();
            xtraTabPage.Controls.Add(objForm);
            xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
        //storag
        public void bindRecordStorageForm(Storage storage)
        {
            initialCodeStorage objForm = new initialCodeStorage(storage,xtraTabControlStoresContent);

            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("تسجيل كميات البنود");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("تسجيل كميات البنود");
                xtraTabPage = getTabPage("تسجيل كميات البنود");

            }
            xtraTabPage.Controls.Clear();
            xtraTabPage.Controls.Add(objForm);
            xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;

            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
        public void bindReportStorageForm(GridControl gridControl)
        {
            Product_Report objForm = new Product_Report(gridControl, "تقرير كميات البنود");
            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("تقرير كميات البنود");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("تقرير كميات البنود");
                xtraTabPage = getTabPage("تقرير كميات البنود");
            }
            xtraTabPage.Controls.Clear();
            xtraTabPage.Controls.Add(objForm);
            xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
        public void bindUpdateStorageForm(List<DataRowView> rows, Storage storage)
        {
            UpdateCodeStorage objForm = new UpdateCodeStorage(rows, storage,xtraTabControlStoresContent);
            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("تعديل  كمية بند");
            if (xtraTabPage == null)
            {
                xtraTabControlStoresContent.TabPages.Add("تعديل  كمية بند");
                xtraTabPage = getTabPage("تعديل  كمية بند");
                xtraTabPage.Controls.Clear();
                xtraTabPage.Controls.Add(objForm);
                xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.Show();
            }
            else if (xtraTabPage.ImageOptions.Image != null)
            {
                DialogResult dialogResult = MessageBox.Show("There is unsave data To you wound override it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    xtraTabPage.Controls.Clear();
                    xtraTabPage.Controls.Add(objForm);
                    xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                    objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    objForm.Dock = DockStyle.Fill;
                    objForm.Show();
                }
                else if (dialogResult == DialogResult.No)
                {
                    xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                }
            }
            else
            {
                xtraTabPage.Controls.Clear();
                xtraTabPage.Controls.Add(objForm);
                xtraTabControlStoresContent.SelectedTabPage = xtraTabPage;
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.Show();
            }

        }

        public XtraTabPage getTabPage(string text)
        {
            for (int i = 0; i < xtraTabControlStoresContent.TabPages.Count; i++)
                if (xtraTabControlStoresContent.TabPages[i].Text == text)
                {
                    return xtraTabControlStoresContent.TabPages[i];
                }
            return null;
        }
        public bool IsTabPageSave()
        {
            for (int i = 0; i < xtraTabControlStoresContent.TabPages.Count; i++)
                if (xtraTabControlStoresContent.TabPages[i].ImageOptions.Image!=null)
                {
                    return false;
                }
            return true;
        }
        public void restForeColorOfNavBarItem()
        {
            foreach (NavBarItem item in navBarControl1.Items)
            {
                item.Appearance.ForeColor = Color.Black;
            }
        }
        private void StoreMainForm_Resize(object sender, EventArgs e)
        {
            try
            {
                if (SetUpdate.tipImage != null)
                {
                    SetUpdate.tipImage.Close();
                    SetUpdate.tipImage = null;
                }
                if (SetRecord.tipImage != null)
                {
                    SetRecord.tipImage.Close();
                    SetRecord.tipImage = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

       
    }

    public static class connection
    {
    //  public static string connectionString = "SERVER=192.168.1.200;DATABASE=test;user=Devccc;PASSWORD=rootroot;CHARSET=utf8";
        public static string connectionString = "SERVER=localhost;DATABASE=testcoding;user=root;PASSWORD=root;CHARSET=utf8";

    }
}