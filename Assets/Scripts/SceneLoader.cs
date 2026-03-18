using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene Settings")]
    [Tooltip("Type the EXACT name of your AR scene here")]
    public string targetSceneName = "CultureRevive";

    private bool isNavigating = false;

    void Update()
    {
        // Keyboard support: Press Enter to load AR scene
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            LoadARScene();
        }
    }

    // Function to load the AR scene
    public void LoadARScene()
    {
        if (isNavigating) return;

        isNavigating = true;
        Debug.Log("Loading Scene: " + targetSceneName);
        SceneManager.LoadScene(targetSceneName);
    }
}
