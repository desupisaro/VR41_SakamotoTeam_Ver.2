using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Unityの新しいInput Systemを使用

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameClear = false;

    public GameObject clearPanel;

    // VRコントローラーのAボタン入力を検知するためのInputAction
    public InputActionProperty restartAction;

    private timeCounter _time;
    private float _timer = 0.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _timer = 0f;
        _time = GameObject.FindGameObjectWithTag("Timer").GetComponent<timeCounter>();
        
        if (clearPanel != null)
        {
            clearPanel.SetActive(false);
        }

        
}

    private void OnEnable()
    {
        // アクションを有効化する
        restartAction.action.Enable();
    }

    private void OnDisable()
    {
        // アクションを無効化する
        restartAction.action.Disable();
    }

    private void Update()
    {
        // 経過時間を取得。
        _timer += Time.deltaTime;

        // ゲームがクリア状態で、かつVRコントローラーのボタンが押されたかチェックする
        if (isGameClear && clearPanel != null)
        {
            clearPanel.SetActive(true);

            // Aボタンが押されたらリスタート処理を呼び出す
            if (restartAction.action.WasPressedThisFrame())
            {
                RestartGame();
            }
        }
    }

    public void SetGameClear()
    {
        isGameClear = true;
        _time.TimerShow();
        Debug.Log("Game Cleared!");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float GetTime()
    {
        return _timer;
    }
}