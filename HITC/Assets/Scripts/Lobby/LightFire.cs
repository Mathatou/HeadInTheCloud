using UnityEngine;

public class LightFire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    private ParticleSystem ps;
    private void Start()
    {
        if(fire.activeInHierarchy) fire.SetActive(false);
        ps = GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Lighter"))
        {
            fire.SetActive(true);
            ps.Play();
        }
        else
        {
            Debug.LogWarning("Collided with " + other.name);
            Debug.LogWarning("Collided with tag : " + other.tag);
        }
    }
}
