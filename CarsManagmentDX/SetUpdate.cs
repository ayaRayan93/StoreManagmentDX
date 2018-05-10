﻿using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
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
    public partial class SetUpdate : Form
    {
        XtraTabPage xtraTabPage = null;
        XtraTabControl xtraTabControlStoresContent = null;
        MySqlConnection dbconnection;
        DataRowView updateRow=null;
        DataGridViewRow row1 = null, row2 = null;
        bool loaded=false;
        TipImage tipImage = null;
        Ataqm ataqm = null;
        public SetUpdate(DataRowView setRow,Ataqm ataqm, XtraTabControl xtraTabControlStoresContent)
        {
            try
            {
                InitializeComponent();
                this.ataqm = ataqm;
                this.xtraTabControlStoresContent = xtraTabControlStoresContent;
                dbconnection = new MySqlConnection(connection.connectionString);
                this.updateRow = setRow;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();

        }
        private void setUpdateData_Load(object sender, EventArgs e)
        {
            try
            {
                xtraTabPage = getTabPage("تعديل طقم");
                dbconnection.Open();
               
                string query = "select * from type";
                MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comType.DataSource = dt;
                comType.DisplayMember = dt.Columns["Type_Name"].ToString();
                comType.ValueMember = dt.Columns["Type_ID"].ToString();
                comType.Text = "";
                txtType.Text = "";

                query = "select * from factory";
                da = new MySqlDataAdapter(query, dbconnection);
                dt = new DataTable();
                da.Fill(dt);
                comFactory.DataSource = dt;
                comFactory.DisplayMember = dt.Columns["Factory_Name"].ToString();
                comFactory.ValueMember = dt.Columns["Factory_ID"].ToString();
                comFactory.Text = "";
                txtFactory.Text = "";

                query = "select * from groupo";
                da = new MySqlDataAdapter(query, dbconnection);
                dt = new DataTable();
                da.Fill(dt);
                comGroup.DataSource = dt;
                comGroup.DisplayMember = dt.Columns["Group_Name"].ToString();
                comGroup.ValueMember = dt.Columns["Group_ID"].ToString();
                comGroup.Text = "";
                txtGroup.Text = "";

                query = "select * from product";
                da = new MySqlDataAdapter(query, dbconnection);
                dt = new DataTable();
                da.Fill(dt);
                comProduct.DataSource = dt;
                comProduct.DisplayMember = dt.Columns["Product_Name"].ToString();
                comProduct.ValueMember = dt.Columns["Product_ID"].ToString();
                comProduct.Text = "";
                txtProduct.Text = "";


                setUpdateData();
                loaded = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }
        private void comBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                ComboBox comBox = (ComboBox)sender;

                switch (comBox.Name)
                {
                    case "comType":
                        txtType.Text = comType.SelectedValue.ToString();
                        displayProducts();
                        break;
                    case "comFactory":
                        txtFactory.Text = comFactory.SelectedValue.ToString();
                        displayProducts();
                        break;
                    case "comGroup":
                        txtGroup.Text = comGroup.SelectedValue.ToString();
                        displayProducts();
                        break;
                    case "comProduct":
                        txtProduct.Text = comProduct.SelectedValue.ToString();
                        displayProducts();
                        break;
                }
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
                            case "txtType":
                                query = "select Type_Name from type where Type_ID='" + txtType.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comType.Text = Name;
                                    txtFactory.Focus();
                                    dbconnection.Close();
                                    displayProducts();
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;
                            case "txtFactory":
                                query = "select Factory_Name from factory where Factory_ID='" + txtFactory.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comFactory.Text = Name;
                                    txtGroup.Focus();
                                    dbconnection.Close();
                                    displayProducts();
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;
                            case "txtGroup":
                                query = "select Group_Name from groupo where Group_ID='" + txtGroup.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comGroup.Text = Name;
                                    txtProduct.Focus();
                                    dbconnection.Close();
                                    displayProducts();
                                }
                                else
                                {
                                    MessageBox.Show("there is no item with this id");
                                    dbconnection.Close();
                                    return;
                                }
                                break;
                            case "txtProduct":
                                query = "select Product_Name from product where Product_ID='" + txtProduct.Text + "'";
                                com = new MySqlCommand(query, dbconnection);
                                if (com.ExecuteScalar() != null)
                                {
                                    Name = (string)com.ExecuteScalar();
                                    comProduct.Text = Name;
                                    txtType.Focus();
                                    dbconnection.Close();
                                    displayProducts();
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
                    MessageBox.Show(ex.ToString());
                }
                dbconnection.Close();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            displayProducts();

        }      
        private void btnUpdateSet_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                deleteSet(Convert.ToInt16(updateRow[0].ToString()));
                if (dataGridView2.Rows.Count > 0)
                {
                    if (txtSetName.Text != "" && txtFactory.Text != "" && txtGroup.Text != "" && txtType.Text != "")
                    {
                        string query = "select Set_Name from sets where Type_ID=" + txtType.Text + " and Group_ID=" + txtGroup.Text + " and Factory_ID=" + txtFactory.Text;
                        MySqlCommand comand = new MySqlCommand(query, dbconnection);
                       
                        MySqlDataReader dr = comand.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["Set_Name"].ToString() == txtSetName.Text)
                            {
                                MessageBox.Show("this set already exist");
                                dr.Close();
                                dbconnection.Close();
                                return;
                            }
                        }
                        dr.Close();

                        //query = "INSERT INTO sets (Set_Name,Factory_ID,Type_ID,Group_ID) VALUES (@Set_Name,@Factory_ID,@Type_ID,@Group_ID)";
                        //comand = new MySqlCommand(query, dbconnection);
                        //comand.Parameters.AddWithValue("@Set_Name", txtSetName.Text);
                        //comand.Parameters.AddWithValue("@Factory_ID", txtFactory.Text);
                        //comand.Parameters.AddWithValue("@Type_ID", txtType.Text);
                        //comand.Parameters.AddWithValue("@Group_ID", txtGroup.Text);
                        query = "update sets Set_Name=@Set_Name where Set_ID="+ updateRow[0].ToString();
                        comand = new MySqlCommand(query, dbconnection);
                        comand.Parameters.AddWithValue("@Set_Name", txtSetName.Text);
                        comand.ExecuteNonQuery();

                        //query = "select Set_ID from sets order by Set_ID desc limit 1";
                        //comand = new MySqlCommand(query, dbconnection);
                        //int set_id = Convert.ToInt16(comand.ExecuteScalar().ToString());
                        int set_id = Convert.ToInt16(updateRow[0].ToString());
                        foreach (DataGridViewRow item in dataGridView2.Rows)
                        {
                            query = "INSERT INTO set_Details (Set_ID,Code,Quantity) VALUES (@Set_ID,@Code,@Quantity)";
                            comand = new MySqlCommand(query, dbconnection);
                            comand.Parameters.AddWithValue("@Set_ID", set_id);
                            comand.Parameters.AddWithValue("@Code", item.Cells[1].Value);
                            comand.Parameters.AddWithValue("@Quantity", double.Parse(item.Cells[2].Value.ToString()));
                            comand.ExecuteNonQuery();
                        }

                        UserControl.UserRecord("sets", "update", set_id.ToString(), DateTime.Now, dbconnection);

                        MessageBox.Show("Done");
                        dataGridView1.Rows.Clear();
                        dataGridView2.Rows.Clear();
                        comFactory.Text = "";
                        txtFactory.Text = "";
                        comGroup.Text = "";
                        txtGroup.Text = "";
                        comType.Text = "";
                        txtType.Text = "";
                        comProduct.Text = "";
                        txtProduct.Text = "";
                        txtCode.Text = "";
                        txtQuantity.Text = "1";
                        ataqm.DisplayAtaqm();
                        xtraTabPage.ImageOptions.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Please fill all fields with right format");
                    }
                }
                else
                {
                    MessageBox.Show("Please insert at least one item");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                row1 = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];
                row1.Selected = true;
                txtCode.Text = row1.Cells["Code"].Value.ToString();
                if (tipImage == null)
                {
                    tipImage = new TipImage(row1.Cells[1].Value.ToString());
                    tipImage.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                    tipImage.Show();
                }
                else
                {
                    tipImage.Close();
                    tipImage = new TipImage(row1.Cells[1].Value.ToString());
                    tipImage.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                    tipImage.Show();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                row2 = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex];
                row2.Selected = true;
                if (tipImage == null)
                {
                    tipImage = new TipImage(row2.Cells[1].Value.ToString());
                    tipImage.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                    tipImage.Show();
                }
                else
                {
                    tipImage.Close();
                    tipImage = new TipImage(row2.Cells[1].Value.ToString());
                    tipImage.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                    tipImage.Show();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        private void btnPut_Click(object sender, EventArgs e)
        {

        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (row2 != null)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = row2.Cells[0].Value;
                    dataGridView1.Rows[n].Cells[1].Value = row2.Cells[1].Value;
                    dataGridView1.Rows[n].Cells[2].Value = row2.Cells[3].Value;
                    dataGridView1.Rows[n].Cells[3].Value = row2.Cells[4].Value;
                    dataGridView1.Rows[n].Cells[4].Value = row2.Cells[5].Value;
                    dataGridView1.Rows[n].Cells[5].Value = row2.Cells[6].Value;
                    dataGridView1.Rows[n].Cells[6].Value = row2.Cells[7].Value;
                    dataGridView1.Rows[n].Cells[7].Value = row2.Cells[8].Value;
                    dataGridView1.Rows[n].Cells[8].Value = row2.Cells[9].Value;
                    dataGridView1.Rows[n].Cells[9].Value = row2.Cells[10].Value;
                    dataGridView1.Rows[n].Cells[10].Value = row2.Cells[11].Value;
                    dataGridView1.Rows[n].Cells[11].Value = row2.Cells[12].Value;
                    dataGridView2.Rows.Remove(row2);

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
        }
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (loaded)
                {
                    xtraTabPage.ImageOptions.Image = Properties.Resources.unsave;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tLPanProductsContainer_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (tipImage != null)
                {
                    tipImage.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //function
        public void displayProducts()
        {
            try
            {
                dbconnection.Open();
              
                string q1, q2, q3, q4;
                if (txtType.Text == "")
                {
                    q1 = "select Type_ID from type";
                }
                else
                {
                    q1 = txtType.Text;
                }
                if (txtFactory.Text == "")
                {
                    q2 = "select Factory_ID from factory";
                }
                else
                {
                    q2 = txtFactory.Text;
                }
                if (txtProduct.Text == "")
                {
                    q3 = "select Product_ID from product";
                }
                else
                {
                    q3 = txtProduct.Text;
                }
                if (txtGroup.Text == "")
                {
                    q4 = "select Group_ID from groupo";
                }
                else
                {
                    q4 = txtGroup.Text;
                }

                string query = "SELECT data.Data_ID,data.Code,product.Product_Name,type.Type_Name,factory.Factory_Name,groupo.Group_Name,color.Color_Name,size.Size_Value,sort.Sort_Value,data.Classification,data.Description,data.Carton from data INNER JOIN type ON type.Type_ID = data.Type_ID INNER JOIN product ON product.Product_ID = data.Product_ID INNER JOIN factory ON data.Factory_ID = factory.Factory_ID INNER JOIN groupo ON data.Group_ID = groupo.Group_ID LEFT outer JOIN color ON data.Color_ID = color.Color_ID LEFT outer  JOIN size ON data.Size_ID = size.Size_ID LEFT outer  JOIN sort ON data.Sort_ID = sort.Sort_ID where  data.Type_ID IN(" + q1 + ") and  data.Factory_ID  IN(" + q2 + ") and  data.Product_ID  IN(" + q3 + ") and data.Group_ID IN (" + q4 + ") group by data.Code";
                MySqlCommand comand = new MySqlCommand(query, dbconnection);
                dataGridView1.Rows.Clear();
                MySqlDataReader dr = comand.ExecuteReader();
                while (dr.Read())
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells["Data_ID"].Value = dr[0];
                    dataGridView1.Rows[n].Cells["Code"].Value = dr[1];
                    dataGridView1.Rows[n].Cells["Product_Name"].Value = dr[2];
                    dataGridView1.Rows[n].Cells["Type_Name"].Value = dr[3];
                    dataGridView1.Rows[n].Cells["Factory_Name"].Value = dr[4];
                    dataGridView1.Rows[n].Cells["Group_Name"].Value = dr[5];
                    dataGridView1.Rows[n].Cells["Colour"].Value = dr[6];
                    dataGridView1.Rows[n].Cells["Size"].Value = dr[7];
                    dataGridView1.Rows[n].Cells["Sort"].Value = dr[8];
                    dataGridView1.Rows[n].Cells["Classification"].Value = dr[9];
                    dataGridView1.Rows[n].Cells["Description"].Value = dr[10];
                    dataGridView1.Rows[n].Cells["Carton"].Value = dr[11];
                }
                dr.Close();
                dataGridView1.Columns[1].Width = 180;
                loaded = true;
                filtterRows();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }

        public void filtterRows()
        {
            if (dataGridView2.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    foreach (DataGridViewRow item1 in dataGridView1.Rows)
                    {
                        if (item.Cells["Code2"].Value.Equals(item1.Cells["Code"].Value))
                            dataGridView1.Rows.Remove(item1);
                    }

                }
            }
        }

        public void setUpdateData()
        {
            txtSetName.Text = updateRow[1].ToString();
            comType.Text = updateRow[2].ToString();
            comGroup.Text = updateRow[3].ToString();
            comFactory.Text = updateRow[4].ToString();
          
            string query = "select Type_ID,Factory_ID,Group_ID from sets where Set_ID=" + updateRow[0].ToString();
            MySqlCommand com = new MySqlCommand(query, dbconnection);
            MySqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                txtType.Text = dr["Type_ID"].ToString();
                txtFactory.Text = dr["Factory_ID"].ToString();
                txtGroup.Text = dr["Group_ID"].ToString();
            }
            dr.Close();

            query = "SELECT data.Data_ID,data.Code,product.Product_Name,type.Type_Name,factory.Factory_Name,groupo.Group_Name,color.Color_Name,size.Size_Value,sort.Sort_Value,data.Classification,data.Description,data.Carton,set_details.Quantity from data INNER JOIN type ON type.Type_ID = data.Type_ID INNER JOIN product ON product.Product_ID = data.Product_ID INNER JOIN factory ON data.Factory_ID = factory.Factory_ID INNER JOIN groupo ON data.Group_ID = groupo.Group_ID LEFT outer JOIN color ON data.Color_ID = color.Color_ID LEFT outer  JOIN size ON data.Size_ID = size.Size_ID LEFT outer  JOIN sort ON data.Sort_ID = sort.Sort_ID inner join set_Details on set_Details.Code=data.Code inner join sets on sets.Set_ID=set_details.Set_ID where set_details.Set_ID=" + updateRow[0].ToString();


            MySqlCommand comand = new MySqlCommand(query, dbconnection);
            dataGridView2.Rows.Clear();
            dr = comand.ExecuteReader();
            while (dr.Read())
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells["Data_ID2"].Value = dr[0];
                dataGridView2.Rows[n].Cells["Code2"].Value = dr[1];
                dataGridView2.Rows[n].Cells["Product2"].Value = dr[2];
                dataGridView2.Rows[n].Cells["Type2"].Value = dr[3];
                dataGridView2.Rows[n].Cells["Factory2"].Value = dr[4];
                dataGridView2.Rows[n].Cells["Group2"].Value = dr[5];
                dataGridView2.Rows[n].Cells["Color2"].Value = dr[6];
                dataGridView2.Rows[n].Cells["Size2"].Value = dr[7];
                dataGridView2.Rows[n].Cells["Sort2"].Value = dr[8];
                dataGridView2.Rows[n].Cells["Classification2"].Value = dr[9];
                dataGridView2.Rows[n].Cells["Description2"].Value = dr[10];
                dataGridView2.Rows[n].Cells["Carton2"].Value = dr[11];
                dataGridView2.Rows[n].Cells["Quantity"].Value = dr[12];
            }
            dr.Close();
            dataGridView2.Columns[1].Width = 180;

           

        }

        public void deleteSet(int id)
        {
            //String query = "delete from sets where Set_ID=" + id;
            //MySqlCommand com = new MySqlCommand(query, dbconnection);
            //com.ExecuteNonQuery();
            String query = "delete from set_details where Set_ID=" + id;
            MySqlCommand com = new MySqlCommand(query, dbconnection);
            com.ExecuteNonQuery();

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

    }
}
