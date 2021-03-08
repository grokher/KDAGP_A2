using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System.Data.SqlClient;


public class GetUserList : MonoBehaviour
{
    public string URL;
    public Text userdata;
   

    private static void CreateCommand(string queryString, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT username, id,isBlocked FROM users ORDER BY isBlocked");

            command.Connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Userinfo> UsersData = new List<Userinfo>();
            while (reader.Read())
            {
                Userinfo U = new Userinfo();
                U.username = (string) reader["username"];
                U.id = (string)reader["id"];
                U.isBlocked = (string)reader["isBlocked"];
                UsersData.Add(U);
            }

            command.ExecuteNonQuery();
        }
    } 

    void Awake()
    {

        StartUpUserList();
    }

    void Start()
    {

    }

    public void StartUpUserList()
    {
        StartCoroutine(GetUsersList());

    }
    
    IEnumerator GetUsersList()
    {
       
        WWW w = new WWW(URL);

        //UsersData.Add(w.ToString());
            yield return w;


            if (w.isDone)
            {

                if (w.text.Contains("Error"))
                {
                    Debug.Log(w.error);
                }
                else
                {
                    /*Userinfo userinfo = new Userinfo();
                    userinfo = JsonUtility.FromJson<Userinfo>(w.text);*/
                    foreach (string username in UsersData)
                    {

                    }
                    userdata.text = w.text;

                    //JsonUtility.FromJson<object>(w.text);
                    //KeepInfo.JsonConvertor(w);

                }

                //Debug.Log(w.text[0][0]);

            }


        w.Dispose();
    }
}

public class Userinfo
{
    public string username { set; get; }
    public string id { set; get; }
    public string isBlocked { set; get; }
}