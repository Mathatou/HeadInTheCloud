using TMPro;
using UnityEngine;

public class GazeNextText : MyGazeInteractor
{
    [SerializeField] private GameObject UItoHide;
    
    private int currentTextIndex = 0;
    private TextMeshProUGUI textZone;
    private string[] textsToCycle = {
    "Bienvenue dans Color Shooter !",
    "Tirez sur les cibles de la couleur adéquate !",
    "Derrière vous se trouve deux pistolets de couleur.",
    "Tirez le levier à côté pour lancer le jeu !"};
    protected override void handleGaze(Transform GameObjectTransform)
    {
        Debug.Log("NEXT TEXT");
        if (GameObjectTransform.name.Equals("Tuto_Canvas"))
        {
            Debug.Log("Gaze detected on Tuto_Canvas");
            if (textZone == null)
            {
                textZone = GameObjectTransform.GetComponentInChildren<TextMeshProUGUI>();
            }
            currentTextIndex = (currentTextIndex + 1) % textsToCycle.Length;
            textZone.text = textsToCycle[currentTextIndex];
            if (UItoHide.activeInHierarchy)
            {
                UItoHide.SetActive(false);
            }
        }
        Debug.Log("Gaze not detected Tuto_Canvas");
    }
}
