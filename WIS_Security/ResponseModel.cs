using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIS_Security
{
    public class ResponseModel<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Object { get; set; }
    }
}
