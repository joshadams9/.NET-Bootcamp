using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    //implemnting IDisposable indicates that this class has heavy duty resources that need to be
    //released 'on-demand'
    //this class has a database connection which is such a resource
    //implementing this interface also allows the C# 'using' pattern to be used on instances of this class
    public class DALContext : IDisposable
    {
        public string ConnectionString
        {
            get { return MyConnection.ConnectionString; }
            set { MyConnection.ConnectionString = value; }
        }
        private System.Data.SqlClient.SqlConnection MyConnection= new System.Data.SqlClient.SqlConnection();
      
        private void EnsureConnected()
        {


            if (MyConnection.State== System.Data.ConnectionState.Closed)
            {
                MyConnection.Open();
            }
            else if (MyConnection.State== System.Data.ConnectionState.Broken)
            {
                throw (new Exception("the sql connection is broken"));
            }
        }
        //get all items in the Numbers table
        #region access functions for the numbers table
        public List<NumberDAL> GetAllNumbers()
        {
            //Ensure connected opens the connection to the database if it is not already opended
            EnsureConnected();
            //create an empty list to return
            List<NumberDAL> rv = new List<NumberDAL>();
            //create a sql command object using the existing and open connection. we know it is open 
            //because of ensureconnection();
            SqlCommand localcommand = MyConnection.CreateCommand();
            //configure the command object. we are sending literal sql to execute, so use text as the type
            // and select * from numbers since we want all numbers
            localcommand.CommandType = System.Data.CommandType.Text;
            localcommand.CommandText = "Select * from Numbers";
            //start the query
            SqlDataReader reader = localcommand.ExecuteReader();
            //reader.read positions us to the first record returned by the sql query
            //and it returns false when there are no more records, and true when the record is postioned
            int IDPosition=0;
            int NamePosition=0;
            int DSPosition=0;
            int FSPosition=0;
            bool first = true;
            while (reader.Read())
            {
                if (first)
                {
                    first = false;
                    IDPosition = reader.GetOrdinal("ID");
                    NamePosition = reader.GetOrdinal("Name");
                    DSPosition = reader.GetOrdinal("Doublestuff");
                    FSPosition = reader.GetOrdinal("Floatstuff");
                }
                NumberDAL r = new NumberDAL();
                r.ID = reader.GetInt32(IDPosition);// this involves boxing, unboxing and garbage generation
                r.Name = (string) reader[NamePosition];
                //r.Doublstuff = (double)reader[DSPosition];
                r.Doublstuff = reader.GetDouble(DSPosition);
                r.Floatstuff = reader.GetFloat(FSPosition);
                //r.Floatstuff = (float)reader[FSPosition];

                rv.Add(r);
            }
            reader.Close();
            return rv;
        }

        //get a single item from the table by ID
        public NumberDAL GetNumberByID(int id)
        {
            return null;
        }
    
        //get numbers from the numbers table meeting  certain conditions
        public List<NumberDAL> GetNumbersStartingWith(char c)
        {
            List<NumberDAL> rv = new List<NumberDAL>();
            return rv;
        }
        //update an existing nmber from the numbers table by using new values
        public void UpdateNumber(NumberDAL newValues)
        {
            UpdateNumber(newValues.ID, newValues.Name, newValues.Doublstuff, newValues.Floatstuff);
        }
       public void UpdateNumber(int id, string name, double doublestuff, float floatstuff)
        {
            //NumberDAL r = new NumberDAL() { ID = id, Name = name, Doublstuff = doublestuff, Floatstuff = floatstuff };
            //UpdateNumber(r);
        }
        //delete an existing number from the numbers table by ID
        public void DeleteNumberByID(int id)
        {

        }
        public void DeleteNumberID(NumberDAL recordToDelete)
        {
            DeleteNumberByID(recordToDelete.ID);
        }
        //create a new number in the numbers table 
        public int CreateNumber(NumberDAL newValues)
        {
           return CreateNumber( newValues.Name, newValues.Doublstuff, newValues.Floatstuff);
        }
        public int CreateNumber( string name, double doublestuff, float floatstuff)
        {
            return 0;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~DALContext()
        {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
             }

            // This code added to correctly implement the disposable pattern.
            public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
        //this class goes even further than simple implementation of the IDisoposable interface 
        //it follows the disposable design pattern which is used to catch some sloppy programming
        //where the user does not use the C# 'using' pattern and 'forgets' to call Dispose()
        //the item will actually be cleaned up during 'garbage collection' when following the 
        //disposable design pattern
        //there are two additional funcions added in addition to the required dispose()
        //DALContext () to catch at the garbage collection time 
        // and dispose(bool) to do the actual work

        #endregion
    }

}
