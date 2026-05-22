using UnityEngine;

public class Lab_Porte : MonoBehaviour
{
    // On crée une case pour y glisser l'objet qui possède le composant Animation
    [SerializeField] private Animation animationPorte;

    [SerializeField] private AudioClip sonOuverture; // Le fichier audio du grincement (.mp3/.wav)
    private AudioSource hautParleur;
    public void ouvrirporte()
    {
        if (animationPorte != null)
        {
            animationPorte.Play("lapuerta");
            Debug.Log("Animation de la porte lancée avec succès !");
        }
        if (hautParleur != null && sonOuverture != null)
        {
            hautParleur.PlayOneShot(sonOuverture);
            Debug.Log("Son d'ouverture lancé !");
        }
        else if (hautParleur == null)
        {
            Debug.LogError("Oups ! Tu as oublié d'ajouter le composant AudioSource sur cet objet !");
        }
    }
}
