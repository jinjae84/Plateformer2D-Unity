using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DataEditor : EditorWindow
{
    [MenuItem("Editor/DataEditor")]
    static void Open()
    {
        GetWindow<DataEditor>();
    }
    private void OnGUI()
    {
        if(GUILayout.Button("Best Score Clear"))
        {
            Debug.Log("PlayePrefs의 BestScore 데이터가 삭제되었습니다.");
            PlayerPrefs.SetFloat(GameData.BestScore, 0);
        }
    }
}
