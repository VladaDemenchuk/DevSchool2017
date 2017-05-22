using System;

namespace MyDropbox.Model
{
    public class File
    {
        public Guid Id { get; set; }
        public User Owner { get; set; }
        public string Name { get; set; }

    }
}
