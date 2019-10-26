using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class NewMenuzTools : EditorWindow
{
    protected string m_NewSceneName;

    protected readonly GUIContent m_NameContent = new GUIContent("New Scene Name");

    [MenuItem("Kit Tools/Create New Scene...", priority = 100)]
    static void Init()
    {
        NewMenuzTools window = GetWindow<NewMenuzTools>();
        window.Show();
    }

    void OnGUI()
    {
        m_NewSceneName = EditorGUILayout.TextField(m_NameContent, m_NewSceneName);

        //if (GUILayout.Button("Create"))
            //CheckAndCreateScene();
    }
}
