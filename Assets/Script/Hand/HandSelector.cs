using Oculus.Interaction;
using UnityEngine;

public class HandSelector : MonoBehaviour
{
    [SerializeField] private GrabInteractable grabInteractable;

    public OVRInput.Controller CurrentHand { get; private set; } = OVRInput.Controller.None;

    // 左右どちらの手で持っているか判定
    bool _isLeft = false;
    bool _isRight = false;

    void Update()
    {
        // どちらの手で持っているか判定
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
            {
                // 左で持っている
                _isLeft = true;
            }
            else if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
            {
                return;
            }
        }
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                // 右で持っている
                _isRight = true;
            }
            else if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
            {
                return;
            }
        }
        else
        {
            // もっていない判定
            _isLeft = false;
            _isRight = false;
        }
    }

    // 左手でアクション
    public bool GetHandLeft()
    {
        return _isLeft;
    }

    // 右手でアクション
    public bool GetHandRight()
    {
        return _isRight;
    }
}