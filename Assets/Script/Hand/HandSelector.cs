using Oculus.Interaction;
using UnityEngine;

public class HandSelector : MonoBehaviour
{
    [SerializeField] private GrabInteractable grabInteractable;

    public OVRInput.Controller CurrentHand { get; private set; } = OVRInput.Controller.None;

    // ���E�ǂ���̎�Ŏ����Ă��邩����
    bool _isLeft = false;
    bool _isRight = false;

    void Update()
    {
        // �ǂ���̎�Ŏ����Ă��邩����
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
            {
                // ���Ŏ����Ă���
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
                // �E�Ŏ����Ă���
                _isRight = true;
            }
            else if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
            {
                return;
            }
        }
        else
        {
            // �����Ă��Ȃ�����
            _isLeft = false;
            _isRight = false;
        }
    }

    // ����ŃA�N�V����
    public bool GetHandLeft()
    {
        return _isLeft;
    }

    // �E��ŃA�N�V����
    public bool GetHandRight()
    {
        return _isRight;
    }
}