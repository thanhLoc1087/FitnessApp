using ExercisesPage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExercisesPage.Services
{
    internal class ExerciseAPIService
    {
        private readonly HttpClient _client;

        public ExerciseAPIService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.api-ninjas.com/")
            };
            _client.DefaultRequestHeaders.Add("X-Api-Key", "hAAb80fMaEfVeHJzefrGew==mtANz9qbscXtURDo");
        }

        public async Task<List<Exercise>> GetExercisesByMuscleGroup(string muscleGroup)
        {
            HttpResponseMessage response = await _client.GetAsync($"v1/exercises?muscle={muscleGroup}");

            List<Exercise> exercises;

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                exercises = JsonConvert.DeserializeObject<List<Exercise>>(responseContent);
                return exercises;
            }
            else
            {
                // Handle the error
                throw new Exception($"Error fetching exercise with muscle {muscleGroup}: {response.ReasonPhrase}");
            }
        }

        public List<Exercise> ReadJsonFile()
        {
            string jsonString;
            string jsonFileName = "Configs.exercises.json";
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Debug.WriteLine("Made it to 1");

            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                Debug.WriteLine("Made it to 2");

                jsonString = reader.ReadToEnd();
            }
            List<Exercise> exercises = JsonConvert.DeserializeObject<List<Exercise>>(jsonString);
            Debug.WriteLine("Made it to 3");

            return exercises;
        }
    }
}
