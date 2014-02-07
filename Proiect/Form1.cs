using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using b_layer;
using var_statice;
namespace Proiect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            business_layer obj=new business_layer();

            if ((obj.check_user(user_txt.Text.ToString(), parola_txt.Text.ToString()) == 1))
            {
                permisiuni.user = user_txt.Text.ToString().Trim(' '); //memoreaza numele userului logat
                permisiuni.id_permisiune = obj.get_id_permisiune(user_txt.Text.ToString().Trim(' ')); //memoreaza id-l [permisiunii
                permisiuni.id_user = obj.get_id_user(user_txt.Text.ToString().Trim(' ')); //mem id user
                this.Visible = false;
                if (permisiuni.id_permisiune == 1)
                {
                    this.Visible = false;
                    Frm_main frm_main = new Frm_main();
                    frm_main.ShowDialog();
                    //permisiuni.id_user=obj.get_id_user(user_txt.Text.ToString().Trim(' '));
                    //this.Close();
                    
                    this.Visible = true;
                    this.Refresh();
                }
                if (permisiuni.id_permisiune == 2)
                {
                    this.Visible = false;
                    profesor frm_main = new profesor();
                    frm_main.ShowDialog();
                    //permisiuni.id_user=obj.get_id_user(user_txt.Text.ToString().Trim(' '));
                    //this.Close();
                    
                    this.Visible = true;
                    this.Refresh();
                }
                if (permisiuni.id_permisiune == 3 )
                {
                    this.Visible = false;
                    super_admin frm_super = new super_admin();
                    frm_super.ShowDialog();
                    this.Visible = true;
                    this.Refresh();
                }
            }
            else
            {
                this.Visible = false;
                MessageBox.Show("User sau parola incorecte");
                this.Visible = true;
                user_txt.Text = "";
                parola_txt.Text = "";
            }
        }
    }
}
