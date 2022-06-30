using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagementStudent.Models
{
    public class Credit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_credit { get; set; }

        public int id_user { get; set; }

        public int id_subject{ get; set; }

        public int status { get; set; }

        public DateTime created { get; set; }

        public virtual User User { get; set; }

        public virtual Subject Subject { get; set; }
    }
}