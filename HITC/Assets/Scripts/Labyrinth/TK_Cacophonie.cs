using UnityEngine;

public class TK_Cacophonie : MonoBehaviour
{
    // On crée une liste (un tableau) pour y glisser tous les hauts-parleurs cachés
    [SerializeField] private AudioSource[] tousLesTK78;

    private bool aExplose = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!aExplose && (other.CompareTag("MainCamera") || other.CompareTag("Player")))
        {
            aExplose = true; // Sécurité pour pas que ça se relance

            // Cette ligne magique dit à TOUS les AudioSources de la liste de hurler en même temps
            foreach (AudioSource tk in tousLesTK78)
            {
                if (tk != null)
                {
                    tk.Play();
                }
            }

            Debug.Log("ATTENTION LES OREILLES !");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera") || other.CompareTag("Player"))
        {
            foreach (AudioSource tk in tousLesTK78)
            {
                if (tk != null)
                {
                    tk.Pause();
                }
            }
            Debug.Log("Sortie de la zone");
        }
    }
}