using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // スポットライトのプレハブ。
    [SerializeField]
    private GameObject m_lightPrefab = null;

    // 持っているかどうか判定するためのやつ
    [SerializeField]
    private GrabInteractable grabInteractable;

    [SerializeField]
    [Header("ライトONOFFのサウンド")]
    private AudioSource _audio;

    [SerializeField]
    private HandSelector _selectHands;

    // ライトの状態判定
    bool _isLight = false;

    void Update()
    {
        // Interactorが存在していれば掴まれていると判定
        if (grabInteractable != null &&
            grabInteractable.Interactors.Count > 0 &&
           _selectHands.GetHandLeft())
        {
            // ライトの切り替え
            OnLight();

            // _audio変数がnullの場合は処理を行わない。（追記：菅村）
            if(_audio != null)
                _audio.Play(); // サウンド再生
        }
    }


    private void OnLight()
    {
        if (m_lightPrefab == null) return;

        _isLight = !_isLight; // 状態を反転（ON ⇄ OFF）

        m_lightPrefab.SetActive(_isLight);
    }
}