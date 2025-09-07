using Oculus.Interaction;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] 
    [Header("弾のオブジェクト")]
    private GameObject bulletPrefab;

    [SerializeField]
    [Header("弾の発射位置")]
    private Transform muzzlePos;

    [SerializeField]
    [Header("銃を撃つサウンド")]
    private SEManager _audio;

    // 持っているかどうか判定するためのやつ
    [SerializeField]
    private GrabInteractable grabInteractable;

    [SerializeField] 
    private HandSelector _selectHands;

    void Update()
    {
        if (grabInteractable != null &&
            grabInteractable.Interactors.Count > 0 &&
           _selectHands.GetHandRight())
        {
            Shoot();

            // サウンド再生
            _audio.PlaySE(0);
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, muzzlePos.position, muzzlePos.rotation);
    }
}