using System;
using System.Collections.Generic;

namespace WebAppMVCLesson1.Admin.Modals;

public partial class EventCategory
{
    public int EventCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreateDate { get; set; }
}
