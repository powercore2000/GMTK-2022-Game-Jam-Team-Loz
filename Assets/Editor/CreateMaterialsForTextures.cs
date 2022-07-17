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
            string ogPath = path;
            path = path.Substring(0,path.IndexOf("_"))+".mat";

            foreach(var tex in textures)
            {
                string type = AssetDatabase.GetAssetPath(tex);
                type = type.Substring(type.LastIndexOf("_")+1);
                if (AssetDatabase.LoadAssetAtPath(path,typeof(Material)) != null)
                {
                    Debug.LogWarning("Can't create material, it already exists: " + path + "creating extra");
                    path = ogPath.Substring(0,ogPath.LastIndexOf("_"))+".mat";
                }

                switch(type){
                    case "color.jpg":
                    mat.SetTexture("_MainTex", tex);
                    break;

                    case "Metallic.jpg":
                    mat.SetTexture("_MetallicGlossMap", tex);
                    break;

                    case "Normal.jpg":
                    mat.SetTexture("_BumpMap", tex);
                    break;

                    case "Height.jpg":
                    mat.SetTexture("_ParallaxMap", tex);
                    break;

                    case "AO.jpg":
                    mat.SetTexture("_OcclusionMap", tex);
                    break;

                    case "Roughness.jpg":
                    mat.SetTexture(" _DetailMask", tex);
                    break;
                }
            }
               
            AssetDatabase.CreateAsset(mat,path);
            
        }
        finally
        {
            AssetDatabase.StopAssetEditing();
            AssetDatabase.SaveAssets();
        }
    }
}