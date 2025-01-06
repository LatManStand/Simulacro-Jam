using System;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public Transform orb;
    private Transform pivot;
    
    void Start()
    {
        pivot = orb.transform;
    }

    void Update()
    {
        Vector3 orbVector = Camera.main.WorldToScreenPoint(orb.position);
        orbVector = Input.mousePosition - orbVector;
        float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

        pivot.position = orb.position;
        pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
