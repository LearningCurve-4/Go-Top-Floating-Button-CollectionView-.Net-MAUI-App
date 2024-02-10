namespace GoTopFloatingButtonList.ViewModels;

public class ListViewModel : BaseViewModel
{
	public ListViewModel()
	{
		ScreenHeight -= 183;  //minus screen objects height before/after of the list
		GetDataCommand.Execute("itemdata.json");  //json file saved in Resources > Raw folder
	}

	public ObservableCollection<ListModel>? ItemList { get; set; } = [];

	public Command GetDataCommand => new Command<string>(async (filename) =>
	{
		try
		{
			IsBusy = true;
			ItemList?.Clear();
			using Stream stream = await FileSystem.OpenAppPackageFileAsync(filename);
			using StreamReader reader = new(stream);
			string jsonResponse = await reader.ReadToEndAsync();

			if (!string.IsNullOrEmpty(jsonResponse))
			{
				ItemList = JsonSerializer.Deserialize<ObservableCollection<ListModel>>(jsonResponse)!;
			}
			OnPropertyChanged(nameof(ItemList));
		}
		catch (Exception ex) { await Shell.Current.DisplayAlert("Error:", ex.Message, "OK"); }
		finally
		{
			IsBusy = false;
		}
	}, (filename) => IsNotBusy);

	public Command ItemDetailCommand => new Command<string>((str) =>
	{
		try
		{
			IsBusy = true;
			string[] substrings = str.Split(',');
			_ = new ItemDetailViewModel { ItemDetail = ItemList?.FirstOrDefault(i => i.ItemCode == substrings[1]) };
			GoToPageCommand.Execute(substrings[0]);
		}
		catch (Exception ex) { Shell.Current.DisplayAlert("Error:", ex.Message, "OK"); }
		finally
		{
			IsBusy = false;
		}
	}, (str) => IsNotBusy);
}
