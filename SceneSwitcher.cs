using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneSwitcher : MonoBehaviour
{
    public Object sceneToLoad;

    private void OnValidate()
    {
#if UNITY_EDITOR
        if (sceneToLoad != null && !AssetDatabase.GetAssetPath(sceneToLoad).EndsWith(".unity"))
        {
            Debug.LogWarning("Assigned object is not a scene. Please assign a scene asset.");
            sceneToLoad = null;
        }
#endif
    }

    public void LoadScene()
    {
        if (sceneToLoad != null)
        {
            string scenePath = AssetDatabase.GetAssetPath(sceneToLoad);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("No scene assigned to load.");
        }
    }
}
