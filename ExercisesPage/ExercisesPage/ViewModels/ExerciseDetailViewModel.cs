using ExercisesPage.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace ExercisesPage.ViewModels
{
    [QueryProperty(nameof(Name), nameof(Name))]
    class ExerciseDetailViewModel : BaseViewModel
    {
        private string name;
        private string type;
        private string muscle;
        private string equipment;
        private string difficulty;
        private string instruction;
        private string videoPath;
        HtmlWebViewSource htmlWebViewSource;
        public HtmlWebViewSource HtmlWebViewSource
        {
            get => htmlWebViewSource;
            set => SetProperty(ref htmlWebViewSource, value);
        }

        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                LoadItemId(value);
            }
        }

        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }
        public string Muscle
        {
            get => muscle;
            set => SetProperty(ref muscle, value);
        }
        public string Equipment
        {
            get => equipment;
            set => SetProperty(ref equipment, value);
        }
        public string Difficulty
        {
            get => difficulty;
            set => SetProperty(ref difficulty, value);
        }
        public string Instructions
        {
            get => instruction;
            set => SetProperty(ref instruction, value);
        }
        public string VideoPath 
        { 
            get => videoPath;
            set
            {
                SetProperty(ref videoPath, value);
                //HtmlWebViewSource = new HtmlWebViewSource { 
                //    Html = @"<html><body><iframe width=""100%"" height=""100%"" src=""https://www.youtube.com/embed/AVN-wjJxOSc"" frameborder=""0"" allowfullscreen></iframe></body></html>"
                //};
                //HtmlWebViewSource.SetBinding(HtmlWebViewSource.HtmlProperty, "HTMLDesc");
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await MusclesViewModel.DataSource.GetItemAsync(itemId);
                Type = item.Type;
                Muscle = item.Muscle;
                Equipment = item.Equipment;
                Difficulty = item.Difficulty;
                Instructions = item.Instructions;
                VideoPath = "https://youtu.be/gSRvFyzg8To";
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Exercise");
            }
        }
    }
}
