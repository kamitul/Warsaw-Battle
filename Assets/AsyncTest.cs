using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncTest : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        List<Task> tasks = new List<Task>();

        tasks.Add(Task.Run(() => transform.Rotate(20, 0, 0)));
        tasks.Add(Task.Run(() => transform.Translate(20, 0, 0)));

        await Task.WhenAll(tasks);

        Debug.Log("XD");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
