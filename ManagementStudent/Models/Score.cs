using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementStudent.Models
{
    public class Score
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_score { get; set; }

        public int id_user { get; set; }

        public int id_subject { get; set; }

        public float point { get; set; }

        public float point2 { get; set; }

        public string pointWord { get; set; }

        public virtual User User { get; set; }

        public virtual Subject Subject { get; set; }
    }
}