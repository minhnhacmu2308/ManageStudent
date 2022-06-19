using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagementStudent.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_feedBack { get; set; }

        public string title { get; set; }

        public string content { get; set; }

        public int id_user { get; set; }

        public DateTime created { get; set; }

        public virtual User User { get; set; }
    }
}