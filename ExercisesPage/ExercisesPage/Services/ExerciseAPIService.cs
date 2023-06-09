﻿using ExercisesPage.Models;
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
        public List<Exercise> ReadJsonFile()
        {
            string jsonString;
            string jsonFileName = "Configs.exercises.json";
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Debug.WriteLine("Made it to 1");

            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }
            List<Exercise> exercises = JsonConvert.DeserializeObject<List<Exercise>>(jsonString);

            return exercises;
        }
    }
}
