using portofolioClassLibrary.Model;

namespace portofolioApi.Interfaces

{
    public interface IProjectRepository
{
        Task<List<Project>> GetAllProjects();
        Task<Project> GetById(int id);
        Task<Project> Add(Project project);
        Task<Project> Update(int id, Project porojectChanegs);
        Task<bool> Delete(int id);
    }
}
