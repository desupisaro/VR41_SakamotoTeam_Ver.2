/*
//-------------------------------------------------------------------------------------------------
�쐬���F2025/09/07 Sun 18:56
��ҁ@�F����

targetChenger.cs
�^�[�Q�b�g�I�u�W�F�N�g�̖��O��\�����邽�߂̃X�N���v�g�B
//-------------------------------------------------------------------------------------------------
 */

using UnityEngine;

public class targetChenger : MonoBehaviour
{
    public void SetTargetName( string _name )
    {
        this.gameObject.GetComponent<UnityEngine.UI.Text>().text = _name + "�������āI";
    }
}