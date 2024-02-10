namespace GoTopFloatingButtonList.Views.Pages;

public partial class FloatingButtonListPage : ContentPage
{
	public FloatingButtonListPage()
	{
		InitializeComponent();
	}

	protected override bool OnBackButtonPressed()
	{
		return true;
	}

	private readonly int scrollTopPosition = 0;

	private void List_Scrolled(object sender, ItemsViewScrolledEventArgs e)
	{
		if (e.VerticalDelta == scrollTopPosition || e.FirstVisibleItemIndex == scrollTopPosition)
		{
			ScrollTop.IsVisible = false;
		}
		else if (scrollTopPosition < e.VerticalDelta)
		{
			ScrollTop.IsVisible = true;
		}
	}

	private void ScrollTop_Clicked(object sender, EventArgs e)
	{
		itemlist.ScrollTo(index: scrollTopPosition, animate: false);
		ScrollTop.IsVisible = false;
	}
}