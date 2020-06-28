using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsSetting : MonoBehaviour
{
    [SerializeField] private MouseData mouseData;
    [SerializeField] private AudioSource audioSource;

    public void SetSensitivityX(float sensX)
    {
        mouseData.MouseSensX = sensX;
    }
    public void SetSensitivityY(float sensY)
    {
        mouseData.MouseSensX = sensY;
    }
    public void SetSensitivityZ(float sensZ)
    {
        mouseData.MouseSensX = sensZ;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
