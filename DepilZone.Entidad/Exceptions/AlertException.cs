using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.Exceptions
{
    public class AlertException: Exception
    {
        public AlertException()
        {
            
        }

        public AlertException(string message) : base(message)
        {
        }

        public AlertException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}
