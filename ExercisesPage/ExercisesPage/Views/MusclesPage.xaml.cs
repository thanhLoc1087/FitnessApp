﻿using ExercisesPage.ViewModels;
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
	public partial class MusclesPage : ContentPage
	{
		MusclesViewModel _viewmodel;
		public MusclesPage()
		{
			InitializeComponent ();

			BindingContext = _viewmodel = new MusclesViewModel();
		}
	}
}