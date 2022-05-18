using ManagementStudent.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ManagementStudent.Repositories
{
    
    public class MajorRepository
    {
        ManageDbContext myDb = new ManageDbContext();
        public List<Majors> GetAll()
        {
            return myDb.majors.ToList();
        }
    }
}