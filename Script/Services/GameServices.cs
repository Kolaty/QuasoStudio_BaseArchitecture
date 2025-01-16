using System.Collections.Generic;
using UnityEngine;

namespace R_D_2.Script.Services
{
    public class GameServices : MonoBehaviour, INeedLevelUpdate
    {
        public static GameServices Instance;
        public UpdateService UpdateService { get; private set; }
        public LevelService LevelService { get; private set; }
        public SpawnService SpawnService { get; private set; }
        public SoundService SoundService { get; private set; }
        public GameManager GameManager { get; private set; }
        public UIService UIService { get; private set; }
        public TimeService TimeService { get; private set; }
        public bool GameServicesInitialized { get; private set; }
        public List<FmodSoundDataScriptableObject> _allSoundOfTheGame; // Yup I know


        public void Awake()
        {
            if (InitializeSingleton())
                Debug.Log("GameServices initialized");
            else
            {
                Debug.Log("GameServices can't be singletoned destroy and stop for this game service");
                GameServicesInitialized = false;
                return;
            }
            AwakeAllService();
            GameServicesInitialized = true;
            LevelService.RegisterForLevelUpdate(this);
        }

        private bool InitializeSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                return true;
            }
            else
            {
                Destroy(gameObject);
                return false;
            }
        }

        private void AwakeAllService()
        {
            LevelService = new LevelService(); // Need to be first other script needed ref (spawn service)
            SpawnService = new SpawnService();
            UpdateService = new UpdateService();
            UIService = new UIService();
            GameManager = new GameManager();
            SoundService = new SoundService(_allSoundOfTheGame);
            TimeService = new TimeService();
        }
        
        public void Update()
        {
            UpdateService.Update();
        }

        public void FixedUpdate()
        {
            UpdateService.FixedUpdate();
        }

        public void LateUpdate()
        {
            UpdateService.LateUpdate();
        }

        public void OnApplicationQuit()
        {
            UpdateService.UnsubscribeAll();
        }

        public void UpdateLevelInformation()
        {
            SoundService.PlayAmbiance("Ambience_1");
        }

        #region Debug
        public void DEBUG_LoadDevRoom()
        {
            LevelService.LoadScene("DevRoom_Alexandre");
        }

        public void DEBUG_LoadMainMenu()
        {
            LevelService.LoadScene("MainMenu");
        }

        public void DEBUG_QuitGame()
        {
            Application.Quit();
        }

        #endregion
    }
}