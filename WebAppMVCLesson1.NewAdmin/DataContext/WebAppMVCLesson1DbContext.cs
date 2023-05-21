using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppMVCLesson1.NewAdmin.Modals;

namespace WebAppMVCLesson1.NewAdmin.DataContext;

public partial class WebAppMVCLesson1DbContext : DbContext
{
    public WebAppMVCLesson1DbContext()
    {
    }

    public WebAppMVCLesson1DbContext(DbContextOptions<WebAppMVCLesson1DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carusel> Carusels { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomProperty> RoomProperties { get; set; }

    public virtual DbSet<TeamWork> TeamWorks { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<JobPosition> JobPositions { get; set; }


}