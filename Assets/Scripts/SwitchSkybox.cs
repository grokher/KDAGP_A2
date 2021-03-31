using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSkybox : MonoBehaviour
{
    // what do you think this does? you can read, right?

    public ImageDownload imgDL;

    public void changeSkyBox(Material mat)
    {
        RenderSettings.skybox = mat;
    }


}
