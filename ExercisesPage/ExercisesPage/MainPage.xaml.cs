using ExercisesPage.Views;
using Xamarin.Forms;

namespace ExercisesPage
{
    public partial class MainPage : Xamarin.Forms.Shell
    {
        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ExercisePage), typeof(ExercisePage));
            Routing.RegisterRoute(nameof(ExerciseDetailPage), typeof(ExerciseDetailPage));
        }
    }
}
