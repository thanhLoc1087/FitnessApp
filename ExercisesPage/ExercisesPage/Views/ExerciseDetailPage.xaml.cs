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
	public partial class ExerciseDetailPage : ContentPage
	{
        ExerciseDetailViewModel _viewmodel;
        public ExerciseDetailPage ()
		{
			InitializeComponent ();
            BindingContext = _viewmodel = new ExerciseDetailViewModel();
        }
    }
}