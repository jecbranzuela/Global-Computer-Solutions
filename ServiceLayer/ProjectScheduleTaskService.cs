using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;
using GCSClasses.EFClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class ProjectScheduleTaskService
    {
        private GcsContext _context;

        public ProjectScheduleTaskService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<ProjectScheduleTask> GetProjectScheduleTasks()
        {
            return _context.ProjectScheduleTasks
            .Include(c=>c.TaskClassLink);
        }
        public void AddProjectTask(ProjectScheduleTask toAddProjSched)
        {
	        _context.ProjectScheduleTasks.Add(toAddProjSched);
	        _context.SaveChanges();
        }
        public IList<TaskSkill> GetTaskSkills(int taskClassId,int projectScheduleTaskId)
        {
	        //return _context.TaskSkills
	        //.Where(c => c.TaskClassId == taskClassId)
	        //.Include(c => c.TaskClassLink)
	        //.Include(c=>c.SkillLink)
	        //.Include(c=>c.TaskSkillEmployeesQuantities);
	        var tEQ = GetTEQ(taskClassId, projectScheduleTaskId);



			var taskSkill = new List<TaskSkill>();
	        foreach (var taskSkillEmployeesQuantity in tEQ)
	        {
                taskSkill.Add(taskSkillEmployeesQuantity.TaskSkillLink);
	        }

	        return taskSkill;
        }

        public IQueryable<TaskSkillEmployeesQuantity> GetTEQ(int taskClassId, int projectScheduleTaskId)
        {
	        return _context.TaskSkillEmployeesQuantities
	        .Where(c => c.TaskSkillLink.TaskClassId == taskClassId && c.ProjectScheduleTaskId == projectScheduleTaskId)
	        .Include(c => c.ProjectScheduleTaskLink)
	        .ThenInclude(c => c.Assignments)
	        .ThenInclude(c => c.EmployeeLink)
	        .Include(c => c.TaskSkillLink)
	        .ThenInclude(c => c.SkillLink);
        }

        public IList<Employee> GetEmployeesForTaskSkills(int taskClassId, int projectScheduleTaskId)
        {
	        var taskSkills = GetTaskSkills(taskClassId, projectScheduleTaskId);
			var employeesOnTask = new List<Employee>();
	        foreach (var taskSkill in taskSkills)
	        foreach (var taskSkillEmployeesQuantities in taskSkill.TaskSkillEmployeesQuantities)
		        employeesOnTask.AddRange(
		        taskSkillEmployeesQuantities.ProjectScheduleTaskLink.Assignments.Select(assignment =>
		        assignment.EmployeeLink));

	        return employeesOnTask;
        }

        public IList<Assignment> GetAssignmentsForSelectedTaskSkill(int taskClassId, int projectScheduleTaskId,int skillId)
        {
			//var taskSkills = GetTaskSkills(taskClassId, projectScheduleTaskId);
			//var assignments = new List<Assignment>();
			//foreach (var taskSkill in taskSkills)
			//{
			//	foreach (var taskSkillEmployeesQuantities in taskSkill.TaskSkillEmployeesQuantities)
			//	{
			//		foreach (var assignment in taskSkillEmployeesQuantities.ProjectScheduleTaskLink.Assignments)
			//		{
			//			assignments.Add(assignment);
			//		}
			//	}
			//}
			var assignments = new List<Assignment>();
			//assignments = _context.Assignments
			//.Include(c => c.ProjectScheduleTaskLink)
			//.ThenInclude(c => c.TaskClassLink)
			//.Where(c => c.ProjectScheduleTaskId == projectScheduleTaskId
			//			&& c.ProjectScheduleTaskLink.TaskClassId == taskClassId
			//			&& c.ProjectScheduleTaskLink.TaskClassLink.
			//).ToList();
			var teq = GetTEQ(taskClassId, projectScheduleTaskId).Where(c => c.TaskSkillLink.SkillId == skillId);
			foreach (var taskSkillEmployeesQuantity in teq)
			{
				foreach (var assignment in taskSkillEmployeesQuantity.ProjectScheduleTaskLink.Assignments)
				{
					assignments.Add(assignment);
				}
			}
			return assignments;
        }



	}
}
