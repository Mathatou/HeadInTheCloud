using UnityEngine;

public class LightFire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    private ParticleSystem fire_ps;
    private void Start()
    {
        fire_ps = fire.GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Lighter")) fire_ps.Play();
        
    }
}
