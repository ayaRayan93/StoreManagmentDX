using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoresManagmentDX
{
    public partial class initialCodeStorage : Form
    {
        MySqlConnection conn;
        int[] courrentIDs;//store ids of products which added to gridview2
        int count = 0;//store count of products in grid view
        bool loaded = false;
        int startNewRecord;
        public initialCodeStorage()
        {
            InitializeComponent();
            courrentIDs = new int[100];
            conn = new MySqlConnection(connection.connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "select * from type";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comType.DataSource = dt;               
                comType.DisplayMember = dt.Columns["Type_Name"].ToString();
                comType.ValueMember = dt.Columns["Type_ID"].ToString();
                comType.Text = "";
                txtType.Text = "";

                query = "select * from factory";
                 da = new MySqlDataAdapter(query, conn);
                 dt = new DataTable();
                da.Fill(dt);
                comFactory.DataSource = dt;             
                comFactory.DisplayMember = dt.Columns["Factory_Name"].ToString();
                comFactory.ValueMember = dt.Columns["Factory_ID"].ToString();
                comFactory.Text = "";
                txtFactory.Text = "";

                query = "select * from groupo";
                da = new MySqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);
                comGroup.DataSource = dt;
                comGroup.DisplayMember = dt.Columns["Group_Name"].ToString();
                comGroup.ValueMember = dt.Columns["Group_ID"].ToString();
                comGroup.Text = "";
                txtGroup.Text = "";

                query = "select * from product";
                da = new MySqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);
                comProduct.DataSource = dt;
                comProduct.DisplayMember = dt.Columns["Product_Name"].ToString();
                comProduct.ValueMember = dt.Columns["Product_ID"].ToString();
                comProduct.Text = "";
                txtProduct.Text = "";

                query = "select * from store";
                da = new MySqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);
                comStore.DataSource = dt;
                comStore.DisplayMember = dt.Columns["Store_Name"].ToString();
                comStore.ValueMember = dt.Columns["Store_ID"].ToString();
                comStore.Text = "";

                //query = "select * from supplier";
                //da = new MySqlDataAdapter(query, conn);
                //dt = new DataTable();
                //da.Fill(dt);
                //comSupplier.DataSource = dt;
                //comSupplier.DisplayMember = dt.Columns["Supplier_Name"].ToString();
                //comSupplier.ValueMember = dt.Columns["Supplier_ID"].ToString();
                //comSupplier.Text = "";

                loaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void comType_SelectedValueChanged(object sender, EventArgs e)
        {
            txtType.Text = comType.SelectedValue.ToString();
        }
        private void comFactory_SelectedValueChanged(object sender, EventArgs e)
        {
            txtFactory.Text = comFactory.SelectedValue.ToString();
        }
        private void comProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            txtProduct.Text = comProduct.SelectedValue.ToString();
        }
        private void comGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            txtGroup.Text = comGroup.SelectedValue.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string q1, q2, q3, q4;
            if (txtType.Text == "")
            {
                q1 = "select Type_ID from data";
            }
            else
            {
                q1 = txtType.Text;
            }
            if (txtFactory.Text == "")
            {
                q2 = "select Factory_ID from data";
            }
            else
            {
                q2 = txtFactory.Text;
            }
            if (txtProduct.Text == "")
            {
                q3 = "select Product_ID from data";
            }
            else
            {
                q3 = txtProduct.Text;
            }
            if (txtGroup.Text == "")
            {
                q4 = "select Group_ID from data";
            }
            else
            {
                q4 = txtGroup.Text;
            }

            //string query = "select Colour as 'لون', Size as 'حجم', Sort as 'الفرز', Description as 'الوصف', Type_Name as 'النوع', Factory_Name as 'المصنع' ,Group_Name as 'المجموعة', Product_Name as 'المنتج' from data , type,factory,groupo,product where data.Type_ID=type.Type_ID and Type_ID IN(" + q1 + ") and data.Factory_ID=factory.Factory_ID and Factory_ID  IN(" + q2 + ") and data.Group_ID=groupo.Group_ID and Group_ID IN (" + q4 + ") and data.Product_ID=product.Product_ID and Product_ID IN (" + q3 + ")";
            string query = "select data.Code as 'كود' , data.Colour as 'لون', data.Size as 'حجم', data.Sort as 'الفرز', data.Description as 'الوصف', type.Type_Name as 'النوع', factory.Factory_Name as 'المصنع' ,groupo.Group_Name as 'المجموعة', product.Product_Name as 'المنتج' from data INNER JOIN type ON type.Type_ID = data.Type_ID INNER JOIN product ON product.Product_ID = data.Product_ID INNER JOIN factory ON data.Factory_ID = factory.Factory_ID INNER JOIN groupo ON data.Group_ID = groupo.Group_ID   where data.Type_ID IN(" + q1 + ") and  data.Factory_ID  IN(" + q2 + ") and data.Group_ID IN (" + q4 + ") and data.Product_ID IN (" + q3 + ")";

            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void txtType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                try
                {

                    if (txtType.Text != "")
                    {
                        conn.Open();
                        string query = "select Type_Name from type where Type_ID='" + txtType.Text + "'";
                        MySqlCommand com = new MySqlCommand(query, conn);
                        string TypeName = (string)com.ExecuteScalar();
                        comType.Text = TypeName;
                        txtFactory.Focus();
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }

        private void txtFactory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    if (txtFactory.Text != "")
                    {
                        conn.Open();
                        string query = "select Factory_Name from factory where Factory_ID='" + txtFactory.Text + "'";
                        MySqlCommand com = new MySqlCommand(query, conn);
                        string TypeName = (string)com.ExecuteScalar();
                        comFactory.Text = TypeName;
                        txtGroup.Focus();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }

        private void txtGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                try
                {

                    if (txtGroup.Text != "")
                    {
                        conn.Open();
                        string query = "select Group_Name from groupo where Group_ID='" + txtGroup.Text + "'";
                        MySqlCommand com = new MySqlCommand(query, conn);
                        string TypeName = (string)com.ExecuteScalar();
                        comGroup.Text = TypeName;
                        txtProduct.Focus();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }

        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                try
                {

                    if (txtProduct.Text != "")
                    {
                        conn.Open();
                        string query = "select Product_Name from product where Product_ID='" + txtProduct.Text + "'";
                        MySqlCommand com = new MySqlCommand(query, conn);
                        string TypeName = (string)com.ExecuteScalar();
                        comProduct.Text = TypeName;
                        txtType.Focus();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }

        private void comSupplier_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (loaded)
            //{
            //    //label15.Visible = true;
            //    //txtPermissionNum.Visible = true;
            //    string q = "select Permission_Number from storage where Supplier_Name='" + comSupplier.Text + "' ORDER BY Storage_ID DESC LIMIT 1 ";
            //    conn.Open();
            //    MySqlCommand com = new MySqlCommand(q, conn);
            //    try
            //    {
            //        int r = int.Parse(com.ExecuteScalar().ToString());
            //        int sum = r + 1;
            //        //txtPermissionNum.Text = sum.ToString();
            //        conn.Close();
            //    }
            //    catch
            //    {
            //        //label15.Visible = true;
            //        //txtPermissionNum.Visible = true;
            //        //txtPermissionNum.Text = "1";
                    
            //    }
            //    conn.Close();
            //}

        }

        private void txtPermissionNum_TextChanged(object sender, EventArgs e)
        {
            //if (txtPermissionNum.Text != "")
            //{
            //    clear();
            //    count = 0;
            //    courrentIDs.Initialize();
            //    try
            //    {
            //        conn.Close();
            //        conn.Open();
            //        string q1 = "select Storage_ID from storage where Permission_Number=" + txtPermissionNum.Text + " and Supplier_Name='" + comSupplier.Text + "'";
            //        MySqlCommand com = new MySqlCommand(q1, conn);
            //        MySqlDataReader dr = com.ExecuteReader();
            //        while (dr.Read())
            //        {
            //            courrentIDs[count] =Convert.ToInt16(dr["Storage_ID"]);
            //            count++;
            //        }
            //        startNewRecord = count;
            //        dr.Close();
            //        string str = "";
            //        for (int i = 0; i < courrentIDs.Length - 1; i++)
            //        {
            //            if (courrentIDs[i] != 0)
            //            {
            //                str += courrentIDs[i] + ",";
            //            }
            //        }
            //        str += courrentIDs[courrentIDs.Length - 1];
              
            //        string q = "select storage.Code as 'كود',type.Type_Name as 'النوع', factory.Factory_Name as 'المصنع',groupo.Group_Name as 'المجموعة',product.Product_Name as 'المنتج', storage.Store_Name as 'المخزن', storage.Supplier_Name as 'المورد',storage.Balatat as 'بلتات', storage.Carton_Balata as 'عدد الكراتين',storage.Total_Meters as 'اجمالي عدد الامتار', storage.Storage_Date as 'تاريخ التخزين' , storage.Store_Place as 'مكان التخزين'  , storage.Note as 'ملاحظة',storage.Permission_Number as 'اذن المخزن' from storage INNER JOIN data  ON storage.Code = data.Code INNER JOIN type ON type.Type_ID = data.Type_ID INNER JOIN product ON product.Product_ID = data.Product_ID INNER JOIN factory ON data.Factory_ID = factory.Factory_ID INNER JOIN groupo ON data.Group_ID = groupo.Group_ID where Permission_Number=" + txtPermissionNum.Text + " and Supplier_Name='" + comSupplier.Text + "' and Storage_ID in (" + str + ") ";              
            //        MySqlDataAdapter da = new MySqlDataAdapter(q, conn);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        dataGridView2.DataSource = dt;                  
            //        dataGridView2.DefaultCellStyle.BackColor = Color.Tomato;                
            //        txtCode.Focus();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    conn.Close();
            //}
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                if (txtNoCarton.Text != "" && txtNoPalatat.Text != "" && txtStorePlace.Text != "" && txtCode.Text != "")
                {
                    string code = txtCode.Text;
                    int StoreID = int.Parse(comStore.SelectedValue.ToString());
                    string q = "select carton from data where Code='" + code + "'";
                    MySqlCommand com = new MySqlCommand(q, conn);
                    double carton = double.Parse(com.ExecuteScalar().ToString());
                    int NoBalatat;
                    int.TryParse(txtNoPalatat.Text, out NoBalatat);
                    int NoCartons;
                    int.TryParse(txtNoCarton.Text, out NoCartons);
                    double total = carton * NoBalatat * NoCartons;
                    labTotalMeter.Text = (total).ToString();

                    string query = "insert into Storage (Store_ID,Store_Name,Storage_Date,Balatat,Carton_Balata,Code,Store_Place,Total_Meters,Supplier_Name,Note,Permission_Number) values (@Store_ID,@Store_Name,@Date,@NoBalatat,@NoCartonInBalata,@CodeOfProduct,@PlaceOfStore,@TotalOfMeters,@Supplier,@Note,@Permission_Number)";
                    com = new MySqlCommand(query, conn);
                    com.Parameters.Add("@Store_ID", MySqlDbType.Int16);
                    com.Parameters["@Store_ID"].Value = StoreID;
                    com.Parameters.Add("@Store_Name", MySqlDbType.VarChar);
                    com.Parameters["@Store_Name"].Value = comStore.Text;
                    com.Parameters.Add("@Date", MySqlDbType.Date, 0);
                    com.Parameters["@Date"].Value = dateTimePicker1.Value;
                    com.Parameters.Add("@NoBalatat", MySqlDbType.Int16);
                    com.Parameters["@NoBalatat"].Value = NoBalatat;
                    com.Parameters.Add("@NoCartonInBalata", MySqlDbType.Int16);
                    com.Parameters["@NoCartonInBalata"].Value = NoCartons;
                    com.Parameters.Add("@CodeOfProduct", MySqlDbType.VarChar);
                    com.Parameters["@CodeOfProduct"].Value = txtCode.Text;
                    com.Parameters.Add("@PlaceOfStore", MySqlDbType.VarChar);
                    com.Parameters["@PlaceOfStore"].Value = txtStorePlace.Text;
                    com.Parameters.Add("@TotalOfMeters", MySqlDbType.Decimal);
                    com.Parameters["@TotalOfMeters"].Value = total;
                    com.Parameters.Add("@Supplier", MySqlDbType.VarChar);
                    //com.Parameters["@Supplier"].Value = comSupplier.Text;
                    //com.Parameters.Add("@Note", MySqlDbType.VarChar);
                    com.Parameters["@Note"].Value = txtNote.Text;
                    //com.Parameters.Add("@Permission_Number", MySqlDbType.Int16);
                    //com.Parameters["@Permission_Number"].Value = int.Parse(txtPermissionNum.Text);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Add success");
                }
                else
                {
                    MessageBox.Show("you must fill all fields please");
                    conn.Close();
                    return;
                }
                string q1 = "select Storage_ID from storage ORDER BY Storage_ID DESC LIMIT 1";  
                MySqlCommand comm = new MySqlCommand(q1,conn);
                int id = (int)comm.ExecuteScalar();
                
                courrentIDs[count] = id;
                count++;

                string str = "";
                for (int i = 0; i < courrentIDs.Length-1; i++)
                {
                    if (courrentIDs[i]!=0)
                    {
                        str += courrentIDs[i] + ",";
                    }
                }
                str += courrentIDs[courrentIDs.Length - 1];

                string qq = "select storage.Code as 'كود',type.Type_Name as 'النوع', factory.Factory_Name as 'المصنع',groupo.Group_Name as 'المجموعة',product.Product_Name as 'المنتج', storage.Store_Name as 'المخزن', storage.Supplier_Name as 'المورد',storage.Balatat as 'بلتات', storage.Carton_Balata as 'عدد الكراتين',storage.Total_Meters as 'اجمالي عدد الامتار', storage.Storage_Date as 'تاريخ التخزين' , storage.Store_Place as 'مكان التخزين'  , storage.Note as 'ملاحظة' from storage INNER JOIN data  ON storage.Code = data.Code INNER JOIN type ON type.Type_ID = data.Type_ID INNER JOIN product ON product.Product_ID = data.Product_ID INNER JOIN factory ON data.Factory_ID = factory.Factory_ID INNER JOIN groupo ON data.Group_ID = groupo.Group_ID where Storage_ID in (" + str+") ";
                MySqlDataAdapter da = new MySqlDataAdapter(qq, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl2.DataSource = dt;
                //for (int i = startNewRecord; i < courrentIDs.Length; i++)
                //{
                //    if (courrentIDs[i] > 0)
                //        gridControl2.Rows[i].DefaultCellStyle.BackColor = Color.White;
                //    else
                //        break;
                //}

                //gridControl2.FirstDisplayedScrollingRowIndex = dataGridView2.RowCount - 1;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = gridView1.Rows[gridView1.SelectedCells[0].RowIndex];
            //string v = row.Cells[0].Value.ToString();
            //txtCode.Text = v;
        }

        private void txtNoPalatat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                string code = txtCode.Text;
                int StoreID = int.Parse(comStore.SelectedValue.ToString());
                string q = "select carton from data where Code='" + code + "'";
                MySqlCommand com = new MySqlCommand(q, conn);
                double carton = double.Parse(com.ExecuteScalar().ToString());
                int NoBalatat;
                int.TryParse(txtNoPalatat.Text, out NoBalatat);
                int NoCartons;
                int.TryParse(txtNoCarton.Text, out NoCartons);
                double total = carton * NoBalatat * NoCartons;
                labTotalMeter.Text = (total).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        //functions
        public void clear()
        {
            txtCode.Text = txtNoCarton.Text = txtNoPalatat.Text = txtNote.Text = txtStorePlace.Text = labTotalMeter.Text = "";
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void labTotalMeter_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }


}
