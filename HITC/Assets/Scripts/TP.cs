using UnityEngine;
using UnityEngine.SceneManagement;

public class TP : MonoBehaviour
{
    [Tooltip("The exact name of the scene to load. Make sure it's added to the Build Settings!")]
    [SerializeField] private string sceneName;
    [SerializeField] 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!string.IsNullOrEmpty(sceneName))
            {
                Debug.Log("Teleporting to scene: " + sceneName);
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogError("Scene name is not set in the inspector!");
            }
        }
    }
}
