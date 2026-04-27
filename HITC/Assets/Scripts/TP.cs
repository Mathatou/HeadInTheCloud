using UnityEngine;
using UnityEngine.SceneManagement;

public class TP : MonoBehaviour
{
    [Tooltip("The exact name of the scene to load. Make sure it's added to the Build Settings!")]
    [SerializeField] private string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogWarning("Scene name is not set for TP script on " + gameObject.name);
            }
        }
        else
        {
            Debug.Log("Collided with non-player object: " + other.gameObject.name);
            Debug.Log("Collided with non-player tag: " + other.gameObject.tag);
        }
    }
}
