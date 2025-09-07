using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���Ǘ��̂��߂ɕK�v

public class Bullet : MonoBehaviour
{
    // ��ʏ��UI�v�f�ւ̎Q��
    public GameObject clearPanel; // �N���A�\���p��UI�p�l���i��\���ɂ��Ă����j

    private void OnTriggerEnter(Collider other)
    {
        // �Փ˂�������̃^�O���m�F
        if (other.gameObject.tag == "Target")
        {
            // �N���A�\���p�l����L���ɂ���
            if (clearPanel != null)
            {
                clearPanel.SetActive(true);
            }

            // �e�ƃ^�[�Q�b�g�I�u�W�F�N�g��j��
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}