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
        print("Trigger");
        var Collided = other.GetComponent<PlayerCar>();

        if (Collided = null)
        {
            return;
        }

        print("here");

        checkPointControl.CheckpointReached(this);
    }
}
