
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

            script.artistas = XMLManager.DeserializarDesdeResources<List<ArtistaData>>("artistas");
            XMLManager.Serializar(script.artistas, "artistas");
            script.instruments = XMLManager.DeserializarDesdeResources<List<InstrumentData>>("listaInstrumentos");
            XMLManager.Serializar(script.instruments, "listaInstrumentos");
            script.canciones = XMLManager.DeserializarDesdeResources<List<Cancion>>("nuevasCanciones");
            XMLManager.Serializar(script.canciones, "nuevasCanciones");
            script.ciudades = XMLManager.DeserializarDesdeResources<List<Ciudad>>("ciudades");
            XMLManager.Serializar(script.ciudades, "ciudades");

            Debug.Log("Datos eliminados");
            PlayerPrefs.SetInt("Money", 500);
            script.currentMoney = 500;

        }
        if (GUILayout.Button("Crear Datos Artistas"))
        {
 
            XMLManager.SerializarAResources(script.artistas, "artistas");
           
      

        }
    }

}
