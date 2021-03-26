using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewArea : MonoBehaviour
{
    // Start is called before the first frame update

    List<GameObject> allAreas = new List<GameObject>();
    int currentSelected = 0;
    Transform currentArea;
    public Transform areasParent;

    public void CreateNewArea()
    {
        GameObject clean = new GameObject();
        GameObject newArea = Instantiate(clean, areasParent);
        newArea.transform.position = Vector3.zero;
        newArea.name = $"Area {allAreas.Count + 1}(name)";
        if (allAreas.Count > 0)
        {
            allAreas[allAreas.Count - 1].SetActive(false);
        }
        allAreas.Add(newArea);
        currentSelected = allAreas.Count;
        currentArea = newArea.transform;
        Destroy(clean);
    }
}
