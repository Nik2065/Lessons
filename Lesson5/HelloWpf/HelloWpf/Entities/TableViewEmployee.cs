using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWpf.Entities
{
    class TableViewEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
    }
}
