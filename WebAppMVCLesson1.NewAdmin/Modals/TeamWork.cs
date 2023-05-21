using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebAppMVCLesson1.NewAdmin.Modals
{
    public class TeamWork
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(250)]
        public string ModdleName { get; set; }
        [Required]
        [StringLength(250)]
        public string LastName { get; set; }
        [StringLength(1024)]
        public string AboutWork { get; set; }

        public DateTime CreatedDate { get; set; }= DateTime.Now;

        [Required]
        [StringLength(250)]
        public string Autor { get; set; } = "Admin";
        [StringLength(250)]
        public string LinkedIn { get; set;}
        [StringLength(250)]
        public string Instagram { get; set;}
        [StringLength(250)]
        public string FaceBook { get; set;}
        [StringLength(250)]
        public bool Status { get; set; }
       
        public int JobPositionId { get; set; }
        [StringLength(500)]
        public string Photo { get; set; }

        public JobPosition JobPositions { get; set; }


       
    }
}
