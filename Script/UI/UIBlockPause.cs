using UnityEngine;
using UnityEngine.UI;
using QuasoStudio.Services;
using QuasoStudio.Input;
using QuasoStudio.Player;

public class UIBlockPause : MonoBehaviour
{
    [SerializeField, Tooltip("resume button of main menu required.")] private Button resumeButton;
    [SerializeField, Tooltip("Option button of main menu required.")] private Button optionButton;
    [SerializeField, Tooltip("Return main menu button of main menu required.")] private Button returnMainMenuButton;
    [SerializeField, Tooltip("InputReader needed.")] private InputReader inputReader;
    public bool IsVisible { get; private set; } = false;
    public bool CanPause { get; private set; } = true;
    
    private void Start()
    {
        gameObject.SetActive(false);
        inputReader.PauseEvent += TogglePause;
    }

    private void OnEnable()
    {
        resumeButton.onClick.AddListener(TogglePause);
        optionButton.onClick.AddListener(() => Debug.Log("Option button pressed."));
        returnMainMenuButton.onClick.AddListener(GameServices.Instance.DEBUG_LoadMainMenu);
    }

    private void OnDisable()
    {
        resumeButton.onClick.RemoveAllListeners();
        optionButton.onClick.RemoveAllListeners();
        returnMainMenuButton.onClick.RemoveAllListeners();
    }

    private void OnDestroy()
    {
        inputReader.PauseEvent -= TogglePause;
        if (GameServices.Instance.TimeService.IsTimePaused)
            GameServices.Instance.TimeService.ChangeGameTime();
    }

    public void TogglePause()
    {
        if (!CanPause) return;
        if (IsVisible)
            UnshowPause();
        else
            ShowPause();
    }

    private void ShowPause()
    {
        if (IsVisible)
        {
            Debug.LogError("Uiblock pause allready visible.");
            return;
        }
        GameServices.Instance.TimeService.ChangeGameTime(); // merf
        gameObject.SetActive(true);
        IsVisible = true;
        GameServices.Instance.UIService.ShowCursor();
        GameObject.Find("Gameplay/Actors/Player").GetComponent<Player>().Look.DeactivateLookInput();
    }

    private void UnshowPause()
    {
        if (!IsVisible)
        {
            Debug.LogError("uiblock pause allready unvisible");
            return;
        }
        GameServices.Instance.TimeService.ChangeGameTime(); // merf
        GameObject.Find("Gameplay/Actors/Player").GetComponent<Player>().Look.ActivateLookInput();
        gameObject.SetActive(false);
        IsVisible = false;
        GameServices.Instance.UIService.HideCursor();
    }
}
