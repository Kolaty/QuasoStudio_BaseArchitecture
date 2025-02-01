using UnityEngine;

namespace QuasoStudio.Services
{
    public class UIService : INeedLevelUpdate
    {
        #region Ui block reference
        public GameObject UiPauseBlock { get; private set; }
        #endregion
        public UIService() 
        {
            GameServices.Instance.LevelService.RegisterForLevelUpdate(this);
            Cursor.lockState = CursorLockMode.Confined;
        }

        public void UpdateLevelInformation()
        {
            switch (GameServices.Instance.LevelService.GetLevelName())
            {
                case "MainMenu":
                    ShowCursor();
                    GameServices.Instance.SpawnService.SpawnUiBlock(UiBlock.MainMenu);
                    break;
                case "DevRoom_Alexandre":
                    HideCursor(); // ???
                    UiPauseBlock = GameServices.Instance.SpawnService.SpawnUiBlock(UiBlock.Pause);
                    break;
            }
        }

        #region Methods UI BLOCK
        public void DisplayPauseBlock()
        {
            ShowCursor();
            UiPauseBlock.SetActive(true);
        }

        public void UndisplayPauseBlock()
        {
            HideCursor();
            UiPauseBlock.SetActive(false);
        }
        #endregion

        public void HideCursor()
        {
            Cursor.visible = false;
        }

        public void ShowCursor()
        {
            Cursor.visible = true;
        }
    }
}
