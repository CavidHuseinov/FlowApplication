using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.Exceptions
{
    public class CreateGenericException<TEntity> : Exception
    {
        public CreateGenericException() : base($"{typeof(TEntity).Name} not created")
        {
        }
        public CreateGenericException(string? message) : base(message)
        {
        }
    }
}
