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
using b_layer;
using var_statice;
using System;

namespace Proiect
{
    public partial class studenti : Form
    {
        private business_layer obj = new business_layer();
        private data_layer stud = new data_layer();
        int id_stud,id_user;
        public studenti()
        {
            InitializeComponent();
            dataGridView1.DataSource = stud.afisare_studenti();
            
        }

        private void studenti_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            stud.add_user(textBox4.Text.ToString(), textBox5.Text.ToString(), 1);
            int id_user = obj.get_id_user(textBox4.Text.ToString());
            
            stud.add_student(textBox1.Text.ToString(), textBox2.Text.ToString(), int.Parse(textBox3.Text.ToString()),id_user);
            
            dataGridView1.DataSource = stud.afisare_studenti();


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            stud.delete_student(id_stud);
            stud.delete_user(id_user);
            dataGridView1.DataSource = stud.afisare_studenti();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["nume"].Value.ToString().Trim(' ');
                textBox2.Text = row.Cells["prenume"].Value.ToString().Trim(' ');
                textBox3.Text = row.Cells["id_grupa"].Value.ToString().Trim(' ');
                id_stud = int.Parse(row.Cells["id_student"].Value.ToString().Trim(' '));
                id_user = int.Parse(row.Cells["id_user"].Value.ToString().Trim(' '));

            }
        }
    }
}
