using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using App1.ViewModels.ProjectSchedule;
using Entities;
using ServiceLayer;

namespace App1.ViewModels.Project
{
    public class ProjectListViewModel
    {
	    private ProjCustEmpRegService _projCustEmpRegService;
	    private string _searchText;
	    private ProjectViewModel _selectedProject;
	    public ObservableCollection<ProjectViewModel> ProjectList { get;}
	    public ObservableCollection<ProjectScheduleTaskViewModel> ProjectScheduleTasks { get; set; }

	    public void LoadProjectScheduleTasks()
	    {
		    var group = _projCustEmpRegService.ProjectService
		    .GetProjectScheduleTasks(SelectedProject.ProjectId)
		    .ToList()
		    .OrderBy(c => c.ScheduledStartDate);
			
			ProjectScheduleTasks.Clear();
			foreach (var projectScheduleTask in group)
			{
				ProjectScheduleTasks.Add(new ProjectScheduleTaskViewModel(projectScheduleTask));
			}
	    }

	    public ProjectScheduleTaskListVM ProjectScheduleTaskList()
	    {
		    try
		    {
			    return new ProjectScheduleTaskListVM(_projCustEmpRegService, ProjectScheduleTasks, SelectedProject.ProjectId);
			}
		    catch (Exception e)
		    {
			    MessageBox.Show("no project selected. lol");
			    throw;
		    }


	    }

	    public ProjectListViewModel(ProjCustEmpRegService projCustEmpRegService)
	    {
			ProjectScheduleTasks = new ObservableCollection<ProjectScheduleTaskViewModel>();
		    _projCustEmpRegService = projCustEmpRegService;
			ProjectList = new ObservableCollection<ProjectViewModel>(
			_projCustEmpRegService.ProjectService.GetProjects()
			.Select(c=> new ProjectViewModel(c))
			);
	    }
		public ProjectViewModel SelectedProject
		{
			get => _selectedProject;
			set
			{
				_selectedProject = value;
				if (_selectedProject != null) LoadProjectScheduleTasks();
			}
		}

		public string SearchText
	    {
		    get => _searchText;
		    set
		    {
			    _searchText = value;
			    SearchProject(_searchText);
		    }
	    }

	    private void SearchProject(string searchString)
	    {
			ProjectList.Clear();
			var projects = _projCustEmpRegService.ProjectService.GetProjects()
			.Where(c => c.ProjectId.ToString().Contains(searchString, StringComparison.InvariantCultureIgnoreCase));

			foreach (var project in projects) ProjectList.Add(new ProjectViewModel(project));
	    }

	    public EditProjectViewModel CreateEditProjectViewModel()
	    {
			return new EditProjectViewModel(_selectedProject,_projCustEmpRegService);
	    }
    }
}
