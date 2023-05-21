using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebAppMVCLesson1.NewAdmin.Modals
{
    public class JobPosition
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual ICollection <TeamWork> Works { get; set; }
    }
}
