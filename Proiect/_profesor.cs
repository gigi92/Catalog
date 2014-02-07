using System;
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
using b_layer;
using System;

namespace Proiect
{
    public partial class adaugare_profesor : Form
    {
        private data_layer data = new data_layer();
        private business_layer obj = new business_layer();
        int id_user;
        int id_profesor;
        int id_materie;
        int id_student=-1;
        public adaugare_profesor()
        {
            InitializeComponent();
            data.afisare_profesori(dataGridView1);
            dataGridView2.DataSource = data.afis_std();

        }

        private void adaugare_profesor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            data.add_user(textBox4.Text.ToString(), textBox5.Text.ToString(), 2);
            int id_user = obj.get_id_user(textBox4.Text.ToString());
            data.add_profesor(textBox1.Text.ToString(), textBox2.Text.ToString(), id_user);
            dataGridView1.DataSource = data.afisare_profesori();


        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            data.delete_profesor(id_profesor);
            data.delete_user(id_user);
            dataGridView1.DataSource = data.afisare_profesori();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["nume"].Value.ToString().Trim(' ');
                textBox2.Text = row.Cells["prenume"].Value.ToString().Trim(' ');
                id_profesor = int.Parse(row.Cells["id_profesor"].Value.ToString().Trim(' '));
                id_user = int.Parse(row.Cells["id_user"].Value.ToString().Trim(' '));
                
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            textBox3.Visible = true;
            if (id_student == -1)
            {
                MessageBox.Show("double-click on the grid 2");
            }
            else
            {

                data.agaugare_std_la_materie(Convert.ToInt32(textBox3.Text.ToString()), id_student, id_profesor, textBox6.Text.ToString());
                MessageBox.Show("adaugare cu succes!!!");
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            id_student = int.Parse(row.Cells["id_student"].Value.ToString().Trim(' '));
            
        }
    }
}
