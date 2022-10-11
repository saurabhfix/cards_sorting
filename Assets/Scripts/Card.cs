using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Image cardImage;
    public int cardNumber;
    public int index;
    bool isDrag, isDrop;

    public Vector3 startPos;
    Transform dropGameObject;

    // Start is called before the first frame update

    //take it in other gameobect and then move both, if both are same then only move or put cards if both are same only
    //initially off raycast and move cards as a child of other gameobject.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isDrop = true;
        dropGameObject = collision.transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isDrop = false;
    }

    private void Update()
    {
        if (isDrag)
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    public void OnStartDrag()
    {
        // if(transform.parent.GetComponentsInChildren<Image>().)

        startPos = transform.position;
        var slotChild = transform.parent.GetComponentsInChildren<Card>();
        if (transform.GetComponent<Card>().index == slotChild.Length - 1)
        {
            /* foreach (var item in slotChild)
             {
                 item.gameObject.SetActive(false);
             }*/
            isDrag = true;
        }
        else
        {
           /* for (int i = transform.GetComponent<Card>().index; i < slotChild.Length; i++)
            {
                slotChild[i].cardNumber
            }*/
        }       
    }

    public void OnEndDrag()
    {
        isDrag = false;

            print(isDrop);

        if (isDrop && !(transform.parent == dropGameObject.transform))
        {
            var cardsInSlot = dropGameObject.GetComponentsInChildren<Card>().Length;
            if (cardsInSlot < GameManager.Instance.maxCardEachSlot)
            {
                transform.GetComponent<RectTransform>().anchoredPosition = dropGameObject.GetComponent<RectTransform>().anchoredPosition;
                transform.position = dropGameObject.position - new Vector3(0, 80, 0) * cardsInSlot;
                transform.parent = dropGameObject;
                transform.GetComponent<Card>().index = cardsInSlot;

                if (cardsInSlot == GameManager.Instance.maxCardEachSlot - 1)
                {
                    //check for right 
                    var all = dropGameObject.GetComponent<CardContainer>().CardsInSlot();
                    var slotChild = dropGameObject.GetComponentsInChildren<Card>();
                    if (all)
                    {
                        foreach (var item in slotChild)
                        {
                            item.gameObject.SetActive(false);
                        }

                    }    

                }
            }
            else
            { 
                transform.position = startPos;
            }
        }
        else
        {
            //print("dddddddddd");

            transform.position = startPos;
        }
    }
}
