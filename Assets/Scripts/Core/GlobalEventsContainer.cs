using System;
using Systems.FirebaseSystem;

namespace Core
{
    public static class GlobalEventsContainer
    {
        public static Action<AnimalWebData> OnAnimalDataChanged { get; set; }
    }
}