using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace App1.ViewModels.Project
{
    public class ProjectListViewModel
    {
	    private ProjectService _projectService;
	    private string _searchText;
	    private ProjectViewModel _selectedProject;
	    public ObservableCollection<ProjectViewModel> ProjectList { get; set; }

	    public ProjectListViewModel(ProjectService projectService)
	    {
		    _projectService = projectService;
			ProjectList = new ObservableCollection<ProjectViewModel>(
			_projectService.GetProjects()
			.Select(c=> new ProjectViewModel(c))
			);
	    }
		private ProjectViewModel SelectedProject
		{
			get => _selectedProject;
			set => _selectedProject = value;
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
			var projects = _projectService.GetProjects()
			.Where(c => c.ProjectId.ToString().Contains(searchString, StringComparison.InvariantCultureIgnoreCase));

			foreach (var project in projects) ProjectList.Add(new ProjectViewModel(project));
	    }
    }
}
