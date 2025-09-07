/*
//-------------------------------------------------------------------------------------------------
作成日：2025/09/07 Sun 18:56
作者　：菅村

timeCounter.cs
経過時間を測定するスクリプト。
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
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "タイム：" + _gameManager.GetTime().ToString("F3");
    }
}