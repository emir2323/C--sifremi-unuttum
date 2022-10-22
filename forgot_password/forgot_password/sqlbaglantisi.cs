using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
namespace forgot_password
{
    internal class sqlbaglantisi
    {

        public SqlConnection baglanti()
        {

            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-58O93P0\\SQLEXPRESS;Initial Catalog=forgot_password;Integrated Security=True");
            baglanti.Open();
            return baglanti;




        }
    }
}
    

