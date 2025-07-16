using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // 銃弾のプレハブ。
    // 発砲した際に、このオブジェクトを弾として実体化する。
    [SerializeField]
    private GameObject m_bulletPrefab = null;

    // 銃口の位置。
    // 銃弾を実体化する時の位置や向きの設定などに使用する。
    [SerializeField]
    private Transform m_muzzlePos = null;

    [SerializeField]
    private GrabInteractable grabInteractable;

    void Update()
    {
        // Interactorが存在していれば掴まれていると判定
        if (grabInteractable != null &&
            grabInteractable.Interactors.Count > 0 &&
            OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            // 弾発射
            ShootAmmo();
        }
    }


    // 銃弾を生成する。
    private void ShootAmmo()
    {
        //弾のプレハブか銃口位置が設定されていなければ処理を行わず帰る。ついでに煽る。
        if (m_bulletPrefab == null ||
            m_muzzlePos == null)
        {
            Debug.Log(" Inspector の設定が間違ってる");
            return;
        }

        //弾を生成する。
        GameObject bulletObj = Instantiate(m_bulletPrefab);

        //弾の位置を、銃口の位置と同一にする。
        bulletObj.transform.position = m_muzzlePos.position;

        //弾の向きを、銃口の向きと同一にする。
        bulletObj.transform.rotation = m_muzzlePos.rotation;

    }
}
