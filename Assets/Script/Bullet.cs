using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂�������̃^�O���m�F
        if (collision.gameObject.tag == "Target")
        {
            // �e�i���g�j��j��
            Destroy(gameObject);

            // �^�[�Q�b�g�I�u�W�F�N�g��j��
            Destroy(collision.gameObject);
        }
    }
}