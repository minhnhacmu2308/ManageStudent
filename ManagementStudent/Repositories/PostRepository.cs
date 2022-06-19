using ManagementStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementStudent.Repositories
{
    public class PostRepository
    {
        ManageDbContext myDb = new ManageDbContext();

        public List<Post> getAll()
        {
            return myDb.posts.OrderByDescending(x => x.created).ToList();
        }

        public void add(Post post)
        {
            myDb.posts.Add(post);
            myDb.SaveChanges();
        }

        public void delete(int id)
        {
            var obj = myDb.posts.FirstOrDefault(x => x.id_post == id);
            myDb.posts.Remove(obj);
            myDb.SaveChanges();
        }

        public void update(Post post)
        {
            var obj = myDb.posts.FirstOrDefault(x => x.id_post == post.id_post);
            obj.title = post.title;
            obj.content = post.content;
            myDb.SaveChanges();
        }
    }
}