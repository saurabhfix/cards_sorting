using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    public bool isFilled;
    public bool isSorted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CardsInSlot()
    {
        var cards = GetComponentsInChildren<Card>();
        List<int> cardsInSlot = new List<int>();

        foreach (var card in cards)
            cardsInSlot.Add(card.cardNumber);
        
        bool isAllEqual = cardsInSlot.Distinct().Count() == 1;
        return isAllEqual;
    }
}
