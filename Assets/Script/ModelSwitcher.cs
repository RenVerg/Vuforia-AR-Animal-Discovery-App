using UnityEngine;
using UnityEngine.UI;

public class ModelSwitcher : MonoBehaviour
{
    public GameObject[] models;          // Array of models to display
    public string[] descriptions;        // Array of descriptions for each model
    public AudioClip[] audioClips;       // Array of audio clips for each model
    public Text descriptionText;         // UI Text element to display descriptions
    public Button nextButton;            // Button to show the next model
    public Button previousButton;        // Button to show the previous model
    public Button descriptionButton;     // Button to show the description of the current model
    public Button playAudioButton;       // Button to play the audio of the current model

    private int currentIndex = 0;        // Index of the currently displayed model
    private AudioSource audioSource;     // Audio source for playing clips

    void Start()
    {
        // Ensure models are assigned
        if (models == null || models.Length == 0)
        {
            Debug.LogError("No models assigned to the ModelSwitcher script! Please assign models in the Inspector.");
            return;
        }

        // Ensure descriptions match the number of models
        if (descriptions == null || descriptions.Length != models.Length)
        {
            Debug.LogError("Descriptions array must have the same length as models array.");
            return;
        }

        // Ensure audio clips match the number of models
        if (audioClips == null || audioClips.Length != models.Length)
        {
            Debug.LogError("Audio clips array must have the same length as models array.");
            return;
        }

        // Add an AudioSource component if not already present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Initialize models and UI
        UpdateModelVisibility();
        ClearDescription(); // Clear description at the start

        // Assign button click listeners
        if (nextButton != null) nextButton.onClick.AddListener(ShowNextModel);
        if (previousButton != null) previousButton.onClick.AddListener(ShowPreviousModel);
        if (descriptionButton != null) descriptionButton.onClick.AddListener(ShowDescription);
        if (playAudioButton != null) playAudioButton.onClick.AddListener(PlayCurrentAudio);
    }

    void UpdateModelVisibility()
    {
        // Activate only the current model, deactivate others
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(i == currentIndex);
        }
    }

    void ClearDescription()
    {
        if (descriptionText != null)
        {
            descriptionText.text = ""; // Clear the text
        }
    }

    void ShowNextModel()
    {
        // Increment index and wrap around if needed
        currentIndex = (currentIndex + 1) % models.Length;
        UpdateModelVisibility();
        ClearDescription(); // Clear description when switching models
        StopAudio();         // Stop audio when switching models
    }

    void ShowPreviousModel()
    {
        // Decrement index and wrap around if needed
        currentIndex = (currentIndex - 1 + models.Length) % models.Length;
        UpdateModelVisibility();
        ClearDescription(); // Clear description when switching models
        StopAudio();         // Stop audio when switching models
    }

    void ShowDescription()
    {
        if (descriptionText != null && descriptions.Length > 0)
        {
            descriptionText.text = descriptions[currentIndex]; // Show the current model's description
        }
    }

    void PlayCurrentAudio()
    {
        if (audioClips[currentIndex] != null && audioSource != null)
        {
            audioSource.clip = audioClips[currentIndex];
            audioSource.Play();
        }
    }

    void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
