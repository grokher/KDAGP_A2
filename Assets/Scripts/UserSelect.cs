using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserSelect : MonoBehaviour
{
    private bool selected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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


    public  void blockUser()
    {
        Debug.Log("presed");
        if (selected == true)
        {

        }
    }
}
