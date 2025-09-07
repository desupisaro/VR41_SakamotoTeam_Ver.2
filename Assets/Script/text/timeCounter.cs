/*
//-------------------------------------------------------------------------------------------------
�쐬���F2025/09/07 Sun 18:56
��ҁ@�F����

timeCounter.cs
�o�ߎ��Ԃ𑪒肷��X�N���v�g�B
//-------------------------------------------------------------------------------------------------
 */

using UnityEngine;

public class timeCounter : MonoBehaviour
{
    private float _time = 0.0f;

    private bool _isPlaying = true;

    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _time = 0f;
    }

    public void TimerShow()
    {
        _isPlaying = false;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "�^�C���F" + _gameManager.GetTime().ToString("F3");
    }
}