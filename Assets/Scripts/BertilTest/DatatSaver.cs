using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatatSaver : MonoBehaviour
{
    public List<string> rawObjectValues = new List<string>();
    public List<string> rawPositions = new List<string>();
    public List<string> rawNames = new List<string>();

    public GameObject positionManager;
    
    protected List<GameObject> currentWindows = new List<GameObject>();

    string saveString;

    QuestionPlacer placer;

    private void Start()
    {
        placer = this.gameObject.GetComponent<QuestionPlacer>();
    }

    public void SavePosition(GameObject newWindow)
    {
        string addToList;
        string betterPos;

        betterPos = "" + newWindow.transform.position;

        addToList = newWindow.name + "|" + betterPos;

        rawObjectValues.Add(addToList);

        currentWindows.Add(newWindow);

    }

    public void SaveData()
    {

        foreach (string mayoniase in rawObjectValues)
        {
            if (saveString != null)
            {
                saveString = saveString + '+' + mayoniase;
            }
            else
            {
                saveString = mayoniase;
            }
        }

        GameObject.Find("DeSteen").GetComponent<HenkDeSteen>().specialString = saveString;
        saveString = null;

        foreach(GameObject window in currentWindows)
        {
            Destroy(window);
        }
    }

    public void LoadData()
    {
        CleanLists();

        string[] savedString = GameObject.Find("DeSteen").GetComponent<HenkDeSteen>().specialString.Split('+');
        
        for (int i = 0; (i + 1) <= savedString.Length;)
        {
            string[] newPoss = savedString[i].Split('|');

            newPoss[1] = RemoveFromString(newPoss[1], "(");
            newPoss[1] = RemoveFromString(newPoss[1], ")");


            positionManager.transform.position = MakeVector(newPoss[1]);


            rawNames.Add(newPoss[0]);
            rawPositions.Add(newPoss[1]);

            placer.InstantiateQuestion(newPoss[0], positionManager.transform);
            i++;
        }
    }






    Vector3 MakeVector(string rawPosition)
    {
        Vector3 translatedPos = new Vector3(0,0,0);

        string[] xyz = rawPosition.Split(',');
        translatedPos = new Vector3(PS(xyz[0]), PS(xyz[1]), PS(xyz[2]));

        Debug.Log(translatedPos);
        return translatedPos;
    }

    float PS(string parse)
    {
        float parsed = float.Parse(parse);
        return parsed;
    }

    void CleanLists()
    {
        rawObjectValues = new List<string>();
        rawPositions = new List<string>();
        rawNames = new List<string>();
        foreach (GameObject window in currentWindows)
        {
            Destroy(window);
        }
    }


    string RemoveFromString(string baseString, string remove)
    {
        baseString = baseString.Replace(remove, "");
        return baseString;
    }
}
