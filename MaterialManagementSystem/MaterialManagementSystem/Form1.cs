using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MaterialManagementSystem
{
    public partial class Form1 : Form
    {
        string cnStr = Properties.Settings.Default.MaterialManagementSystemConnectionString;
        string path = @"D:\Larrys file\programing\WindowsForm\MaterialManagementSystem2\MaterialManagementSystem\MaterialManagementSystem\img\prodPhoto\";//圖片位置
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'materialManagementSystemDataSet5.CheckList' table. You can move, or remove it, as needed.
            this.checkListTableAdapter1.Fill(this.materialManagementSystemDataSet5.CheckList);
            // TODO: This line of code loads data into the 'materialManagementSystemDataSet4.CheckList' table. You can move, or remove it, as needed.
            this.checkListTableAdapter.Fill(this.materialManagementSystemDataSet4.CheckList);
            // TODO: This line of code loads data into the 'materialManagementSystemDataSet3.SupplierElements' table. You can move, or remove it, as needed.
            this.supplierElementsTableAdapter.Fill(this.materialManagementSystemDataSet3.SupplierElements);
            // TODO: This line of code loads data into the 'materialManagementSystemDataSet2.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.materialManagementSystemDataSet2.Suppliers);
            // TODO: This line of code loads data into the 'materialManagementSystemDataSet1.Elements' table. You can move, or remove it, as needed.
            this.elementsTableAdapter.Fill(this.materialManagementSystemDataSet1.Elements);

            //newpanel.Visible = false;
            SupplierListPanel.Visible = false;//廠商列表頁面
            newElementsPanel.Visible = false;//新增料件頁面
            Checkpanel.Visible = false;//審核頁面
            SearchmaterialsMenu_btn.ForeColor = Color.Black;
            SearchmaterialsMenu_btn.BackColor = Color.White;
            CheckID_txt.Text=CheckListUtility.SentNewCheckIDBack().ToString();
            

        }

        private void SearchmaterialsMenu_btn_Click(object sender, EventArgs e)
        {
            searchpanel.Visible = true;
            newElementsPanel.Visible = false;
            SupplierListPanel.Visible = false;
            Checkpanel.Visible = false;
            SearchmaterialsMenu_btn.ForeColor = Color.Black;
            SearchmaterialsMenu_btn.BackColor = Color.White;
            Newmaterials_btn.ForeColor = Color.White;
            Newmaterials_btn.BackColor = Color.DodgerBlue;
            SupplierList_btn.ForeColor = Color.White;
            SupplierList_btn.BackColor = Color.DodgerBlue;
            CheckListPanel_btn.ForeColor = Color.White;
            CheckListPanel_btn.BackColor = Color.DodgerBlue;
            
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != System.DBNull.Value)
            {
                int MS_ID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                SqlConnection cn = new SqlConnection(cnStr);
                SqlCommand cmd = new SqlCommand("SELECT * FROM Elements WHERE MS_ID=@MS_ID", cn);
                cmd.Parameters.AddWithValue("@MS_ID", MS_ID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    id_txt.Text = dr[0].ToString();
                    component_txt.Text = dr[1].ToString();
                    supplier_txt.Text = dr[2].ToString();
                    config_txt.Text = dr[3].ToString();
                    description_txt.Text = dr[4].ToString();
                    qty_txt.Text = dr[6].ToString();
                    string picstring = dr[5].ToString();
                    pic_lab.Text = dr[5].ToString();
                    pictureBox2.ImageLocation = path+picstring;
                    //textBox4.Text = Convert.ToDecimal(dr[3]).ToString();
                    //Hidden_ProductID_lab.Text = dr[0].ToString();
                    //MessageBox.Show(Hidden_ProductID_lab.Text);
                }
            }

        }
        /// <summary>
        /// 請購料件panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Newmaterials_btn_Click(object sender, EventArgs e)
        {
            newElementsPanel.Visible = true;
            searchpanel.Visible = false;
            SupplierListPanel.Visible = false;
            Checkpanel.Visible = false;
            Newmaterials_btn.ForeColor = Color.Black;
            Newmaterials_btn.BackColor = Color.White;
            SearchmaterialsMenu_btn.ForeColor = Color.White;
            SearchmaterialsMenu_btn.BackColor = Color.DodgerBlue;
            SupplierList_btn.ForeColor = Color.White;
            SupplierList_btn.BackColor = Color.DodgerBlue;
            CheckListPanel_btn.ForeColor = Color.White;
            CheckListPanel_btn.BackColor = Color.DodgerBlue;

        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            Element elmt = new Element()
            {
                MS_ID = Convert.ToInt32(id_txt.Text),
                Component = component_txt.Text,
                Supplier = supplier_txt.Text,
                Config = config_txt.Text,
                Description = description_txt.Text,
                Qty = Convert.ToInt32(qty_txt.Text),
                Picture = pic_lab.Text,
                Lasteditdate = DateTime.Now
            };
            //MessageBox.Show("確定要修改嗎?", "問題", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MessageBox.Show("確定要修改嗎?", "問題", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ElementUtility.EditElement(elmt);
                dataGridView1.DataSource = ElementUtility.GetAllElement();
                dataGridView1.Refresh();
            }
            else
            {
                dataGridView1.DataSource = ElementUtility.GetAllElement();
                dataGridView1.Refresh();
            }
   
        }
        /// <summary>
        /// 刪除料件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_btn_Click(object sender, EventArgs e)
        {
            int esid = Convert.ToInt32(id_txt.Text);
            if (MessageBox.Show("確定要刪除嗎?", "問題", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ElementUtility.DeleteElementByID(esid);
                dataGridView1.DataSource = ElementUtility.GetAllElement();
                dataGridView1.Refresh();
                MessageBox.Show("刪除完成");
            }
            else
            {
                dataGridView1.DataSource = ElementUtility.GetAllElement();
                dataGridView1.Refresh();
            }
        }

        /// <summary>
        /// 選取圖片(查詢修改頁面)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //string selectedFile = openFileDialog1.FileName;//路徑
                string selectedFile = Path.GetFileName(openFileDialog1.FileName);//using system.IO;

                pic_lab.Text = selectedFile;
                pictureBox2.ImageLocation = path+pic_lab.Text;
            }
        }
        /// <summary>
        /// 查詢料件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource= ElementUtility.SearchElementsByKW(searchbox_txt.Text);
            dataGridView1.Refresh();
        }

        private void SupplierList_btn_Click(object sender, EventArgs e)
        {
            SupplierListPanel.Visible = true;
            searchpanel.Visible = false;
            newElementsPanel.Visible = false;
            Checkpanel.Visible = false;
            SupplierList_btn.ForeColor = Color.Black;
            SupplierList_btn.BackColor = Color.White;
            SearchmaterialsMenu_btn.ForeColor = Color.White;
            SearchmaterialsMenu_btn.BackColor = Color.DodgerBlue;
            Newmaterials_btn.ForeColor = Color.White;
            Newmaterials_btn.BackColor = Color.DodgerBlue;
            CheckListPanel_btn.ForeColor = Color.White;
            CheckListPanel_btn.BackColor = Color.DodgerBlue;
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[0].Value != System.DBNull.Value)
            {
                int SupID = (int)dataGridView2.Rows[e.RowIndex].Cells[0].Value;
                SqlConnection cn = new SqlConnection(cnStr);
                SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers WHERE SupplierID=@SupplierID", cn);
                cmd.Parameters.AddWithValue("@SupplierID", SupID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    HideSID_lab.Text = dr[0].ToString();
                    HideSID2_lab.Text = dr[0].ToString();
                    textBox1.Text = dr[1].ToString();
                    textBox2.Text = dr[2].ToString();
                    textBox3.Text = dr[3].ToString();
                    textBox4.Text = dr[4].ToString();
                    textBox5.Text = dr[5].ToString();

                }
                cn.Close();
                SqlDataAdapter da = new SqlDataAdapter("Select * From SupplierElements Where SupplierID=@SupplierID", cn);
                da.SelectCommand.Parameters.AddWithValue("@SupplierID", SupID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                var query = from row in dt.AsEnumerable()
                            select new SupplierElements() {
                                  SupplierID=Convert.ToInt32(row["SupplierID"]),
                                  Product=row["Product"].ToString()
                            };
                dataGridView3.DataSource = query.ToList();
                dataGridView3.Refresh();
                //dataGridView3.Columns.RemoveAt(0);
            }
        }
        /// <summary>
        /// 修改公司基本資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supplierinfoedit_btn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                Supplier sp = new Supplier() {
                     SupplierID=Convert.ToInt32(HideSID_lab.Text),
                      CompanyName=textBox1.Text,
                       Address=textBox2.Text,
                        Contact=textBox3.Text,
                         DirectTelephone=textBox4.Text,
                          Email=textBox5.Text
                };
                SupplierUtility.EditSupplier(sp);
                dataGridView2.DataSource = SupplierUtility.GetAllSuppliers();
                dataGridView2.Refresh();
                supplierinfoedit_btn.Visible = false;
                OpenEdit_btn.Visible = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox1.BackColor = Color.LightGray;
                textBox2.BackColor = Color.LightGray;
                textBox3.BackColor = Color.LightGray;
                textBox4.BackColor = Color.LightGray;
                textBox5.BackColor = Color.LightGray;
            }
            else
            {
                MessageBox.Show("請選取欲修改公司");
            }


        }
        /// <summary>
        /// 依廠商編號添加供應料件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supplierelmtnew_btn_Click(object sender, EventArgs e)
        {
            if (HideSID2_lab.Text!="")
            {
                SupplierElements supelmt = new SupplierElements() {
                    SupplierID = Convert.ToInt32(HideSID2_lab.Text),
                     Product=textBox6.Text
                };
                int SupID = Convert.ToInt32(HideSID2_lab.Text);
                SupplierUtility.SupplierElementsnew(supelmt);
                SqlDataAdapter da = new SqlDataAdapter("Select * From SupplierElements Where SupplierID=@SupplierID", cnStr);
                da.SelectCommand.Parameters.AddWithValue("@SupplierID", SupID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                var query = from row in dt.AsEnumerable()
                            select new SupplierElements()
                            {
                                SupplierID = Convert.ToInt32(row["SupplierID"]),
                                Product = row["Product"].ToString()
                            };

                dataGridView3.DataSource = query.ToList();
                dataGridView3.Refresh();
                //dataGridView3.Columns.RemoveAt(0);
            }
            else
            {
                MessageBox.Show("請選取欲增加料件的公司");
            }

        }
        /// <summary>
        /// 清空公司和料件資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            HideSID_lab.Text = "";
            HideSID2_lab.Text = "";
            dataGridView3.DataSource = null;
        }
        /// <summary>
        /// 供應商資料刪除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supplierinfodelete_btn_Click(object sender, EventArgs e)
        {
            if (HideSID_lab.Text!="")
            {
                if (MessageBox.Show("確定要刪除嗎?", "問題", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SupplierUtility.DeleteSupplier(Convert.ToInt32(HideSID_lab.Text));
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    HideSID_lab.Text = "";
                    HideSID2_lab.Text = "";
                    dataGridView3.DataSource = null;
                    dataGridView2.DataSource = SupplierUtility.GetAllSuppliers();
                    dataGridView2.Refresh();
                }
                else
                {
                    dataGridView2.DataSource = SupplierUtility.GetAllSuppliers();
                    dataGridView2.Refresh();
                }
            }
            else
            {
                MessageBox.Show("請選取欲刪除公司");
            }


        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Rows[e.RowIndex].Cells[0].Value != System.DBNull.Value)
            {
                int SupID = (int)dataGridView3.Rows[e.RowIndex].Cells[0].Value;
                string prod = Convert.ToString(dataGridView3.Rows[e.RowIndex].Cells[1].Value);
                SqlConnection cn = new SqlConnection(cnStr);
                SqlCommand cmd = new SqlCommand("Select * From SupplierElements Where SupplierID=@SupplierID and Product=@Product", cn);
                cmd.Parameters.AddWithValue("@SupplierID", SupID);
                cmd.Parameters.AddWithValue("@Product", prod);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    HideSID2_lab.Text = dr[0].ToString();
                    hideproduct_lab.Text = dr[1].ToString();

                }
                cn.Close();

            }
        }
        /// <summary>
        /// 刪除供應商提供的料件類別
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supplierelmtdelete_btn_Click(object sender, EventArgs e)
        {
            if (hideproduct_lab.Text!="")
            {
                if (MessageBox.Show("確定要刪除嗎?", "問題", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int SupID = Convert.ToInt32(HideSID2_lab.Text);
                    string Prod = hideproduct_lab.Text;
                    SupplierUtility.DeleteSupplierElement(SupID, Prod);
                    SqlDataAdapter da = new SqlDataAdapter("Select * From SupplierElements Where SupplierID=@SupplierID", cnStr);
                    da.SelectCommand.Parameters.AddWithValue("@SupplierID", SupID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    var query = from row in dt.AsEnumerable()
                                select new SupplierElements()
                                {
                                    SupplierID = Convert.ToInt32(row["SupplierID"]),
                                    Product = row["Product"].ToString()
                                };

                    dataGridView3.DataSource = query.ToList();
                    dataGridView3.Refresh();
                }
            }
            else
            {
                MessageBox.Show("請選取欲刪除的料件");
            }
        }
        /// <summary>
        /// 開啟修改供應商資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenEdit_btn_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            OpenEdit_btn.Visible = false;
            supplierinfoedit_btn.Visible = true;
            CancelEdit_btn.Visible = true;
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            textBox5.BackColor = Color.White;

        }
        /// <summary>
        /// 關閉修改供應商資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelEdit_btn_Click(object sender, EventArgs e)
        {
            OpenEdit_btn.Visible = true;
            supplierinfoedit_btn.Visible = false;
            CancelEdit_btn.Visible = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox1.BackColor = Color.LightGray;
            textBox2.BackColor = Color.LightGray;
            textBox3.BackColor = Color.LightGray;
            textBox4.BackColor = Color.LightGray;
            textBox5.BackColor = Color.LightGray;
        }


        /// <summary>
        /// 根據選擇的廠商，顯示該廠商供應的料件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newSupplier_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            newelement_cbx.Items.Clear();
            List<SupplierElements> supelmtList=CheckListUtility.GetProductBycomboID(Convert.ToInt32(newSupplier_cbx.SelectedValue));
            for (int i = 0; i < supelmtList.Count; i++)
            {
                newelement_cbx.Items.Add(supelmtList[i].Product);

            }
        }
        /// <summary>
        /// 計算總價(含稅)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newTotalPrice_txt_Click(object sender, EventArgs e)
        {
            if (newQty_txt.Text==""||newPerPrice_txt.Text==""||newTax_txt.Text=="")
            {
                MessageBox.Show("尚未輸入數量、單價或稅");
            }
            else
            {
                int PerPrice, Qty;
                double Tax, TaxPrice, TotalPrice, TotalPriceTaxed;
                Qty = Convert.ToInt32(newQty_txt.Text);
                PerPrice = Convert.ToInt32(newPerPrice_txt.Text);
                Tax = Convert.ToDouble(newTax_txt.Text) / Convert.ToDouble(100);
                TotalPrice = Qty * PerPrice;
                TaxPrice = TotalPrice * Tax;
                TotalPriceTaxed = TotalPrice + TaxPrice;
                newTotalPrice_txt.Text = TotalPriceTaxed.ToString();

            }
        }

        /// <summary>
        /// 送審
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SenttoCheck_btn_Click(object sender, EventArgs e)
        {

            CheckList clist = new CheckList() {
                MS_ID=Convert.ToInt32(newOldMSID_txt.Text),
                Supplier = newSupplier_cbx.Text,
                Component = newelement_cbx.Text,
                Config= newConfig_txt.Text,
                Description = newDescription_txt.Text,
                Picture = newPicture_lab.Text,
                Qty = Convert.ToInt32(newQty_txt.Text),
                Price = Convert.ToInt32(newTotalPrice_txt.Text),
                CheckResult = "審核中",
                EmployeeName = "Larry",//暫時
                SentCheckTime = DateTime.Now
            };
            CheckListUtility.CheckListAdd(clist);
            newOldMSID_txt.Text = "";
            newSupplier_cbx.Text = "";
            newelement_cbx.Text = "";
            newConfig_txt.Text = "";
            newDescription_txt.Text = "";
            newPicture_lab.Text = "";
            newQty_txt.Text = "";
            newPerPrice_txt.Text = "";
            newTax_txt.Text = "";
            newTotalPrice_txt.Text = "";
            CheckID_txt.Text = CheckListUtility.SentNewCheckIDBack().ToString();
            dataGridView4.DataSource = CheckListUtility.GetAllCheckList();
            dataGridView5.DataSource = CheckListUtility.GetAllCheckList();
            dataGridView4.Refresh();

        }

        /// <summary>
        /// 送審中dataGridview4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.Rows[e.RowIndex].Cells[0].Value != System.DBNull.Value)
            {
                int SupID = (int)dataGridView4.Rows[e.RowIndex].Cells[0].Value;
                string prod = Convert.ToString(dataGridView4.Rows[e.RowIndex].Cells[1].Value);
                SqlConnection cn = new SqlConnection(cnStr);
                SqlCommand cmd = new SqlCommand("Select * From CheckList Where CheckID=@CheckID", cn);
                cmd.Parameters.AddWithValue("@CheckID", SupID);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string check = dr[8].ToString();
                    if (check=="審核中")
                    {
                        checkback_btn.Visible = true;
                        checkback_lab.Text = dr[0].ToString();
                    }
                    else
                    {
                        checkback_btn.Visible = false;
                    }



                }
                cn.Close();

            }
        }

        private void checkback_btn_Click(object sender, EventArgs e)
        {
            int ckid = Convert.ToInt32(checkback_lab.Text);
            if (MessageBox.Show("確定要取消審核嗎?", "問題", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CheckListUtility.DeleteCheckList(ckid);
                checkback_lab.Visible = false;

            }
            dataGridView4.DataSource = CheckListUtility.GetAllCheckList();
            dataGridView4.Refresh();


        }

        private void newChosePic_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //string selectedFile = openFileDialog1.FileName;//路徑
                string selectedFile = Path.GetFileName(openFileDialog1.FileName);//using system.IO;//檔名

                newPicture_lab.Text = selectedFile;
                pictureBox3.ImageLocation = path + newPicture_lab.Text;
            }
        }
        /// <summary>
        /// 請購按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Replenishment_btn_Click(object sender, EventArgs e)
        {
            if (id_txt.Text!="")
            {
                newOldMSID_txt.Text = id_txt.Text;
                newSupplier_cbx.Text = supplier_txt.Text;
                newelement_cbx.Text = component_txt.Text;
                newConfig_txt.Text = config_txt.Text;
                newDescription_txt.Text = description_txt.Text;
                newPicture_lab.Text = pic_lab.Text;
                pictureBox3.ImageLocation = path+newPicture_lab.Text;
                searchpanel.Visible = false;
                newElementsPanel.Visible = true;
                //
                id_txt.Text = "";
                supplier_txt.Text = "";
                component_txt.Text = "";
                config_txt.Text = "";
                description_txt.Text = "";
                pictureBox2.ImageLocation = null;
                pic_lab.Text = "";
                Newmaterials_btn.ForeColor = Color.Black;
                Newmaterials_btn.BackColor = Color.White;
                SearchmaterialsMenu_btn.ForeColor = Color.White;
                SearchmaterialsMenu_btn.BackColor = Color.DodgerBlue;
            }
            else
            {
                MessageBox.Show("請選擇要請購得料件");
            }



        }
        /// <summary>
        /// 審核頁面Panel按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckListPanel_btn_Click(object sender, EventArgs e)
        {
            Checkpanel.Visible = true;
            SupplierListPanel.Visible = false;
            searchpanel.Visible = false;
            newElementsPanel.Visible = false;
            CheckListPanel_btn.ForeColor = Color.Black;
            CheckListPanel_btn.BackColor = Color.White;
            SupplierList_btn.ForeColor = Color.White;
            SupplierList_btn.BackColor = Color.DodgerBlue;
            SearchmaterialsMenu_btn.ForeColor = Color.White;
            SearchmaterialsMenu_btn.BackColor = Color.DodgerBlue;
            Newmaterials_btn.ForeColor = Color.White;
            Newmaterials_btn.BackColor = Color.DodgerBlue;
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.Rows[e.RowIndex].Cells[0].Value != System.DBNull.Value)
            {
                int SupID = (int)dataGridView5.Rows[e.RowIndex].Cells[0].Value;
                string prod = Convert.ToString(dataGridView5.Rows[e.RowIndex].Cells[1].Value);
                SqlConnection cn = new SqlConnection(cnStr);
                SqlCommand cmd = new SqlCommand("Select * From CheckList Where CheckID=@CheckID", cn);
                cmd.Parameters.AddWithValue("@CheckID", SupID);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    checkCheckID_txt.Text = dr[0].ToString();
                    checkMSID_txt.Text = dr[1].ToString();
                    checkComponent_txt.Text = dr[2].ToString();
                    checkSupplier_txt.Text = dr[3].ToString();
                    checkConfig_txt.Text = dr[4].ToString();
                    checkDescription_txt.Text = dr[5].ToString();
                    checkPic_lab.Text = dr[6].ToString();
                    checkQty_txt.Text = dr[7].ToString();
                    checkResult_txt.Text = dr[8].ToString();
                    checkempName_txt.Text = dr[9].ToString();
                    checkPrice_txt.Text = dr[11].ToString();
                    pictureBox4.ImageLocation = path + checkPic_lab.Text;

                }
                cn.Close();

            }
        }
        /// <summary>
        /// 審核通過按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkPass_btn_Click(object sender, EventArgs e)
        {
            CheckList cklst = new CheckList()
            {
                CheckID = Convert.ToInt32(checkCheckID_txt.Text),
                MS_ID = Convert.ToInt32(checkMSID_txt.Text),
                Component = checkComponent_txt.Text,
                Supplier = checkSupplier_txt.Text,
                Config = checkConfig_txt.Text,
                Description = checkDescription_txt.Text,
                Picture = checkPic_lab.Text,
                Qty = Convert.ToInt32(checkQty_txt.Text),
                CheckResult = "通過",
                EmployeeName = checkempName_txt.Text,
                Price = Convert.ToInt32(checkPrice_txt.Text)
            };
            CheckListUtility.EditCheckList(cklst);

            if (checkMSID_txt.Text!="")
            {
                Element elmt1 = new Element()
                {
                    MS_ID = Convert.ToInt32(checkMSID_txt.Text),
                    Component = checkComponent_txt.Text,
                    Supplier = checkSupplier_txt.Text,
                    Config = checkConfig_txt.Text,
                    Description = checkDescription_txt.Text,
                    Picture = checkPic_lab.Text,
                    Qty = Convert.ToInt32(checkQty_txt.Text),
                    Lasteditdate = DateTime.Now
                };
                CheckListUtility.CheckListUpdateElements(elmt1);
            }
            else
            {
                Element elmt2 = new Element()
                {
                    Component = checkComponent_txt.Text,
                    Supplier = checkSupplier_txt.Text,
                    Config = checkConfig_txt.Text,
                    Description = checkDescription_txt.Text,
                    Picture = checkPic_lab.Text,
                    Qty = Convert.ToInt32(checkQty_txt.Text),
                    Purchase_date = DateTime.Now,
                    Lasteditdate = DateTime.Now
                };
            }
            checkCheckID_txt.Text = "";
            checkMSID_txt.Text = "";
            checkempName_txt.Text = "";
            checkSupplier_txt.Text = "";
            checkComponent_txt.Text = "";
            checkConfig_txt.Text = "";
            checkQty_txt.Text = "";
            checkDescription_txt.Text = "";
            checkPrice_txt.Text = "";
            checkResult_txt.Text = "";
            pictureBox4.ImageLocation = null;
            checkPic_lab.Text = "";


            dataGridView5.DataSource = CheckListUtility.GetAllCheckList();
            dataGridView1.DataSource = ElementUtility.GetAllElement();
            dataGridView1.Refresh();

        }
        /// <summary>
        /// 審核未通過按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkdenied_btn_Click(object sender, EventArgs e)
        {
            CheckList cklst = new CheckList()
            {
                CheckID = Convert.ToInt32(checkCheckID_txt.Text),
                MS_ID = Convert.ToInt32(checkMSID_txt.Text),
                Component = checkComponent_txt.Text,
                Supplier = checkSupplier_txt.Text,
                Config = checkConfig_txt.Text,
                Description = checkDescription_txt.Text,
                Picture = checkPic_lab.Text,
                Qty = Convert.ToInt32(checkQty_txt.Text),
                CheckResult = "未通過",
                EmployeeName = checkempName_txt.Text,
                Price = Convert.ToInt32(checkPrice_txt.Text)
            };
            CheckListUtility.EditCheckList(cklst);
        }


    }
}
