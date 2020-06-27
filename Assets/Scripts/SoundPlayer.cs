using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    protected List<AudioClip> hoverClips = default;
    [SerializeField]
    protected List<AudioClip> clcikClips = default;

    protected AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Hover()
    {
        source.Stop();
        source.time = 0f;
        AudioClip clip = hoverClips[Random.Range(0, hoverClips.Count - 1)];
        source.clip = clip;
        source.Play();
    }

    public void Click()
    {
        source.Stop();
        source.time = 0f;
        AudioClip clip = clcikClips[Random.Range(0, clcikClips.Count - 1)];
        source.clip = clip;
        source.Play();
    }
}
