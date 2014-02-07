using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var_statice
{
    class permisiuni
    {
        public static Int32 id_user;
        public static String user;
        public static Int32 id_rol = new Int32();
        public static String tip;
        public static Int32 id_permisiune = new Int32();
        public static Int32 id_student = new Int32();
        public static Int32 id_materie=new Int32();
        public static bool view;
        public static bool insert;
        public static bool search;
        public static bool update;
        public static bool create_account;
        public static bool change_perm;
    }
}
