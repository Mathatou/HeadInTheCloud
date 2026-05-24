using UnityEngine;

public class LightFire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private ParticleSystem fireOfLighter;
    private ParticleSystem fire_ps;
    private AudioSource mAS;
    private void Start()
    {
        fire_ps = fire.GetComponent<ParticleSystem>();
        mAS = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lighter") && fireOfLighter.isPlaying)
        {
            fire_ps.Play();
            mAS.PlayOneShot(mAS.clip);
        }
    }
}
