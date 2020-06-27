using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopSoundPlayer : SoundPlayer
{
    [SerializeField]
    private List<AudioClip> attackSounds;

    [SerializeField]
    private List<AudioClip> shoutSounds;

    [SerializeField]
    private List<AudioClip> moveSounds;

    public void Attack()
    {
        source.Stop();
        source.time = 0f;
        AudioClip clip = attackSounds[Random.Range(0, attackSounds.Count - 1)];
        source.clip = clip;
        source.Play();
    }

    public void Shout()
    {
        source.Stop();
        source.time = 0f;
        AudioClip clip = shoutSounds[Random.Range(0, shoutSounds.Count - 1)];
        source.clip = clip;
        source.Play();
    }

    public void Move()
    {
        source.Stop();
        source.time = 0f;
        AudioClip clip = moveSounds[Random.Range(0, moveSounds.Count - 1)];
        source.clip = clip;
        source.Play();
    }
}
