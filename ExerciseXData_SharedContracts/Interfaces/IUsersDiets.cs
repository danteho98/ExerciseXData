﻿namespace ExerciseXData_SharedContracts.Interfaces
{
    public class IUsersDiets
    {
        public int UserId { get; set; }
        public int DietId { get; set; }
        public string DietName { get; set; }
        public string DietDetails { get; set; }
    }
}