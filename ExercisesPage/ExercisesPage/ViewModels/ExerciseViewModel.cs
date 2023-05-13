using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExercisesPage.ViewModels
{
    [QueryProperty(nameof(MuscleName), nameof(MuscleName))]
    class ExerciseViewModel
    {
        public string _muscleName;
        public string MuscleName
        {
            get => _muscleName; 
            set
            {
                _muscleName = value;
            }
        }
    }
}
