using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手のタグを確認
        if (collision.gameObject.tag == "Target")
        {
            // 弾（自身）を破棄
            Destroy(gameObject);

            // ターゲットオブジェクトを破棄
            Destroy(collision.gameObject);
        }
    }
}