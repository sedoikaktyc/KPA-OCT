using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectsOnImage))]
[CanEditMultipleObjects]

public class ObjectsOnImageGUI : Editor
{

    public override void OnInspectorGUI()
    {
        /* создаем объет класса скрипта, чтобы к нему обращаться */
        ObjectsOnImage ImageParent = (ObjectsOnImage)target;

        if (GUILayout.Button("Save Data"))
        {
            ImageParent.SaveItemsData();
            //XML.Table1.ItemList.Add(new List<XML.ItemEntry>());
        }


        EditorGUILayout.PropertyField(serializedObject.FindProperty("PrefFoImage"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("CanvasParent"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("GameObjectParent"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("BlockName"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Image"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("BlockSquares"), true); 




        if (GUILayout.Button("Add Item"))
        {
            ImageParent.AddItemToTable();
            //XML.Table1.ItemList.Add(new List<XML.ItemEntry>());
        }

        GUILayout.Space(10f);

        if (GUILayout.Button("Add Listener at Botton"))
        {
            ImageParent.AddListenerAtBotton();
            //XML.Table1.ItemList.Add(new List<XML.ItemEntry>());
        }

        

     




        serializedObject.ApplyModifiedProperties();
    }



}
