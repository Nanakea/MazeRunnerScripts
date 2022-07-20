using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEditorInternal;
#endif
namespace SA
{
#if UNITY_EDITOR
    [CustomEditor(typeof (AI_PatrolPointList))]
    public class AI_PatrolPointScriptableListEditor : Editor
    {
        private ReorderableList patrolPoints_ReorderableList;

        public void OnEnable()
        {
            patrolPoints_ReorderableList = new ReorderableList(serializedObject, serializedObject.FindProperty("patrolPoints"), true, true, true, true);
            
            patrolPoints_ReorderableList.drawHeaderCallback = DrawHeader;
            patrolPoints_ReorderableList.drawElementCallback = DrawListItems;
        }

        void DrawHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Patrol Points");
        }

        // index -> 0 -> 1 -> 2 -> 3 ... n
        void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
        {   
            //The reorderListSerializedProperty in the list
            SerializedProperty element = patrolPoints_ReorderableList.serializedProperty.GetArrayElementAtIndex(index);
            if (element == null)
            {
                Debug.LogError("element" + index + " is null.");
                return;
            }

            EditorGUI.ObjectField(new Rect(rect.x, rect.y, 350, EditorGUIUtility.singleLineHeight), element, GUIContent.none);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            patrolPoints_ReorderableList.DoLayoutList();

            serializedObject.ApplyModifiedProperties();

            EditorUtility.SetDirty(target);
        }
    }
#endif
}

/*
    SerializedProperty element = patrolPoints_ReorderableList.serializedProperty.GetArrayElementAtIndex(index);
    if (element == null)
    {
        Debug.LogError("element" + index + " is null.");
        return;
    }

    EditorGUI.ObjectField(new Rect(rect.x, rect.y, 700, EditorGUIUtility.singleLineHeight), element, GUIContent.none);
 */
