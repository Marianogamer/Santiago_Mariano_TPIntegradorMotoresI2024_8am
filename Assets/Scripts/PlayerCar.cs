using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    [SerializeField] float turnSpeed = 5;
    Quaternion targetRotation;

    void Update()
    {
        SetRotationPoint();
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
    private void SetRotationPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if(plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(0, rotationAngle, 0);
        }
    }
}
