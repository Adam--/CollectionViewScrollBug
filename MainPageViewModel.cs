namespace CollectionViewScrollBug;

public class MainPageViewModel
{
    private System.Threading.Timer _timer;
    private IDispatcherTimer _dispatcherTimer;

    public List<ItemViewModel> Items { get; }

    public MainPageViewModel()
    {
        Items = [];

        for (var i = 0; i < 16; i++)
        {
            Items.Add(new ItemViewModel());
        }

        // UseSystemThreadingTimer();
        UseDispatcherTimer();
    }

    private void UseSystemThreadingTimer()
    {
        _timer = new System.Threading.Timer(
            callback: _ => UpdateItems(),
            state: null,
            dueTime: TimeSpan.Zero,
            period: TimeSpan.FromSeconds(1));
    }

    private void UseDispatcherTimer()
    {
        _dispatcherTimer = Application.Current.Dispatcher.CreateTimer();
        _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        _dispatcherTimer.Tick += (_, _) => UpdateItems();
        _dispatcherTimer.Start();
    }

    private void UpdateItems()
    {
        foreach (var item in Items)
        {
            item.Update();
        }
    }
}