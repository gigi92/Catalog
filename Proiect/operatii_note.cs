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
   
    public partial class operatii_note : Form
    {
        int id_nota;
        data_layer a = new data_layer();
        int index;
        public operatii_note()
        {
            InitializeComponent();
            a.afisare_note(permisiuni.id_materie, dataGridView1, permisiuni.id_student);
        }

        private void operatii_note_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["nota_curs"].Value.ToString().Trim(' ');
                textBox2.Text = row.Cells["nota_laborator"].Value.ToString().Trim(' ');
                id_nota =int.Parse(row.Cells["id_nota"].Value.ToString().Trim(' '));

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a.add_nota(float.Parse(textBox1.Text.ToString()), float.Parse(textBox2.Text.ToString()), permisiuni.id_materie, permisiuni.id_student);
            a.afisare_note(permisiuni.id_materie, dataGridView1, permisiuni.id_student);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            a.update_nota(float.Parse(textBox1.Text.ToString()), float.Parse(textBox2.Text.ToString()), permisiuni.id_materie, permisiuni.id_student,id_nota);
            a.afisare_note(permisiuni.id_materie, dataGridView1, permisiuni.id_student);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a.delete_nota(id_nota);
            a.afisare_note(permisiuni.id_materie, dataGridView1, permisiuni.id_student);
        }
    }
}
