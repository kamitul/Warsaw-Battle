using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField]
    private Transform center;

    private void Update()
    {
        transform.LookAt(center);
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
