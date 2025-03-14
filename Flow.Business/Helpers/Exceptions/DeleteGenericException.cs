using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.Exceptions
{
    public class DeleteGenericException<TEntity> : Exception
    {
        public DeleteGenericException():base($"{typeof(TEntity).Name} not deleted")
        {
        }

        public DeleteGenericException(string? message) : base(message)
        {
        }
    }
}
