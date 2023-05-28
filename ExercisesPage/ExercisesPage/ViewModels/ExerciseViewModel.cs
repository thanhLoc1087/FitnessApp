using ExercisesPage.Models;
using ExercisesPage.Services;
using ExercisesPage.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExercisesPage.ViewModels
{
    [QueryProperty(nameof(Muscle), nameof(Muscle))]
    class ExerciseViewModel : BaseViewModel
    {
        string _muscle;
        public Command<Exercise> ItemTapped { get; }

        public ExerciseViewModel() 
        {
            ItemTapped = new Command<Exercise>(OnItemSelected);
        }

        public string Muscle
        {
            get => _muscle; 
            set
            {
                Title = value.ToUpper();
                SetProperty(ref _muscle, value);
                GetExercisesByMuscle(Muscle);
            }
        }
        List<Exercise> _muscleExercises;
        public List<Exercise> MuscleExercises
        {
            get => _muscleExercises;
            set
            {
                SetProperty(ref _muscleExercises, value);
            }
        }
        List<Exercise> AbdominalsExercises;
        List<Exercise> BicepsExercises;
        List<Exercise> CalvesExercises;
        List<Exercise> ChestExercises;
        List<Exercise> ForearmsExercises;
        List<Exercise> GlutesExercises;
        List<Exercise> HamstringsExercises;
        List<Exercise> LatsExercises;
        List<Exercise> LowerBackExercises;
        List<Exercise> MiddleBackExercises;
        List<Exercise> NeckExercises;
        List<Exercise> QuadricepsExercises;
        List<Exercise> TrapsExercises;
        List<Exercise> TricepExercises;

        void GetExercisesByMuscle(string muscleGroup)
        {
           MuscleExercises = GetExercises(muscleGroup);
        }
        public List<Exercise> GetExercises(string muscleGroup)
        {
            Debug.WriteLine(muscleGroup);
            List<Exercise> exerciseList = new List<Exercise>();
            foreach(var exercise in MusclesViewModel.DataSource.exercises)
            {
                if (exercise.Muscle == muscleGroup)
                {
                    exerciseList.Add(exercise);
                }
            }
            return exerciseList;
        }
        private async void OnItemSelected(Exercise item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ExerciseDetailPage)}?{nameof(ExerciseDetailViewModel.Name)}={item.Name}");
        }
    }
}
