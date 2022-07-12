using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagementStudent.Models
{
    public class CreditDto
    {
        public string MaSinhVien { get; set; }
        public string HoTen { get; set; }
        public string Nganh { get; set; }

        public string MonHoc{ get; set; }

        public string ThamSo { get; set; }
    }
}