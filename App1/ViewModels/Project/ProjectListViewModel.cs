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
	    private ProjCustEmpRegService _projCustEmpRegService;
	    private string _searchText;
	    private ProjectViewModel _selectedProject;
	    public ObservableCollection<ProjectViewModel> ProjectList { get;}

	    public ProjectListViewModel(ProjCustEmpRegService projCustEmpRegService)
	    {
		    _projCustEmpRegService = projCustEmpRegService;
			ProjectList = new ObservableCollection<ProjectViewModel>(
			_projCustEmpRegService.ProjectService.GetProjects()
			.Select(c=> new ProjectViewModel(c))
			);
	    }
		public ProjectViewModel SelectedProject
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
