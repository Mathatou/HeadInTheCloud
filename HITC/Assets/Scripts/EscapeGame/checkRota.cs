using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class checkRota : MonoBehaviour
{
    [SerializeField]private DecalProjector DP;
    [SerializeField] private Material[] imagesToShow;
    private int index = -1;
    private float lastTriggerValue = 0.5f;
    private void Awake()
    {
        if(DP==null)
        {
            Debug.LogWarning("DecalProjector component not assigned in the inspector."); return;
        }
        DP.enabled = false;
    }
    public void onKnobValueChanged(float value)
    {        
        if (value-lastTriggerValue > 1.5f)
        {
            DP.enabled = true;
            changeImage();
            lastTriggerValue = value;
        }

    }
    void changeImage()
    {
        
        if (imagesToShow == null || imagesToShow.Length == 0) return;

        index = (index+1) % imagesToShow.Length;
        DP.material = imagesToShow[index];
        DP.enabled = true;
    }
}
