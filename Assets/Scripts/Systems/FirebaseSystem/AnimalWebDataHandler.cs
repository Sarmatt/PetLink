using System;
using Core;
using Firebase.Database;
using Firebase.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Systems.FirebaseSystem
{
    public class AnimalWebDataHandler : MonoBehaviour
    {
        [SerializeField] private AnimalWebData _animalData;

        private void OnEnable()
            => GlobalEventsContainer.OnAnimalDataChanged += SendAnimalData;

        private void OnDisable()
            => GlobalEventsContainer.OnAnimalDataChanged -= SendAnimalData;

        private void SendAnimalData(AnimalWebData animalData)
        {
            _animalData = animalData;
            var json = JsonUtility.ToJson(animalData);
            FirebaseDatabase.DefaultInstance.RootReference.Child("animals").Child("animal_001")
                .SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
                {
                    if (task.IsCompleted)
                    {
                        Debug.Log("Data successfully saved to firebase!");
                    }
                    else
                    {
                        Debug.LogError("Error loading: " + task.Exception);
                    }
                });
        }

        [Button]
        private void LoadAnimalData()
        {
            FirebaseDatabase.DefaultInstance.RootReference.Child("animals").Child("animal_001").GetValueAsync()
                .ContinueWithOnMainThread(task =>
                {
                    if (task.IsCompleted)
                    {
                        var json = task.Result.GetRawJsonValue();
                        var animalData = JsonUtility.FromJson<AnimalWebData>(json);
                        _animalData = animalData;
                    }
                    else
                    {
                        Debug.LogError("Error loading: " + task.Exception);
                    }
                });
        }
    }
}