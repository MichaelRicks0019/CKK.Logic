using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CKK.DB.Interfaces
{
    public interface IConnectionFactory
    {
        //This should establish a connection to the database
        IDbConnection GetConnection { get; }
    }
}
