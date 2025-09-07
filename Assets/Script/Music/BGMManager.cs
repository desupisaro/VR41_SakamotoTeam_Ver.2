/*
//-------------------------------------------------------------------------------------------------
作成日：2025/09/07 Sun 15:35
作者　：菅村

BGMManager.cs
BGMの再生処理を行うためのスクリプト。
//-------------------------------------------------------------------------------------------------
 */

using UnityEngine;
using UnityEngine.Audio;

[RequireComponent (typeof(AudioSource))]
public class BGMManager : MonoBehaviour
{
    //-------------------------------------------------------------------------------------------------
    // 変数宣言。
    //-------------------------------------------------------------------------------------------------
    private static BGMManager _instance; // このオブジェクトのインスタンス。

    private AudioSource _audioSource; // BGM再生用のAudioSource型変数。

    [Header("初期設定一覧")]
    [SerializeField] private bool _mute         = false;
    [SerializeField] private bool _playOnAwake  = false;
    [SerializeField] private bool _loop         = true;
    [SerializeField, Range(0, 1)] private float _volume = 0.5f;

    [Header("再生するBGM")] 
    [SerializeField] private AudioResource _BGM;


    //-------------------------------------------------------------------------------------------------
    // private void Awake()関数。
    //-------------------------------------------------------------------------------------------------
    private void Awake()
    {
        // インスタンスを生成。
        if(_instance == null)
        {
            _instance = this;                   // インスタンスを設定。
            DontDestroyOnLoad(this.gameObject); // このオブジェクトを削除しないよう設定。
        }
        else
        {
            Destroy(this.gameObject); // 新たに生成されたオブジェクトを削除。
        }
    }

    //-------------------------------------------------------------------------------------------------
    // private void Start()関数。
    //-------------------------------------------------------------------------------------------------
    private void Start()
    {
        // AudioSourceのコンポーネントを取得。
        _audioSource = this.GetComponent<AudioSource>();

        // AudioSourceコンポーネントが存在する場合。
        if(_audioSource != null)
        {
            // あらかじめ設定した初期設定に変更。
            _audioSource.resource       = _BGM;
            _audioSource.mute           = _mute;
            _audioSource.playOnAwake    = _playOnAwake;
            _audioSource.loop           = _loop;
            _audioSource.volume         = _volume;

            // BGMが設定されている場合。
            if (_BGM != null)
                _audioSource.Play(); // BGMの再生。
            else
                Debug.LogWarning("BGMを設定してください。");
        }
        else
        {
            Debug.LogWarning("AudioSourceがアタッチされていません。");
        }
    }
}