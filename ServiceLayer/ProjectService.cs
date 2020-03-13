using System.Linq;
using Entities;
using GCSClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
	public class ProjectService
	{
		private readonly GcsContext _context;

		public ProjectService(GcsContext context)
		{
			_context = context;
		}

		public IQueryable<Project> GetProjects()
		{
			return _context.Projects
			.Where(c => c.IsDeleted == false)
			.Include(c => c.CustomerLink)
			.ThenInclude(c=>c.RegionLink)
			.Include(c => c.EmployeeLink)
			.ThenInclude(c=>c.RegionLink)
			;
		}

		public void AddProject(Project project)
		{
			_context.Projects.Add(project);
			_context.SaveChanges();
		}

		public void EditProject(int projectId, string description, int actualCost, int budget)
		{
			var project = _context.Projects.Find(projectId);
			project.Description = description;
			project.ActualCost = actualCost;
			project.Budget = budget;
			_context.SaveChanges();
		}

		public void DeleteProject(int projectId)
		{
			var project = _context.Projects.Find(projectId);
			project.IsDeleted = true;
		}
	}
}