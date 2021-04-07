using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;
using UnityEngine.UI;
using TMPro;


public class ImageDownload : MonoBehaviour
{
    string downloadPath;
    public Text materialCountText;
    public Material cubeMat;
    public GameObject contentObject;
    public GameObject buttonPrefab;
    public Image img;
    public SwitchSkybox changeSkybox;

    //dropdown menu for the download path
    public enum downloadPart
    {
        Images,
        Skyboxes
    }
    public downloadPart urlPart;

    [SerializeField] List<string> fileNames;
    [SerializeField] string[] fileName;

    WWW arrayRequest;
    public List<Material> materials = new List<Material>();
    public List<Sprite> image = new List<Sprite>();

    public void OnEnable()
    {
        foreach (Transform child in contentObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        fileName = new string[0];
        fileNames = new List<string>();
        materials = new List<Material>();
        image = new List<Sprite>();
        CreateArray();
    }


    public void CreateArray()
    {
        StartCoroutine("StartRequest");
    }

    IEnumerator StartRequest()
    {
        // creates a form that allows you to send data to a php file with headers
        WWWForm formHeaders = new WWWForm();
        var headers = formHeaders.headers;
        headers["Access-Control-Allow-Origin"] = "http://www.mediaenvormgeving.nl";

        string imgURL = "http://www.mediaenvormgeving.nl/stamgroepa2/Upload/";
        string imgURL2 = " ";

        // selects the files to download based on path set in the editor
        if (urlPart == downloadPart.Skyboxes)
        {
            arrayRequest = new WWW(imgURL + "download2.php", null, headers);
        }

        else if (urlPart == downloadPart.Images)
        {
            arrayRequest = new WWW(imgURL + "download3.php", null, headers);
        }



        // waits until the request is finished
        yield return arrayRequest;

        // splits the array of the request so the urls can be properly read
        Debug.Log(arrayRequest.text);
        fileName = arrayRequest.text.Split('|');
        fileNames = new List<string>(fileName);

        // removes the last item from the list of URLS as its always empty
        fileNames.RemoveAt(fileNames.Count - 1);
        Debug.Log(fileNames.Count);

        if (urlPart == downloadPart.Skyboxes)
        {
            imgURL2 = "Images/Skyboxes/";
        }
        else if (urlPart == downloadPart.Images)
        {
            imgURL2 = "Images/Images/";
        }

        // loops and downloads the files from the webserver
        for (int i = 0; i < fileNames.Count; i++)
        {
            arrayRequest = new WWW(imgURL + imgURL2 + fileNames[i], null, headers);
            yield return arrayRequest;
            CreateMaterial(arrayRequest, i, fileNames[i]);
        }
    }

    void CreateMaterial(WWW webReq, int imgNum, string filename)
    {
        //Debug.Log(imgNum);

        // converts images from the skybox folder into skyboxes
        if (urlPart == downloadPart.Skyboxes)
        {
            materials.Add(new Material(Shader.Find("Skybox/Panoramic")));
            materials[imgNum].mainTexture = webReq.texture;
            materials[imgNum].name = filename;
        }


        // converts images into sprites for buttons and other images
        image.Add(Sprite.Create(webReq.textureNonReadable,
                new Rect(0, 0, webReq.textureNonReadable.width, webReq.textureNonReadable.height),
                new Vector2(0, 0)));
        image[imgNum].name = filename;
        GameObject buttonpref = Instantiate(buttonPrefab, contentObject.transform);
        buttonpref.GetComponent<Image>().sprite = image[imgNum];
        buttonpref.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(filename);

        //adds an onclick function to the button to change the skybox
        buttonpref.GetComponent<Button>().onClick.AddListener(() => { changeSkybox.changeSkyBox(materials[imgNum]); });

        //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa holy fucking shit

    }

}
