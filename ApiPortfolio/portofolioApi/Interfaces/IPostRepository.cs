using portofolioClassLibrary.Model;

namespace portofolioApi.Interfaces

{
    public interface IPostRepository
    {

        Task<List<Post>> GetAllPosts();
        Task<Post> GetById(int id);
        Task<Post> Add(Post post);
        Task<Post> Update(int id, Post postChanegs);
        Task<bool> Delete(int id);
    }
}
