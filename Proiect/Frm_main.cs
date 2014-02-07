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
    public partial class Frm_main : Form
    {
        int contor = -1;
        int nr = 0;
        data_layer a = new data_layer();
        public Frm_main()
        {
            InitializeComponent();
            a.afisare_student(dataGridView1,permisiuni.id_user,label1,label2,label3,label4);
            nr = Convert.ToInt32(label4.Text);
            a.afisare_materii(dataGridView1,nr);
            label5.Visible = false;

        }

        private void Frm_main_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            contor = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_materie"].Value.ToString());

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            a.afisare_note(contor, dataGridView2,Convert.ToInt32(label4.Text));
            label5.Visible = true;
            label5.Text=a.get_medie2(dataGridView2, nr, contor).ToString();
            label6.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a.afisare_absente(contor, dataGridView2, Convert.ToInt32(label4.Text));
            label5.Text = a.get_nr_abs(dataGridView2).ToString();
            label7.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
