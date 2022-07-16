using System.Linq;
using UnityEditor;
using UnityEngine;

namespace TileMap
{
    [CustomEditor(typeof(TileMap))]
    public class TileMapEditor : Editor
    {
        private string[] rollsOptions = {"1","2","3","4","5","6"};
        private int index = 0;
        private TileMap _tileMap;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EditorGUILayout.LabelField("Test generate with set roll value");
            index = EditorGUILayout.Popup(index, rollsOptions);
            if (GUILayout.Button("Generate "))
            {
                _tileMap.GenerateMap(index+1);
            }
            if (GUILayout.Button("Reset To DefautTiles"))
            {
                _tileMap.Reset();
            }
        }
        private void OnEnable()
        {
            _tileMap = target as TileMap;
        }
    }
}