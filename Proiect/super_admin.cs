using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using var_statice;
using d_layer;
using var_statice;
using System;
namespace Proiect
{
    public partial class super_admin : Form
    {
        private int id_user;
        private data_layer obj = new data_layer();
        public super_admin()
        {
            InitializeComponent();
            dataGridView1.DataSource = obj.afisare_useri();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["nume_user"].Value.ToString().Trim(' ');
                textBox2.Text = row.Cells["parola"].Value.ToString().Trim(' ');
                textBox3.Text = row.Cells["id_permisiune"].Value.ToString().Trim(' ');
                id_user = int.Parse(row.Cells["id_user"].Value.ToString().Trim(' '));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() != null && textBox2.Text.ToString() != null && textBox3.Text.ToString() != null)
            {
                if (int.Parse(textBox3.Text.ToString()) <= 3 && int.Parse(textBox3.Text.ToString()) != 0)
                {
                    obj.add_user(textBox1.Text.ToString(), textBox2.Text.ToString(), int.Parse(textBox3.Text.ToString()));
                    dataGridView1.DataSource = obj.afisare_useri();
                }
                else
                {
                    MessageBox.Show("introduceti o alta permisiunea !!!");
                }
            }
            else
                MessageBox.Show("introduceti datele pentru un utilizator nou!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() != null && textBox2.Text.ToString() != null && textBox3.Text.ToString() != null)
            {
                if (id_user != 3)
                {
                    obj.delete_user(id_user);
                    dataGridView1.DataSource = obj.afisare_useri();
                }
                else
                    MessageBox.Show("nu se poate sterge superadmin-ul!!!");
            }
            else
                MessageBox.Show("selectati un user!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() != null && textBox2.Text.ToString() != null && textBox3.Text.ToString() != null)
            {
                if (int.Parse(textBox3.Text.ToString()) <= 3 && int.Parse(textBox3.Text.ToString()) != 0)
                {
                    obj.update_user(id_user, textBox1.Text.ToString(), textBox2.Text.ToString(), int.Parse(textBox3.Text.ToString()));
                    dataGridView1.DataSource = obj.afisare_useri();
                }
                else
                {
                    MessageBox.Show("nu exista permisiunea selectata!!!");
                }
            }
            else
                MessageBox.Show("Introduceti detalii pntru modificare user-ului!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            studenti std = new studenti();
            std.Show();
            dataGridView1.DataSource = obj.afisare_useri();
        }

        private void super_admin_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            adaugare_profesor std = new adaugare_profesor();
            std.Show();
            dataGridView1.DataSource = obj.afisare_useri();
        }
    }
}
