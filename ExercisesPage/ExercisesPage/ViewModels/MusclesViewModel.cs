using ExercisesPage.Models;
using ExercisesPage.Services;
using ExercisesPage.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ExercisesPage.ViewModels
{
    internal class MusclesViewModel : BaseViewModel
    {
        public Command<MuscleGroup> ItemTapped { get; }
        private List<Exercise> _exercises;
        public List<Exercise> Exercises
        {
            get => _exercises; set
            {
                SetProperty(ref _exercises, value);
            }
        }
        static public DataSource DataSource { get; set; }

        public MusclesViewModel()
        {
            _exercises = new List<Exercise>();
            ItemTapped = new Command<MuscleGroup>(OnItemSelected);
            DataSource = new DataSource();
        }

        private async void OnItemSelected(MuscleGroup item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ExercisePage)}");
            await Shell.Current.GoToAsync($"{nameof(ExercisePage)}?{nameof(ExerciseViewModel.Muscle)}={item.Name}");
        }

        //public List<MuscleGroupEnum> MuscleGroups { get; } = new List<MuscleGroupEnum>
        //{
        //    MuscleGroupEnum.lats,
        //    MuscleGroupEnum.biceps,
        //};
        public List<MuscleGroup> MuscleGroups { get; } = new List<MuscleGroup>
        {
            new MuscleGroup("Abdominals", MuscleGroupEnum.abdominals),
            new MuscleGroup("Biceps", MuscleGroupEnum.biceps),
            new MuscleGroup("Calves", MuscleGroupEnum.calves),
            new MuscleGroup("Chest", MuscleGroupEnum.chest),
            new MuscleGroup("Forearms", MuscleGroupEnum.forearms),
            new MuscleGroup("Glutes", MuscleGroupEnum.glutes),
            new MuscleGroup("Hamstrings", MuscleGroupEnum.hamstrings),
            new MuscleGroup("Lats", MuscleGroupEnum.lats),
            new MuscleGroup("Lower Back", MuscleGroupEnum.lower_back),
            new MuscleGroup("Middle Back", MuscleGroupEnum.middle_back),
            new MuscleGroup("Neck", MuscleGroupEnum.neck),
            new MuscleGroup("Quadriceps", MuscleGroupEnum.quadriceps),
            new MuscleGroup("Traps", MuscleGroupEnum.traps),
            new MuscleGroup("Tricep", MuscleGroupEnum.tricep),
        };
    }
}
