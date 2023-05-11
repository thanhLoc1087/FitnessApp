using ExercisesPage.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExercisesPage
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        MuscleGroupEnum _selectedItem;
        ExerciseAPIService _service = new ExerciseAPIService();
        public List<Exercise> Exercises { get; set; }
        public MuscleGroupEnum SelectedItem { get=> _selectedItem; set => _selectedItem = value; }
        public List<MuscleGroupEnum> MuscleGroups { get; } = new List<MuscleGroupEnum>
        {
            MuscleGroupEnum.abdominals,
            MuscleGroupEnum.biceps,
            MuscleGroupEnum.calves,
            MuscleGroupEnum.chest,
            MuscleGroupEnum.forearms,
            MuscleGroupEnum.glutes,
            MuscleGroupEnum.hamstrings,
            MuscleGroupEnum.lats,
            MuscleGroupEnum.lower_back,
            MuscleGroupEnum.middle_back,
            MuscleGroupEnum.neck,
            MuscleGroupEnum.quadriceps,
            MuscleGroupEnum.traps,
            MuscleGroupEnum.tricep,
        };

        public async void GetExercises()
        {
            Exercises = await _service.GetExercisesByMuscleGroup("lats");
            OnPropertyChanged(nameof(Exercises));
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
