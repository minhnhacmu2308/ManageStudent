using ManagementStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementStudent.Repositories
{
    public class UserRepository
    {
        ManageDbContext myDb = new ManageDbContext();

        public List<User> getListStudent()
        {
            return myDb.users.Where(x => x.Role.id_role == 3).ToList();
        }

        public List<User> getClass(string lop)
        {
            return myDb.users.Where(x => x.grade.Equals(lop)).ToList();
        }

        public List<User> getMajor(int id)
        {
            return myDb.users.Where(x => x.id_major == id).ToList();
        }

        public List<User> getListGiangVien()
        {
            return myDb.users.Where(x => x.Role.id_role == 2).ToList();
        }

        public void add(User user)
        {
            myDb.users.Add(user);
            myDb.SaveChanges();
        }

        public void edit(User user)
        {
            var obj = myDb.users.FirstOrDefault(x => x.id_user == user.id_user);
            obj.id_role = user.id_role;
            obj.username = user.username;
            obj.password = user.password;
            obj.id_major = user.id_major;
            obj.grade = user.grade;
            obj.gender = user.gender;  
            obj.address = user.address;
            obj.fullname = user.fullname;
            obj.nguontuyen = user.nguontuyen;
            obj.truongchuyen = user.truongchuyen;
            obj.dantoc = user.dantoc;
            obj.tongiao = user.tongiao;
            obj.quoctinh = user.quoctinh;
            obj.cmnd = user.cmnd;
            obj.noicap = user.noicap;
            obj.ngaycap = user.ngaycap;
            obj.chieucao = user.chieucao;
            obj.cannang = user.cannang;
            obj.sonambodoi = user.sonambodoi;
            obj.sonamtnxp = user.sonamtnxp;
            myDb.SaveChanges();
        }

        public void SVedit(User user)
        {
            var obj = myDb.users.FirstOrDefault(x => x.id_user == user.id_user);
            obj.password = user.password;
            
            myDb.SaveChanges();
        }

        public void delete(int id)
        {
            var obj = myDb.users.FirstOrDefault(x => x.id_user == id);
            myDb.users.Remove(obj);
            myDb.SaveChanges();
        }

        public User checkExistName(string name)
        {
            return myDb.users.FirstOrDefault(x => x.username == name);
        }
       
        public User getUserById(int id)
        {
            return myDb.users.FirstOrDefault(x => x.id_user == id);
        }
    }
}