using UnityEngine;

namespace R_D_2.Script.Services
{
    public class SpawnService : INeedLevelUpdate
    {
        private Transform levelUiTransformPosition {  get; set; }

        #region UI
        private readonly GameObject UiBlockMainMenu = Resources.Load<GameObject>("Prefabs/UI/UIBlock/MainMenu");
        private readonly GameObject UiBlockPause = Resources.Load<GameObject>("Prefabs/UI/UIBlock/Pause");
        #endregion

        public SpawnService()
        {
            GameServices.Instance.LevelService.RegisterForLevelUpdate(this);
        }

        public void UpdateLevelInformation()
        {
            levelUiTransformPosition = GameObject.Find("@UI").gameObject.transform;
        }

        public GameObject SpawnUiBlock(UiBlock BlockToSpawn)
        {
            GameObject tempo;
            switch (BlockToSpawn)
            {
                case UiBlock.MainMenu:
                    tempo = GameObject.Instantiate(UiBlockMainMenu, levelUiTransformPosition).gameObject;
                    tempo.name = "MainMenu";
                    return tempo;
                case UiBlock.Pause:
                    tempo = GameObject.Instantiate(UiBlockPause, levelUiTransformPosition).gameObject;
                    tempo.name = "Pause";
                    return tempo;

            }
            Debug.LogError("Impossible");
            return null;
        }
    }

}

