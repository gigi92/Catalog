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
    public partial class operatii_absente : Form
    {
        data_layer a = new data_layer();
        public operatii_absente()
        {
            InitializeComponent();
            a.afisare_absente(permisiuni.id_materie, dataGridView1, permisiuni.id_student);
            textBox1.Visible = true;
        }

        private void operatii_absente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            DateTime data=DateTime.Parse(textBox1.Text);
            a.delete_absenta(data);
            a.afisare_absente(permisiuni.id_materie, dataGridView1, permisiuni.id_student);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["data"].Value.ToString().Trim(' ');
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DateTime data = DateTime.Parse(textBox1.Text);
            a.add_absenta(data, permisiuni.id_materie, permisiuni.id_student);
            a.afisare_absente(permisiuni.id_materie, dataGridView1, permisiuni.id_student);

        }
    }
}
