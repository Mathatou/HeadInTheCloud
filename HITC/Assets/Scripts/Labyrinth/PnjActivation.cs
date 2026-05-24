using UnityEngine;

public class PnjActivation : MonoBehaviour
{
    [SerializeField] private AudioSource pnjAudioSource;
    [SerializeField] private AudioClip son;
    [SerializeField] private GameObject pnjParentComplet; // Le dossier parent qui contient TOUT le PNJ

    private bool aDejaParle = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") || other.CompareTag("Player"))
        {
            if (!aDejaParle && pnjAudioSource != null && son != null)
            {
                aDejaParle = true; // Sécurité anti-spam directe

                // 1. On joue le son
                pnjAudioSource.PlayOneShot(son);

                // 2. On programme la disparition totale à la fin exacte du son
                Invoke("SupprimerPnj", son.length);

                Debug.Log("Le PNJ parle. Disparition de toute la hiérarchie dans " + son.length + " secondes.");
            }
        }
    }

    private void SupprimerPnj()
    {
        if (pnjParentComplet != null)
        {
            // Désactive le parent : tout le monde s'éteint (enfants, meshs, colliders, lumières...)
            pnjParentComplet.SetActive(false);
            Debug.Log("Pouff ! Tout le groupe PNJ a disparu de la scène.");
        }
    }
}