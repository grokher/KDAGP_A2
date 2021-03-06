﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;
using UnityEngine.UI;


public class ImageDownload2 : MonoBehaviour
{
    string downloadPath;
    public Text materialCountText;
    public Material cubeMat;
    [SerializeField] string[] fileNames;
    [SerializeField] List<Sprite> image = new List<Sprite>();

    private void Start()
    {
        CreateArray();
    }

    public void CreateArray()
    {
        StartCoroutine("StartRequest");
    }

    IEnumerator StartRequest()
    {
        WWWForm formHeaders = new WWWForm();
        var headers = formHeaders.headers;
        headers["Access-Control-Allow-Origin"] = "http://www.mediaenvormgeving.nl";

        string imgURL = "http://www.mediaenvormgeving.nl/stamgroepa2/Upload/";
        WWW arrayRequest = new WWW(imgURL + "download3.php", null, headers);
        



        yield return arrayRequest;

        Debug.Log(arrayRequest.text);
        fileNames = arrayRequest.text.Split('|');
        Debug.Log(fileNames.Length);
        for (int i = 0; i < fileNames.Length; i++)
        {
            arrayRequest = new WWW(imgURL + "Images/Images/" + fileNames[i], null, headers);
            yield return arrayRequest;
            CreateMaterial(arrayRequest, i, fileNames[i]);
        }
        image.RemoveAt(image.Count - 1);
        materialCountText.text = image.Count.ToString();
    }

    void CreateMaterial(WWW webReq, int imgNum, string filename)
    {
        //Debug.Log(imgNum);
        //materials.Add(new Material(Shader.Find("Skybox/Panoramic")));
        //materials[imgNum].mainTexture = webReq.texture;
        //materials[imgNum].name = filename; 
        image.Add(Sprite.Create(webReq.textureNonReadable,
                new Rect(0, 0, webReq.textureNonReadable.width, webReq.textureNonReadable.height),
                new Vector2(0, 0)));
        image[imgNum].name = filename;


        //a


        //tempmat[imgNum] = new Material(Shader.Find("Skybox/Panoramic"));
        //tempmat[imgNum].mainTexture = webReq.texture;

        //materials.Add(tempmat[imgNum]);

    }

}
