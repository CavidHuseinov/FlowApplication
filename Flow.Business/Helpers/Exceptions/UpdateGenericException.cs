using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.Exceptions
{
    public class UpdateGenericException<TEntity> : Exception
    {
        public UpdateGenericException() : base($"{typeof(TEntity).Name} not updated")
        {
        }
        public UpdateGenericException(string? message) : base(message)
        { }
    }
}
