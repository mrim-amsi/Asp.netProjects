using portofolioApi.Interfaces;
using portofolioClassLibrary.Model;

namespace portofolioApi.Repositories
{
    public class MockPostRepository : IPostRepository
    {
        public static List<Post> _posts { get; set; }

        public MockPostRepository()
        {
            _posts = new List<Post>() {
                new Post() { Id = 1, Title ="Asp.net core with angular"},
                new Post() { Id = 2, Title ="Web Development"},
            };
        }
        public Task<Post> Add(Post Post)
        {
            _posts.Add(Post);
            return Task.FromResult(Post);
        }

        public Task<bool> Delete(int id)
        {
            var Post = _posts.FirstOrDefault(x => x.Id == id);
            if (Post != null)
            {
                _posts.Remove(Post);
                return Task.FromResult(true);
            }
            else
                return Task.FromResult(false);

        }

        public Task<List<Post>> GetAllPosts()
        {
            return Task.FromResult(_posts.ToList());
        }

        public Task<Post> GetById(int id)
        {
            var Post = _posts.FirstOrDefault(x => x.Id == id);
            //if (Project == null)
            //else
            return Task.FromResult(Post);
        }

        public Task<Post> Update(int id, Post PostChanegs)
        {
            var Post = _posts.FirstOrDefault(x => x.Id == id);
            if (Post != null)
            {
                Post.Title = PostChanegs.Title;
                return Task.FromResult(Post);
            }
            else
                throw new Exception("Post Not found");
        }

       

  

    

    }
}
