using UnityEngine;

public class BreakWindow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Debug.Log("Window broken!");
            // Add your logic here to handle the window breaking, such as playing a sound, spawning particles, etc.
            Destroy(gameObject); // This will destroy the window object
        }
    }
}
