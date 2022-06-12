using ManagementStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementStudent.Repositories
{
    public class ScoreRepository
    {
        ManageDbContext myDb = new ManageDbContext();

        public List<Score> getAll()
        {
            return myDb.scores.ToList();
        }

        public void add(Score score)
        {
            myDb.scores.Add(score);
            myDb.SaveChanges();
        }

        public void update(Score score)
        {
            var obj = myDb.scores.FirstOrDefault(x => x.id_user == score.id_user);
            obj.id_user = score.id_user;
            obj.point = score.point;
            obj.id_subject = score.id_subject;
            obj.point2 = score.point2;
            myDb.SaveChanges();
        }

        public void delete(int id)
        {
            var obj = myDb.scores.FirstOrDefault(x => x.id_score == id);
            myDb.scores.Remove(obj);
            myDb.SaveChanges();
        }

        public Score getScoreById(int id)
        {
            return myDb.scores.FirstOrDefault(x => x.id_user == id);
        }

        public Score checkPointExist(Score score)
        {
            var obj =  myDb.scores.FirstOrDefault(x => x.id_subject == score.id_subject && x.id_user == score.id_user && x.point.ToString() != null);
            return obj;
        }

        public List<Score> getListScoreById(int id)
        {
            return myDb.scores.Where(x => x.id_user == id).ToList();
        }
        public List<Rank> getRank()
        {
            string sql = "Select b.fullname, ROUND(avg(point), 2) as 'diemtb' From Scores as a, Users as b Where a.id_user = b.id_user Group by b.fullname Order by ROUND(avg(point), 2) DESC";
            return myDb.Database.SqlQuery<Rank>(sql).ToList();
        }
    }
}