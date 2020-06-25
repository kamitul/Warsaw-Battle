using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> screens;

    public void OpenScreen(string name)
    {
        for(int i = 0; i < screens.Count; ++i)
        {
            screens[i].SetActive(false);
        }
        GameObject screen = screens.Find(x => x.name == name);
        screen.SetActive(true);
    }

    public void DisableScreen(string name)
    {
        GameObject screen = screens.Find(x => x.name == name);
        screen.SetActive(false);
    }
}
