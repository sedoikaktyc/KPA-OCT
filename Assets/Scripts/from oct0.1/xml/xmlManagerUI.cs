using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(xmlManager))]
[CanEditMultipleObjects]

public class xmlManagerUI : Editor
{

    xmlManager subject;
    SerializedProperty compType;
    SerializedProperty TypeOfAnswer;

    void OnEnable()
    {
        subject = target as xmlManager;
        compType = serializedObject.FindProperty("Project");
        TypeOfAnswer = serializedObject.FindProperty("TypeOfAnswer");

    }

    public override void OnInspectorGUI()


    {

        if (GUILayout.Button("Save Data & Name"))
        {
            subject.SaveItemsData();
            //XML.Table1.ItemList.Add(new List<XML.ItemEntry>());
        }

        if (GUILayout.Button("FindObjest at Scene"))
        {
            subject.FindAllObjects();
            //XML.Table1.ItemList.Add(new List<XML.ItemEntry>());
        }

        



        EditorGUILayout.PropertyField(serializedObject.FindProperty("PziName"), true);
        //serializedObject.Update();

        EditorGUILayout.PropertyField(compType);


        if (subject.Project == xmlManager.ComponentType.KPA)
        {

            GUILayout.Space(10f);
            GUILayout.Label("↓↓↓ First Block - Arduino ↓↓↓");
            GUILayout.Space(10f);
            //Вывод в редактор слайдера
            //EditorGUILayout.IntSlider(varCompFirst, 0, 100, new GUIContent("Variable First"));
            //compName.stringValue = "First";
            EditorGUILayout.PropertyField(serializedObject.FindProperty("TableKPA"), true);
            if (GUILayout.Button("Add Item"))
            {
                subject.AddItemToTable(subject.TableKPA);
                //XML.Table1.ItemList.Add(new List<XML.ItemEntry>());
            }
            /* удаляем блок со стола 1 */
            if (GUILayout.Button("Remove Item"))
            {
                if (subject.TableKPA.Blocks.Count > 0)
                {
                    subject.RemoveItemOfTable(subject.TableKPA);
                }
                else
                {
                    Debug.LogError("TableKPA count 0 !!!");
                }
                //XML.Table1.ItemList.Add(new List<XML.ItemEntry>());
            }


            EditorGUILayout.PropertyField(serializedObject.FindProperty("PZI"), true);


                for (var i = 0; i < subject.PZI.Steps.Count; i++)
            {
                if (subject.PZI.Steps[i].TypeOfAnswer != xmlManager.StepProperties.TypeOfAnswerProper.Arduino)
                {

                    if (subject.PZI.Steps[i].TypeOfArduinoAnswer != xmlManager.StepProperties.TypeOfArduinoAnswerProper.disabled)
                    {

                        Debug.LogError("select #Arduino# at " + i + " step or change the Type Of Arduino Answer to #disabled#");
                      

                    }

                        


                }


            }



        }



        serializedObject.ApplyModifiedProperties();
    }


   
    


    }
