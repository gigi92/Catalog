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
        
       
       
       

    }
}
