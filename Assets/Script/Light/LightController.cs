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

    // ライトの状態判定
    bool _isLight = false;

    void Update()
    {
        // Interactorが存在していれば掴まれていると判定
    if (grabInteractable != null &&
        grabInteractable.Interactors.Count > 0 &&
        OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            // ライトの切り替え
            OnLight();
        }
    }


    private void OnLight()
    {
        if (m_lightPrefab == null) return;

        _isLight = !_isLight; // 状態を反転（ON ⇄ OFF）

        m_lightPrefab.SetActive(_isLight);
    }
}