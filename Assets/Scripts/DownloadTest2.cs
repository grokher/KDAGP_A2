using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;
using UnityEngine.UI;


public class DownloadTest2 : MonoBehaviour
{
    string downloadPath;
    public Text buttonText;
    public Text errorText;
    public Material cubeMat;
    [SerializeField] string[] fileNames;

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
        WWW arrayRequest = new WWW(imgURL + "download2.php", null, headers);
        



        yield return arrayRequest;

        Debug.Log(arrayRequest.text);
        fileNames = arrayRequest.text.Split('|');
        arrayRequest = new WWW(imgURL + "Images/Skyboxes/" + fileNames[3], null, headers);
        yield return arrayRequest;
        cubeMat.mainTexture = arrayRequest.texture;
            
    }


    public void StartDownloadFiles()
    {

        if (!Directory.Exists(Application.persistentDataPath + "/downloadedFiles/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/downloadedFiles/");
        }
        downloadPath = Application.persistentDataPath + "/downloadedFiles/";
        string downloadURL = "http://www.mediaenvormgeving.nl/stamgroepa2/Upload/download.php";
        WWWForm form = new WWWForm();
        form.AddField("downloadPath", downloadPath);
        WWW www = new WWW(downloadURL, form);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
            buttonText.text = "aaaaa";
            errorText.text = "WWW Ok!: " + www.text + "\n" + downloadPath.ToString();
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
            errorText.text = "WWW Error: " + www.error;
        }
    }


    [SerializeField] List<string> directories = new List<string>();
    public void DownloadFiles()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/downloadedFiles/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/downloadedFiles/");
        }


        FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://stamgroepa2%2540mediaenvormgeving.nl@mediaenvormgeving.nl/Upload/Images/Skyboxes/");
        ftpRequest.Credentials = new NetworkCredential("stamgroepa2@mediaenvormgeving.nl", "KZ93D3fB01");
        ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
        FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
        StreamReader streamReader = new StreamReader(response.GetResponseStream());
        

        string line = streamReader.ReadLine();
        while (!string.IsNullOrEmpty(line))
        {
            directories.Add(line);
            line = streamReader.ReadLine();
        }
        streamReader.Close();


        using (WebClient ftpClient = new WebClient())
        {
            ftpClient.Credentials = new System.Net.NetworkCredential("stamgroepa2@mediaenvormgeving.nl", "KZ93D3fB01");
            directories.RemoveAt(0);
            directories.RemoveAt(0);
            for (int i = 0; i <= directories.Count - 1; i++)
            {
                if (directories[i].Contains("."))
                {
                    
                    string path = "ftp://stamgroepa2%2540mediaenvormgeving.nl@mediaenvormgeving.nl/Upload/Images/Skyboxes/" + directories[i].ToString();
                    string trnsfrpth = Application.persistentDataPath + "/downloadedFiles/" + directories[i].ToString();
                    ftpClient.DownloadFile(path, trnsfrpth);
                }
            }
        }
    }
}
