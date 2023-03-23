using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using portofolioApi.Interfaces;
using portofolioClassLibrary;
using portofolioClassLibrary.Model;

namespace portofolioApi.Repositories
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly portofolioDBContext _context;



        public ProjectRepository(portofolioDBContext context)
        {
            _context = context;
        }





        public async Task<Project> Add(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<bool> Delete(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return false;
            else
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            //if (Project == null)
            //    return false;
            return project;
        }

        public async Task<Project> Update(int id, Project porojectChanegs)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return project;
            else
            {
                project.Name = porojectChanegs.Name;
                project.Disc = porojectChanegs.Disc;
                await _context.SaveChangesAsync();
                return project;
            }
        }
    }
}
