using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDropbox.Model
{
   public class Share
    {
        public File FileId { get; set; }
        public User UserId { get; set; }
        public Permission PermissionId { get; set; }
    }
}
