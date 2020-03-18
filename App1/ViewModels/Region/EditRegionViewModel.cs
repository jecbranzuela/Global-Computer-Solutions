using ServiceLayer;

namespace App1.ViewModels.Region
{
	public class EditRegionViewModel
	{
		private RegionService _regionService;
		public RegionViewModel AssociatedRegionModel { get; private set; }
		public string Name { get; set; }

		public EditRegionViewModel(RegionService regionService, RegionViewModel regionModel)
		{
			_regionService = regionService;
			AssociatedRegionModel = regionModel;
			CopyEditableFields(regionModel);
		}

		private void CopyEditableFields(RegionViewModel regionModel)
		{
			Name = regionModel.Name;
		}

		public void Edit()
		{
			AssociatedRegionModel.Name = Name;

			_regionService.EditRegion(AssociatedRegionModel.RegionId,AssociatedRegionModel.Name);
		}
	}
}