using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Header("Hitエフェクト")]
    private ParticleSystem HitEffect;

    private void OnTriggerEnter(Collider other)
    {
        // 衝突した相手のタグが"Target"か確認
        if (other.gameObject.tag == "Target")
        {
            // GameManagerが存在すれば、クリア状態を通知する
            if (GameManager.instance != null)
            {
                HitEffect.Play();
                GameManager.instance.SetGameClear();
            }

            // 弾とターゲットを破棄
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}