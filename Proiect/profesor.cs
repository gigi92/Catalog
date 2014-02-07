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
namespace Proiect
{
    public partial class profesor : Form
    {
        data_layer a = new data_layer();
        int contor;
        int id_materie, id_student;
        float id_curs, id_lab;
        float medie = 0;
        public profesor()
        {
            InitializeComponent();

            a.afisare_profesor(dataGridView1, permisiuni.id_user, label1, label2);
        }

        private void profesor_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            contor = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_materie"].Value.ToString());
            
            a.afisare_elevi_materie(contor, dataGridView2);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_materie= Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["id_materie"].Value.ToString());
            id_student= Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["id_student"].Value.ToString());
            permisiuni.id_student = id_student;
            permisiuni.id_materie = id_materie;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            label5.Visible = true; 
            label6.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            a.afisare_note(id_materie, dataGridView3, id_student);
            button4.Visible = true;
            button5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a.afisare_absente(id_materie, dataGridView3, id_student);
            button5.Visible = true;
            button4.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            int i = Convert.ToInt32(textBox1.Text.ToString());
            int j = Convert.ToInt32(textBox2.Text.ToString());
            if (i + j != 100)
            {
                MessageBox.Show("Eroare la procentaje!!!!");
            }

            medie = a.get_medie(dataGridView3, i, j);
            textBox3.Text = medie.ToString();
            a.update_medie(id_student, id_materie, medie);
        }

        private void button4_Click(object sender, EventArgs e)
        {
             operatii_note p =new operatii_note();
             p.ShowDialog();
             a.afisare_note(id_materie, dataGridView3, id_student);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            operatii_absente p = new operatii_absente();
            p.ShowDialog();
            a.afisare_absente(id_materie, dataGridView3, id_student);
        }
    }
}
