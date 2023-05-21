using System;
using System.Collections.Generic;

namespace WebAppMVCLesson1.Admin.Modals;

public partial class SliderArea
{
    public int SliderAreaId { get; set; }

    public string? Header { get; set; }

    public string? Description { get; set; }

    public string? Url { get; set; }

    public string? PathImg { get; set; }
}
