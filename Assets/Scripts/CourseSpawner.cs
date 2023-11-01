using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseSpawner : MonoBehaviour
{

    public GameObject refImage;
    [SerializeField]
    public TextAsset textFile;

    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject cylinderPrefab;
    public GameObject rectanglePrefab;
    public GameObject ballPrefab;
    public GameObject holePrefab;
    public GameObject planePrefab;
    public GameObject putterPrefab;

    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        if (triggerRight > 0.9f){
            ProcessText(refImage);
            this.enabled = false;
            gameController.SetActive(true);
        }
    }

    public void ProcessText(GameObject gameObject){
        Vector3 refImagePos = gameObject.transform.position;
        float refImageX = refImagePos.x;
        float refImageY = refImagePos.y;
        float refImageZ = refImagePos.z;

        string text = textFile.ToString();
        string newLine = "\n";
        string[] lines = text.Split(newLine);

        foreach (string line in lines){
            string space = " ";
            string[] lineEntries = line.Split(space);
            SpawnLine(lineEntries, new Vector3 (refImageX, refImageY, refImageZ)); 
        }
        gameObject.SetActive(false);

        //Add putter;
        Instantiate(putterPrefab, refImagePos + new Vector3(0f,0.6f,0f), Quaternion.identity);
    }

    public void SpawnLine(string[] textLine, Vector3 refImagePos){
        if (textLine.Length > 1){

            GameObject objectToBeSpawned = null;
            string objectName = textLine[0];
            float objectX = float.Parse(textLine[1]);
            float objectY = float.Parse(textLine[2]);
            float objectZ = float.Parse(textLine[3]);

            if (objectName.Contains("CubeParent")){
                objectToBeSpawned = cubePrefab;
            } else if (objectName.Contains("SphereParent")){
                objectToBeSpawned = spherePrefab;
            } else if (objectName.Contains("CylinderParent")){
                objectToBeSpawned = cylinderPrefab;
            } else if (objectName.Contains("RectangleParent")){
                objectToBeSpawned = rectanglePrefab;
            } else if (objectName.Contains("BallParent")){
                // objectToBeSpawned = ballPrefab;
                SpawnBall(ballPrefab, refImagePos);
            } else if (objectName.Contains("HoleParent")){
                objectToBeSpawned = holePrefab;
            } 
            // TODO: text file should not contain the reference image
            if (objectToBeSpawned == null){
                Debug.Log("Unknown object encountered: " + objectName);
            } else {
                Vector3 spawnPos = refImagePos;
                spawnPos += new Vector3(objectX, objectY, objectZ);
                Instantiate(objectToBeSpawned, spawnPos, Quaternion.identity);
            }
        }
        Instantiate(planePrefab, refImagePos, Quaternion.identity);
    }

    private void SpawnBall(GameObject gameObject, Vector3 pos){
        Vector3 spawnPos = pos + new Vector3(0f,0.05f,0f);
        Instantiate(gameObject, spawnPos, Quaternion.identity);
    }

}
