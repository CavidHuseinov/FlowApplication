using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.Exceptions
{
    public class GetGenericException<TEntity> : Exception
    {
        public GetGenericException():base($"{typeof(TEntity).Name} not found")
        {
        }

        public GetGenericException(string? message) : base(message)
        {
        }
    }
}
