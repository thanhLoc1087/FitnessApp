﻿using ExercisesPage.ViewModels;
using ExercisesPage.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExercisesPage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
