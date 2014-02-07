using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using var_statice;

namespace d_layer
{
    class data_layer
    {
        public SqlConnection connection { get; set;}
        public void initializare_conn()
        {
            connection = new SqlConnection("Data Source=X-PC;Initial Catalog=proiect;Integrated Security=True");

        }
       // private SqlConnection connection = new SqlConnection(connection_string);
        public DataTable read_users()
        {

            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT nume_user, parola,id_user,id_permisiune FROM dbo.tabel_useri";
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            connection.Close();
            return dt;
        }
        public void afisare_student(DataGridView a,int id,Label l1,Label l2,Label l3,Label l4)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT dbo.tabel_studenti.nume,dbo.tabel_studenti.id_student, dbo.tabel_studenti.prenume,dbo.tabel_grupe.nume_grupa FROM dbo.tabel_studenti INNER JOIN dbo.tabel_grupe ON dbo.tabel_studenti.id_grupa=dbo.tabel_grupe.id_grupa WHERE dbo.tabel_studenti.id_user="+id+"";
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            connection.Close();
            a.DataSource = dt;
            a.Visible = false;
            DataGridViewRow row = a.Rows[0];
            
            l1.Text = row.Cells["nume"].Value.ToString();
            l2.Text = row.Cells["prenume"].Value.ToString();
            l3.Text = row.Cells["nume_grupa"].Value.ToString();
            l4.Text = row.Cells["id_student"].Value.ToString();
        }
        public void afisare_profesor(DataGridView a, int id, Label l1, Label l2)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT nume,prenume,id_profesor FROM dbo.tabel_profesor WHERE id_user="+id+"";
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            connection.Close();
            a.DataSource = dt;
            
            DataGridViewRow row = a.Rows[0];
            string sir;
            l1.Text = row.Cells["nume"].Value.ToString();
            l2.Text = row.Cells["prenume"].Value.ToString();
            sir=row.Cells["id_profesor"].Value.ToString();
            SqlCommand cmd1 = connection.CreateCommand();
            cmd1.CommandText = "SELECT nume_materie,id_materie FROM dbo.tabel_materie WHERE id_prof=" + sir + "";
            cmd1.CommandType = CommandType.Text;
            connection.Open();       
            var aux1 = cmd1.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt1 = new DataTable();
            dt1.Load(aux1);
            connection.Close();
            a.DataSource = dt1;
            
        }
        public void afisare_profesori(DataGridView a)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.tabel_profesor";
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            a.DataSource = dt;
            connection.Close();
        }
      
        public void add_nota(float nota_c, float nota_l,int id_mat,int id_std)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.add_nota";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter a = new SqlParameter();
            a.ParameterName = "@id_std";
            a.SqlDbType = SqlDbType.Int;
            a.Value = id_std;
            cmd.Parameters.Add(a);

            SqlParameter b = new SqlParameter();
            b.ParameterName = "@id_mat";
            b.SqlDbType = SqlDbType.Int;
            b.Value = id_mat;
            cmd.Parameters.Add(b);

            SqlParameter c = new SqlParameter();
            c.ParameterName = "@nota_c";
            c.SqlDbType = SqlDbType.Float;
            c.Value = nota_c;
            cmd.Parameters.Add(c);

            SqlParameter d = new SqlParameter();
            d.ParameterName = "@nota_l";
            d.SqlDbType = SqlDbType.Float;
            d.Value = nota_l;
            cmd.Parameters.Add(d);

            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
        }
        public void update_nota(float nota_c, float nota_l, int id_mat, int id_std,int id_nota)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.update_nota";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter a = new SqlParameter();
            a.ParameterName = "@id_std";
            a.SqlDbType = SqlDbType.Int;
            a.Value = id_std;
            cmd.Parameters.Add(a);

            SqlParameter b = new SqlParameter();
            b.ParameterName = "@id_mat";
            b.SqlDbType = SqlDbType.Int;
            b.Value = id_mat;
            cmd.Parameters.Add(b);

            SqlParameter c = new SqlParameter();
            c.ParameterName = "@nota_c";
            c.SqlDbType = SqlDbType.Float;
            c.Value = nota_c;
            cmd.Parameters.Add(c);

            SqlParameter d = new SqlParameter();
            d.ParameterName = "@nota_l";
            d.SqlDbType = SqlDbType.Float;
            d.Value = nota_l;
            cmd.Parameters.Add(d);

            SqlParameter e = new SqlParameter();
            e.ParameterName = "@id_nota";
            e.SqlDbType = SqlDbType.Int;
            e.Value = id_nota;
            cmd.Parameters.Add(e);

            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
        }
        public void delete_nota( int id_nota)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.delete_nota";
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlParameter e = new SqlParameter();
            e.ParameterName = "@id_nota";
            e.SqlDbType = SqlDbType.Int;
            e.Value = id_nota;
            cmd.Parameters.Add(e);

            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
        }
        public void delete_absenta(DateTime absenta)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.delete_absenta";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter e = new SqlParameter();
            e.ParameterName = "@absenta";
            e.SqlDbType = SqlDbType.DateTime;
            e.Value = absenta;
            cmd.Parameters.Add(e);

            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
        }
        public void add_absenta(DateTime data, int id_mat, int id_std)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.add_absenta";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter a = new SqlParameter();
            a.ParameterName = "@id_stud";
            a.SqlDbType = SqlDbType.Int;
            a.Value = id_std;
            cmd.Parameters.Add(a);

            SqlParameter b = new SqlParameter();
            b.ParameterName = "@id_mat";
            b.SqlDbType = SqlDbType.Int;
            b.Value = id_mat;
            cmd.Parameters.Add(b);

           

            SqlParameter d = new SqlParameter();
            d.ParameterName = "@data";
            d.SqlDbType = SqlDbType.DateTime;
            d.Value = data;
            cmd.Parameters.Add(d);

            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
        }
        public DataTable afisare_useri()
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT  * FROM dbo.tabel_useri";
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            connection.Close();
            return dt;
        }
       
     
        public DataTable afisare_profesori()
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.tabel_profesor";            
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            connection.Close();
            return dt;
        }
        
        public void add_profesor(String nume, String prenume,int id_user)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.add_profesor";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter a = new SqlParameter();
            a.ParameterName = "@nume";
            a.SqlDbType = SqlDbType.Text;
            a.Value = nume;
            cmd.Parameters.Add(a);

            SqlParameter b = new SqlParameter();
            b.ParameterName = "@prenume";
            b.SqlDbType = SqlDbType.Text;
            b.Value = prenume;
            cmd.Parameters.Add(b);

            SqlParameter d = new SqlParameter();
            d.ParameterName = "@id_user";
            d.SqlDbType = SqlDbType.Int;
            d.Value = id_user;
            cmd.Parameters.Add(d);

            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
        }
       
        public void delete_profesor(int id_stud)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.delete_profesor";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter e = new SqlParameter();
            e.ParameterName = "@id_profesor";
            e.SqlDbType = SqlDbType.Int;
            e.Value = id_stud;
            cmd.Parameters.Add(e);

            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
        }

    }
}
