using portofolioApi.Interfaces;
using portofolioClassLibrary.Model;

namespace portofolioApi.Repositories
{
    public class MockProjectRepository : IProjectRepository
    {

        public static List<Project> _Projects { get; set; }

        public MockProjectRepository()
        {
            _Projects = new List<Project>() {
                new Project() { id = 1, Name ="Asp.net core with angular", Disc ="jknnml"},
                new Project() { id = 2, Name ="Web Development", Disc ="jknnml"},
            };
        }
        public Task<Project> Add(Project Project)
        {
            _Projects.Add(Project);
            return Task.FromResult(Project);
        }

        public Task<bool> Delete(int id)
        {
            var Project = _Projects.FirstOrDefault(x => x.id == id);
            if (Project != null)
            {
                _Projects.Remove(Project);
                return Task.FromResult(true);
            }
            else
                return Task.FromResult(false);

        }

        public Task<List<Project>> GetAllProjects()
        {
            return Task.FromResult(_Projects.ToList());
        }

        public Task<Project> GetById(int id)
        {
            var Project = _Projects.FirstOrDefault(x => x.id == id);
            //if (Project == null)
            //else
            return Task.FromResult(Project);
        }

        public Task<Project> Update(int id, Project ProjectChanegs)
        {
            var Project = _Projects.FirstOrDefault(x => x.id == id);
            if (Project != null)
            {
                Project.Name = ProjectChanegs.Name;
                return Task.FromResult(Project);
            }
            else
                throw new Exception("Project Not found");
        }

        Task<Post> IProjectRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<Post> IProjectRepository.Add(Project project)
        {
            throw new NotImplementedException();
        }

        Task<Post> IProjectRepository.Update(int id, Project porojectChanegs)
        {
            throw new NotImplementedException();
        }
    }
}
