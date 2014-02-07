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
        public void afisare_materii(DataGridView a, int id)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT nume_materie,id_materie FROM dbo.tabel_materie where id_student="+id+"";
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            connection.Close();
            a.DataSource = dt;
            a.Visible = true;
            
        }
        public void afisare_note(int nr, DataGridView a,int id)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT id_nota,nota_curs,nota_laborator FROM dbo.tabel_note where id_materie=" + nr + " and id_student="+id+"";
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            connection.Close();
            a.DataSource = dt;
            a.Visible = true;
        }
        public void afisare_absente(int nr, DataGridView a,int id)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT data FROM dbo.tabel_absente where id_materie=" + nr + " and id_student=" + id + "";
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            connection.Close();
            a.DataSource = dt;
            a.Visible = true;
        }
        public void afisare_elevi_materie(int id_mat,DataGridView a)
        {
             initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT dbo.tabel_studenti.nume,dbo.tabel_studenti.prenume,dbo.tabel_studenti.id_student,id_materie FROM dbo.tabel_studenti INNER JOIN dbo.tabel_materie ON dbo.tabel_studenti.id_student=dbo.tabel_materie.id_student WHERE dbo.tabel_materie.id_materie=" + id_mat + " GROUP BY id_materie,nume,prenume,dbo.tabel_studenti.id_student;";
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            connection.Close();
            a.DataSource = dt;
           

        }
        public void calculare_medie()
        {

        }
        public int get_id_from_mat(DataGridView a,int i )
        {
            
            DataGridViewRow row = a.Rows[i];
            return Convert.ToInt32(row.Cells["id_materie"].Value.ToString());



        }
        public void update_medie(int std, int materie,float medie)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.update_medie";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter a = new SqlParameter();
            a.ParameterName = "@id_std";
            a.SqlDbType = SqlDbType.Int;
            a.Value = std;
            cmd.Parameters.Add(a);

            SqlParameter c = new SqlParameter();
            c.ParameterName = "@id_mat";
            c.SqlDbType = SqlDbType.Int;
            c.Value = materie;
            cmd.Parameters.Add(c);

            SqlParameter d = new SqlParameter();
            d.ParameterName = "@medie";
            d.SqlDbType = SqlDbType.Float;
            d.Value = medie;
            cmd.Parameters.Add(d);

            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
        }
        public float get_medie(DataGridView a,int p1,int p2)
        {
            float id_curs=0, id_lab=0;
            int nr_lin = Int32.Parse(a.Rows.Count.ToString());
            for (int aux = 0; aux < nr_lin - 1; aux++)
            {
                id_curs = id_curs + float.Parse(a.Rows[aux].Cells["nota_curs"].Value.ToString());
                id_lab = id_lab + float.Parse(a.Rows[aux].Cells["nota_laborator"].Value.ToString());
            }
             return (id_curs * p1 / 100 + id_lab * p2 / 100) / (nr_lin - 1);
        }
        public float get_medie2(DataGridView a,int id_std,int id_med)
        {
            float medie=0;
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT dbo.tabel_materie.medie FROM dbo.tabel_materie WHERE dbo.tabel_materie.id_student=" + id_std + " and dbo.tabel_materie.id_materie="+id_med+" ";
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            connection.Close();
            medie =float.Parse( dt.Rows[0][0].ToString());
            return medie;
        }
        public int get_nr_abs(DataGridView a)
        {
            int abs=0;
            abs =Convert.ToInt32( a.Rows.Count.ToString());
            return abs-1;
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
        public void add_user(String nume_user, String parola, int id_permisiune)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.add_user";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter a = new SqlParameter();
            a.ParameterName = "@nume_user";
            a.SqlDbType = SqlDbType.Text;
            a.Value = nume_user;
            cmd.Parameters.Add(a);

            SqlParameter b = new SqlParameter();
            b.ParameterName = "@parola";
            b.SqlDbType = SqlDbType.Text;
            b.Value = parola;
            cmd.Parameters.Add(b);

            SqlParameter c = new SqlParameter();
            c.ParameterName = "@id_permisiune";
            c.SqlDbType = SqlDbType.Int;
            c.Value = id_permisiune;
            cmd.Parameters.Add(c);



            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
        }
        public void delete_user(int id_user)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.delete_user";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter e = new SqlParameter();
            e.ParameterName = "@id_user";
            e.SqlDbType = SqlDbType.Int;
            e.Value = id_user;
            cmd.Parameters.Add(e);

            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
        }
        public void update_user(int id_user,String nume_user, String parola, int id_permisiune)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.update_user";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter a = new SqlParameter();
            a.ParameterName = "@id_user";
            a.SqlDbType = SqlDbType.Int;
            a.Value = id_user;
            cmd.Parameters.Add(a);

            SqlParameter b = new SqlParameter();
            b.ParameterName = "@nume_user";
            b.SqlDbType = SqlDbType.Text;
            b.Value = nume_user;
            cmd.Parameters.Add(b);

            SqlParameter c = new SqlParameter();
            c.ParameterName = "@parola";
            c.SqlDbType = SqlDbType.Text;
            c.Value = parola;
            cmd.Parameters.Add(c);

            SqlParameter e = new SqlParameter();
            e.ParameterName = "@id_permisiune";
            e.SqlDbType = SqlDbType.Int;
            e.Value = id_permisiune;
            cmd.Parameters.Add(e);

            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
        }
        public DataTable afisare_studenti()
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT dbo.tabel_studenti.nume, dbo.tabel_studenti.prenume,dbo.tabel_studenti.id_student,dbo.tabel_studenti.id_user,dbo.tabel_grupe.id_grupa FROM dbo.tabel_studenti INNER JOIN dbo.tabel_grupe ON dbo.tabel_studenti.id_grupa=dbo.tabel_grupe.id_grupa ";
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            connection.Close();
            return dt;
        }
        public DataTable afis_std()
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "Select * from dbo.tabel_studenti";
            cmd.CommandType = CommandType.Text;
            connection.Open();
            var aux = cmd.ExecuteReader(); //citesc cele 2 coloane din tabel
            DataTable dt = new DataTable();
            dt.Load(aux);
            connection.Close();
            return dt;
        }
        public void agaugare_std_la_materie(int materie, int student, int prof, string nume_materie)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.add_std_la_materie";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter a = new SqlParameter();
            a.ParameterName = "@materie";
            a.SqlDbType = SqlDbType.Int;
            a.Value = materie;
            cmd.Parameters.Add(a);

            SqlParameter b = new SqlParameter();
            b.ParameterName = "@student";
            b.SqlDbType = SqlDbType.Int;
            b.Value = student;
            cmd.Parameters.Add(b);

            SqlParameter c = new SqlParameter();
            c.ParameterName = "@prof";
            c.SqlDbType = SqlDbType.Int;
            c.Value = prof;
            cmd.Parameters.Add(c);

            SqlParameter d = new SqlParameter();
            d.ParameterName = "@nume_materie";
            d.SqlDbType = SqlDbType.Text;
            d.Value = nume_materie;
            cmd.Parameters.Add(d);

            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
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
        public void add_student(String nume, String prenume, int id_grupa,int id_user)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.add_student";
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

            SqlParameter c = new SqlParameter();
            c.ParameterName = "@id_grupa";
            c.SqlDbType = SqlDbType.Int;
            c.Value = id_grupa;
            cmd.Parameters.Add(c);

            SqlParameter d = new SqlParameter();
            d.ParameterName = "@id_user";
            d.SqlDbType = SqlDbType.Int;
            d.Value = id_user;
            cmd.Parameters.Add(d);

            connection.Open();
            cmd.ExecuteReader();
            connection.Close();
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
        public void delete_student(int id_std)
        {
            initializare_conn();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "dbo.delete_student";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter e = new SqlParameter();
            e.ParameterName = "@id_student";
            e.SqlDbType = SqlDbType.Int;
            e.Value = id_std;
            cmd.Parameters.Add(e);

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
