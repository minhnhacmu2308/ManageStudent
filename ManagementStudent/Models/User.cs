using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementStudent.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_user { get; set; }

        [StringLength(255)]
        [Required]
        public string username { get; set; }

        [StringLength(255)]
        [Required]
        public string password { get; set; }

        [StringLength(255)]
        [Required]
        public string fullname { get; set; }

        [StringLength(255)]
        [Required]
        public string address { get; set; }

        public int gender { get; set; }

        [StringLength(255)]
        [Required]
        public string grade { get; set; }

        public int status { get; set; }

        public int id_role { get; set; }
        public int id_major { get; set; }
        
        //Sơ yếu lí lịch
        [StringLength(500)]
        public string nguontuyen { get; set; }

        [StringLength(500)]
        public string truongchuyen { get; set; }

        [StringLength(500)]
        public string dantoc { get; set; }

        [StringLength(500)]
        public string tongiao { get; set; }

        [StringLength(500)]
        public string quoctinh { get; set; }

        [StringLength(500)]
        public string cmnd { get; set; }

        [StringLength(500)]
        public string noicap { get; set; }

        [StringLength(500)]
        public string chieucao { get; set; }

        [StringLength(500)]
        public string cannang { get; set; }

        [StringLength(500)]
        public string sonambodoi { get; set; }

        [StringLength(500)]
        public string sonamtnxp { get; set; }

        [StringLength(500)]
        public string ngaycap { get; set; }

        //

        public virtual Role Role { get; set; }
        public virtual Majors Majors { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}