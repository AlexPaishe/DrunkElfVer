using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCardScript : MonoBehaviour
{
    public int Race; //Раса карты сброса
    public int Specialization;// Специализация карты сброса (лучник, воин, маг, ассассин, демиург или некромант)
    public int ForceCard; //Сила карты
    public Image BattleImage;//Картинка карты
    public Card SelfCard;//Все данные карты
    public Text Name;// Имя персонажа
    public Image Icon;
    public Image Number;
    public Sprite[] AllNumber;
    public Sprite[] AllIcon;

    private void ShowCardInfo(Card card)//Получение карты при старте игры
    {
        SelfCard = card;
        Race = card.Race;
        Specialization = card.Specialization;
        ForceCard = card.ForceCard;
        BattleImage.sprite = card.Logo;
        Name.text = card.Name;

    }

    private void Start()
    {
        BattleImage = GetComponent<Image>();
        CardManagerScript cardMan = FindObjectOfType<CardManagerScript>();
        ShowCardInfo(CardManager.AllCards[Random.Range(0, cardMan.CardVariation.Length - 20)]);
        InstallCardIconAndNumber();
        Debug.Log($" Раса {Race} Сила {ForceCard} Специализация {Specialization} картинка {BattleImage.sprite.name}");
    }

    public void InstallCardIconAndNumber()
    {
        for(int i = 0; i< AllNumber.Length;i++)
        {
            if(i == ForceCard - 1)
            {
                Number.sprite = AllNumber[i];
            }
        }
        
        for(int i = 0; i< AllIcon.Length; i++)
        {
            if(i == Specialization - 1 && Race<4)
            {
                Icon.sprite = AllIcon[i];
            }
            else if(  Race == 4 ) 
            {
                Icon.sprite = AllIcon[AllIcon.Length - 2];
            }
            else if(Race == 5)
            {
                Icon.sprite = AllIcon[AllIcon.Length - 1];
            }
        }
    }
}
