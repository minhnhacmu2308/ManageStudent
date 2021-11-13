using ManagementStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementStudent.Repositories
{
    public class ScheduleRepository
    {
        ManageDbContext myDb = new ManageDbContext();

        public List<Schedule> getSchedule(int day,int buoi)
        {
            return myDb.schedules.Where(s => s.id_day == day && s.id_session == buoi).ToList();
        }
        public List<Day> getDay()
        {
            return myDb.days.ToList();
        }
        public void add(Schedule schedule)
        {
            myDb.schedules.Add(schedule);
            myDb.SaveChanges();
        }
        public void delete(int thu, int buoi, int monhoc)
        {
            var obj = myDb.schedules.FirstOrDefault(x => x.id_subject == monhoc && x.id_day == thu && x.id_session == buoi);
            myDb.schedules.Remove(obj);
            myDb.SaveChanges();
        }
        public Schedule getInfor(int thu, int buoi, int monhoc)
        {
            var obj = myDb.schedules.FirstOrDefault(x => x.id_subject == monhoc && x.id_day == thu && x.id_session == buoi);
            if(obj != null)
            {
                return obj;
            }
            return null;
        }
    }
}