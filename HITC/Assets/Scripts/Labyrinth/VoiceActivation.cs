using UnityEngine;

public class VoiceActivation : MonoBehaviour
{
    [SerializeField] private AudioSource pnjAudioSource; // L'AudioSource sur le PNJ
    [SerializeField] private AudioClip voixExplication; // Le fichier audio .mp3/.wav

    private bool aDejaParle = false; // Pour éviter que le son se relance en boucle si le joueur avance/recule

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") || other.CompareTag("Player"))
        {
            if (!aDejaParle && pnjAudioSource != null && voixExplication != null)
            {
                // Si un ancien son tournait encore, on le stoppe pour éviter la superposition dégueu
                pnjAudioSource.Stop();

                pnjAudioSource.PlayOneShot(voixExplication);
                aDejaParle = true;
                Debug.Log("Le PNJ commence ses instructions.");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera") || other.CompareTag("Player"))
        {
            // On réinitialise la sécurité : le PNJ pourra reparler la prochaine fois !
            aDejaParle = false;
            Debug.Log("Le joueur est parti, le PNJ est prêt à répéter.");
        }
    }
}