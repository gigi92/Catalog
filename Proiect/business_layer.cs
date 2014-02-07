using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using d_layer;
using var_statice;
using System.IO;
namespace b_layer
{
    class business_layer
    {
        public int check_user(string user, string parola)
        {
            data_layer obj = new data_layer();
            DataTable dt = new DataTable();
            dt = obj.read_users();
            //string str = dt.Rows[0][0].ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((String.Compare(dt.Rows[i][0].ToString().Trim(' '), user) == 0))
                    if (String.Compare(dt.Rows[i][1].ToString().Trim(' '), parola) == 0)
                        return 1;
            }
            return 0;
        }
        public Int32 get_id_permisiune(string user)
        {
            data_layer obj = new data_layer();
            DataTable dt = new DataTable();
            dt = obj.read_users();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((String.Compare(dt.Rows[i][0].ToString().Trim(' '), user) == 0))
                {
                    return Convert.ToInt32(dt.Rows[i][3].ToString());
                }
            }
            return 0;
        }
        public Int32 get_id_user(string user)
        {
            data_layer obj = new data_layer();
            DataTable dt = new DataTable();
            dt = obj.read_users();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((String.Compare(dt.Rows[i][0].ToString().Trim(' '), user) == 0))
                {
                    return Convert.ToInt32(dt.Rows[i][2].ToString());
                }
            }
            return 0;
        }

    }
}
