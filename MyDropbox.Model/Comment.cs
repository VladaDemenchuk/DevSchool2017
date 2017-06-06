using System;

namespace MyDropbox.Model
{
    public class Comment
    {
        public Guid Id { get; set; }
        public File File { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public override string ToString() => Text;
    }
}
