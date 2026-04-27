using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Mathf.Sin(Time.time) / 10000);
    }

}
