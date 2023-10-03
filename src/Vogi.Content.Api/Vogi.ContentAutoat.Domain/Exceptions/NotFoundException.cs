using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vogi.ContentAutoat.Domain.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string element) : base($"{element} not found")
        {

        }
    }
}
