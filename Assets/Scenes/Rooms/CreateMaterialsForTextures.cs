using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;

//Automated tool to assign textures 
public class CreateMaterialsForTextures : Editor
{
    [MenuItem("Tools/CreateMaterialsForTextures")]
    static void CreateMaterials ()
    {
        try
        {
            AssetDatabase.StartAssetEditing();

            //Create a list will all selected textures
            var textures = Selection.GetFiltered(typeof(Texture), SelectionMode.Assets).Cast<Texture>();

            //Create a new material with the standard shader
            var mat = new Material(Shader.Find("Standard"));

            //Set path for creation by borrowing it from the first texture selected
            string path = AssetDatabase.GetAssetPath(textures.First());
            path = path.Substring(0,path.LastIndexOf("."))+".mat";

            foreach(var tex in textures)
            {
                string type = AssetDatabase.GetAssetPath(tex);
                type = type.Substring(0,path.FirstIndexOf("_"))+".mat";
                if (AssetDatabase.LoadAssetAtPath(path,typeof(Material)) != null)
                {
                    Debug.LogWarning("Can't create material, it already exists: " + path);
                    continue;
                }
                mat.mainTexture = tex;
                AssetDatabase.CreateAsset(mat,path);
            }
        }
        finally
        {
            AssetDatabase.StopAssetEditing();
            AssetDatabase.SaveAssets();
        }
    }
}