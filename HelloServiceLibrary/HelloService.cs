using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloCompLibrary;
using System.Data.SqlClient;
using System.Data;

namespace HelloServiceLibrary
{
    public class HelloService : IHello
    {
        SqlConnection connection;
        SqlCommand command;
        public HelloService()
        {
            connection = new SqlConnection("Data Source=SATB2BSQL1\\SQL2008;Initial Catalog=WCFDB;IntegratedSecurity=SSPI");
            connection.Open();
            Console.WriteLine(connection.State.ToString());
        }

        public void PostMessages(MessagePost message)
        {
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert Into PostMessages Values(@PostDetails)";
            command.Parameters.AddWithValue("@PostDetails", message.MessageDetails);
            command.ExecuteNonQuery();
            Console.WriteLine("Message Inserted to Database");
            connection.Close();
            //Console.WriteLine(message.MessageDetails);
        }

        public string Greet(string name)
        {
            return string.Format("Hello {0}, Welcome to WCF Service", name);
        }
    }
}
