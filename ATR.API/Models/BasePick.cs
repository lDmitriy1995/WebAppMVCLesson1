using System;
using System.Collections.Generic;

namespace ATR.API.Models
{
    public partial class BasePick
    {
        public int Carruselld { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? PictureUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
