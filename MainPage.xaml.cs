using StudyClasses;

namespace MD3
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private readonly AppDbContext _context;
        public MainPage(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
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
