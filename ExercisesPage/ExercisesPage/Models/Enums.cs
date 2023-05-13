namespace ExercisesPage.Models
{
    enum MuscleGroupEnum
    {
        abdominals,
        biceps,
        calves,
        chest,
        forearms,
        glutes,
        hamstrings,
        lats,
        lower_back,
        middle_back,
        neck,
        quadriceps,
        traps,
        tricep,
    }
    class MuscleGroup
    {
        public MuscleGroup(string Name, MuscleGroupEnum Enum) 
        {
            this.Name = Name;
            this.Enum = Enum;
        }
        public string Name { get; set; }
        public MuscleGroupEnum Enum { get; set; }
    }
}
