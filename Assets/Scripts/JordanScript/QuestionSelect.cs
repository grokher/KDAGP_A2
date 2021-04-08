using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSelect : MonoBehaviour
{
    private bool selected;
    public static string username;
    public static string blocked;
    public static GameObject toets;
    public static string Questionname;

    // Update is called once per frame
    void Update()
    {
        selectUser();
    }

    private void selectUser()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("mouse down, repeat mouse down");
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInfo = Physics2D.Raycast(mousePoint, Vector2.zero);
            if (hitInfo.collider != null)
            {
                Debug.Log(hitInfo.collider.name);
                selected = true;
            }
            else
            {
                //Debug.Log("where you aiming at");
            }

            /*if (Input.GetMouseButtonDown(0))
            {
                selected = false;
                Debug.Log("unselected");
            }*/

            /*bool hit = Physics2D.Raycast();
            if (hit)
            {
                Debug.Log("hit" + hitInfo.transform.gameObject.name);
            }*/
        }
        //selecting user
    }


    public  void SelectToets()
    {
        username = this.transform.GetChild(1).GetComponent<Text>().text;
        blocked = this.transform.GetChild(0).GetComponent<Text>().text;
        toets = this.gameObject.transform.parent.gameObject;
        AddQuestionToToets.question = this.transform.GetChild(1).gameObject;
        
        /*if (selected == true)
        {
            username = this.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text;
            blocked = this.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text;
            Debug.Log(username);
            Debug.Log(blocked);
        }*/
    }
}
