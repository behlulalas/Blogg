using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogger.Models.Comments;

namespace TheBlogger.Models
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        Post GetPost(int id);
        List<Post> GetAllPosts();
        void RemovePost(int id);
        void UpdatePost(int id, Post post);
        void UpdatePost2(Post post);
        void UpdatePostState(int id, Post post);
        int GetStatePost(int id);
        List<Post> GetByUser(IdentityUser user);
        void AddSubComment(SubComment comment);
        Task<bool> SaveChangesAsync();

    }
}
