using TMPro;
using UnityEngine;

public abstract class MyGazeInteractor : MonoBehaviour
{

    [SerializeField] protected float maxDistance = 100f;
    [SerializeField] protected float TimerUntilGazeIsCompleted = 10f;
    [SerializeField] protected LayerMask TargetLayer;

    private Camera mainCam;
    private float gazeTimer;
    protected Transform currentTarget;

    private void Awake()
    {
        mainCam = Camera.main;        
    }

    protected abstract void handleGaze(Transform GameObjetTransform);
    // Update is called once per frame
    void Update()
    {
        var camTransform = mainCam.transform;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit rHit, maxDistance, TargetLayer))
        {
            var targetTransform = rHit.transform;
            if (targetTransform == currentTarget)
            {
                gazeTimer += Time.deltaTime;
                if (gazeTimer >= TimerUntilGazeIsCompleted)
                {
                    handleGaze(targetTransform);
                    //rHit.collider.gameObject.SetActive(false);
                    gazeTimer = 0f;
                }
            }
            else
            {
                currentTarget = targetTransform;
                gazeTimer = 0f;
            }
        }
        else
        {
            currentTarget = null;
        }
    }
}
