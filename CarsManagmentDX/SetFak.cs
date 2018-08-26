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
    public partial class SetFak : Form
    {
        MySqlConnection dbconnection, dbconnection1, dbconnection2;
        bool loaded = false;
        bool flag = false;
        public SetFak()
        {
            InitializeComponent();
            dbconnection = new MySqlConnection(connection.connectionString);
            dbconnection1 = new MySqlConnection(connection.connectionString);
            dbconnection2 = new MySqlConnection(connection.connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from store ";
                MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comStore.DataSource = dt;
                comStore.DisplayMember = dt.Columns["Store_Name"].ToString();
                comStore.ValueMember = dt.Columns["Store_ID"].ToString();
                comStore.Text = "";
                txtStoreID.Text = "";

                query = "select * from sets inner join factory on sets.Factory_ID=factory.Factory_ID inner join type on sets.Type_ID=type.Type_ID inner join groupo on groupo.Group_ID=sets.Group_ID";
                da = new MySqlDataAdapter(query, dbconnection);
                dt = new DataTable();
                da.Fill(dt);
                comFactory.DataSource = dt;
                comFactory.DisplayMember = dt.Columns["Factory_Name"].ToString();
                comFactory.ValueMember = dt.Columns["Factory_ID"].ToString();
                comFactory.Text = "";
                txtFactory.Text = "";


                comType.DataSource = dt;
                comType.DisplayMember = dt.Columns["Type_Name"].ToString();
                comType.ValueMember = dt.Columns["Type_ID"].ToString();
                comType.Text = "";
                txtType.Text = "";


                comGroup.DataSource = dt;
                comGroup.DisplayMember = dt.Columns["Group_Name"].ToString();
                comGroup.ValueMember = dt.Columns["Group_ID"].ToString();
                comGroup.Text = "";
                txtGroup.Text = "";

                loaded = true;
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
                if (loaded)
                {
                    ComboBox comBox = (ComboBox)sender;

                    switch (comBox.Name)
                    {
                        case "comFactory":
                            txtFactory.Text = comFactory.SelectedValue.ToString();
                            Search();
                            break;
                        case "comType":
                            txtType.Text = comType.SelectedValue.ToString();
                            Search();
                            break;
                        case "comGroup":
                            txtGroup.Text = comGroup.SelectedValue.ToString();
                            Search();
                            break;
                        case "comStore":
                            txtStoreID.Text = comStore.SelectedValue.ToString();
                            break;
                        case "comSets":
                            if (flag)
                            {
                                txtSetsID.Text = comSets.SelectedValue.ToString();
                                displayQuantitySet();
                            }
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
            TextBox txtBox = (TextBox)sender;
            string query;
            MySqlCommand com;
            string Name;
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtBox.Text != "")
                    {
                        dbconnection.Open();
                        switch (txtBox.Name)
                        {
                            case "txtFactory":
                                query = "select Factory_Name from sets where Factory_ID='" + txtFactory.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comFactory.Text = Name;
                                    Search();
                                    txtGroup.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;
                            case "txtType":
                                query = "select Type_Name from sets where Type_ID='" + txtType.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comType.Text = Name;
                                    Search();
                                    txtFactory.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;
                            case "txtGroup":
                                query = "select Group_Name from sets where Group_ID='" + txtGroup.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comGroup.Text = Name;
                                    Search();
                                    txtSetsID.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;
                            case "txtStoreID":
                                query = "select Store_Name from store where Store_ID='" + txtStoreID.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comStore.Text = Name;
                                    txtFactory.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;
                            case "txtSetsID":
                                if (flag)
                                {
                                    query = "select Set_Name from sets where Set_ID='" + txtSetsID.Text + "'";
                                    com = new MySqlCommand(query, dbconnection);
                                    if (com.ExecuteScalar() != null)
                                    {
                                        Name = (string)com.ExecuteScalar();
                                        comSets.Text = Name;
                                        displayQuantitySet();
                                        txtStoreID.Focus();
                                    }
                                    else
                                    {
                                        MessageBox.Show("there is no item with this id");
                                        dbconnection.Close();
                                        return;
                                    }
                                }
                                break;
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                dbconnection.Close();
            }
        }

        private void btnFak_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                dataGridView1.Rows.Clear();
                double quantitySet;
                if (double.TryParse(txtSetQuantity.Text, out quantitySet))
                {
                    int id;
                    if (int.TryParse(txtSetsID.Text, out id))
                    {
                        double q = fakSet(quantitySet,id);
                        increaseItemsQuantity(q, id);
                    }
                    else
                    {
                        MessageBox.Show("enter correct value");
                    }
                }
                else
                {
                    MessageBox.Show("enter correct value");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                RecordSetQuantityInStorage(Convert.ToDouble(txtSetQuantity.Text), Convert.ToInt16(txtSetsID.Text));
                increaseItemsQuantityInDB(Convert.ToDouble(txtSetQuantity.Text), Convert.ToInt16(txtSetsID.Text));
                MessageBox.Show("Done");
                dataGridView1.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }

        //functions 
        //display quantity of set in store
        public void displayQuantitySet()
        {
            dbconnection.Open();
            int SetID, StoreID;
            if (int.TryParse(txtSetsID.Text, out SetID) && int.TryParse(txtStoreID.Text, out StoreID))
                {
                string query = "select Total_Meters from storage  where Data_ID='" + SetID + "' and Store_ID=" + StoreID;
                MySqlCommand com = new MySqlCommand(query, dbconnection);
                if (com.ExecuteScalar() != null)
                {
                    double storeQuantity = Convert.ToDouble(com.ExecuteScalar());
                    txtTotalQuantitySet.Text = storeQuantity.ToString();
                }
                else
                {
                    MessageBox.Show("we don't have this set in  store");
                }
            }
            else
            {
                MessageBox.Show("enter correct value");
            }
            dbconnection.Close();
        }
        // الطقم تفكيك
        public double fakSet(double quantitySetFak, int SetID)
        {
           
            string query = "select Total_Meters from storage  where Data_ID='" + SetID+ "' and Store_ID=" + txtStoreID.Text;
            MySqlCommand com = new MySqlCommand(query,dbconnection);
            if (com.ExecuteScalar() != null)
            {
                double storeQuantity = Convert.ToDouble(com.ExecuteScalar());
                if (quantitySetFak <= storeQuantity)
                {
                   return quantitySetFak;
                }
                else
                {
                    MessageBox.Show("this quantity is bigegr than which in store");
                }
            }
            else
            {
                MessageBox.Show("we don't have this set in  store");
            }
            return -1;
        }
        //record to database
        public void RecordSetQuantityInStorage(double newQuantitySet, int SetID)
        {
            string query = "select Total_Meters from storage  where Data_ID='" + SetID + "' and Store_ID=" + txtStoreID.Text;
            MySqlCommand com = new MySqlCommand(query, dbconnection);
            if (com.ExecuteScalar() != null)
            {
                double storeQuantity = Convert.ToDouble(com.ExecuteScalar());
                query = "update storage set Total_Meters =" + (storeQuantity - newQuantitySet) + "  where Data_ID=" + SetID + " and Store_ID=" + txtStoreID.Text;
                com = new MySqlCommand(query, dbconnection);
                com.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("we don't have this set in  store");
            }
        }
        //increase the quantity of taqm items
        public void increaseItemsQuantity(double TaqmQuantity,int setID)
        {
            if (TaqmQuantity>0)
            {
                dbconnection1.Open();
                dbconnection2.Open();
                string query = "select Data_ID,Quantity from set_details  where Set_ID=" + setID;
                MySqlCommand com = new MySqlCommand(query,dbconnection);
                MySqlDataReader dr = com.ExecuteReader();
                while(dr.Read())
                {
                    query = "select sum(Total_Meters) from storage where Data_ID='" + dr["Data_ID"].ToString()+ "' group by Store_ID having Store_ID=" + txtStoreID.Text ;
                    MySqlCommand com1 = new MySqlCommand(query, dbconnection1);
                    double QuantityInStore = Convert.ToDouble(com1.ExecuteScalar());
                    double QuantityInSet= Convert.ToDouble(dr["Quantity"].ToString());
                    double newQuantity = QuantityInStore+(QuantityInSet * TaqmQuantity);
                    query = "select distinct data.Code as 'الكود' , type.Type_Name as 'النوع', factory.Factory_Name as 'المصنع' ,groupo.Group_Name as 'المجموعة', product.Product_Name as 'المنتج' ,data.Colour as 'لون', data.Size as 'المقاس', data.Sort as 'الفرز' from data INNER JOIN type ON type.Type_ID = data.Type_ID INNER JOIN product ON product.Product_ID = data.Product_ID INNER JOIN factory ON data.Factory_ID = factory.Factory_ID INNER JOIN groupo ON data.Group_ID = groupo.Group_ID  where Data_ID=" + dr["Data_ID"].ToString() + "";

                    com = new MySqlCommand(query, dbconnection1);
                    MySqlDataReader dataReader1 = com.ExecuteReader();
                    while (dataReader1.Read())
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["ProductCode"].Value = dataReader1["الكود"].ToString();
                        dataGridView1.Rows[n].Cells["Type_Name"].Value = dataReader1["النوع"].ToString();
                        dataGridView1.Rows[n].Cells["Factory_Name"].Value = dataReader1["المصنع"].ToString();
                        dataGridView1.Rows[n].Cells["Group_Name"].Value = dataReader1["المجموعة"].ToString();
                        dataGridView1.Rows[n].Cells["ProductName"].Value = dataReader1["المنتج"].ToString();
                        dataGridView1.Rows[n].Cells["ProductColor"].Value = dataReader1["لون"].ToString();
                        dataGridView1.Rows[n].Cells["productSize"].Value = dataReader1["المقاس"].ToString();
                        dataGridView1.Rows[n].Cells["ProductSort"].Value = dataReader1["الفرز"].ToString();
                        dataGridView1.Rows[n].Cells["ProductQuantity"].Value = newQuantity.ToString();
                    }
                    dataReader1.Close();
                }
                dr.Close();
               
            }
            dbconnection1.Close();
            dbconnection2.Close();
        }
        //
        public void increaseItemsQuantityInDB(double TaqmQuantity, int setID)
        {
            if (TaqmQuantity > 0)
            {
                dbconnection1.Open();
                dbconnection2.Open();
                string query = "select Data_ID,Quantity from set_details  where Set_ID=" + setID;
                MySqlCommand com = new MySqlCommand(query, dbconnection);
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    query = "select sum(Total_Meters) from storage where Data_ID='" + dr["Data_ID"].ToString() + "' group by Store_ID having Store_ID=" + txtStoreID.Text;
                    MySqlCommand com1 = new MySqlCommand(query, dbconnection1);
                    double QuantityInStore = Convert.ToDouble(com1.ExecuteScalar());
                    double QuantityInSet = Convert.ToDouble(dr["Quantity"].ToString());
                    double newQuantity = QuantityInSet * TaqmQuantity;

                    query = "select Storage_ID,Total_Meters from storage where Data_ID='" + dr["Data_ID"].ToString() + "' and Store_ID=" + txtStoreID.Text;
                    com1 = new MySqlCommand(query, dbconnection1);
                    MySqlDataReader dr2 = com1.ExecuteReader();
                    int id = 0;
                    while (dr2.Read())
                    {
                        double storageQ = Convert.ToDouble(dr2["Total_Meters"]);
                        if (storageQ > newQuantity)
                        {
                            id = Convert.ToInt16(dr2["Storage_ID"]);
                            query = "update storage set Total_Meters=" + (storageQ + newQuantity) + " where Storage_ID=" + id;
                            MySqlCommand comm = new MySqlCommand(query, dbconnection2);
                            comm.ExecuteNonQuery();
                            break;
                        }
                    
                    }
                    dr2.Close();
                }
                dr.Close();
              
            }
            dbconnection1.Close();
            dbconnection2.Close();
        }
        //
        private void Search()
        {
            try
            {
                string q1;
                if (txtType.Text != "" && txtFactory.Text != "" && txtGroup.Text != "")
                {
                    q1 = "Type_ID =" + txtType.Text + " and Factory_ID=" + txtFactory.Text + " and Group_ID=" + txtGroup.Text;

                    string query = "select Set_ID,Set_Name from sets where " + q1;
                    MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comSets.DataSource = dt;
                    comSets.DisplayMember = dt.Columns["Set_Name"].ToString();
                    comSets.ValueMember = dt.Columns["Set_ID"].ToString();
                    groupBox1.Visible = true;
                    comSets.Text = "";
                    txtSetsID.Text = "";
                    flag = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
  

     
    }
}
