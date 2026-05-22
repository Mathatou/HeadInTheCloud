using UnityEngine;

public class Cle : MonoBehaviour
{
    public int spheresRecoltees = 0;
    [SerializeField] private GameObject cle;

    void Start()
    {
        if (cle != null)
        {
            cle.SetActive(false); 
        }
        else
        {
            Debug.LogError("Oups ! Tu as oublié de glisser l'objet Clé dans le script du GameManager !");
        }
    }

    public void AjouterSphere()
    {
        spheresRecoltees++;
        Debug.Log("Sphères : " + spheresRecoltees + "/4");

        if (spheresRecoltees >= 4)
        {
            ApparitionCle();
        }
    }

    void ApparitionCle()
    {
        if (cle != null) cle.SetActive(true);
        Debug.Log("La clé est apparue ! ");
    }
}