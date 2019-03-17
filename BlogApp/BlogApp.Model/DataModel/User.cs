using BlogApp.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogApp.Model.DataModel
{
    public class User : BaseModel, IEntity
    {
        public User()
        {
            Posts = new HashSet<Post>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }

        //[ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public virtual ICollection<Post> Posts{ get; set; }
    }
}
