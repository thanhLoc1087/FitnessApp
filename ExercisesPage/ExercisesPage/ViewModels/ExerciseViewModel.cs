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
        public string _muscle;
        ExerciseAPIService _service;
        public Command<Exercise> ItemTapped { get; }

        public ExerciseViewModel() 
        {
            _service = new ExerciseAPIService();
            ItemTapped = new Command<Exercise>(OnItemSelected);
        }

        public string Muscle
        {
            get => _muscle; 
            set
            {
                value = value.ToLower();
                switch(value)
                {
                    case "abdominals":
                        GetExercisesByMuscle(AbdominalsExercises, "abdominals");
                        break;
                    case "biceps":
                        GetExercisesByMuscle(BicepsExercises, "biceps");
                        break;
                    case "calves":
                        GetExercisesByMuscle(CalvesExercises, "calves");
                        break;
                    case "chest":
                        GetExercisesByMuscle(ChestExercises, "chest");
                        break;
                    case "forearms":
                        GetExercisesByMuscle(ForearmsExercises, "forearms");
                        break;
                    case "glutes":
                        GetExercisesByMuscle(GlutesExercises, "glutes");
                        break;
                    case "hamstrings":
                        GetExercisesByMuscle(HamstringsExercises, "hamstrings");
                        break;
                    case "lats":
                        GetExercisesByMuscle(LatsExercises, "lats");
                        break;
                    case "lower back":
                        GetExercisesByMuscle(LowerBackExercises, "lower_back");
                        break;
                    case "middle back":
                        GetExercisesByMuscle(MiddleBackExercises, "middle_back");
                        break;
                    case "neck":
                        GetExercisesByMuscle(NeckExercises, "neck");
                        break;
                    case "quadriceps":
                        GetExercisesByMuscle(QuadricepsExercises, "quadriceps");
                        break;
                    case "traps":
                        GetExercisesByMuscle(TrapsExercises, "traps");
                        break;
                    case "tricep":
                        GetExercisesByMuscle(TricepExercises, "tricep");
                        break;
                }
                SetProperty(ref _muscle, value);
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

        async void GetExercisesByMuscle(List<Exercise> exercises, string muscle)
        {
            if (exercises != null)
            {
                return;
            } 
            else
            {
                exercises = await GetExercises(muscle);
                CacheExercises(exercises);
                MuscleExercises = exercises;
            }
        }
        public async Task<List<Exercise>> GetExercises(string muscle)
        {
            return await _service.GetExercisesByMuscleGroup(muscle);
        }
        private async void OnItemSelected(Exercise item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ExerciseDetailPage)}?{nameof(ExerciseDetailViewModel.Name)}={item.Name}");
        }

        void CacheExercises(List<Exercise> exercises)
        {
            MusclesViewModel.DataSource.exercises.AddRange(exercises);
        }
    }
}
