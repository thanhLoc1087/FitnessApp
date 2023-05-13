using ExercisesPage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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
    }
}
