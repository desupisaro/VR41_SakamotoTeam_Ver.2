/*
//-------------------------------------------------------------------------------------------------
作成日：2025/09/07 Sun 18:56
作者　：菅村

targetChenger.cs
ターゲットオブジェクトの名前を表示するためのスクリプト。
//-------------------------------------------------------------------------------------------------
 */

using UnityEngine;

public class targetChenger : MonoBehaviour
{
    public void SetTargetName( string _name )
    {
        this.gameObject.GetComponent<UnityEngine.UI.Text>().text = _name + "を撃って！";
    }
}