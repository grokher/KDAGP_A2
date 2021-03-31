using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSkybox : MonoBehaviour
{
    public ImageDownload imgDL;

    public void changeSkyBox(Material mat)
    {
        RenderSettings.skybox = mat;
    }


}
