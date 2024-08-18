using System;
using UnityEngine;

/// <summary>
/// BGMを登録・調整する
/// </summary>
[Serializable]
public class BgmData
{
    /// <summary>
    /// BGMの種類
    /// </summary>
    public enum BGM
    {
       Battle,
    }

    [Tooltip("音の種類をラベルで設定")]
    public BGM bgm;
    [Tooltip("使用したい音を設定")]
    public AudioClip audioClip;
    [Range(0.0f, 1.0f), Tooltip("音量")] public float volume = 1.0f;
}
