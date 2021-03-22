using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatatSaver : MonoBehaviour
{
    public List<string> rawObjectValues = new List<string>();
    public List<string> rawPositions = new List<string>();
    public List<string> rawNames = new List<string>();

    string saveString;

    public void SavePosition(GameObject newWindow)
    {
        string addToList;
        string betterPos;

        betterPos = "" + newWindow.transform.position;

        RemoveFromString(betterPos, "(");
        RemoveFromString(betterPos, ")");

        addToList = newWindow.name + "|" + betterPos;

        rawObjectValues.Add(addToList);

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
    }

    public void LoadData()
    {
        string[] savedString = GameObject.Find("DeSteen").GetComponent<HenkDeSteen>().specialString.Split('+');

        for (int i = 0; (i + 1) <= savedString.Length;)
        {
            string[] newPoss = savedString[i].Split('|');
            Debug.Log(newPoss);

            rawNames.Add(newPoss[0]);
            rawPositions.Add(newPoss[1]);
            i++;
        }
    }








    void CleanLists()
    {
        rawObjectValues = new List<string>();
        rawPositions = new List<string>();
        rawNames = new List<string>();
    }


    void RemoveFromString(string baseString, string remove)
    {
        baseString = baseString.Replace(remove, "");
    }
}
