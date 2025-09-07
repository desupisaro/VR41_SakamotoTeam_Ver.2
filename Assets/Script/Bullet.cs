using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理のために必要

public class Bullet : MonoBehaviour
{
    // 画面上のUI要素への参照
    public GameObject clearPanel; // クリア表示用のUIパネル（非表示にしておく）

    private void OnTriggerEnter(Collider other)
    {
        // 衝突した相手のタグを確認
        if (other.gameObject.tag == "Target")
        {
            // クリア表示パネルを有効にする
            if (clearPanel != null)
            {
                clearPanel.SetActive(true);
            }

            // 弾とターゲットオブジェクトを破棄
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}