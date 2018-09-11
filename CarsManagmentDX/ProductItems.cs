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
        int id = -1;
        bool load = false;
        bool flagFactory = false;//in group tap
        bool flagFactoryP = false;//in product tap
        bool flagGroup = false;//in product tap
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
                        txtFactory.Focus();
                        dbconnection.Open();
                        string query = "select * from type";
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        MySqlDataReader dr = com.ExecuteReader();
                        checkedListBox1.Items.Clear();
                        while (dr.Read())
                            checkedListBox1.Items.Add(dr["Type_Name"].ToString() + "\t" + dr["Type_ID"]);

                        dr.Close();
                        break;

                    case "btnGroup":
                        mTC_Content.SelectedIndex = 4;                       
                        comType.Focus();
                        comType.Text = "";
                        comFactory.Text = "";
                        txtType1.Text = "";
                        txtFactory1.Text = "";
                        txtGroup.Text = "";                      
                        break;

                    case "btnProduct":
                        mTC_Content.SelectedIndex = 3;
                        comTypeProduct.Focus();
                        comTypeProduct.Text = "";
                        comFactoryGroup.Text = "";
                        comGroup.Text = "";
                        txtType2.Text = "";
                        txtFactory2.Text = "";
                        txtGroup2.Text = "";
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
            dbconnection.Close();
        }
        private void ProductItems_Load(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                string query = "select * from type";       
                MySqlCommand com = new MySqlCommand(query, dbconnection);
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                    checkedListBox1.Items.Add(dr["Type_Name"].ToString() + "\t" + dr["Type_ID"]);

                dr.Close();

                MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comType.DataSource = dt;
                comType.DisplayMember = dt.Columns["Type_Name"].ToString();
                comType.ValueMember = dt.Columns["Type_ID"].ToString();
                comType.Text = "";
               
                comType2.DataSource = dt;
                comType2.DisplayMember = dt.Columns["Type_Name"].ToString();
                comType2.ValueMember = dt.Columns["Type_ID"].ToString();
                comType2.Text = "";

                comTypeProduct.DataSource = dt;
                comTypeProduct.DisplayMember = dt.Columns["Type_Name"].ToString();
                comTypeProduct.ValueMember = dt.Columns["Type_ID"].ToString();
                comTypeProduct.Text = "";

                query = "select distinct * from factory";
                da = new MySqlDataAdapter(query, dbconnection);
                dt = new DataTable();
                da.Fill(dt);
                //comFactory.DataSource = dt;
                //comFactory.DisplayMember = dt.Columns["Factory_Name"].ToString();
                //comFactory.ValueMember = dt.Columns["Factory_ID"].ToString();
                //comFactory.Text = "";

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
                //comFactoryGroup.DataSource = dt;
                //comFactoryGroup.DisplayMember = dt.Columns["Factory_Name"].ToString();
                //comFactoryGroup.ValueMember = dt.Columns["Factory_ID"].ToString();
                //comFactoryGroup.Text = "";
                query = "select distinct * from groupo";
                da = new MySqlDataAdapter(query, dbconnection);
                dt = new DataTable();
                da.Fill(dt);
                comGroup.DataSource = dt;
                comGroup.DisplayMember = dt.Columns["Group_Name"].ToString();
                comGroup.ValueMember = dt.Columns["Group_ID"].ToString();
                comGroup.Text = "";

                load = true;

                dataGridViewStyle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
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
                        txtFactory.Focus();
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
        private void comBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (load)
                {
                    ComboBox comBox = (ComboBox)sender;

                    switch (comBox.Name)
                    {
                        case "comType":
                            txtType1.Text = comType.SelectedValue.ToString();
                            txtFactory1.Text = "";
                            txtFactory1.Focus();
                            break;

                        case "comTypeProduct":
                            txtType2.Text = comTypeProduct.SelectedValue.ToString();
                            break;

                        case "comType2":
                            txtType3.Text = comType2.SelectedValue.ToString();
                            break;

                        case "comFactory":
                            if (flagFactory)
                            {
                                txtFactory1.Text = comFactory.SelectedValue.ToString();
                                txtGroup.Focus();
                            }                  
                            break;

                        case "comFactoryGroup":
                            txtFactory2.Text = comFactoryGroup.SelectedValue.ToString();
                            break;

                        case "comFactory2":
                            txtFactory3.Text = comFactory2.SelectedValue.ToString();
                            break;

                        case "comGroup":
                            txtGroup2.Text = comGroup.SelectedValue.ToString();                          
                            break;
                      
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
         
            if (e.KeyCode == Keys.Enter)
            {
                TextBox txtBox = (TextBox)sender;
                string query;
                MySqlCommand com;
                string Name;
                try
                {
                    if (txtBox.Text != "")
                    {
                        dbconnection.Open();
                        switch (txtBox.Name)
                        {
                            case "txtType1":
                                query = "select Type_Name from type where Type_ID='" + txtType1.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    displayGroup_Type(Convert.ToInt16(txtType1.Text));
                                    Name = (string)com.ExecuteScalar();
                                    comType.Text = Name;
                                    if (txtType1.Text == "1")
                                        txtGroup.Focus();
                                    txtFactory1.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;
                            case "txtType2":
                                query = "select Type_Name from type where Type_ID='" + txtType2.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comTypeProduct.Text = Name;

                                    txtFactory2.Focus();
                                    dataGridViewProduct.DataSource = displayProduct_Type(Convert.ToInt16(txtType2.Text));
                                    dataGridViewProduct.Columns[0].Width = 50;
                                  
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;
                            case "txtType3":
                                query = "select Type_Name from type where Type_ID='" + txtType3.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comType2.Text = Name;

                                    txtColor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;

                            case "txtFactory1":
                                query = "select Factory_Name from factory where Factory_ID='" + txtFactory1.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    displayGroup_Factory(Convert.ToInt16(txtFactory1.Text));
                                    Name = (string)com.ExecuteScalar();
                                    comFactory.Text = Name;
                                  
                                    txtGroup.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;
                            case "txtFactory2":
                                query = "select Factory_Name from factory where Factory_ID='" + txtFactory2.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comFactoryGroup.Text = Name;

                                    txtGroup2.Focus();
                                    dataGridViewProduct.DataSource = displayProduct_Factory(Convert.ToInt16(txtFactory2.Text));
                                    dataGridViewProduct.Columns[0].Width = 50;
                                 
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;
                            case "txtFactory3":
                                query = "select Factory_Name from factory where Factory_ID='" + txtFactory3.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comFactory2.Text = Name;

                                    txtSize.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;

                            case "txtGroup2":
                                query = "select Group_Name from groupo where Group_ID='" + txtGroup2.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comGroup.Text = Name;

                                    txtProduct.Focus();
                                    displayProduct_Group();
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;
                        
                        }

                    }

                }
                catch (Exception ex)
                {
                    //  MessageBox.Show(ex.ToString());
                }
                dbconnection.Close();
            }
        }
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
                        query = "select distinct factory.Factory_ID as 'كود',Factory_Name as 'المصنع',Type_Name as 'النوع' from factory inner join type_factory on factory.Factory_ID=type_factory.Factory_ID inner join type  on type.Type_ID=type_factory.Type_ID where Factory_Name like'" + txtFactory.Text + "%'";
                        adapter = new MySqlDataAdapter(query, dbconnection);
                        dtaple = new DataTable();
                        adapter.Fill(dtaple);
                        dataGridViewFactory.DataSource = dtaple;
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
                        //if (comType.Text != "")
                        //{
                        //    query = "select Color_ID as 'كود',Color_Name as 'الأسم' from Color where Color_Name like'" + txtColor.Text + "%' and Type_ID=" + comType.SelectedValue;
                        //    adapter = new MySqlDataAdapter(query, dbconnection);
                        //    dtaple = new DataTable();
                        //    adapter.Fill(dtaple);
                        //    dataGridViewColor.DataSource = dtaple;
                        //}
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
                        
                        UserControl.UserRecord("type","اضافة", com.ExecuteScalar().ToString(), DateTime.Now,dbconnection);
                      
                        displayType();
                        txtType.Text = "";
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
                            txtType.Text="";
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
                 
                        UserControl.UserRecord("type", "حذف", storeRow.Cells[0].Value.ToString(), DateTime.Now, dbconnection);

                        displayType();
                        txtType.Focus();
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
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        #endregion

        #region factory panel
        private void btnFactory_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                string query = "select Factory_ID from factory where Factory_Name = '" + txtFactory.Text + "'";
                MySqlCommand com = new MySqlCommand(query, dbconnection);
                if (com.ExecuteScalar() == null)
                {
                    if (checkedListBox1.CheckedItems.Count > 0)
                    {
                        if (txtFactory.Text != "")
                        {
                            query = "insert into factory (Factory_Name) values (@name)";
                            com = new MySqlCommand(query, dbconnection);
                            com.Parameters.AddWithValue("@name", txtFactory.Text);
                            com.ExecuteNonQuery();

                            query = "select Factory_ID from factory order by Factory_ID desc limit 1";
                            com = new MySqlCommand(query, dbconnection);
                            int factory_ID = Convert.ToInt16(com.ExecuteScalar().ToString());

                            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                            {
                                int Type_ID = Convert.ToInt16(checkedListBox1.CheckedItems[i].ToString().Split('\t')[1]);
                                query = "insert into type_factory (Type_ID,Factory_ID) values (@Type_ID,@Factory_ID)";
                                com = new MySqlCommand(query, dbconnection);
                                com.Parameters.Add("@Type_ID", MySqlDbType.Int16);
                                com.Parameters["@Type_ID"].Value = Type_ID;
                                com.Parameters.Add("@factory_ID", MySqlDbType.Int16);
                                com.Parameters["@factory_ID"].Value = factory_ID;
                                com.ExecuteNonQuery();
                            }


                            query = "select Factory_ID from factory order by Factory_ID desc limit 1";
                            com = new MySqlCommand(query, dbconnection);
                            UserControl.UserRecord("factory", "اضافة", factory_ID.ToString(), DateTime.Now, dbconnection);

                            //  displayFactory(Convert.ToInt16(comType.SelectedValue));
                            txtFactory.Text = "";
                            for (int j = 0; j < checkedListBox1.Items.Count; j++)
                            {
                                checkedListBox1.SetItemChecked(j, false);

                            }

                        }
                        else
                        {
                            txtFactory.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("select type");
                    }
                }
                else
                {
                    MessageBox.Show("This factory already exist");
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
                    dbconnection.Open();
                    string query = "select Factory_ID from factory where Factory_Name = '" + txtFactory.Text + "'";
                    MySqlCommand com = new MySqlCommand(query, dbconnection);
                    if (com.ExecuteScalar() == null)
                    {
                        if (checkedListBox1.CheckedItems.Count > 0)
                        {
                            if (txtFactory.Text != "")
                            {
                                query = "insert into factory (Factory_Name) values (@name)";
                                com = new MySqlCommand(query, dbconnection);
                                com.Parameters.AddWithValue("@name", txtFactory.Text);
                                com.ExecuteNonQuery();

                                query = "select Factory_ID from factory order by Factory_ID desc limit 1";
                                com = new MySqlCommand(query, dbconnection);
                                int factory_ID = Convert.ToInt16(com.ExecuteScalar().ToString());

                                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                                {
                                    int Type_ID = Convert.ToInt16(checkedListBox1.CheckedItems[i].ToString().Split('\t')[1]);
                                    query = "insert into type_factory (Type_ID,Factory_ID) values (@Type_ID,@Factory_ID)";
                                    com = new MySqlCommand(query, dbconnection);
                                    com.Parameters.Add("@Type_ID", MySqlDbType.Int16);
                                    com.Parameters["@Type_ID"].Value = Type_ID;
                                    com.Parameters.Add("@factory_ID", MySqlDbType.Int16);
                                    com.Parameters["@factory_ID"].Value = factory_ID;
                                    com.ExecuteNonQuery();
                                }


                                query = "select Factory_ID from factory order by Factory_ID desc limit 1";
                                com = new MySqlCommand(query, dbconnection);
                                UserControl.UserRecord("factory", "اضافة", factory_ID.ToString(), DateTime.Now, dbconnection);

                                displayFactory();
                                txtFactory.Text = "";
                                for (int j = 0; j < checkedListBox1.Items.Count; j++)
                                {
                                    checkedListBox1.SetItemChecked(j, false);

                                }

                            }
                            else
                            {
                                txtFactory.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("select type");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This factory already exist");
                    }
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
               if (id != -1)
                {                  
                    if (checkedListBox1.CheckedItems.Count > 0)
                    {
                        string query = "select Factory_ID from factory where Factory_Name = '" + txtFactory.Text + "' and Factory_ID not in(" + id + ")";
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        if (com.ExecuteScalar() == null)
                        {
                            if (txtFactory.Text != "")
                            {
                                query = "update factory set Factory_Name=@name where Factory_ID=" + id;
                                com = new MySqlCommand(query, dbconnection);
                                com.Parameters.AddWithValue("@name", txtFactory.Text);
                                com.ExecuteNonQuery();

                                query = "delete from type_factory where Factory_ID=" + id;
                                com = new MySqlCommand(query, dbconnection);
                                com.ExecuteNonQuery();
                                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                                {
                                    int Type_ID = Convert.ToInt16(checkedListBox1.CheckedItems[i].ToString().Split('\t')[1]);
                                    query = "insert into type_factory (Type_ID,Factory_ID) values (@Type_ID,@Factory_ID)";
                                    com = new MySqlCommand(query, dbconnection);
                                    com.Parameters.Add("@Type_ID", MySqlDbType.Int16);
                                    com.Parameters["@Type_ID"].Value = Type_ID;
                                    com.Parameters.Add("@Factory_ID", MySqlDbType.Int16);
                                    com.Parameters["@Factory_ID"].Value = id;
                                    com.ExecuteNonQuery();
                                }


                                query = "select Factory_ID from factory order by Factory_ID desc limit 1";
                                com = new MySqlCommand(query, dbconnection);
                                UserControl.UserRecord("factory", "تعديل", id.ToString(), DateTime.Now, dbconnection);

                                //  displayFactory(Convert.ToInt16(comType.SelectedValue));
                                txtFactory.Text = "";
                                btnSave.Visible = false;
                                for (int j = 0; j < checkedListBox1.Items.Count; j++)
                                {
                                   checkedListBox1.SetItemChecked(j, false);
           
                                }
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
                else
                {
                    MessageBox.Show("select row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                btnSave.Visible = true;
                row1 = dataGridViewFactory.Rows[dataGridViewFactory.SelectedCells[0].RowIndex];
                if (row1 != null)
                {
                    id = Convert.ToInt16(row1.Cells[0].Value.ToString());
                    string query = "select Type_ID from type_factory where Factory_ID="+id;
                    MySqlCommand com = new MySqlCommand(query, dbconnection);
                    MySqlDataReader dr = com.ExecuteReader();
                    List<int> idList = new List<int>();
                    while (dr.Read())
                    {
                        idList.Add(Convert.ToInt16(dr["Type_ID"].ToString()));
                    }
                    dr.Close();
                    dbconnection.Close();
                    txtFactory.Text = row1.Cells[1].Value.ToString();
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        int Type_ID = Convert.ToInt16(checkedListBox1.Items[i].ToString().Split('\t')[1]);
                        for (int j = 0; j < idList.Count; j++)
                        {
                            if (Type_ID == idList[j])
                            {
                                checkedListBox1.SetItemChecked(i, true);
                            }
                        }
                    }

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
        private void btnDeleteFactory_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
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

                        UserControl.UserRecord("factory", "حذف", row1.Cells[0].Value.ToString(), DateTime.Now, dbconnection);

                        displayFactory();

                        txtFactory.Text="";
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
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void btnDisplayAllFactory_Click(object sender, EventArgs e)
        {
            try
            {
                displayFactory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region group panel
        private void btnGroup_Click(object sender, EventArgs e)
        {
            try
            {
               
                    dbconnection.Open();
                    string query = "select Group_ID from groupo where Group_Name = '" + txtGroup.Text + "'";
                    MySqlCommand com = new MySqlCommand(query, dbconnection);
                    if (com.ExecuteScalar() == null)
                    {
                        if (txtGroup.Text != "")
                        {
                            if (comType.SelectedValue.ToString() != "1")
                            {
                                if (comFactory.Text != "")
                                {
                                    query = "insert into groupo (Group_Name,Factory_ID,Type_ID) values (@name,@Factory_ID,@Type_ID)";
                                    com = new MySqlCommand(query, dbconnection);
                                    com.Parameters.AddWithValue("@name", txtGroup.Text);
                                    com.Parameters.AddWithValue("@Factory_ID", Convert.ToInt16(comFactory.SelectedValue));
                                    com.Parameters.AddWithValue("@Type_ID", Convert.ToInt16(comType.SelectedValue));
                                    com.ExecuteNonQuery();
                                    displayGroup(Convert.ToInt16(comFactory.SelectedValue));
                                }
                                else
                                {
                                    MessageBox.Show("اختر المصنع");
                                }
                            }
                            else
                            {
                                query = "insert into groupo (Group_Name,Factory_ID,Type_ID) values (@name,@Factory_ID,@Type_ID)";
                                com = new MySqlCommand(query, dbconnection);
                                com.Parameters.AddWithValue("@name", txtGroup.Text);
                                com.Parameters.AddWithValue("@Factory_ID", 0);
                                com.Parameters.AddWithValue("@Type_ID", Convert.ToInt16(comType.SelectedValue));
                                com.ExecuteNonQuery();
                                displayGroup(0);
                            }

                            query = "select Group_ID from groupo order by Group_ID desc limit 1";
                            com = new MySqlCommand(query, dbconnection);
                            UserControl.UserRecord("groupo", "اضافة", com.ExecuteScalar().ToString(), DateTime.Now, dbconnection);
                           
                            txtGroup.Text = "";
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
                    dbconnection.Open();
                    string query = "select Group_ID from groupo where Group_Name = '" + txtGroup.Text + "'";
                    MySqlCommand com = new MySqlCommand(query, dbconnection);
                    if (com.ExecuteScalar() == null)
                    {
                        if (txtGroup.Text != "")
                        {
                            if (comType.SelectedValue.ToString() != "1")
                            {
                                if (comFactory.Text != "")
                                {
                                    query = "insert into groupo (Group_Name,Factory_ID,Type_ID) values (@name,@Factory_ID,@Type_ID)";
                                    com = new MySqlCommand(query, dbconnection);
                                    com.Parameters.AddWithValue("@name", txtGroup.Text);
                                    com.Parameters.AddWithValue("@Factory_ID", Convert.ToInt16(comFactory.SelectedValue));
                                    com.Parameters.AddWithValue("@Type_ID", Convert.ToInt16(comType.SelectedValue));
                                    com.ExecuteNonQuery();
                                    displayGroup(Convert.ToInt16(comFactory.SelectedValue));
                                }
                                else
                                {
                                    MessageBox.Show("اختر المصنع");
                                }
                            }
                            else
                            {
                                query = "insert into groupo (Group_Name,Factory_ID,Type_ID) values (@name,@Factory_ID,@Type_ID)";
                                com = new MySqlCommand(query, dbconnection);
                                com.Parameters.AddWithValue("@name", txtGroup.Text);
                                com.Parameters.AddWithValue("@Factory_ID", 0);
                                com.Parameters.AddWithValue("@Type_ID", Convert.ToInt16(comType.SelectedValue));
                                com.ExecuteNonQuery();
                                displayGroup(0);
                            }

                            query = "select Group_ID from groupo order by Group_ID desc limit 1";
                            com = new MySqlCommand(query, dbconnection);
                            UserControl.UserRecord("groupo", "اضافة", com.ExecuteScalar().ToString(), DateTime.Now, dbconnection);

                            txtGroup.Text = "";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void comType_SelectedValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (load)
                {
                    if (comType.SelectedValue.ToString() != "1")
                    {
                        flagFactory = false;
                        string query = "select distinct factory.Factory_ID, Factory_Name from factory inner join type_factory on type_factory.Factory_ID=factory.Factory_ID where type_factory.Type_ID=" + comType.SelectedValue.ToString();
                        MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        comFactory.DataSource = dt;
                        comFactory.DisplayMember = dt.Columns["Factory_Name"].ToString();
                        comFactory.ValueMember = dt.Columns["Factory_ID"].ToString();
                        comFactory.Text = "";
                        txtFactory1.Text = "";

                        flagFactory = true;

                        displayGroup_Type(Convert.ToInt16(comType.SelectedValue.ToString()));
                        

                        label6.Visible = true;
                        comFactory.Visible = true;
                        txtFactory1.Visible = true;
                    }
                    else
                    {
                        displayGroup_Type(Convert.ToInt16(comType.SelectedValue.ToString()));

                        label6.Visible = false;
                        comFactory.Visible = false;
                        txtFactory1.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                if (flagFactory)
                {
                    displayGroup_Factory(Convert.ToInt16(comFactory.SelectedValue));
                    
                    txtFactory1.Text = "";
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

                        UserControl.UserRecord("groupo", "حذف", row1.Cells[0].Value.ToString(), DateTime.Now, dbconnection);
                        if (comFactory.Text != "")
                        {
                            displayGroup(Convert.ToInt16(comFactory.SelectedValue));
                        }
                        else
                        {
                            displayGroup();
                        }

                      txtGroup.Text="";
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
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void btnGroupDisplayAll_Click(object sender, EventArgs e)
        {
            try
            {
                displayGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region product panel
        private void btnProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (comGroup.Text != "" && comFactoryGroup.Text != "" && comTypeProduct.Text != "")
                {
                    dbconnection.Open();
                    string query = "select Product_ID from product where Product_Name = '" + txtProduct.Text + "'";
                    MySqlCommand com = new MySqlCommand(query, dbconnection);
                    if (com.ExecuteScalar() == null)
                    {
                        if (txtProduct.Text != "")
                        {
                            query = "insert into product (Product_Name,Type_ID,Factory_ID,Group_ID) values (@name,@Type_ID,@Factory_ID,@Group_ID)";
                            com = new MySqlCommand(query, dbconnection);
                            com.Parameters.AddWithValue("@name", txtProduct.Text);
                            com.Parameters.AddWithValue("@Type_ID", Convert.ToInt16(comTypeProduct.SelectedValue));
                            com.Parameters.AddWithValue("@Factory_ID", Convert.ToInt16(comFactoryGroup.SelectedValue));
                            com.Parameters.AddWithValue("@Group_ID", Convert.ToInt16(comGroup.SelectedValue));
                            com.ExecuteNonQuery();
                            query = "select Product_ID from product order by Product_ID desc limit 1";
                            com = new MySqlCommand(query, dbconnection);
                            UserControl.UserRecord("product", "اضافة", com.ExecuteScalar().ToString(), DateTime.Now, dbconnection);

                            displayProduct_Group();
                            txtProduct.Text = "";
                            txtProduct.Focus();
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
                    MessageBox.Show("Fill all fields");
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
                    if (comGroup.Text != ""&& comFactoryGroup.Text != ""&& comTypeProduct.Text != "")
                    {
                        dbconnection.Open();
                        string query = "select Product_ID from product where Product_Name = '" + txtProduct.Text + "' and Group_ID=" + comGroup.SelectedValue;
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        if (com.ExecuteScalar() == null)
                        {
                            if (txtProduct.Text != "")
                            {
                                query = "insert into product (Product_Name,Type_ID,Factory_ID,Group_ID) values (@name,@Type_ID,@Factory_ID,@Group_ID)";
                                com = new MySqlCommand(query, dbconnection);
                                com.Parameters.AddWithValue("@name", txtProduct.Text);
                                com.Parameters.AddWithValue("@Type_ID", Convert.ToInt16(comTypeProduct.SelectedValue));
                                com.Parameters.AddWithValue("@Factory_ID", Convert.ToInt16(comFactoryGroup.SelectedValue));
                                com.Parameters.AddWithValue("@Group_ID", Convert.ToInt16(comGroup.SelectedValue));
                                com.ExecuteNonQuery();
                                query = "select Product_ID from product order by Product_ID desc limit 1";
                                com = new MySqlCommand(query, dbconnection);
                                UserControl.UserRecord("product", "اضافة", com.ExecuteScalar().ToString(), DateTime.Now, dbconnection);

                                displayProduct_Group();
                                txtProduct.Text = "";
                                txtProduct.Focus();
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
                    displayProduct_Group();
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
                if (flagFactoryP)
                {
                    if (comTypeProduct.SelectedValue.ToString() != "1")
                    {
                        string query = "select * from groupo where Factory_ID=" + comFactoryGroup.SelectedValue;
                        MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        comGroup.DataSource = dt;
                        comGroup.DisplayMember = dt.Columns["Group_Name"].ToString();
                        comGroup.ValueMember = dt.Columns["Group_ID"].ToString();
                        comGroup.Text = "";
                        txtGroup2.Text = "";
                        comGroup.Focus();           
                    }
                    dataGridViewProduct.DataSource = null;
                    dataGridViewProduct.DataSource = displayProduct_Factory(Convert.ToInt16(comFactoryGroup.SelectedValue));
                    dataGridViewProduct.Columns[0].Width = 50;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (flagGroup)
                {
                    displayProduct_Group();
                    txtProduct.Focus();
                    txtProduct.SelectAll();
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

                        UserControl.UserRecord("product", "حذف", row1.Cells[0].Value.ToString(), DateTime.Now, dbconnection);
                        if (comGroup.Text != "")
                            displayProduct_Group();
                        else
                            displayProduct();                      

                       txtProduct.Focus();
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
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void btnDisplayAllProduct_Click(object sender, EventArgs e)
        {
            try
            {
                displayProductAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comTypeProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (mTC_Content.SelectedIndex == 3)
                {
                    flagFactoryP = false;
                    flagGroup = false;
                    txtType2.Text = comTypeProduct.SelectedValue.ToString();
                    if (comTypeProduct.SelectedValue.ToString() == "1")
                    {
                        string query = "select distinct factory.Factory_ID, Factory_Name from factory inner join type_factory on type_factory.Factory_ID=factory.Factory_ID where type_factory.Type_ID=" + comTypeProduct.SelectedValue.ToString();
                        MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        comFactoryGroup.DataSource = dt;
                        comFactoryGroup.DisplayMember = dt.Columns["Factory_Name"].ToString();
                        comFactoryGroup.ValueMember = dt.Columns["Factory_ID"].ToString();
                        comFactoryGroup.Text = "";
                        txtFactory2.Text = "";
                     
                        query = "select distinct groupo.Group_ID, Group_Name from groupo inner join type on type.Type_ID=type.Type_ID where type.Type_ID=" + comTypeProduct.SelectedValue.ToString() + " and Factory_ID=0";
                        da = new MySqlDataAdapter(query, dbconnection);
                        dt = new DataTable();
                        da.Fill(dt);
                        comGroup.DataSource = dt;
                        comGroup.DisplayMember = dt.Columns["Group_Name"].ToString();
                        comGroup.ValueMember = dt.Columns["Group_ID"].ToString();
                        comGroup.Text = "";
                        txtGroup2.Text = "";
                        flagGroup = true;
                    }
                    else
                    {                
                        string query = "select distinct factory.Factory_ID, Factory_Name from factory inner join type_factory on type_factory.Factory_ID=factory.Factory_ID where type_factory.Type_ID=" + comTypeProduct.SelectedValue.ToString();
                        MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        comFactoryGroup.DataSource = dt;
                        comFactoryGroup.DisplayMember = dt.Columns["Factory_Name"].ToString();
                        comFactoryGroup.ValueMember = dt.Columns["Factory_ID"].ToString();
                        comFactoryGroup.Text = "";
                        txtFactory2.Text = "";
                    }
                    dataGridViewProduct.DataSource = displayProduct_Type(Convert.ToInt16(txtType2.Text));
                    dataGridViewProduct.Columns[0].Width = 50;
                    flagFactoryP = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                            query = "select Color_ID from color order by Color_ID desc limit 1";
                            com = new MySqlCommand(query, dbconnection);
                            UserControl.UserRecord("color", "اضافة", com.ExecuteScalar().ToString(), DateTime.Now, dbconnection);

                            displayColor(Convert.ToInt16(comType2.SelectedValue));
                            txtColor.Text = "";
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
                                query = "select Color_ID from color order by Color_ID desc limit 1";
                                com = new MySqlCommand(query, dbconnection);
                                UserControl.UserRecord("color", "اضافة", com.ExecuteScalar().ToString(), DateTime.Now, dbconnection);

                                displayColor(Convert.ToInt16(comType2.SelectedValue));
                                txtColor.Text = "";
                                txtColor.Focus();                              
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

                        UserControl.UserRecord("color", "حذف", row1.Cells[0].Value.ToString(), DateTime.Now, dbconnection);

                        if (comType2.Text != "")
                        {
                            displayColor(Convert.ToInt16(comType2.SelectedValue));
                        }
                        else
                        {
                            displayColor();
                        }

                        txtColor.Focus();
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
                            query = "select Product_ID from product order by Product_ID desc limit 1";
                            com = new MySqlCommand(query, dbconnection);
                            UserControl.UserRecord("product", "اضافة", com.ExecuteScalar().ToString(), DateTime.Now, dbconnection);

                            displaySize(Convert.ToInt16(comFactory2.SelectedValue));
                            txtSize.Text = "";
                            txtSize.Focus();
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
                                query = "select Product_ID from product order by Product_ID desc limit 1";
                                com = new MySqlCommand(query, dbconnection);
                                UserControl.UserRecord("product", "اضافة", com.ExecuteScalar().ToString(), DateTime.Now, dbconnection);

                                displaySize(Convert.ToInt16(comFactory2.SelectedValue));
                                txtSize.Text = "";
                                txtSize.Focus();
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

                        UserControl.UserRecord("size", "حذف", row1.Cells[0].Value.ToString(), DateTime.Now, dbconnection);

                        if (comFactory2.Text != "")
                        {
                            displaySize(Convert.ToInt16(comFactory2.SelectedValue));
                        }
                        else
                        {
                            displaySize();
                        }

                        txtSize.Focus();
                        
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("select row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        txtSort.Text = "";
                        txtSort.Focus();
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
                            txtSort.Text = "";
                            txtSort.Focus();
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
                        
                        UserControl.UserRecord("sort", "حذف", row1.Cells[0].Value.ToString(), DateTime.Now, dbconnection);

                        displaySort();
                        txtSort.Focus();
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
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        #endregion


        //function 
        #region Type Tap
        public void displayType()
        {
            string query = "select distinct Type_ID as 'كود',Type_Name as 'النوع' from type";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = dataGridView1.Width - 50;

            query = "select distinct * from type";
            da = new MySqlDataAdapter(query, dbconnection);
            dt = new DataTable();
            da.Fill(dt);
            comType2.DataSource = dt;
            comType2.DisplayMember = dt.Columns["Type_Name"].ToString();
            comType2.ValueMember = dt.Columns["Type_ID"].ToString();

        }
        #endregion

        #region Factory Tap
        public void displayFactory()
        {
            string query = "select distinct factory.Factory_ID as 'كود',Factory_Name as 'المصنع',Type_Name as 'النوع' from factory inner join type_factory on factory.Factory_ID=type_factory.Factory_ID inner join type  on type.Type_ID=type_factory.Type_ID order by factory.Factory_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewFactory.DataSource = null;
            dataGridViewFactory.DataSource = dt;
            dataGridViewFactory.Columns[0].Width = 50;
            dataGridViewFactory.Columns[1].Width = 120;
            dataGridViewFactory.Columns[2].Width = dataGridViewFactory.Width - 170;
        }
        public void displayFactory(int id)
        {
            string query = "select distinct Factory_ID as 'كود',Factory_Name as 'المصنع' from factory where Type_ID=" + id + " order by Factory_ID ";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewFactory.DataSource = null;
            dataGridViewFactory.DataSource = dt;
            dataGridViewFactory.Columns[0].Width = 50;
            dataGridViewFactory.Columns[1].Width = dataGridViewFactory.Width - 50;

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

            da = new MySqlDataAdapter(query, dbconnection);
            dt = new DataTable();
            da.Fill(dt);
            comFactoryGroup.DataSource = dt;
            comFactoryGroup.DisplayMember = dt.Columns["Factory_Name"].ToString();
            comFactoryGroup.ValueMember = dt.Columns["Factory_ID"].ToString();
            comFactoryGroup.Text = "";
        }
        #endregion

        #region Group Tap
        public void displayGroup_Type(int type_id)
        {
            string query = "select distinct Group_ID as 'كود',Factory_Name as 'المصنع',Group_Name as 'المجموعة' from groupo left join factory on factory.Factory_ID=groupo.Factory_ID  where groupo.Type_ID=" + type_id + " order by Group_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewGroup.DataSource = dt;
            dataGridViewGroup.Columns[0].Width = 50;
        }
        public void displayGroup_Factory(int factory_id)
        {
            string query = "select distinct Group_ID as 'كود',Group_Name as 'المجموعة' from groupo left join factory on factory.Factory_ID=groupo.Factory_ID  where groupo.Type_ID=" + txtType1.Text + " and groupo.Factory_ID=" + factory_id + "  order by Group_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewGroup.DataSource = dt;
            dataGridViewGroup.Columns[0].Width = 50;
        }
        public void displayGroup(int type_id)
        {
            string query = "select distinct Group_ID as 'كود',Group_Name as 'المجموعة' from groupo   where groupo.Type_ID=" + txtType2.Text + " and groupo.Factory_ID=" + type_id + " order by Group_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewGroup.DataSource = dt;
            dataGridViewGroup.Columns[0].Width = 50;
            dataGridViewGroup.Columns[1].Width = dataGridViewGroup.Width - 50;

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
            string query = "select distinct Group_ID as 'كود',Factory_Name as 'المصنع',Type_Name as 'النوع',Group_Name as 'المجموعة' from groupo left join factory on factory.Factory_ID=groupo.Factory_ID inner join type on type.Type_ID=groupo.Type_ID order by Group_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewGroup.DataSource = dt;
            dataGridViewGroup.Columns[0].Width = 50;
            dataGridViewGroup.Columns[1].Width = 100;
            dataGridViewGroup.Columns[2].Width = 100;
            dataGridViewGroup.Columns[3].Width = dataGridViewGroup.Width - 250;
        }

        #endregion
        #region functions of product tap    
        public void displayProductAll()
        {
            string query = "select distinct Product_ID as 'كود', Type_Name as 'النوع',Factory_Name as 'المصنع', Group_Name as 'المجموعة',Product_Name as 'الصنف' from product inner join  groupo on product.Group_ID=groupo.Group_ID inner join  factory on product.Factory_ID=factory.Factory_ID inner join  type on product.Type_ID=type.Type_ID   order by Product_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewProduct.DataSource = dt;
            dataGridViewProduct.Columns[0].Width = 50;
        }
        public object displayProduct_Type(int type_id)
        {
            string query = "select distinct Product_ID as 'كود' ,Factory_Name as 'المصنع', Group_Name as 'المجموعة',Product_Name as 'الصنف' from product inner join  groupo on product.Group_ID=groupo.Group_ID inner join  factory on product.Factory_ID=factory.Factory_ID inner join  type on product.Type_ID=type.Type_ID where product.Type_ID=" + type_id + " order by Product_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public object displayProduct_Factory(int factory_id)
        {
            string query = "select distinct Product_ID as 'كود' , Group_Name as 'المجموعة',Product_Name as 'الصنف' from product inner join  groupo on product.Group_ID=groupo.Group_ID   where product.Type_ID=" + txtType2.Text + " and product.Factory_ID=" + factory_id+" order by Product_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void displayProduct_Group()
        {
            if (txtType2.Text != "" && txtFactory2.Text != "" && txtGroup2.Text != "")
            {
                string query = "select distinct Product_ID as 'كود' ,Product_Name as 'الصنف' from product  where product.Type_ID=" + txtType2.Text + " and product.Factory_ID=" + txtFactory2.Text + "  order by Product_ID";
                MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewProduct.DataSource = dt;
                dataGridViewProduct.Columns[0].Width = 50;
            }
        }
        public void displayProduct()
        {
            string query = "select distinct Product_ID as 'كود' ,Product_Name as 'الصنف' from product  where product.Type_ID=" + txtType2.Text + " and product.Factory_ID=" + txtFactory2.Text + " and  product.Group_ID=" + txtGroup2.Text + " order by Product_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewProduct.DataSource = dt;
            dataGridViewProduct.Columns[0].Width = 50;
        }
        #endregion

        #region The optional Taps
        public void displayColor(int id)
        {
            string query = "select distinct Color_ID as 'كود',Color_Name as 'الأسم' from color where Type_ID=" + id + " order by Color_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewColor.DataSource = dt;
            dataGridViewColor.Columns[0].Width = 50;
        }
        public void displayColor()
        {
            string query = "select distinct Color_ID as 'كود',Type_Name as 'النوع',Color_Name as 'اللون' from color inner join type on color.Type_ID=type.Type_ID  order by Color_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewColor.DataSource = dt;
            dataGridViewColor.Columns[0].Width = 50;
        }
        public void displaySize(int id)
        {
            string query = "select distinct Size_ID as 'كود',Size_Value as 'المقاس' from size where Factory_ID=" + id + " order by Size_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewSize.DataSource = dt;
            dataGridViewSize.Columns[0].Width = 50;
        }
        public void displaySize()
        {
            string query = "select distinct Size_ID as 'كود',Factory_Name as 'المصنع',Size_Value as 'المقاس' from size inner join factory on factory.Factory_ID=size.Factory_ID  order by Size_ID";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewSize.DataSource = dt;
            dataGridViewSize.Columns[0].Width = 50;
        }
        public void displaySort()
        {
            string query = "select Sort_ID as 'كود',Sort_Value as 'الفرز' from sort";
            MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewSort.DataSource = dt;
        }
        #endregion

        #region Hellper Functions
        public void RestControls()
        {
            displayType();
            comFactory.Text = "";
            // comType.Text = "";
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
        public void updateTablesDB(string tableName, string ColumnName, int id)
        {
            string query = "ALTER TABLE " + tableName + " AUTO_INCREMENT = 1;";
            MySqlCommand com = new MySqlCommand(query, dbconnection);
            com.ExecuteNonQuery();
        }
        public void ClearButtonsColor()
        {
            foreach (Control control in this.tableLayoutPanel2.Controls)
            {
                if (control is Button)
                    control.BackColor = Color.FromArgb(229, 229, 229);
            }
        }
        public void dataGridViewStyle()
        {
            foreach (DataGridView item in this.DataGridViewList)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle(dataGridView1.ColumnHeadersDefaultCellStyle);
                style.ForeColor = Color.AliceBlue;
                item.ColumnHeadersDefaultCellStyle = style;
                item.RowHeadersDefaultCellStyle = style;
            }
        }
        #endregion


    }
}
