/*
//-------------------------------------------------------------------------------------------------
�쐬���F2025/09/07 Sun 16:26
��ҁ@�F����

SEManager.cs
SE�̍Đ��������s�����߂̃X�N���v�g�B
//-------------------------------------------------------------------------------------------------
 */

using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SEManager : MonoBehaviour
{
    //-------------------------------------------------------------------------------------------------
    // �ϐ��錾�B
    //-------------------------------------------------------------------------------------------------
    private static SEManager _instance; // ���̃I�u�W�F�N�g�̃C���X�^���X�B

    private AudioSource _audioSource; // BGM�Đ��p��AudioSource�^�ϐ��B

    [Header("�����ݒ�ꗗ")]
    [SerializeField] private bool _mute         = false;
    [SerializeField] private bool _playOnAwake  = false;
    [SerializeField] private bool _loop         = false;
    [SerializeField, Range(0, 1)] private float _volume = 0.5f;

    // SE���܂Ƃ߂�\���́B
    [System.Serializable]
    private struct SoundEffects
    {
        public string _name;
        public int _number;
        public AudioClip _clip;
    }

    [Header("�Đ�����SE")]
    [SerializeField] private SoundEffects[] _soundEffects;


    //-------------------------------------------------------------------------------------------------
    // private void Awake()�֐��B
    //-------------------------------------------------------------------------------------------------
    private void Awake()
    {
        // �C���X�^���X�𐶐��B
        if (_instance == null)
        {
            _instance = this;                   // �C���X�^���X��ݒ�B
            DontDestroyOnLoad(this.gameObject); // ���̃I�u�W�F�N�g���폜���Ȃ��悤�ݒ�B
        }
        else
        {
            Destroy(this.gameObject); // �V���ɐ������ꂽ�I�u�W�F�N�g���폜�B
        }
    }

    //-------------------------------------------------------------------------------------------------
    // private void Start()�֐��B
    //-------------------------------------------------------------------------------------------------
    private void Start()
    {
        // AudioSource�̃R���|�[�l���g���擾�B
        _audioSource = this.GetComponent<AudioSource>();

        // AudioSource�R���|�[�l���g�����݂���ꍇ�B
        if (_audioSource != null)
        {
            // ���炩���ߐݒ肵�������ݒ�ɕύX�B
            _audioSource.mute           = _mute;
            _audioSource.playOnAwake    = _playOnAwake;
            _audioSource.loop           = _loop;
            _audioSource.volume         = _volume;
        }
        else
        {
            Debug.LogWarning("AudioSource���A�^�b�`����Ă��܂���B");
        }
    }

    //-------------------------------------------------------------------------------------------------
    // public void PlaySE()�֐��B
    // �����P�F�Đ�����SE�ԍ��B
    //-------------------------------------------------------------------------------------------------
    public void PlaySE(int _num)
    {
        // _soundEffects���̏���S�Ē��ׂ�B
        foreach (SoundEffects _effect in _soundEffects)
        {
            // �Đ���������SE�ԍ��ƈ�v�����ꍇ�B
            if(_effect._number == _num)
            {
                // SE���Đ�������A���[�v�I���B
                _audioSource.PlayOneShot(_effect._clip);
                break;
            }
        }
    }
}