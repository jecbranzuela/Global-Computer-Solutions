using System;
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

		public IQueryable<Employee> PoolEmployeesPerRegion(int customerRegionId)
		{
			return _context.Employees.Where(c => c.RegionId == customerRegionId);
		}

		public void AddProject(Project project)
		{
			_context.Projects.Add(project);
			_context.SaveChanges();
		}

		public void EditProject(int projectId, int customerId,int? employeeId,DateTime estimatedEnd,
		DateTime estimatedStart, string description,int? actualCost, int budget, DateTime date, DateTime? actualStart,DateTime? actualEnd)
		{
			var project = _context.Projects.Find(projectId);
			project.CustomerId = customerId;
			project.EmployeeId = employeeId;
			project.EstimatedStartDate = estimatedStart;
			project.EstimatedEndDate = estimatedEnd;
			project.Description = description;
			project.ActualCost = actualCost;
			project.Budget = budget;
			project.Date = date;
			project.ActualStartDate = actualStart;
			project.ActualEndDate = actualEnd;
			_context.SaveChanges();
		}

		public void DeleteProject(int projectId)
		{
			var project = _context.Projects.Find(projectId);
			project.IsDeleted = true;
		}

		public IQueryable<ProjectScheduleTask> GetProjectScheduleTasks(int projectId)
		{
			return _context.ProjectScheduleTasks
			.Where(c => c.ProjectId == projectId)
			.Include(c=>c.TaskClassLink);
		}
	}
}