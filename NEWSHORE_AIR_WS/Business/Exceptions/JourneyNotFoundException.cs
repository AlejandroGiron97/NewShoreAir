using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class JourneyNotFoundException : Exception
    {
        public JourneyNotFoundException()
        {
        }

        public JourneyNotFoundException(string message)
            : base(message)
        {
        }

        public JourneyNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
