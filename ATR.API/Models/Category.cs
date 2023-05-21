using System;
using System.Collections.Generic;

namespace ATR.API.Models
{
    public partial class Category
    {
        public Category()
        {
            Rooms = new HashSet<Room>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
