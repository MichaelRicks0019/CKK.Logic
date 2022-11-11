using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
