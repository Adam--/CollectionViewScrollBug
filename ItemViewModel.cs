namespace CollectionViewScrollBug;

using System.ComponentModel;
using System.Runtime.CompilerServices;

public class ItemViewModel : INotifyPropertyChanged
{
    private readonly Random _random = new();
    private string _value;

    private static int _instanceCount;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Name { get; } = _instanceCount++.ToString();

    public string Value
    {
        get => _value;
        private set
        {
            if (_value != value)
            {
                _value = value;
                OnPropertyChanged();
            }
        }
    }

    public void Update()
    {
        var randomValue = _random.NextDouble();
        Value = randomValue.ToString();
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}