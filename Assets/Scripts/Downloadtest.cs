using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;

public class Downloadtest : MonoBehaviour
{
    // Start is called before the first frame update

    NetworkCredential login = new NetworkCredential("stamgroepa2@mediaenvormgeving.nl", "KZ93D3fB01");
    string baseURL = "ftp://stamgroepa2%2540mediaenvormgeving.nl@mediaenvormgeving.nl/Upload/Images/Skyboxes/";
    string filePath = "";
    void DownloadFtpDirectory(string url, NetworkCredential credentials, string localPath)
    {
        FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(new Uri(url));
        listRequest.UsePassive = true;
        listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        listRequest.Credentials = credentials;

        List<string> lines = new List<string>();

        using (WebResponse listResponse = listRequest.GetResponse())
        using (Stream listStream = listResponse.GetResponseStream())
        using (StreamReader listReader = new StreamReader(listStream))
        {
            while (!listReader.EndOfStream)
            {
                lines.Add(listReader.ReadLine());
            }
        }

        foreach (string line in lines)
        {
            string[] tokens =
                line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[8];
            string permissions = tokens[0];

            string localFilePath = Path.Combine(localPath, name);
            string fileUrl = url + name;

            if (permissions[0] == 'd')
            {
                Directory.CreateDirectory(localFilePath);
                DownloadFtpDirectory(fileUrl + "/", credentials, localFilePath);
            }
            else
            {
                FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                downloadRequest.UsePassive = true;
                downloadRequest.UseBinary = true;
                downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                downloadRequest.Credentials = credentials;

                using (Stream ftpStream = downloadRequest.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(localFilePath))
                {
                    ftpStream.CopyTo(fileStream);
                }
            }
        }
    }

    void Start()
    {
        filePath = Application.persistentDataPath + "/downloadedFiles";
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        DownloadFtpDirectory(baseURL, login, filePath);
    }

#if UNITY_EDITOR
    private void Awake()
    {
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        //path = Path.Combine(path, "H");
        //downloadWithFTP("ftp://stamgroepa2%2540mediaenvormgeving.nl@mediaenvormgeving.nl/Images/561798.jpg", path, "stamgroepa2@mediaenvormgeving.nl", "KZ93D3fB01");
    }

    private byte[] downloadWithFTP(string ftpUrl, string savePath = "", string userName = "", string password = "")
    {
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftpUrl));
        //request.Proxy = null;

        request.UsePassive = true;
        request.UseBinary = true;
        request.KeepAlive = true;

        //If username or password is NOT null then use Credential
        if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
        {
            request.Credentials = new NetworkCredential(userName, password);
        }

        request.Method = WebRequestMethods.Ftp.DownloadFile;

        //If savePath is NOT null, we want to save the file to path
        //If path is null, we just want to return the file as array
        if (!string.IsNullOrEmpty(savePath))
        {
            downloadAndSave(request.GetResponse(), savePath);
            return null;
        }
        else
        {
            return downloadAsbyteArray(request.GetResponse());
        }
    }

    byte[] downloadAsbyteArray(WebResponse request)
    {
        using (Stream input = request.GetResponseStream())
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while (input.CanRead && (read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }

    void downloadAndSave(WebResponse request, string savePath)
    {
        Stream reader = request.GetResponseStream();

        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(savePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(savePath));
        }

        FileStream fileStream = new FileStream(savePath, FileMode.Create);


        int bytesRead = 0;
        byte[] buffer = new byte[2048];

        while (true)
        {
            bytesRead = reader.Read(buffer, 0, buffer.Length);

            if (bytesRead == 0)
                break;

            fileStream.Write(buffer, 0, bytesRead);
        }
        fileStream.Close();
    }


#endif
}
