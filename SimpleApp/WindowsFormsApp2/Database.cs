using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class Database
    {
        private MySqlConnection connection;

        public Database()
        {
            string con = "Server = studmysql01.fhict.local; Database = dbi317997; Uid = dbi317997; Pwd = i317997;";
            connection = new MySqlConnection(con);

        }

        public User GetUser(int UserId)
        {
            MySqlCommand command;
            User person = null;

            try
            {
                connection.Open();

                command = new MySqlCommand("Select User_Id,FirstName, LastName , DOB, Address, City, Balance From Users Where User_Id = '" + UserId + "';", connection);

                MySqlDataReader Reader = command.ExecuteReader();

                while(Reader.Read())
                {
                    person = new User(Convert.ToInt32(Reader[0]), Reader[1].ToString(), Reader[2].ToString(), Reader[3].ToString(),Reader[4].ToString(),Reader[5].ToString(), Convert.ToDecimal(Reader[6]));
                }

                return person;
            }

            catch(MySqlException exception)
            {
                MessageBox.Show(exception.ToString());

                return person;
            }

            finally
            {
                connection.Close();
            }

        }

        public User AddUser(string fname, string lname, string dob, string address, string city, decimal amount)
        {
            MySqlCommand command;
            int uid = 0;int campnr = 0; int campsection = 0;



            try
            {
                connection.Open();

                command = new MySqlCommand("Select max(User_Id) 'User_Id', max(Camp_Nr) 'CampNr', max(Camp_Section)'CampSection' From Users ;", connection);

                MySqlDataReader Reader = command.ExecuteReader();

                while(Reader.Read())
                {
                    uid = Convert.ToInt32(Reader[0]) + 1;

                    campnr = Convert.ToInt32(Reader[1]);

                    campsection = Convert.ToInt32(Reader[2]);

                    
                }

                connection.Close();
                

               


                command = null;
                connection.Open();
                command = new MySqlCommand("Insert INTO Users (	User_Id,FirstName,LastName,DOB,Address,City,Camp_Nr,Camp_Section,Balance)" + "Values('"+ uid + "','" + fname +"','" + lname + "','" + dob + "','" + address + "','"+ city + "','" + campnr + "','" + campsection +"','"+ amount +"');",connection);
                command.ExecuteNonQuery();

                return null;
            
            }

            catch(MySqlException exception)
            {
                MessageBox.Show(exception.ToString());

                return null;

            }

            finally
            {
                connection.Close();
            }
        }
    }
}
