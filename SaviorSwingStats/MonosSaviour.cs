
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


namespace SaviorSwingStats
{
    class MonosSaviour : MonoBehaviour

    {
        private GameObject[] noteGrid;
        //private Canvas _canvas;
        //private TextMeshProUGUI marker;
        //RectTransform canvasRT;

        void Awake()
        {
            Logger.log.Info("Monosavior awake");
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);

            }
            noteGrid = new GameObject[12];

            transform.position = Vector3.zero;
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Object.DontDestroyOnLoad(cube);

            cube.transform.SetParent(transform);
            cube.transform.SetPositionAndRotation(transform.position, Quaternion.identity);

            cube.transform.position = new Vector3(.3f, .8f,1.5f);
            Logger.log.Info(cube.GetComponent<Renderer>().material.ToString());
            Logger.log.Info(cube.GetComponent<Renderer>().material.color.ToString());
            Logger.log.Info(cube.GetComponent<Renderer>().material.ToString());
            Logger.log.Info(cube.transform.localScale.ToString());


            Logger.log.Info("Monosavior awake");
        }

        void CreateNoteGrid()
        { 
        //float[] xGrid = { -.9f, -.3f, .3f, .9f };
        //float[] yGrid = { 0.83f, 1.38f, 1.88f };
        //int i = 0;

        //Vector3 scale = new Vector3(0.5f, 0.5f, 0.5f);
        //for (int x = 0; x < 4; x++)
        //{
        //    for (int y = 0; y < 3; y++)
        //    {
        //        gridPlane[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //        gridPlane[i].transform.position = new Vector3(xGrid[x], yGrid[y], 1f);
        //        gridPlane[i].transform.localScale = scale;
        //        Renderer renderer = gridPlane[i].GetComponent<Renderer>();
        //        renderer.material = materialCopy;
        //        materialCopy.SetColor("_Color", Color.white);

        //        i++;
        //    }
        //    Logger.log.Info("Grid created");
        //}

        void Update()
        {
            if (!cube.activeSelf)
            {
                cube.SetActive(true);
            }
        }

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
    }
}
