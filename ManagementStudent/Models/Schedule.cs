using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementStudent.Models
{
    public class Schedule
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_role { get; set; }

        public int id_subject { get; set; }

        public int id_day { get; set; }

        public int id_session { get; set; }

        public int id_major { get; set; }

        public virtual Day Day { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Session Session { get; set; }
        public virtual Majors Majors { get; set; }
    }
}