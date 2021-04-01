using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBrowser : MonoBehaviour
{
    // what do you think this does? you can read, right?
    public void openTAB()
    {
        Application.ExternalEval("window.open(\"http://www.mediaenvormgeving.nl/stamgroepa2/Upload/\",\"_blank\")");
    }

}
