using TMPro;
using UnityEngine;

public class MyGazeInteractor : MonoBehaviour
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

    protected virtual void handleGaze(Transform GameObjetTransform)
    {
        Debug.Log("basic gaze");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update called in MyGazeInteractor");
        var camTransform = mainCam.transform;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit rHit, maxDistance, TargetLayer))
        {
            Debug.Log("gougougaga");
            var targetTransform = rHit.transform;
            Debug.Log("Raycast hit: " + targetTransform.name);

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
