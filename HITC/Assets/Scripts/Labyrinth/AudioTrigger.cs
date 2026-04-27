using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private AudioSource mAS;
    [SerializeField] private AudioClip mClip;
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")))
        {
            mAS.PlayOneShot(mClip);
        }
    }
    private void Start()
    {
        mAS = GetComponent<AudioSource>();
    }
}
