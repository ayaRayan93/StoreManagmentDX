using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class ProductItems : Form
    {
        MySqlConnection dbconnection;
        DataGridViewRow row1 = null;
        bool load = false;
        public ProductItems()
        {
            try
            {         
                InitializeComponent();
                dbconnection = new MySqlConnection(connection.connectionString);
                mTC_Content.SelectedIndex = 6;
                displayType();
                txtType.Focus();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //header tabs
        private void btnSwitchTab_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                switch (btn.Name)
                {
                    case "btnType":
                        mTC_Content.SelectedIndex = 6;
                        displayType();
                        txtType.Focus();
                        break;
                    case "btnFactory":
                        mTC_Content.SelectedIndex = 5;
                        displayFactory();
                        comType.Focus();
                        break;
                    case "btnGroup":
                        mTC_Content.SelectedIndex = 4;
                        displayGroup();
                        comFactory.Focus();
                        break;
                    case "btnProduct":
                        mTC_Content.SelectedIndex = 3;
                        displayProduct();
                        comFactoryGroup.Focus();
                        break;
                    case "btnColor":
                        mTC_Content.SelectedIndex = 2;
                        displayColor();
                        comType2.Focus();
                        break;
                    case "btnSize":
                        mTC_Content.SelectedIndex = 1;
                        displaySize();
                        comFactory.Focus();
                        break;
                    case "btnSort":
                        mTC_Content.SelectedIndex = 0;
                        displaySort();
                        txtSort.Focus();

                        break;
                       
                }
                ClearButtonsColor();
                btn.BackColor = Color.FromArgb(194,192,192);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductItems_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from type";
                MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comType.DataSource = dt;
                comType.DisplayMember = dt.Columns["Type_Name"].ToString();
                comType.ValueMember = dt.Columns["Type_ID"].ToString();
                comType.Text = "";

                da = new MySqlDataAdapter(query, dbconnection);
                dt = new DataTable();
                da.Fill(dt);
                comType2.DataSource = dt;
                comType2.DisplayMember = dt.Columns["Type_Name"].ToString();
                comType2.ValueMember = dt.Columns["Type_ID"].ToString();
                comType2.Text = "";


                query = "select distinct * from factory";
                da = new MySqlDataAdapter(query, dbconnection);
                dt = new DataTable();
                da.Fill(dt);
                comFactory.DataSource = dt;
                comFactory.DisplayMember = dt.Columns["Factory_Name"].ToString();
                comFactory.ValueMember = dt.Columns["Factory_ID"].ToString();
                comFactory.Text = "";

                da = new MySqlDataAdapter(query, dbconnection);
                dt = new DataTable();
                da.Fill(dt);
                comFactory2.DataSource = dt;
                comFactory2.DisplayMember = dt.Columns["Factory_Name"].ToString();
                comFactory2.ValueMember = dt.Columns["Factory_ID"].ToString();
                comFactory2.Text = "";

                da = new MySqlDataAdapter(query, dbconnection);
                dt = new DataTable();
                da.Fill(dt);
                comFactoryGroup.DataSource = dt;
                comFactoryGroup.DisplayMember = dt.Columns["Factory_Name"].ToString();
                comFactoryGroup.ValueMember = dt.Columns["Factory_ID"].ToString();
                comFactoryGroup.Text = "";
                query = "select distinct * from groupo";
                da = new MySqlDataAdapter(query, dbconnection);
                dt = new DataTable();
                da.Fill(dt);
                comGroup.DataSource = dt;
                comGroup.DisplayMember = dt.Columns["Group_Name"].ToString();
                comGroup.ValueMember = dt.Columns["Group_ID"].ToString();
                comGroup.Text = "";

                load = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                row1 = null;
                RestControls();
                switch (mTC_Content.SelectedIndex)
                {
                    case 6 :
                        ClearButtonsColor();
                        btnType.BackColor = Color.FromArgb(194, 192, 192);
                        txtType.Focus();
                        break;
                    case 5:
                        ClearButtonsColor();
                        btnFactory.BackColor = Color.FromArgb(194, 192, 192);
                        comType.Focus();
                        break;
                    case 4:
                        ClearButtonsColor();
                        btnGroup.BackColor = Color.FromArgb(194, 192, 192);
                        comFactory.Focus();
                        break;
                    case 3:
                        ClearButtonsColor();
                        btnProduct.BackColor = Color.FromArgb(194, 192, 192);
                        comFactoryGroup.Focus();
                        break;
                    case 2:
                        ClearButtonsColor();
                        btnColor.BackColor = Color.FromArgb(194, 192, 192);
                        comType2.Focus();
                        break;
                    case 1:
                        ClearButtonsColor();
                        btnSize.BackColor = Color.FromArgb(194, 192, 192);
                        comFactory2.Focus();
                        break;
                    case 0:
                        ClearButtonsColor();
                        btnSort.BackColor = Color.FromArgb(194, 192, 192);
                        txtSort.Focus();
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region type panel
        private void btnType_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                string query = "select Type_ID from type where Type_Name = '" + txtType.Text + "'";
                MySqlCommand com = new MySqlCommand(query, dbconnection);
                if (com.ExecuteScalar() == null)
                {
                    if (txtType.Text != "")
                    {
                        query = "insert into type (Type_Name) values (@name)";
                        com = new MySqlCommand(query, dbconnection);
                        com.Parameters.AddWithValue("@name", txtType.Text);
                        com.ExecuteNonQuery();
                        
                        query = "select Type_ID from type order by Type_ID desc limit 1";
                        com = new MySqlCommand(query, dbconnection);
                        
                        UserControl.UserRecord("type","add", com.ExecuteScalar().ToString(), DateTime.Now,dbconnection);
                      
                        displayType();
                    }
                    else
                    {
                        txtType.Focus();
                        
                    }
                }
                else
                {
                    MessageBox.Show("This type already exist");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void txtType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dbconnection.Open();
                    string query = "select Type_ID from type where Type_Name = '" + txtType.Text + "'";
                    MySqlCommand com = new MySqlCommand(query, dbconnection);
                    if (com.ExecuteScalar() == null)
                    {
                        if (txtType.Text != "")
                        {
                            query = "insert into type (Type_Name) values (@name)";
                            com = new MySqlCommand(query, dbconnection);
                            com.Parameters.AddWithValue("@name", txtType.Text);
                            com.ExecuteNonQuery();
                            
                            query = "select Type_ID from type order by Type_ID desc limit 1";
                            com = new MySqlCommand(query, dbconnection);

                            UserControl.UserRecord("type", "add", com.ExecuteScalar().ToString(), DateTime.Now, dbconnection);

                            displayType();
                            txtType.Focus();
                            txtType.SelectAll();
                        }
                        else
                        {
                            txtType.Focus();    
                        }
                    }
                    else
                    {
                        MessageBox.Show("This type already exist");
                    }
                }
                else if (e.KeyCode==Keys.Tab)
                {
                    dataGridView1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
    
        private void btnDeleteType_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                // DataRowView storeRow = (DataRowView)(((GridView)dataGridView1.MainView).GetRow(((GridView)dataGridView1.MainView).GetSelectedRows()[0]));
                DataGridViewRow storeRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

                if (storeRow != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int id = Convert.ToInt16(storeRow.Cells[0].Value.ToString());
                        string query = "delete from type where Type_ID=" + id;
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        com.ExecuteNonQuery();
                        updateTablesDB("type", "Type_ID", id);
                        displayType();
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
                else
                {
                    MessageBox.Show("select row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("select row");
            }
            dbconnection.Close();
        }
        #endregion
        #region factory panel
        private void btnFactory_Click(object sender, EventArgs e)
        {
            try
            {
                if (comType.Text != "")
                {
                    dbconnection.Open();
                    string query = "select Factory_ID from factory where Factory_Name = '" + txtFactory.Text + "' and Type_ID=" + comType.SelectedValue;
                    MySqlCommand com = new MySqlCommand(query, dbconnection);
                    if (com.ExecuteScalar() == null)
                    {
                        if (txtFactory.Text != "")
                        {
                            query = "insert into factory (Factory_Name,Type_ID) values (@name,@Type_ID)";
                            com = new MySqlCommand(query, dbconnection);
                            com.Parameters.AddWithValue("@name", txtFactory.Text);
                            com.Parameters.AddWithValue("@Type_ID", Convert.ToInt16(comType.SelectedValue));
                            com.ExecuteNonQuery();
                            
                            displayFactory(Convert.ToInt16(comType.SelectedValue));
                            txtFactory.Focus();
                            txtFactory.SelectAll();
                        }
                        else
                        {
                            txtFactory.Focus();
                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("This factory already exist");
                    }
                }
                else
                {
                    MessageBox.Show("select type");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void txtFactory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (comType.Text != "")
                    {
                        dbconnection.Open();
                        string query = "select Factory_ID from factory where Factory_Name = '" + txtFactory.Text + "' and Type_ID=" + comType.SelectedValue;
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        if (com.ExecuteScalar() == null)
                        {
                            if (txtFactory.Text != "")
                            {
                                query = "insert into factory (Factory_Name,Type_ID) values (@name,@Type_ID)";
                                com = new MySqlCommand(query, dbconnection);
                                com.Parameters.AddWithValue("@name", txtFactory.Text);
                                com.Parameters.AddWithValue("@Type_ID", Convert.ToInt16(comType.SelectedValue));
                                com.ExecuteNonQuery();
                                
                                displayFactory(Convert.ToInt16(comType.SelectedValue));
                                txtFactory.Focus();
                                txtFactory.SelectAll();
                            }
                            else
                            {
                                txtFactory.Focus();
                             

                            }
                        }
                        else
                        {
                            MessageBox.Show("This factory already exist");
                        }
                    }
                    else
                    {
                        MessageBox.Show("select type");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void comType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    displayFactory((int)comType.SelectedValue);
                    txtFactory.Focus();
                    txtFactory.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (load)
                {
                    displayFactory((int)comType.SelectedValue);
                    txtFactory.Focus();
                    txtFactory.SelectAll();
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     
        private void btnDeleteFactory_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                // DataRowView row1 = (DataRowView)(((GridView)dataGridViewFactory.MainView).GetRow(((GridView)dataGridViewFactory.MainView).GetSelectedRows()[0]));
                DataGridViewRow row1 = dataGridViewFactory.Rows[dataGridViewFactory.SelectedCells[0].RowIndex];
                if (row1 != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int id = Convert.ToInt16(row1.Cells[0].Value.ToString());
                        string query = "delete from factory where Factory_ID=" + id;
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        com.ExecuteNonQuery();
                        updateTablesDB("factory", "Factory_ID", id);
                        if (comType2.Text != "")
                        {
                            displayFactory(Convert.ToInt16(comType2.SelectedValue));
                        }
                        else
                        {
                            displayFactory();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
                else
                {
                    MessageBox.Show("select row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("select row");
            }
            dbconnection.Close();
        }
        #endregion
        #region group panel
        private void btnGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (comFactory.Text != "")
                {
                    dbconnection.Open();
                    string query = "select Group_ID from groupo where Group_Name = '" + txtGroup.Text + "' and Factory_ID=" + comFactory.SelectedValue;
                    MySqlCommand com = new MySqlCommand(query, dbconnection);
                    if (com.ExecuteScalar() == null)
                    {
                        if (txtGroup.Text != "")
                        {
                            query = "insert into groupo (Group_Name,Factory_ID) values (@name,@Factory_ID)";
                            com = new MySqlCommand(query, dbconnection);
                            com.Parameters.AddWithValue("@name", txtGroup.Text);
                            com.Parameters.AddWithValue("@Factory_ID", Convert.ToInt16(comFactory.SelectedValue));
                            com.ExecuteNonQuery();
                            
                            displayGroup(Convert.ToInt16(comFactory.SelectedValue));
                            txtGroup.Focus();
                            txtGroup.SelectAll();
                        }
                        else
                        {
                            txtGroup.Focus();
                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("This group already exist");
                    }
                }
                else
                {
                    MessageBox.Show("select factory");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void txtGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (comFactory.Text != "")
                    {
                        dbconnection.Open();
                        string query = "select Group_ID from groupo where Group_Name = '" + txtGroup.Text + "' and Factory_ID=" + comFactory.SelectedValue;
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        if (com.ExecuteScalar() == null)
                        {
                            if (txtGroup.Text != "")
                            {
                                query = "insert into groupo (Group_Name,Factory_ID) values (@name,@Factory_ID)";
                                com = new MySqlCommand(query, dbconnection);
                                com.Parameters.AddWithValue("@name", txtGroup.Text);
                                com.Parameters.AddWithValue("@Factory_ID", Convert.ToInt16(comFactory.SelectedValue));
                                com.ExecuteNonQuery();
                                
                                displayGroup(Convert.ToInt16(comFactory.SelectedValue));
                                txtGroup.Focus();
                                txtGroup.SelectAll();
                            }
                            else
                            {
                                txtGroup.Focus();
                              
                            }
                        }
                        else
                        {
                            MessageBox.Show("This group already exist");
                        }
                    }
                    else
                    {
                        MessageBox.Show("select factory");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void comFactory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    displayGroup((int)comFactory.SelectedValue);
                    txtGroup.Focus();
                    txtGroup.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comFactory_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (load)
                {
                    displayGroup((int)comFactory.SelectedValue);
                    txtGroup.Focus();
                    txtGroup.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }     
        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                // DataRowView row1 = (DataRowView)(((GridView)dataGridViewGroup.MainView).GetRow(((GridView)dataGridViewGroup.MainView).GetSelectedRows()[0]));
                DataGridViewRow row1 = dataGridViewGroup.Rows[dataGridViewGroup.SelectedCells[0].RowIndex];

                if (row1 != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int id = Convert.ToInt16(row1.Cells[0].Value.ToString());
                        string query = "delete from groupo where Group_ID=" + id;
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        com.ExecuteNonQuery();
                        updateTablesDB("groupo", "Group_ID", id);
                        if (comFactory2.Text != "")
                        {
                            displayGroup(Convert.ToInt16(comFactory2.SelectedValue));
                        }
                        else
                        {
                            displayGroup();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
                else
                {
                    MessageBox.Show("select row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("select row");
            }
            dbconnection.Close();
        }
        #endregion
        #region product panel
        private void btnProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (comFactoryGroup.Text != "")
                {
                    dbconnection.Open();
                    string query = "select Product_ID from product where Product_Name = '" + txtProduct.Text + "' and Group_ID=" + comFactoryGroup.SelectedValue;
                    MySqlCommand com = new MySqlCommand(query, dbconnection);
                    if (com.ExecuteScalar() == null)
                    {
                        if (txtProduct.Text != "")
                        {
                            query = "insert into product (Product_Name,Group_ID) values (@name,@Group_ID)";
                            com = new MySqlCommand(query, dbconnection);
                            com.Parameters.AddWithValue("@name", txtProduct.Text);
                            com.Parameters.AddWithValue("@Group_ID", Convert.ToInt16(comFactoryGroup.SelectedValue));
                            com.ExecuteNonQuery();
                           
                            displayProduct(Convert.ToInt16(comFactoryGroup.SelectedValue));
                            txtProduct.Focus();
                            txtProduct.SelectAll();
                        }
                        else
                        {
                            txtProduct.Focus();
                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("This product already exist");
                    }
                }
                else
                {
                    MessageBox.Show("select group");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (comFactoryGroup.Text != "")
                    {
                        dbconnection.Open();
                        string query = "select Product_ID from product where Product_Name = '" + txtProduct.Text + "' and Group_ID=" + comFactoryGroup.SelectedValue;
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        if (com.ExecuteScalar() == null)
                        {
                            if (txtProduct.Text != "")
                            {
                                query = "insert into product (Product_Name,Group_ID) values (@name,@Group_ID)";
                                com = new MySqlCommand(query, dbconnection);
                                com.Parameters.AddWithValue("@name", txtProduct.Text);
                                com.Parameters.AddWithValue("@Group_ID", Convert.ToInt16(comFactoryGroup.SelectedValue));
                                com.ExecuteNonQuery();
                                
                                displayProduct(Convert.ToInt16(comFactoryGroup.SelectedValue));
                                txtProduct.Focus();
                                txtProduct.SelectAll();
                            }
                            else
                            {
                                txtProduct.Focus();
                               
                            }
                        }
                        else
                        {
                            MessageBox.Show("This product already exist");
                        }
                    }
                    else
                    {
                        MessageBox.Show("select group");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void comGroup2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    displayProduct((int)comGroup.SelectedValue);
                    txtProduct.Focus();
                    txtProduct.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comFactoryGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (load)
                {
                    string query = "select * from groupo where Factory_ID=" + comFactoryGroup.SelectedValue;
                    MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comGroup.DataSource = dt;
                    comGroup.DisplayMember = dt.Columns["Group_Name"].ToString();
                    comGroup.ValueMember = dt.Columns["Group_ID"].ToString();
                    comGroup.Text = "";
                    txtGroup.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                // DataRowView row1 = (DataRowView)(((GridView)dataGridViewGroup.MainView).GetRow(((GridView)dataGridViewGroup.MainView).GetSelectedRows()[0]));
                DataGridViewRow row1 = dataGridViewProduct.Rows[dataGridViewProduct.SelectedCells[0].RowIndex];

                if (row1 != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int id = Convert.ToInt16(row1.Cells[0].Value.ToString());
                        string query = "delete from product where Product_ID=" + id;
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        com.ExecuteNonQuery();
                        updateTablesDB("product", "Product_ID", id);
                        if (comFactoryGroup.Text != "")
                            displayProduct(Convert.ToInt16(comFactoryGroup.SelectedValue));
                        else
                            displayProduct();
                        txtProduct.Focus();
                        txtProduct.SelectAll();
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
                else
                {
                    MessageBox.Show("select row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("select row");
            }
            dbconnection.Close();
        }
        #endregion
        #region color panel
        private void btnColor_Click(object sender, EventArgs e)
        {
            try
            {
                if (comType2.Text != "")
                {
                    dbconnection.Open();
                    string query = "select Color_ID from color where Color_Name = '" + txtColor.Text + "' and Type_ID=" + Convert.ToInt16(comType2.SelectedValue);
                    MySqlCommand com = new MySqlCommand(query, dbconnection);
                    if (com.ExecuteScalar() == null)
                    {
                        if (txtColor.Text != "")
                        {
                            query = "insert into color (Color_Name,Type_ID) values (@name,@id)";
                            com = new MySqlCommand(query, dbconnection);
                            com.Parameters.AddWithValue("@name", txtColor.Text);
                            com.Parameters.AddWithValue("@id", Convert.ToInt16(comType2.SelectedValue));
                            com.ExecuteNonQuery();
                            
                            displayColor(Convert.ToInt16(comType2.SelectedValue));
                            txtColor.Focus();
                            txtColor.SelectAll();
                        }
                        else
                        {
                            txtColor.Focus();
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Color already exist");
                    }
                }
                else
                {
                    MessageBox.Show("select Type");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void txtColor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (comType2.Text != "")
                    {
                        dbconnection.Open();
                        string query = "select Color_ID from color where Color_Name = '" + txtColor.Text + "' and Type_ID=" + Convert.ToInt16(comType2.SelectedValue);
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        if (com.ExecuteScalar() == null)
                        {
                            if (txtColor.Text != "")
                            {
                                query = "insert into color (Color_Name,Type_ID) values (@name,@id)";
                                com = new MySqlCommand(query, dbconnection);
                                com.Parameters.AddWithValue("@name", txtColor.Text);
                                com.Parameters.AddWithValue("@id", Convert.ToInt16(comType2.SelectedValue));
                                com.ExecuteNonQuery();
                                
                                displayColor(Convert.ToInt16(comType2.SelectedValue));
                                txtColor.Focus();
                                txtColor.SelectAll();
                            }
                            else
                            {
                                txtColor.Focus();
                               
                            }
                        }
                        else
                        {
                            MessageBox.Show("This Color already exist");
                        }
                    }
                    else
                    {
                        MessageBox.Show("select Type");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void comType2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    displayColor((int)comType2.SelectedValue);
                    txtColor.Focus();
                    txtColor.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comType2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (load)
                {
                    displayColor((int)comType2.SelectedValue);
                    txtColor.Focus();
                    txtColor.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  
        private void btnDeleteColor_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                //   DataRowView row1 = (DataRowView)(((GridView)dataGridViewColor.MainView).GetRow(((GridView)dataGridViewColor.MainView).GetSelectedRows()[0]));
                DataGridViewRow row1 = dataGridViewColor.Rows[dataGridViewColor.SelectedCells[0].RowIndex];

                if (row1 != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int id = Convert.ToInt16(row1.Cells[0].Value.ToString());
                        string query = "delete from color where Color_ID=" + id;
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        com.ExecuteNonQuery();
                        updateTablesDB("color", "Color_ID", id);
                        if (comType.Text != "")
                        {
                            displayColor(Convert.ToInt16(comType.SelectedValue));
                        }
                        else
                        {
                            displayColor();
                        }
                      
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
                else
                {
                    MessageBox.Show("select row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("select row");
            }
            dbconnection.Close();
        }
        #endregion
        #region size panel
        private void btnSize_Click(object sender, EventArgs e)
        {
            try
            {
                if (comFactory2.Text != "")
                {
                    dbconnection.Open();
                    string query = "select Size_ID from size where Size_Value = '" + txtSize.Text + "' and Factory_ID=" + Convert.ToInt16(comFactory2.SelectedValue);
                    MySqlCommand com = new MySqlCommand(query, dbconnection);
                    if (com.ExecuteScalar() == null)
                    {
                        if (txtSize.Text != "")
                        {
                            query = "insert into size (Size_Value,Factory_ID) values (@name,@id)";
                            com = new MySqlCommand(query, dbconnection);
                            com.Parameters.AddWithValue("@name", txtSize.Text);
                            com.Parameters.AddWithValue("@id", Convert.ToInt16(comFactory2.SelectedValue));
                            com.ExecuteNonQuery();
                            
                            displaySize(Convert.ToInt16(comFactory2.SelectedValue));
                        }
                        else
                        {
                            txtSize.Focus();
                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Size already exist");
                    }
                }
                else
                {
                    MessageBox.Show("select Factory");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void txtSize_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (comFactory2.Text != "")
                    {
                        dbconnection.Open();
                        string query = "select Size_ID from size where Size_Value = '" + txtSize.Text + "' and Factory_ID=" + Convert.ToInt16(comFactory2.SelectedValue);
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        if (com.ExecuteScalar() == null)
                        {
                            if (txtSize.Text != "")
                            {
                                query = "insert into size (Size_Value,Factory_ID) values (@name,@id)";
                                com = new MySqlCommand(query, dbconnection);
                                com.Parameters.AddWithValue("@name", txtSize.Text);
                                com.Parameters.AddWithValue("@id", Convert.ToInt16(comFactory2.SelectedValue));
                                com.ExecuteNonQuery();
                                
                                displaySize(Convert.ToInt16(comFactory2.SelectedValue));
                            }
                            else
                            {
                                txtSize.Focus();
                              
                            }
                        }
                        else
                        {
                            MessageBox.Show("This Size already exist");
                        }
                    }
                    else
                    {
                        MessageBox.Show("select Factory");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void comFactory2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    displaySize((int)comFactory2.SelectedValue);
                    txtSize.Focus();
                    txtSize.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comFactory2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (load)
                {
                    displaySize((int)comFactory2.SelectedValue);
                    txtSize.Focus();
                    txtSize.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDeleteSize_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                // DataRowView row1 = (DataRowView)(((GridView)dataGridViewSize.MainView).GetRow(((GridView)dataGridViewSize.MainView).GetSelectedRows()[0]));
                DataGridViewRow row1 = dataGridViewSize.Rows[dataGridViewSize.SelectedCells[0].RowIndex];

                if (row1 != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int id = Convert.ToInt16(row1.Cells[0].Value.ToString());
                        string query = "delete from size where Size_ID=" + id;
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        com.ExecuteNonQuery();
                        updateTablesDB("size", "Size_ID", id);
                        if (comFactory.Text != "")
                        {
                            displaySize(Convert.ToInt16(comFactory.SelectedValue));
                        }
                        else
                        {
                            displaySize();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
                else
                {
                    MessageBox.Show("select row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("select row");
            }
            dbconnection.Close();
        }
        #endregion
        #region sort panel
        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {

                dbconnection.Open();
                string query = "select Sort_ID from sort where Sort_Value = '" + txtSort.Text + "'";
                MySqlCommand com = new MySqlCommand(query, dbconnection);
                if (com.ExecuteScalar() == null)
                {
                    if (txtSort.Text != "")
                    {
                        query = "insert into sort (Sort_Value) values (@name)";
                        com = new MySqlCommand(query, dbconnection);
                        com.Parameters.AddWithValue("@name", txtSort.Text);
                        com.ExecuteNonQuery();
                        displaySort();
                        txtSort.Focus();
                        txtSort.SelectAll();
                    }
                    else
                    {
                        txtSort.Focus();
                     
                    }
                }
                else
                {
                    MessageBox.Show("This Sort already exist");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void txtSort_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dbconnection.Open();
                    string query = "select Sort_ID from sort where Sort_Value = '" + txtSort.Text + "'";
                    MySqlCommand com = new MySqlCommand(query, dbconnection);
                    if (com.ExecuteScalar() == null)
                    {
                        if (txtSort.Text != "")
                        {
                            query = "insert into sort (Sort_Value) values (@name)";
                            com = new MySqlCommand(query, dbconnection);
                            com.Parameters.AddWithValue("@name", txtSort.Text);
                            com.ExecuteNonQuery();
                           
                            displaySort();
                            txtSort.Focus();
                            txtSort.SelectAll();
                        }
                        else
                        {
                            txtSort.Focus();
                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Sort already exist");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        } 
        private void btnDeleteSort_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                //  DataRowView row1 = (DataRowView)(((GridView)dataGridViewSort.MainView).GetRow(((GridView)dataGridViewSort.MainView).GetSelectedRows()[0]));
                DataGridViewRow row1 = dataGridViewSort.Rows[dataGridViewSort.SelectedCells[0].RowIndex];
                row1.Selected = true;
                if (row1 != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int id = Convert.ToInt16(row1.Cells[0].Value.ToString());
                        string query = "delete from sort where Sort_ID=" + id;
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        com.ExecuteNonQuery();

                        updateTablesDB("sort","Sort_ID",id);
                        
                        displaySort();

                    }
                    else if (dialogResult == DialogResult.No)
                    { }
                }
                else
                {
                    MessageBox.Show("select row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("select row");
            }
            dbconnection.Close();
        }
        #endregion

        private void txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                TextBox txtbox = (TextBox)sender;
                MySqlDataAdapter adapter;
                DataTable dtaple;
                string query = "";
                switch (txtbox.Name)
                {
                    case "txtType":
                        query = "select Type_ID as 'كود',Type_Name as 'الأسم' from type where Type_Name like'" + txtType.Text + "%'";
                        adapter = new MySqlDataAdapter(query, dbconnection);
                        dtaple = new DataTable();
                        adapter.Fill(dtaple);
                        dataGridView1.DataSource = dtaple;
                        break;
                    case "txtFactory":
                        if (comType2.Text != "")
                        {
                            query = "select Factory_ID as 'كود',Factory_Name as 'الأسم' from Factory where Factory_Name like'" + txtFactory.Text + "%' and Type_ID=" + comType2.SelectedValue;
                            adapter = new MySqlDataAdapter(query, dbconnection);
                            dtaple = new DataTable();
                            adapter.Fill(dtaple);
                            dataGridViewFactory.DataSource = dtaple;
                        }
                        break;
                    case "txtGroup":
                        if (comFactory2.Text != "")
                        {
                            query = "select Group_ID as 'كود',Group_Name as 'الأسم' from Groupo where Group_Name like'" + txtGroup.Text + "%' and Factory_ID=" + comFactory2.SelectedValue;
                            adapter = new MySqlDataAdapter(query, dbconnection);
                            dtaple = new DataTable();
                            adapter.Fill(dtaple);
                            dataGridViewGroup.DataSource = dtaple;
                        }
                        break;
                    case "txtProduct":
                        if (comFactoryGroup.Text != "")
                        {
                            query = "select Product_ID as 'كود',Product_Name as 'الأسم' from Product where Product_Name like'" + txtProduct.Text + "%' and Group_ID=" + comFactoryGroup.SelectedValue;
                            adapter = new MySqlDataAdapter(query, dbconnection);
                            dtaple = new DataTable();
                            adapter.Fill(dtaple);
                            dataGridViewProduct.DataSource = dtaple;
                        }
                        break;
                    case "txtSort":
                        query = "select Sort_ID as 'كود',Sort_Value as 'الأسم' from Sort where Sort_Value like'" + txtSort.Text + "%'";
                        adapter = new MySqlDataAdapter(query, dbconnection);
                        dtaple = new DataTable();
                        adapter.Fill(dtaple);
                        dataGridViewSort.DataSource = dtaple;
                        break;
                    case "txtColor":
                        if (comType.Text != "")
                        {
                            query = "select Color_ID as 'كود',Color_Name as 'الأسم' from Color where Color_Name like'" + txtColor.Text + "%' and Type_ID=" + comType.SelectedValue;
                            adapter = new MySqlDataAdapter(query, dbconnection);
                            dtaple = new DataTable();
                            adapter.Fill(dtaple);
                            dataGridViewColor.DataSource = dtaple;
                        }
                        break;
                    case "txtSize":
                        if (comFactory.Text != "")
                        {
                            query = "select Size_ID as 'كود',Size_Value as 'الأسم' from Size where Size_Value like'" + txtSize.Text + "%' and Factory_ID=" + comFactory.SelectedValue;
                            adapter = new MySqlDataAdapter(query, dbconnection);
                            dtaple = new DataTable();
                            adapter.Fill(dtaple);
                            dataGridViewSize.DataSource = dtaple;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
      
        //function 
        public void displayType()
        {
            string query = "select distinct Type_ID as 'كود',Type_Name as 'النوع' from type";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            query = "select distinct * from type";
            da = new MySqlDataAdapter(query, dbconnection);
            dt = new DataTable();
            da.Fill(dt);
            comType.DataSource = dt;
            comType.DisplayMember = dt.Columns["Type_Name"].ToString();
            comType.ValueMember = dt.Columns["Type_ID"].ToString();

            da = new MySqlDataAdapter(query, dbconnection);
            dt = new DataTable();
            da.Fill(dt);
            comType2.DataSource = dt;
            comType2.DisplayMember = dt.Columns["Type_Name"].ToString();
            comType2.ValueMember = dt.Columns["Type_ID"].ToString();
        }
        public void displayFactory()
        {
            string query = "select distinct Factory_ID as 'كود',Type_Name as 'النوع',Factory_Name as 'المصنع' from factory inner join type on factory.Type_ID=type.Type_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewFactory.DataSource = null;
            dataGridViewFactory.DataSource = dt;         
        }
        public void displayFactory(int id)
        {
            string query = "select distinct Factory_ID as 'كود',Factory_Name as 'المصنع' from factory where Type_ID=" + id;
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewFactory.DataSource = null;
            dataGridViewFactory.DataSource = dt;

            query = "select distinct * from factory";
            da = new MySqlDataAdapter(query, dbconnection);
            dt = new DataTable();
            da.Fill(dt);
            comFactory.DataSource = dt;
            comFactory.DisplayMember = dt.Columns["Factory_Name"].ToString();
            comFactory.ValueMember = dt.Columns["Factory_ID"].ToString();

            da = new MySqlDataAdapter(query, dbconnection);
            dt = new DataTable();
            da.Fill(dt);
            comFactory2.DataSource = dt;
            comFactory2.DisplayMember = dt.Columns["Factory_Name"].ToString();
            comFactory2.ValueMember = dt.Columns["Factory_ID"].ToString();
            comFactory2.Text = "";
        }
        public void displayGroup(int id)
        {
            string query = "select distinct Group_ID as 'كود',Group_Name as 'الأسم' from groupo where Factory_ID=" + id;
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewGroup.DataSource = dt;

            query = "select distinct * from groupo";
            da = new MySqlDataAdapter(query, dbconnection);
            dt = new DataTable();
            da.Fill(dt);
            comGroup.DataSource = dt;
            comGroup.DisplayMember = dt.Columns["Group_Name"].ToString();
            comGroup.ValueMember = dt.Columns["Group_ID"].ToString();
            comGroup.Text = "";
        }
        public void displayGroup()
        {
            string query = "select distinct Group_ID as 'كود',Factory_Name as 'المصنع' ,Group_Name as 'المجموعة' from groupo inner join factory on factory.Factory_ID=groupo.Factory_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewGroup.DataSource = dt;
        }
        public void displayProduct(int id)
        {
            string query = "select distinct Product_ID as 'كود',Product_Name as 'الأسم' from product where Group_ID=" + id;
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewProduct.DataSource = dt;
        }
        public void displayProduct()
        {
            string query = "select distinct Product_ID as 'كود',Group_Name as 'المجموعة',Product_Name as 'الصنف' from product inner join  groupo on product.Group_ID=groupo.Group_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewProduct.DataSource = dt;
        }
        public void displayColor(int id)
        {
            string query = "select distinct Color_ID as 'كود',Color_Name as 'الأسم' from color where Type_ID=" + id;
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewColor.DataSource = dt;
        }
        public void displayColor()
        {
            string query = "select distinct Color_ID as 'كود',Type_Name as 'النوع',Color_Name as 'اللون' from color inner join type on color.Type_ID=type.Type_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewColor.DataSource = dt;
        }
        public void displaySize(int id)
        {
            string query = "select distinct Size_ID as 'كود',Size_Value as 'المقاس' from size where Factory_ID=" + id;
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewSize.DataSource = dt;
        }
        public void displaySize()
        {
            string query = "select distinct Size_ID as 'كود',Factory_Name as 'المصنع',Size_Value as 'المقاس' from size inner join factory on factory.Factory_ID=size.Factory_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewSize.DataSource = dt;
        }
        public void displaySort()
        {
            string query = "select Sort_ID as 'كود',Sort_Value as 'الفرز' from sort";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewSort.DataSource = dt;
        }

        public void RestControls()
        {
            displayType();
            comFactory.Text = "";
            comType.Text = "";
            comFactory2.Text = "";
            comType2.Text = "";
            comFactoryGroup.Text = "";
            txtType.Text = "";
            txtSort.Text = "";
            txtProduct.Text = "";
            txtGroup.Text = "";
            txtFactory.Text = "";
            txtColor.Text = "";
            txtSize.Text = "";
            dataGridViewSize.DataSource = null;
            dataGridViewSort.DataSource = null;
            dataGridViewColor.DataSource = null;
            dataGridView1.DataSource = null;
            dataGridViewFactory.DataSource = null;
            dataGridViewGroup.DataSource = null;
            dataGridViewProduct.DataSource = null;
        }
        public void updateTablesDB(string tableName,string ColumnName,int id)
        {
            string query = "ALTER TABLE "+tableName+" AUTO_INCREMENT = 1;";
            MySqlCommand com = new MySqlCommand(query, dbconnection);
            com.ExecuteNonQuery();        
        }

        public void ClearButtonsColor()
        {
            foreach (Control control in this.tableLayoutPanel2.Controls)
            {
                if (control is Button)
                    control.BackColor = Color.FromArgb(229,229,229);
            }
        }

       
    }
}
