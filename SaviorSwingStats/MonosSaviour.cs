﻿
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

namespace SaviorSwingStats
{
	class MonosSaviour : MonoBehaviour

	{
		//public GameObject NotePlotParent;
		private GameObject[] notePlot;

		private Color noteColor = new Color(0f, 1f, 0.5f, 0.25f);



		void Awake()
		{
			//NotePlotParent = new GameObject();

			//NotePlotParent.transform.position = Vector3.zero;
			//NotePlotParent.transform.rotation = Quaternion.identity;
			//NotePlotParent.transform.localScale = Vector3.zero;

			//cutCount = 0;
			DrawNotes();
		}



		private Material SetMaterial(Color color, string name)
		{
			Material output;
			Material shaderCheck = new Material(Shader.Find("Custom/Glowing"));
			if (shaderCheck == null)
			{
				Material missingMaterial = new Material(Shader.Find("Hidden/InternalErrorShader"));
				output = missingMaterial;
			}

			else
			{
				output = shaderCheck;
			}

			output.name = name;
			output.SetColor("_Color", color);

			Logger.log.Info("Matl : " + output.name);
			Logger.log.Info("Shader    : " + output.shader.name);

			return output;
		}

		void DrawNotes()
		{
			notePlot = new GameObject[12];
			//Formuala that Beat Saber uses for note height values: 
			// return Mathf.Clamp((playerHeight - 1.8f) * 0.5f, -0.2f, 0.6f);
			float[] xGrid = { -.9f, -.3f, .3f, .9f };
			float[] yGrid = { 0.9f, 1.4f, 1.9f };

			float scale = .014f;

			int i = 0;
			for (int x = 0; x < 4; x++)
			{
				for (int y = 0; y < 3; y++)
				{
					notePlot[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					Object.DontDestroyOnLoad(notePlot[i]);
					notePlot[i].SetActive(true);
					notePlot[i].transform.SetParent(transform);
					notePlot[i].transform.position = new Vector3(xGrid[x], yGrid[y], 1f);
					notePlot[i].transform.localScale = Vector3.one * scale;
					Renderer renderer = notePlot[i].GetComponent<Renderer>();
					renderer.material = SetMaterial(noteColor, "_note_material");

					//Logger.log.Info(renderer.material.name.ToString());

					i++;
				}
			}
		}

	}
}

		//private Material FindRandomMaterial()
		//{
		//    Logger.log.Info("Finding random material");

//    Material[] materialArray = Resources.FindObjectsOfTypeAll<Material>();
//    int r = materialArray.Length;

//    return materialArray[r];


//}


//private Material FindGameMaterial()
//{
//    Material output = GetComponent<Renderer>().material;
//    Material[] MaterialArray = Resources.FindObjectsOfTypeAll<Material>();
//    foreach (Material currentMaterial in MaterialArray)
//    {
//        if (currentMaterial.name == "GridNoMirror (Instance)")
//        {
//            output = currentMaterial;
//            Logger.log.Info(output.name.ToString());
//            return output;
//        }
//        else
//        {
//            output = FindRandomMaterial();

//            Logger.log.Info(output.name.ToString());
//            return output; 
//        }
//    }
//    Logger.log.Info(output.name.ToString());
//    return output;
//}

//void DrawGrid()
//{
//    Logger.log.Info("Monosavior awake");
//    if (!gameObject.activeSelf)
//    {
//        gameObject.SetActive(true);
//        transform.position = Vector3.zero;
//    }



//    float[] xGrid = { -.9f, -.3f, .3f, .9f };
//    float[] yGrid = { 0.9f, 1.4f, 1.9f };


//    float scale = .1f;
//    Color gridColor = new Color(1f, 0f, 1f, 1f);

//    // Create a material with transparent diffuse shader

//    // Material gameMatl = new Material(Shader.Find("Custom / ObstacleCoreLW (Instance)"));



//    int i = 0;
//    for (int x = 0; x < 4; x++)
//    {
//        for (int y = 0; y < 3; y++)
//        {
//            notePlot[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
//            Object.DontDestroyOnLoad(notePlot[i]);
//            notePlot[i].SetActive(true);
//            notePlot[i].transform.SetParent(transform);
//            notePlot[i].transform.position = new Vector3(xGrid[x], yGrid[y], 1f);
//            notePlot[i].transform.localScale = Vector3.one * scale;
//            Renderer renderer = notePlot[i].GetComponent<Renderer>();
//            renderer.material.SetColor("_Color", gridColor);

//            Logger.log.Info(renderer.material.name.ToString());

//            i++;
//        }
//    }
//    //Logger.log.Info(grid[0].GetComponent<Renderer>().material.name.ToString());
//}

//        void Update()
//        {
//            if (gameObject.activeSelf)
//                return;
//            else
//            {
//                DrawGrid();
//                Logger.log.Info("Grid redrawn");
//            }
//        }
//    }
//}

//GameObject canvasGo = new GameObject("Canvas", typeof(Canvas));

//canvasGo.transform.parent = transform;
//_canvas.renderMode = RenderMode.WorldSpace;

//var canvasTransform = _canvas.transform;
//var canvasRectTransfrorm = _canvas.GetComponent<RectTransform>();

//canvasTransform.position = new Vector3(0f, 0f, 2.5f);
//canvasTransform.localScale = Vector3.one;

//// _currentTimeText = CreateText(_canvas, new Vector2(0f, 0f), "");


//SceneManager.sceneLoaded += OnSceneLoaded;
//SceneManager.sceneUnloaded += OnSceneUnloaded;
//SceneManager.activeSceneChanged += OnActiveSceneChanged;



//private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//{
//    Logger.log.Info("OnSceneLoaded: " + scene.name + " (" + mode + ")");
//}

//private void OnSceneUnloaded(Scene scene)
//{
//    Logger.log.Info("OnSceneUnloaded: " + scene.name);
//}

//private void OnActiveSceneChanged(Scene previous, Scene current)
//{
//    Logger.log.Info("OnActiveSceneChanged: " + previous.name + " -> " + current.name);
//}

//public void OnNoteCut(INoteController noteController, NoteCutInfo cutInfo)
//{
//    NoteData note = noteController.noteData;
//    if (note.noteType == NoteType.Bomb)
//        return;

//    else
//    {
//    }
//}
//public void OnNoteMissed(NoteData note, int multiplier)
//{
//    if (note.noteType == NoteType.Bomb)
//        return;
//    else
//    {
//    }
//}

//DrawGrid();



//cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//Object.DontDestroyOnLoad(cube);

//cube.transform.SetParent(transform);
//cube.transform.SetPositionAndRotation(transform.position, Quaternion.identity);

//cube.transform.position = new Vector3(.3f, .8f,1.5f);
//Logger.log.Info(cube.GetComponent<Renderer>().material.ToString());
//Logger.log.Info(cube.GetComponent<Renderer>().material.color.ToString());
//Logger.log.Info(cube.GetComponent<Renderer>().material.ToString());
//Logger.log.Info(cube.transform.localScale.ToString());



//defaultMaterial = GetComponent<Renderer>().material;
//Logger.log.Info("Monosavior awake");
//Material[] materialArray = Resources.FindObjectsOfTypeAll<Material>();
//foreach (Material material in materialArray)
//{
//    Logger.log.Info("Matl: " + material.name.ToString());
//    Logger.log.Info("Shader    : " + material.shader.name.ToString());

//}


// Create a material with transparent diffuse shader

// Material gameMatl = new Material(Shader.Find("Custom / ObstacleCoreLW (Instance)"));
//Renderer rendA = objA.GetComponent<Renderer>();
//rendA.material = myMaterial;