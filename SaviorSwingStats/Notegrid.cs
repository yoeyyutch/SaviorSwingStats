using BS_Utils.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SaviorSwingStats
{
    internal class Notegrid : MonoBehaviour
    {
        //public static IEnumerable<Material> AllMaterials { get; private set; }
        //private Material materialCopy;
        private GameObject[] gridPlane = new GameObject[12];

        //private GameObject[] gridPlane;

        public Notegrid()
        {
            Logger.log.Info("Notegrid.start called.");
            
           // materialCopy = FindObjectsOfType<Material>().FirstOrDefault();
            //Logger.log.Info(materialCopy.name);

        }

        void DrawCube()
        {
            Logger.log.Info("DrawCube called");
            Color alphagray = new Color(0.75f, 0.75f, 0.75f, 1f);
            GameObject cute = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Logger.log.Info("Cube Created");
            cute.transform.position = new Vector3(0f, 1f, -1f);
            MeshRenderer renderer = cute.GetComponent<MeshRenderer>();
            renderer.material.SetColor("_Color", alphagray);
            Logger.log.Info(cute.GetComponent<MeshRenderer>().material.name);
            Logger.log.Info(cute.GetComponent<MeshRenderer>().material.color.ToString());
        }

        void DrawGrid()
        {
            float[] xGrid = { -.9f, -.3f, .3f, .9f };
            float[] yGrid = { 0.83f, 1.38f, 1.88f };
            int i = 0;

            Vector3 scale = new Vector3(0.5f, 0.5f, 0.5f);
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    gridPlane[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    gridPlane[i].transform.position = new Vector3(xGrid[x], yGrid[y], 1f);
                    gridPlane[i].transform.localScale = scale;
                    Renderer renderer = gridPlane[i].GetComponent<Renderer>();
                    renderer.material = materialCopy;
                    materialCopy.SetColor("_Color", Color.white);

                    i++;
                }
                Logger.log.Info("Grid created");
            }

    }

}
//if(gridPlane[0]==null)
//{
//    Logger.log.Info("gridplane is null");

//}
//Logger.log.Info(gridPlane[0].transform.position.ToString());



//materialCopy = Utilities.UiNoGlow;

//DrawGrid();

//if (MaterialExists("Galaxy"))
//{
//    Logger.log.Info("Found material");
//    DrawGrid();
//}
//else
//{
//    Logger.log.Info("Didn't find the material");
//    DrawGrid();
//}

//private bool MaterialExists(string name)
//{
//    return true;
//AllMaterials = Resources.FindObjectsOfTypeAll<Material>();

//foreach (Material matl in AllMaterials)
//{
//    if (matl.name.Contains(name))
//    {
//        string materialOriginal = matl.name;
//        materialCopy = matl;

//        Logger.log.Info("Origninal material name = " + materialOriginal);
//        materialCopy.name = materialOriginal + " (Instance)";
//        Shader originalShader = materialCopy.shader;
//        Logger.log.Info("Copy name = " + materialCopy.name);
//        Logger.log.Info("Shader name = " + originalShader.name);
//        return true;
//    }
//}

//return false;
//}

//private void DrawGrid()
//{

//    Color alphagray = new Color(0.5f, 0.5f, 0.5f, 0.5f);


//foreach(GameObject gridPositon in gridPlane)
//{
//    MeshRenderer renderer = gridPositon.GetComponent<MeshRenderer>();
//    renderer.material = materialCopy;
//}


//if (materialCopy == null)
//{
//    materialCopy = Utilities.UiNoGlow;
//    Logger.log.Info("Error: Material not found");
//    return;
//}

//else

//{
//Logger.log.Info("Starting foreach loop for drawing grid");


//}

//}
//}






