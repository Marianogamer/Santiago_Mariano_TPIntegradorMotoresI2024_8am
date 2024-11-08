using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CheckPoint : MonoBehaviour
{

    public bool IsStartFinish;

    CheckPointControl checkPointControl;
    void Start()
    {
        checkPointControl = GetComponentInParent<CheckPointControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        var collided = other.GetComponent<PlayerCar>();

        if (collided = null)
            return;

        checkPointControl.CheckpointReached(this);
        
    }
}
