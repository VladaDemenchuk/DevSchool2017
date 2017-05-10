using System;

namespace MyDropbox.Model
{
    public class Comment
    {
        public Guid UserId { get; set; }
        public Guid FileId { get; set; }
        public string Text { get; set; }
    }
}
