namespace DataAccess
{
    
    
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    using global::DataAccess.Models;
    using global::DataAccess.Common;

    public class DataAccess
    {
        // get users from the user table
        public List<UserDO> GetUsers()
        {

            //create a list because i need to return a list of users
            List<UserDO> _list = new List<UserDO>();
            string connectionstring = ConfigurationManager.ConnectionStrings["airresconnection"].ConnectionString;

            //need to open a sqlconnection- need a connection string
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                //create a sqlcommand
                using (SqlCommand command = new SqlCommand("SP_SELECT_USER", conn))
                {
                    //details to the select command
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    //need a loop to get users from the database

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserDO _userdo = new UserDO();
                            _userdo.UserID = (int)reader["UserID"];
                            _userdo.FirstName = (string)reader["FirstName"];
                            _userdo.LastName = (string)reader["LastName"];
                            _userdo.UserName = (string)reader["UserName"];
                            _userdo.Password = (string)reader["Password"];

                            //_userdo.Role = (RoleType)reader["Role"];
                            //TODO - fix; will throw an exception
                            _list.Add(_userdo);
                        }

                    }
                }

            }

           
            return _list;
        }


    }
}
