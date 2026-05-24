using TMPro;
using UnityEngine;

public class GazeNextText : MyGazeInteractor
{
    [SerializeField] private GameObject UItoHide;
    
    private int currentTextIndex = 0;
    private TextMeshProUGUI textZone;
    private string[] textsToCycle = {
    "Bienvenue dans Color Shooter !",
    "Derriere vous se trouve deux pistolets de couleur.",
    "Entrez votre nom, appuyez sur le bouton valider, et pressez le bouton rouge avec votre main !",
    "Puis, tirez sur les cibles de la couleur adequate qui seront sur votre gauche !"};
    protected override void handleGaze(Transform GameObjectTransform)
    {
        if (GameObjectTransform.name.Equals("Tuto_Canvas"))
        {
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
    }
}
