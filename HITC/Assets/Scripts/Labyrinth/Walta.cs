using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    // On crée une référence pour trouver le GameManager
    [SerializeField] private Cle gameManager;

    void Start()
    {
        // On cherche l'objet GameManager dans la scène au lancement
        gameManager = Object.FindFirstObjectByType<Cle>();
    }

    void Update()
    {
        // Ton animation de flottement actuelle
        transform.Translate(Vector3.up * Mathf.Sin(Time.time) / 10000);
    }

    // Détection du contact
    private void OnTriggerEnter(Collider other)
    {
        // On vérifie si c'est le joueur qui touche (par son Tag)
        if (other.CompareTag("Main"))
        {
            // On prévient le manager
            gameManager.AjouterSphere();

            // On détruit la sphère
            Destroy(gameObject);
        }
    }
}