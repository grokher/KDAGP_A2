using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatatSaver : MonoBehaviour
{
    //rauwe posities die uit de string zijn gehaald
    public List<string> rawObjectValues = new List<string>();
    public List<string> rawPositions = new List<string>();
    public List<string> rawNames = new List<string>();
    //

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
        //Bro waarom heb je een string genaam mayoniase?
        //Mijn antwoord is simpel. ):<

        //Slaat alle positions op in een lange string zodat deze later kan worden gedecode.
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
        //

        GameObject.Find("DeSteen").GetComponent<HenkDeSteen>().specialString = saveString;
        saveString = null;

        //Destroyed alle windows om beter te laten zien dat he saven werkt :D
        foreach(GameObject window in currentWindows)
        {
            Destroy(window);
        }
        //
    }

    public void LoadData()
    {
        //Oh god here we go. Its the chonky boio ;-;
        CleanLists();

        //+ is de modifier die alle positions seperately split zodat ze basically per gameobject worden gesplit
        string[] savedString = GameObject.Find("DeSteen").GetComponent<HenkDeSteen>().specialString.Split('+');
        

        for (int i = 0; (i + 1) <= savedString.Length;)
        {
            //Haalt de naam van het object en de posities van elkaar af
            string[] newPoss = savedString[i].Split('|');

            //Haalt de haakjes weg die om vector strings zitten i.e. (10,20,4)
            newPoss[1] = RemoveFromString(newPoss[1], "(");
            newPoss[1] = RemoveFromString(newPoss[1], ")");

            //De position manager is een leeg object die word gemoved met de positie van de window
            //Een transform is geen los variabel en heeft een Gameobject nodig. Daarvoor dus een leeg object.
            positionManager.transform.position = MakeVector(newPoss[1]);
            // Make vector uitgelegd verder benee :D

            rawNames.Add(newPoss[0]);
            rawPositions.Add(newPoss[1]);

            placer.InstantiateQuestion(newPoss[0], positionManager.transform);
            i++;
        }
    }





    //Neem de vector string en haalt deze uit elkaar om er een echt vector variabel van te maken.
    //De string wordt gedisect en in elkaar gezet als een vector die dan wordt gekoppeld aan een window
    Vector3 MakeVector(string rawPosition)
    {
        Vector3 translatedPos = new Vector3(0,0,0);

        string[] xyz = rawPosition.Split(',');
        translatedPos = new Vector3(PS(xyz[0]), PS(xyz[1]), PS(xyz[2]));
        
        //returned een vector3 is makkelijker dan een ander variable steeds aan te passen >w<
        return translatedPos;
    }
    //


    //Simplere versie om een string te parsen naar een float. (Ben lui ok laat mij)
    float PS(string parse)
    {
        float parsed = float.Parse(parse);
        return parsed;
    }
    //


    //Vraag me af wat dit doet
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

    //Haalt een string weg uit een andere string. (Wonder what happens if its the same string)
    string RemoveFromString(string baseString, string remove)
    {
        baseString = baseString.Replace(remove, "");
        return baseString;
    }
}
