using ExercisesPage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExercisesPage.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExercisePage : ContentPage
	{
        ExerciseViewModel _viewmodel;

        public ExercisePage ()
		{
			InitializeComponent ();
            BindingContext = _viewmodel = new ExerciseViewModel();
        }
    }
}