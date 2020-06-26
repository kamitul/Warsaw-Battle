using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    [SerializeField]
    private Transform spotLight;

    public void SetLightning(GameObject obj)
    {
        spotLight.LookAt(obj.transform);
    }
}
