using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagementStudent.Models
{
    public class FeedbackDto
    {
        
        public string TieuDe { get; set; }

        public string NoiDung { get; set; }

        public string NguoiGui { get; set; }

        public string NgayGui { get; set; }

        public string TinhTrang { get; set; }


    }
}