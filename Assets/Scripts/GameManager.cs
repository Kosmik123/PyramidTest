using System;
using UnityEngine;

namespace PyramidGamesTest
{
    public class GameManager : MonoBehaviour
    {
        private string savepath;

        public static GameManager instance;

        public static event Action OnApplicationLoaded;
        public static event Action OnGameStarted;
        public static event Action<float> OnPlaytimeChanged;
        public static event Action OnGameFinished;

        [Header("To Link")]
        public RoomGeneration.RoomGenerator roomGenerator;
        public UI.UIManager uiManager;

        [Header("States")]        
        public bool isCounting;

        public float currentPlaytime;
        public float bestPlaytime;
        public float previousBestTime;

        public bool hasKey;
        
        private string savename => $"{savepath}/save1.sav";

        private void Awake()
        {
            savepath = Application.dataPath;
            instance = Singleton.MakeInstance(this, instance);    
        }

        private void Start()
        {
            bestPlaytime = previousBestTime = 5999.999f;
            LoadGame();

            OnApplicationLoaded?.Invoke();
        }

        public void RestartGame()
        {
            hasKey = false;
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

        public void ObtainKey()
        {
            hasKey = true;
        }

        public void Finish()
        {
            isCounting = false;
            previousBestTime = bestPlaytime;
            if (currentPlaytime < bestPlaytime)
                bestPlaytime = currentPlaytime;
            
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
            var dataToSave = new GameData();
            dataToSave.bestPlaytime = bestPlaytime;
            FileManager.WriteSaveFile(dataToSave, savename);
        }

        private void LoadGame()
        {
            var loadedData = FileManager.ReadSaveFile<GameData>(savename);
            if (loadedData != null)
                bestPlaytime = loadedData.bestPlaytime;
        }
    }

    [System.Serializable]
    public class GameData
    {
        public float bestPlaytime;
    }

}




