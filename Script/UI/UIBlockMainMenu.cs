using UnityEngine;
using UnityEngine.UI;
using R_D_2.Script.Services;

public class UIBlockMainMenu : MonoBehaviour
{
    [SerializeField, Tooltip("Play button of main menu required.")] private Button playButton;
    [SerializeField, Tooltip("Option button of main menu required.")] private Button optionButton;
    [SerializeField, Tooltip("Quit button of main menu required.")] private Button quitButton;

    private void OnEnable()
    {
        playButton.onClick.AddListener(GameServices.Instance.DEBUG_LoadDevRoom);
        optionButton.onClick.AddListener(() => Debug.Log("Option button pressed."));
        quitButton.onClick.AddListener(GameServices.Instance.DEBUG_QuitGame);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveAllListeners();
        optionButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
    }
}
