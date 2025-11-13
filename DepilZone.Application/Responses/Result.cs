using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Responses
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool First { get; set; }
        public bool Last { get; set; }
        public int Number { get; set; }
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
        public bool Empty { get; set; }
    }
}
