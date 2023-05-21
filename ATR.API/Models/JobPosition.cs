using System;
using System.Collections.Generic;

namespace ATR.API.Models
{
    public partial class JobPosition
    {
        public JobPosition()
        {
            TeamWorks = new HashSet<TeamWork>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<TeamWork> TeamWorks { get; set; }
    }
}
