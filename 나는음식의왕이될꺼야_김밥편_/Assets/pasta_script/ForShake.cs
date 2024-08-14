using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForShake : MonoBehaviour
{
    public cameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        cameraShake = Camera.main.GetComponent<cameraShake>();


        cameraShake.TriggerShake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
