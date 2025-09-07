using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    /// <summary>
    /// 弾の速度 (m/s)
    /// </summary>
    [SerializeField]
    private float m_bulletSpeed = 27.0f;

    // Update is called once per frame
    void Update()
    {
        //弾を前に進ませる
        transform.position +=
            transform.forward * m_bulletSpeed * Time.deltaTime;
    }

    // 衝突判定（Trigger）
    //private void OnTriggerEnter(Collider other)
    //{
    //    // 例：敵に当たったら破壊
    //    if (other.CompareTag("Enemy"))
    //    {
    //        // 敵にダメージを与える処理など
    //        Destroy(other.gameObject);
    //    }

    //    // 弾自身も消す
    //    Destroy(gameObject);
    //}

}