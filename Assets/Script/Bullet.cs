using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Header("Hit�G�t�F�N�g")]
    private ParticleSystem HitEffect;

    private void OnTriggerEnter(Collider other)
    {
        // �Փ˂�������̃^�O��"Target"���m�F
        if (other.gameObject.tag == "Target")
        {
            // GameManager�����݂���΁A�N���A��Ԃ�ʒm����
            if (GameManager.instance != null)
            {
                HitEffect.Play();
                GameManager.instance.SetGameClear();
            }

            // �e�ƃ^�[�Q�b�g��j��
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}