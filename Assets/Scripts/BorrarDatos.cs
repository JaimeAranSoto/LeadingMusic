using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;




[CustomEditor(typeof(DataManager))]
public class DataManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DataManager script = (DataManager)target;
        if (GUILayout.Button("Borrar Datos"))
        {
            PlayerPrefs.DeleteAll();

            script.artistas = XMLManager.Deserializar<List<ArtistaData>>("artistas");

            foreach (ArtistaData a in script.artistas)
            {
                a.contratado = false;
                a.concierto.tiempo = 0;

            }
            foreach (InstrumentData i in script.instruments)
            {
                i.level = 0;

            }
            script.instruments[0].level = 1;
            XMLManager.Serializar(script.artistas, "Assets/Resources/artistas.xml");
            Debug.Log("Datos eliminados");
            PlayerPrefs.SetInt("Money", 500);
            script.currentMoney = 500;
            script.artistas = XMLManager.Deserializar<List<ArtistaData>>("artistas");

        }
    }

}