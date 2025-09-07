using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ���X�^�[�g�{�^���������ꂽ�Ƃ��ɌĂ΂��֐�
    public void RestartGame()
    {
        // ���݂̃V�[�����ēǂݍ��݂���
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // �^�C�g���֖߂�{�^���������ꂽ�Ƃ��ɌĂ΂��֐�
    public void GoToTitle()
    {
        // �^�C�g���V�[���Ɉړ�����
        SceneManager.LoadScene("TitleScene"); // �����Ƀ^�C�g���V�[���̖��O�����
    }
}