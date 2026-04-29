using UnityEngine;

public class Lobby_LighterManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem flame_ps;
    bool isLit = false;

    public void ToggleLighter()
    {
        isLit = !isLit;
        if (isLit) flame_ps.Play();
        else flame_ps.Stop();
    }

}
