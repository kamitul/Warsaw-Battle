using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using DG.Tweening;

public class StartSceneController : MonoBehaviour
{
    [SerializeField] private List<ImageSlideData> panels;
    private int index = 0;
    private float currentTime=6.0f;

    void Update()
    {
        ChangePanel();
    }

    private void ChangePanel()
    {
        if (Time.time>currentTime)
        {
            ChangeImage();
            currentTime = Time.time + panels[index].slideTime;
            index++;
            if (index >= panels.Count)
            {
                CheckEnd();
            }
        }
    }

    private void CheckEnd()
    {
      index = 0;
      SceneManager.LoadScene(0);
    }

    private void ChangeImage()
    {
        Color color = panels[index].image.color;
        color.a = 0;
        panels[index].image.DOColor(color, panels[index].alphaToZeroDuration);
        panels[index].text.SetActive(false);
    }
}

[Serializable]
public class ImageSlideData
{
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _text;
    [SerializeField] private float _slideTime = 6.0f;
    [SerializeField] private float _alphaToZeroDuration = 1.0f;

    public Image image { get => _image; set => _image = value; }
    public GameObject text { get => _text; set => _text = value; }
    public float slideTime { get => _slideTime; set => _slideTime = value; }
    public float alphaToZeroDuration { get => _alphaToZeroDuration; set => _alphaToZeroDuration = value; }
}