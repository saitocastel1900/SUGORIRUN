﻿using UnityEngine;

/// <summary>
/// AudioSourceの拡張メソッド
/// </summary>
public static class AudioSourceExtension
{
    /// <summary>
    /// 再生
    /// </summary>
    public static void Play(this AudioSource audioSource, AudioClip audioClip)
    {
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}