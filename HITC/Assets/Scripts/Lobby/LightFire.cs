using UnityEngine;

public class LightFire : MonoBehaviour
{
    [SerializeField] private GameObject fire;

    private void Start()
    {
        if(fire.activeInHierarchy) fire.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Lighter"))
        {
            if(!fire.activeInHierarchy)
            {
                fire.SetActive(true);
            }
        }
    }
}
