/*
//-------------------------------------------------------------------------------------------------
�쐬���F2025/09/07 Sun 15:35
��ҁ@�F����

BGMManager.cs
BGM�̍Đ��������s�����߂̃X�N���v�g�B
//-------------------------------------------------------------------------------------------------
 */

using UnityEngine;
using UnityEngine.Audio;

[RequireComponent (typeof(AudioSource))]
public class BGMManager : MonoBehaviour
{
    //-------------------------------------------------------------------------------------------------
    // �ϐ��錾�B
    //-------------------------------------------------------------------------------------------------
    private static BGMManager _instance; // ���̃I�u�W�F�N�g�̃C���X�^���X�B

    private AudioSource _audioSource; // BGM�Đ��p��AudioSource�^�ϐ��B

    [Header("�����ݒ�ꗗ")]
    [SerializeField] private bool _mute         = false;
    [SerializeField] private bool _playOnAwake  = false;
    [SerializeField] private bool _loop         = true;
    [SerializeField, Range(0, 1)] private float _volume = 0.5f;

    [Header("�Đ�����BGM")] 
    [SerializeField] private AudioResource _BGM;


    //-------------------------------------------------------------------------------------------------
    // private void Awake()�֐��B
    //-------------------------------------------------------------------------------------------------
    private void Awake()
    {
        // �C���X�^���X�𐶐��B
        if(_instance == null)
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
        if(_audioSource != null)
        {
            // ���炩���ߐݒ肵�������ݒ�ɕύX�B
            _audioSource.resource       = _BGM;
            _audioSource.mute           = _mute;
            _audioSource.playOnAwake    = _playOnAwake;
            _audioSource.loop           = _loop;
            _audioSource.volume         = _volume;

            // BGM���ݒ肳��Ă���ꍇ�B
            if (_BGM != null)
                _audioSource.Play(); // BGM�̍Đ��B
            else
                Debug.LogWarning("BGM��ݒ肵�Ă��������B");
        }
        else
        {
            Debug.LogWarning("AudioSource���A�^�b�`����Ă��܂���B");
        }
    }
}