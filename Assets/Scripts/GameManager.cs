using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Card[] cardPrefab;
    [SerializeField] CardContainer[] cardSlots;
    [SerializeField] List<Card> card;

    private static GameManager instance;
    static public GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public int maxCardEachSlot;
    public int maxSlotAlloted;

    private void Start()
    {
        for (int i = 0; i < maxSlotAlloted; i++)
        {
            for (int j = 0; j < maxCardEachSlot; j++)
            {
                //instantite card prefab, 
                var newCard = Instantiate(cardPrefab[i]);
                card.Add(newCard);
            }
        }

        for (int i = 0; i < maxSlotAlloted; i++)
        {
            //random slot
            var randomSlot = RandomSlotNumber();
            for (int j = 0; j < maxCardEachSlot; j++)
            {
                var randomCard = Random.Range(0, card.Count);
                card[randomCard].transform.parent = cardSlots[randomSlot].transform;
                card[randomCard].index = j;
                card[randomCard].GetComponent<RectTransform>().anchoredPosition = cardSlots[randomSlot].GetComponent<RectTransform>().anchoredPosition - new Vector2(0, 80) * j;
                card.RemoveAt(randomCard);
            }
        }
    }

    int RandomSlotNumber()
    {
        var random = Random.Range(0, cardSlots.Length);

        if (!cardSlots[random].isFilled)
        {
            cardSlots[random].isFilled = true;
            return random;
        }
        else
        {
            return RandomSlotNumber();
        }
    }

    
}
