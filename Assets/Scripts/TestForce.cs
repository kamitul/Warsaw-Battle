using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForce : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rg;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rg.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            rg.AddTorque(new Vector3(UnityEngine.Random.Range(0, 500), UnityEngine.Random.Range(0, 500), UnityEngine.Random.Range(0, 500)));
        }
    }
}
