﻿using System;
using UnityEngine;

namespace PyramidGamesTest
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public static event Action OnGameStarted;
        public static event Action<float> OnPlaytimeChanged;
        public static event Action OnGameFinished;

        [Header("To Link")]
        public RoomGeneration.RoomGenerator roomGenerator;
        public UI.UIManager uiManager;

        [Header("States")]        
        public bool isCounting;
        public float currentPlaytime;

        private void Awake()
        {
            instance = Singleton.MakeInstance(this, instance);    
        }

        public void RestartGame()
        {
            currentPlaytime = 0;
            OnGameStarted?.Invoke();
            isCounting = true;
            
        }


        private void Update()
        {
            if (isCounting)
            {
                currentPlaytime += Time.deltaTime;
                OnPlaytimeChanged?.Invoke(currentPlaytime);
            }
        }

        public void Finish()
        {
            isCounting = false;
            OnGameFinished?.Invoke();
        }


        private void OnApplicationPause(bool pause)
        {
            if(pause)
                SaveGame();
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }

        private void SaveGame()
        {
        }
    }


}



