using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;

public class UploadTest : MonoBehaviour
{

    public string FTPHost = "ftp://stamgroepa2%2540mediaenvormgeving.nl@mediaenvormgeving.nl/Upload/Images/Skyboxes/";

    public string FTPUserName = "stamgroepa2@mediaenvormgeving.nl";

    public string FTPPassword = "KZ93D3fB01";

    public string FilePath;

    // Start is called before the first frame update
    void Start()
    {
        Upload();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Upload()
    {
        WebClient client = new System.Net.WebClient();

        Uri uri = new Uri(FTPHost + "/" + new FileInfo(FilePath).Name);

        client.Credentials = new System.Net.NetworkCredential(FTPUserName, FTPPassword);

        client.UploadFileAsync(uri, "STOR", FilePath);
    }
}
