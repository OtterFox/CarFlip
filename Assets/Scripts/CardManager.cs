using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    //Set List prefabs in Inspector
    public List<GameObject> cardsInDeck = new List<GameObject>();
    //get index of card in List. In order to remove from list after instantiate. To avoid duplicate cards
    int ID;

    public Transform cardTrans;
    GameObject currentCard;

    GameObject currentTopCard;

    //use for built deck
    GameObject currentDeck;

    public Text cardsLeftInDeck;
    public int cardsLeftAmt;

    public bool topCard;


    private void Awake()
    {
        
       // For debugging List
       //for(int i = 0; i < cardsInDeck.Count ; i++)
       // {
       //     Debug.Log(cardsInDeck[i].name);
       // }
    }

    //Updates card via button "New Card"
    public void SelectCard()
    {

        if (topCard)
        {
            CardDestroy();
        }
        else if (!topCard)
        {
            CardPick();
        }
    }

   
    //Picks card if none is currently showing

    //Still buggy. sometimes wrong index is removed
    public void CardPick()
    {
        //Instantiate go from prefabs avaliable within List
        currentCard = Instantiate(cardsInDeck[UnityEngine.Random.Range(0, cardsInDeck.Count)], cardTrans);
        //Name card in order to get top cards index
        currentCard.name = "currentCard";
        
        //Grabs index of instantiated card in order to remove from list
        cardsInDeck.IndexOf(currentCard);

                //remove current card go from array via ID int. that grabs index from cardsInDeck.IndexOf(currentCard);
        cardsInDeck.RemoveAt(ID);

        cardsLeftAmt -= 1;
        TextUpdate();
        topCard = true;
         
    }

    //Destroys card currently showing then call to create new one
    public void CardDestroy()
    {



        //Destroy current card go
        Destroy(currentCard);
        topCard = false;
        CardPick();                  
    }


    public void TextUpdate()
    {
        cardsLeftInDeck.text = "Cards Left: " + cardsLeftAmt.ToString() + " /52";
    }

   //TODO
    public void ResetDeck()
    {
        //Pretty sure there should be dual lists in order to reload deck

    }

    //TODO
    public void RedoPick()
    {
        //use the command pattern
        //
    }

}
