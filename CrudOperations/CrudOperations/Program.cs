using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            operations op = new operations();
            op.CreateUser();
            op.RetriveUser();
            op.UpdateUser();    
            op.DeleteUser();     
        }
    }
}
