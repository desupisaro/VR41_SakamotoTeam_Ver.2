using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Unity�̐V����Input System���g�p

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameClear = false;

    public GameObject clearPanel;

    // VR�R���g���[���[��A�{�^�����͂����m���邽�߂�InputAction
    public InputActionProperty restartAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (clearPanel != null)
        {
            clearPanel.SetActive(false);
        }
    }

    private void OnEnable()
    {
        // �A�N�V������L��������
        restartAction.action.Enable();
    }

    private void OnDisable()
    {
        // �A�N�V�����𖳌�������
        restartAction.action.Disable();
    }

    private void Update()
    {
        // �Q�[�����N���A��ԂŁA����VR�R���g���[���[�̃{�^���������ꂽ���`�F�b�N����
        if (isGameClear && clearPanel != null)
        {
            clearPanel.SetActive(true);

            // A�{�^���������ꂽ�烊�X�^�[�g�������Ăяo��
            if (restartAction.action.WasPressedThisFrame())
            {
                RestartGame();
            }
        }
    }

    public void SetGameClear()
    {
        isGameClear = true;
        Debug.Log("Game Cleared!");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}