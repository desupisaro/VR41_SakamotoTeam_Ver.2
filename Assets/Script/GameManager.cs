using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // リスタートボタンが押されたときに呼ばれる関数
    public void RestartGame()
    {
        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // タイトルへ戻るボタンが押されたときに呼ばれる関数
    public void GoToTitle()
    {
        // タイトルシーンに移動する
        SceneManager.LoadScene("TitleScene"); // ここにタイトルシーンの名前を入力
    }
}