using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsPopup : MonoBehaviour
{
    public GameObject settingsPanel; // Reference to the settings panel
    public Slider volumeSlider; // Reference to the volume slider
    public Button restartButton; // Reference to the restart button
    public Button menuButton; // Reference to the menu button
    public Button closeButton; // Reference to the close button

    void Start()
    {
        // Ensure the settings panel is initially hidden
        settingsPanel.SetActive(false);

        // Add listeners to the buttons
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartScene);
        }
        else
        {
            Debug.LogError("Restart button reference is missing!");
        }

        if (menuButton != null)
        {
            menuButton.onClick.AddListener(ReturnToMenu);
        }
        else
        {
            Debug.LogError("Menu button reference is missing!");
        }

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseSettings);
        }
        else
        {
            Debug.LogError("Close button reference is missing!");
        }

        // Initialize volume slider
        if (volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume;
            Debug.Log("Initial volume value: " + volumeSlider.value);
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }
        else
        {
            Debug.LogError("Volume slider reference is missing!");
        }
    }

    // Function to open the settings panel
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    // Function to close the settings panel
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    // Function to change the global volume
    void ChangeVolume(float value)
    {
        Debug.Log("Volume changed to: " + value);
        AudioListener.volume = value;
    }

    // Function to restart the current scene
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Function to return to the menu
    void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu"); // Make sure to replace "Menu" with the actual name of your menu scene
    }
}
