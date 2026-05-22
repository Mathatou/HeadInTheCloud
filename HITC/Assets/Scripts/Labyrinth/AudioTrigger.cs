using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private AudioSource mAS;
    [SerializeField] private AudioClip mClip;
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")))
        {
            Debug.Log("?????");
            if (mAS.isPlaying)
            {
                mAS.Stop();
            }
            else
            {
                mAS.Play();
            }
        }
    }
    private void Start()
    {
        mAS = GetComponent<AudioSource>();
    }
}
