using ManagementStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementStudent.Repositories
{
    public class CreditRepository
    {
        ManageDbContext myDb = new ManageDbContext();

        public List<Credit> getAll()
        {
            return myDb.credits.ToList();
        }

        public List<Credit> check(int idUser, int idSub)
        {
            return myDb.credits.Where(x => x.id_subject == idSub && x.id_user == idUser).ToList();
        }
        public List<Credit> getUser(int idUser)
        {
            return myDb.credits.Where(x => x.id_user == idUser).ToList();
        }

        public List<Credit> getSub(int idSub)
        {
            return myDb.credits.Where(x => x.id_subject == idSub && x.status == 1).ToList();
        }

        public void add(Credit credit)
        {
            myDb.credits.Add(credit);
            myDb.SaveChanges();
        }

        public void update(int idCre)
        {
            var obj = myDb.credits.FirstOrDefault(x => x.id_credit == idCre);
            obj.status = 1;
            myDb.SaveChanges();
        }
    }
}