using UnityEngine;

public class LightFire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    private ParticleSystem fire_ps;
    [SerializeField] private ParticleSystem fireOfLighter;
    private void Start()
    {
        fire_ps = fire.GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Lighter") && fireOfLighter.isPlaying) fire_ps.Play();
        
    }
}
