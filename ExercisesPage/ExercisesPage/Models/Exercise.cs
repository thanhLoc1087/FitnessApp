using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesPage.Models
{
    internal class Exercise
    {
        private String _name;
        public String Name { set => _name = value; get => _name; }
        private String _type;
        public String Type { set => _type = value; get => _type; }
        private String _muscle;
        public String Muscle { set => _muscle = value; get => _muscle; }
        private String _equipment;
        public String Equipment { set => _equipment = value; get => _equipment; }
        private String _difficulty;
        public String Difficulty { set => _difficulty = value; get => _difficulty; }
        private String _instructions;
        public String Instructions { set => _instructions = value; get => _instructions; }
        public Exercise(string name, string type, string muscle, string equipment, string difficulty, string instructions)
        {
            Name = name;
            Type = type;
            Muscle = muscle;
            Equipment = equipment;
            Difficulty = difficulty;
            Instructions = instructions;
        }
    }
}
