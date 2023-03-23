using Microsoft.EntityFrameworkCore;
using portofolioApi.Interfaces;
using portofolioClassLibrary;
using portofolioClassLibrary.Model;

namespace portofolioApi.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly portofolioDBContext _context;

  

    public PostRepository(portofolioDBContext context)
    {
        _context = context;
    }
       

        public async Task<Post> Add(Post post)
        {

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

    

        public async Task<bool> Delete(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
                return false;
            else
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return true;
            }
        }

  

        public async Task<List<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }
      
        public async Task<Post> GetById(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            //if (Project == null)
            //    return false;
            return post;
        }

        public async Task<Post> Update(int id, Post postChanegs)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
                return post;
            else
            {
                post.Title = postChanegs.Title;
                await _context.SaveChangesAsync();
                return post;
            }
        }

      

     

      

       
    }
  }