using Xamarin.Forms;

namespace ExercisesPage
{
    public partial class MainPage : ContentPage
    {
        readonly MainViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MainViewModel();
            _viewModel.GetExercises();
        }
    }
}
