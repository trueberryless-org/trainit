namespace View.Services;

public class DateManager
{
    private readonly EventProvider _eventProvider;

    public DateManager(EventProvider eventProvider)
    {
        _eventProvider = eventProvider;
        SelectedDate = DateTime.Today;
    }
    
    private DateTime? _selectedDate;
    public DateTime? SelectedDate
    {
        get => _selectedDate;
        set
        {
            _selectedDate = value;
            
            // raise event
            _eventProvider.OnSelectedDateChanged();
        }
    }

    public bool MaxDateReached => SelectedDate == DateTime.Today;
    
    public MudDatePicker? DatePicker { get; set; }

    public void PrevDate()
    {
        SelectedDate = SelectedDate?.AddDays(-1);
    }

    public void NextDate()
    {
        SelectedDate = SelectedDate?.AddDays(1);
    }
    
    public async Task DatePickerToday()
    {
        await DatePicker!.GoToDate(DateTime.Today);
        DatePicker.Close();
    }
}