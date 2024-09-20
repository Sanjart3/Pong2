using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Call this method to load a scene by name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Call this method to load a scene by index
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}