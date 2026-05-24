using UnityEngine;

public class PnjRunningActivation : MonoBehaviour
{
    [SerializeField] private AudioSource pnjAudioSource;
    [SerializeField] private AudioClip son;
    [SerializeField] private GameObject pnjParentComplet; // Le dossier parent qui contient TOUT le PNJ

    [Header("Paramètres de Déplacement")]
    [SerializeField] private float vitesseDeplacement = 1.5f; // Vitesse à laquelle il avance

    private bool aDejaParle = false;
    private bool doitAvancer = false; // Permet de déclencher le mouvement dans l'Update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") || other.CompareTag("Player"))
        {
            if (!aDejaParle && pnjAudioSource != null && son != null)
            {
                aDejaParle = true;

                // 1. On joue le son
                pnjAudioSource.PlayOneShot(son);

                // 2. On donne l'ordre d'avancer
                doitAvancer = true;

                // 3. On programme la disparition totale à la fin exacte du son
                Invoke("SupprimerPnj", son.length);

                Debug.Log("Le PNJ parle et avance. Disparition dans " + son.length + " secondes.");
            }
        }
    }

    private void Update()
    {
        // Si le PNJ a reçu l'ordre d'avancer, on le déplace vers SON avant (Z local)
        if (doitAvancer && pnjParentComplet != null)
        {
            // Vector3.forward correspond à l'axe bleu (Z) du PNJ. Il marchera droit devant lui.
            pnjParentComplet.transform.Translate(Vector3.forward * vitesseDeplacement * Time.deltaTime);
        }
    }

    private void SupprimerPnj()
    {
        if (pnjParentComplet != null)
        {
            doitAvancer = false; // On stoppe le mouvement par sécurité
            pnjParentComplet.SetActive(false);
            Debug.Log("Pouff ! Tout le groupe PNJ a disparu de la scène.");
        }
    }
}