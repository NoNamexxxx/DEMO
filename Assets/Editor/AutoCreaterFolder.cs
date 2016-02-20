using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
public class AutoCreaterFolder : EditorWindow {
    public bool Scenes;
    public bool Scripts;
    public bool Audios;
    public bool Models;
    public bool Prefabs;
    public bool Plugins;
    public bool Textures;
    public bool Materials;
    public bool Documents;
    public bool Animations;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [MenuItem("Auto/CreaterFolder")]
    public static void AddFolder()
    {
        Debug.Log("Creat");
        EditorWindow.GetWindow(typeof(AutoCreaterFolder));
        
    }
    void OnGUI()
    {
        Scenes = EditorGUILayout.Toggle("Scenes",Scenes);
        Documents = EditorGUILayout.Toggle("Documents", Documents);
        Models = EditorGUILayout.Toggle("Model", Models);
        Plugins = EditorGUILayout.Toggle("Plugins", Plugins);
        Prefabs = EditorGUILayout.Toggle("Prefabs", Prefabs);
        Scripts = EditorGUILayout.Toggle("Scripts", Scripts);
        Textures = EditorGUILayout.Toggle("Texture", Textures);
        Materials = EditorGUILayout.Toggle("Materials", Materials);
        Audios = EditorGUILayout.Toggle("Audios", Audios);
        Animations = EditorGUILayout.Toggle("Animations", Animations);
        #region Create
        if (GUILayout.Button("创建"))
        {
            if (Animations)
            {
                Directory.CreateDirectory(@"Assets/Animations");
            }
            if (Materials)
            {
                Directory.CreateDirectory(@"Assets/Materials");
            }
            if (Scenes)
            {
                Directory.CreateDirectory(@"Assets/Scenes");
            }
            if (Documents)
            {
                Directory.CreateDirectory(@"Assets/Documents");

            }
            if (Models)
            {
                Directory.CreateDirectory(@"Assets/Models");

            }
            if (Audios)
            {
                Directory.CreateDirectory(@"Assets/Audios");

            }
            if (Plugins)
            {
                Directory.CreateDirectory(@"Assets/Plugins");

            }
            if (Models)
            {
                Directory.CreateDirectory(@"Assets/Models");

            }
            if (Prefabs)
            {
                Directory.CreateDirectory(@"Assets/Prefabs");

            }
            if (Textures)
            {
                Directory.CreateDirectory(@"Assets/Textures");

            }
            if (Scripts)
            {
                Directory.CreateDirectory(@"Assets/Scripts");

            }
        }
        #endregion
        
    }
}
