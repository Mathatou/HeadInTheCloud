using UnityEngine;

public class Lab_Porte : MonoBehaviour
{
    private Animation mAnim;
    private void Awake()
    {
        mAnim = GetComponent<Animation>();
    }
    public void ouvrirporte()
    {
        Debug.Log("Je joue l animation magnifique");
        mAnim.Play();
        //Lalalalala
    }
}
