using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaspiStruct
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public struct Turizm
        {
            public string categotyType;
            public string categotyName;
            public string brandName;
            public string articul;
            public string color;
            public int price;
        }

        Turizm[] tz = new Turizm[100];
    
        int SelectedIndex;
        int i = 0, j, k;
        String type, name, brand, articuls, colors;
        int min_price, max_price;

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[] { "Активный отдых", "Велоспорт", "Фитнес" });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            SelectedIndex = comboBox1.SelectedIndex;
            if (SelectedIndex == 0)
            {
                comboBox2.Items.AddRange(new string[] { "Гироскутер", "Ролики", "Самокаты" });
            }
            else if(SelectedIndex == 1)
            {
                comboBox2.Items.AddRange(new string[] { "Велосипеды", "Велостанки", "Фонари" });
            }
            else if(SelectedIndex == 2)
            {
                comboBox2.Items.AddRange(new string[] { "Велотренажеры", "Гири", "Турники" });
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            SelectedIndex = comboBox1.SelectedIndex;
            SelectedIndex = comboBox2.SelectedIndex;
            if (SelectedIndex == 0)
            {
                comboBox3.Items.AddRange(new string[] { "Fila Skates", "Joerex", "Nex" });
            }
            else if (SelectedIndex == 1)
            {
                comboBox3.Items.AddRange(new string[] { "Cube", "Giant", "TRECK" });
            }
            else if (SelectedIndex == 2)
            {
                comboBox3.Items.AddRange(new string[] { "FitLIX", "Gf", "Artner" });
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tz[i].categotyType = comboBox1.SelectedItem.ToString();
                tz[i].categotyName = comboBox2.SelectedItem.ToString();
                tz[i].brandName = comboBox3.SelectedItem.ToString();
                tz[i].articul = textBox1.Text;
                tz[i].color = textBox2.Text;
                tz[i].price = Convert.ToInt32(textBox3.Text);

                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = tz[i].categotyType;
                dataGridView1.Rows[i].Cells[1].Value = tz[i].categotyName;
                dataGridView1.Rows[i].Cells[2].Value = tz[i].brandName;
                dataGridView1.Rows[i].Cells[3].Value = tz[i].articul;
                dataGridView1.Rows[i].Cells[4].Value = tz[i].color;
                dataGridView1.Rows[i].Cells[5].Value = tz[i].price;
                i++;
            } catch (Exception Ex)
            {
                
            }
        }

        private void AddDataGrid2()
        {
            dataGridView2.Rows.Add();
            dataGridView2.Rows[k].Cells[0].Value = tz[j].categotyType;
            dataGridView2.Rows[k].Cells[1].Value = tz[j].categotyName;
            dataGridView2.Rows[k].Cells[2].Value = tz[j].brandName;
            dataGridView2.Rows[k].Cells[3].Value = tz[j].articul;
            dataGridView2.Rows[k].Cells[4].Value = tz[j].color;
            dataGridView2.Rows[k].Cells[5].Value = tz[j].price;
            k++;
        }

        private void getMaxMinNumbers()
        {
            min_price = 0;
            max_price = 9999999;
            int numbers = 0;
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                for (int m = 0; m < checkedListBox1.CheckedItems.Count; m++)
                {
                    if (checkedListBox1.CheckedItems[m].ToString() == "10 000")
                    {
                        min_price = 0;
                        max_price = 10000;
                        numbers++;
                    }
                    else if (checkedListBox1.CheckedItems[m].ToString() == "10 000 - 30 000")
                    {
                        if (numbers == 0) min_price = 10000;
                        max_price = 30000;
                        numbers++;
                    }
                    else if (checkedListBox1.CheckedItems[m].ToString() == "30 000 - 60 000")
                    {
                        if (numbers == 0) min_price = 30000;
                        max_price = 60000;
                        numbers++;
                    }
                    else if (checkedListBox1.CheckedItems[m].ToString() == "60 000 - 100 000")
                    {
                        if (numbers == 0) min_price = 60000;
                        max_price = 100000;
                        numbers++;
                    }
                    else
                    {
                        if (numbers == 0) min_price = 100000;
                        max_price = 9999999;
                        numbers++;
                    }
                }
            }
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            j = 0;
            k = 0;
            type = comboBox1.Text;
            name = comboBox2.Text;
            brand = comboBox3.Text;
            articuls = textBox1.Text;
            colors = textBox2.Text;
            getMaxMinNumbers();
            if (type != "" && name != "" && brand != "" && articuls != "" && colors != "")
            {
                while (j < i)
                {
                    if (type == tz[j].categotyType &&
                        name == tz[j].categotyName &&
                        brand == tz[j].brandName &&
                        articuls == tz[j].articul &&
                        colors == tz[j].color &&
                        tz[j].price >= min_price &&
                        tz[j].price <= max_price
                        )
                    { AddDataGrid2(); }
                    j++;
                }
            }
            else if (type != "" && name != "" && brand != "" && articuls != "" && colors != "")
            {
                while (j < i)
                {
                    if (type == tz[j].categotyType &&
                        name == tz[j].categotyName &&
                        brand == tz[j].brandName &&
                        articuls == tz[j].articul &&
                        colors == tz[j].color &&
                        tz[j].price >= min_price &&
                        tz[j].price <= max_price
                        )
                    { AddDataGrid2(); }
                    j++;
                }
            }
            else if (type != "" && name != "" && brand != "" && articuls != "")
            {
                while (j < i)
                {
                    if (type == tz[j].categotyType &&
                        name == tz[j].categotyName &&
                        brand == tz[j].brandName &&
                        articuls == tz[j].articul &&
                        tz[j].price >= min_price &&
                        tz[j].price <= max_price
                        )
                    { AddDataGrid2(); }
                    j++;
                }
            }
            else if (type != "" && name != "" && brand != "" && colors != "")
            {
                while (j < i)
                {
                    if (type == tz[j].categotyType &&
                        name == tz[j].categotyName &&
                        brand == tz[j].brandName &&
                        colors == tz[j].color &&
                        tz[j].price >= min_price &&
                        tz[j].price <= max_price
                        )
                    { AddDataGrid2(); }
                    j++;
                }
            }
            else if (type != "" && name != "" && brand != "")
            {
                while (j < i)
                {
                    if (type == tz[j].categotyType &&
                        name == tz[j].categotyName &&
                        brand == tz[j].brandName &&
                        tz[j].price >= min_price &&
                        tz[j].price <= max_price
                        )
                    { AddDataGrid2(); }
                    j++;
                }
            }
            else if (type != "" && name != "")
            {
                while (j < i)
                {
                    if (type == tz[j].categotyType &&
                        name == tz[j].categotyName &&
                        tz[j].price >= min_price &&
                        tz[j].price <= max_price
                        )
                    { AddDataGrid2(); }
                    j++;
                }
            }
            else if (type != "")
            {
                while (j < i)
                {
                    if (type == tz[j].categotyType &&
                        tz[j].price >= min_price &&
                        tz[j].price <= max_price
                        )
                    { AddDataGrid2(); }
                    j++;
                }
            }
            else if(true)
            {
                while (j < i)
                {
                    if (tz[j].price >= min_price &&
                        tz[j].price <= max_price
                        )
                    { AddDataGrid2(); }
                    j++;
                }
            }   
            if (j == 0)
            {
                    MessageBox.Show("По данным критериям коипьютеров не найдено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            checkedListBox1.SetItemChecked(0, false);
            checkedListBox1.SetItemChecked(1, false);
            checkedListBox1.SetItemChecked(2, false);
            checkedListBox1.SetItemChecked(3, false);
            checkedListBox1.SetItemChecked(4, false);
            dataGridView2.Rows.Clear();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
