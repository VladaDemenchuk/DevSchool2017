using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDropbox.Model
{
    public class File
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public User Owner { get; set; }
    }
}
