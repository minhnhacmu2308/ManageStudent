using ManagementStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementStudent.Repositories
{
    public class SubjectRepository
    {
        ManageDbContext myDb = new ManageDbContext();

        public List<Subject> getAll()
        {
            return myDb.subjects.ToList();
        }

        public Subject getSubjectByName(string name)
        {
            return myDb.subjects.FirstOrDefault(x => x.name == name);
        }

        public void add(Subject subject)
        {
            myDb.subjects.Add(subject);
            myDb.SaveChanges();
        }

        public void delete(int id)
        {
            var obj = myDb.subjects.FirstOrDefault(x => x.id_subject == id);
            myDb.subjects.Remove(obj);
            myDb.SaveChanges();
        }

        public void update(Subject subject)
        {
            var obj = myDb.subjects.FirstOrDefault(x => x.id_subject == subject.id_subject);
            obj.status = 1;
            obj.name = subject.name;
            myDb.SaveChanges();
        }
    }
}