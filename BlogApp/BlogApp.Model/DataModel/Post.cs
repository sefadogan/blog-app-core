using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogApp.Model.DataModel
{
    public class Post : BaseModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; }

        #region Navigation Properties

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        #endregion

    }
}
