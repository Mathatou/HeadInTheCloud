using UnityEngine;
using UnityEngine.XR.Content.Interaction; // Vérifie bien le namespace

public class EscapeManager : MonoBehaviour
{
    [SerializeField] private Door m_TargetDoor;

    // Appelle cette fonction quand l'énigme est réussie !
    public void OnEnigmaSolved()
    {
        // 1. On récupère le HingeJoint via un petit script ou on le modifie directement.
        // Si tu utilises le script Door.cs tel quel, il s'ouvre normalement 
        // via la fonction DoorHandleUpdate ou KeyUpdate.

        // Si tu veux la déverrouiller instantanément par script sans clé :
        m_TargetDoor.onUnlock.Invoke();

        // Pour ouvrir physiquement les limites de la porte (en imitant la poignée) :
        m_TargetDoor.DoorHandleUpdate(0.0f); // 0.0f est inférieur à m_HandleOpenValue, donc ça ouvre !
    }
}