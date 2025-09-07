/*
//-------------------------------------------------------------------------------------------------
作成日：2025/09/07 Sun 16:26
作者　：菅村

SEManager.cs
SEの再生処理を行うためのスクリプト。
//-------------------------------------------------------------------------------------------------
 */

using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SEManager : MonoBehaviour
{
    //-------------------------------------------------------------------------------------------------
    // 変数宣言。
    //-------------------------------------------------------------------------------------------------
    private static SEManager _instance; // このオブジェクトのインスタンス。

    private AudioSource _audioSource; // BGM再生用のAudioSource型変数。

    [Header("初期設定一覧")]
    [SerializeField] private bool _mute         = false;
    [SerializeField] private bool _playOnAwake  = false;
    [SerializeField] private bool _loop         = false;
    [SerializeField, Range(0, 1)] private float _volume = 0.5f;

    // SEをまとめる構造体。
    [System.Serializable]
    private struct SoundEffects
    {
        public string _name;
        public int _number;
        public AudioClip _clip;
    }

    [Header("再生するSE")]
    [SerializeField] private SoundEffects[] _soundEffects;


    //-------------------------------------------------------------------------------------------------
    // private void Awake()関数。
    //-------------------------------------------------------------------------------------------------
    private void Awake()
    {
        // インスタンスを生成。
        if (_instance == null)
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
        if (_audioSource != null)
        {
            // あらかじめ設定した初期設定に変更。
            _audioSource.mute           = _mute;
            _audioSource.playOnAwake    = _playOnAwake;
            _audioSource.loop           = _loop;
            _audioSource.volume         = _volume;
        }
        else
        {
            Debug.LogWarning("AudioSourceがアタッチされていません。");
        }
    }

    //-------------------------------------------------------------------------------------------------
    // public void PlaySE()関数。
    // 引数１：再生するSE番号。
    //-------------------------------------------------------------------------------------------------
    public void PlaySE(int _num)
    {
        // _soundEffects内の情報を全て調べる。
        foreach (SoundEffects _effect in _soundEffects)
        {
            // 再生させたいSE番号と一致した場合。
            if(_effect._number == _num)
            {
                // SEを再生した後、ループ終了。
                _audioSource.PlayOneShot(_effect._clip);
                break;
            }
        }
    }
}