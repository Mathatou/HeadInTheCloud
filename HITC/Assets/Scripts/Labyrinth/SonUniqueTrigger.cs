using UnityEngine;

public class SonUniqueTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip sonAJouer;
    private AudioSource source;
    private bool aDejaJouer = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!aDejaJouer && (other.CompareTag("MainCamera") || other.CompareTag("Player")))
        {
            aDejaJouer = true; // Verrouillage immédiat

            if (sonAJouer != null && source != null)
            {
                source.PlayOneShot(sonAJouer);
                Debug.Log("Son unique lancé !");

                // Nettoyage : l'objet se détruit tout seul après la fin du son
                Destroy(gameObject, sonAJouer.length);
            }
        }
    }
}