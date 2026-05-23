using UnityEngine;

public class EscapeGameManager : MonoBehaviour
{
    public static EscapeGameManager Instance { get; private set; }
    public string theMagnifiqueCode = "";
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        for (int i = 0; i < 3; i++)
        {
            theMagnifiqueCode += Random.Range(0, 10).ToString();
        }
    }
} 
