namespace GoTopFloatingButtonList.ViewModels;

public class ItemDetailViewModel : BaseViewModel
{
	static ListModel? itemDetail = null;
	public ListModel? ItemDetail
	{
		get => itemDetail;
		set
		{
			if (itemDetail == value) { return; }
			itemDetail = value;
			OnPropertyChanged();
		}
	}
}
