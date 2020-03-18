using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace App1.ViewModels.Region
{
    public class AddRegionViewModel
    {
	    private RegionService _regionService;
	    private readonly RegionListViewModel _regionListViewModel;

	    public RegionViewModel AddRegionModel { get; private set; }

	    public AddRegionViewModel(RegionService regionService,
	    RegionListViewModel regionListViewModel)
	    {
			AddRegionModel = new RegionViewModel();
		    _regionService = regionService;
		    _regionListViewModel = regionListViewModel;
	    }

	    public void Add()
	    {
			var toAddRegion = new Entities.Region();
			toAddRegion.Name = AddRegionModel.Name;
			_regionService.AddRegion(toAddRegion);
			AddRegionModel.RegionId = toAddRegion.RegionId;
			_regionListViewModel.RegionList.Insert(0,AddRegionModel);
	    }
    }
}
