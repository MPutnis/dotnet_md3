using Microsoft.Data.SqlClient;
using StudyClasses;
using System.Collections.ObjectModel;

namespace MD3
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        // Add a private field for the AppDbContext
        private readonly AppDbContext _appDbContext;
        // prepare a collection for teachers
        public ObservableCollection<Teacher> Teachers { get; set; }

        public MainPage(AppDbContext appDbContext)
        {
            InitializeComponent();

            // injcet the AppDbContext into the MainPage
            _appDbContext = appDbContext;

            // get the teachers from the database
            Teachers = new ObservableCollection<Teacher>(_appDbContext.Teachers.ToList());
            TeachersListView.ItemsSource = Teachers;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
