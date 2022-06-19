using ManagementStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementStudent.Repositories
{
    public class FeedbackRepository
    {
        ManageDbContext myDb = new ManageDbContext();

        public List<Feedback> getAll()
        {
            return myDb.feedbacks.OrderByDescending(x => x.created).ToList();
        }

        public void add(Feedback feedback)
        {
            myDb.feedbacks.Add(feedback);
            myDb.SaveChanges();
        }
    }
}