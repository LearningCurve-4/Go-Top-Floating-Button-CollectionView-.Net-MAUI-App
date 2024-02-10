namespace GoTopFloatingButtonList
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			InitializeRouting();
		}

		public void InitializeRouting()
		{
			Routing.RegisterRoute(nameof(FloatingButtonListPage), typeof(FloatingButtonListPage));
			Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
		}
	}
}
