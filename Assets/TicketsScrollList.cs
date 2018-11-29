
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using zendeskUnityDll;


public class TicketsScrollList : MonoBehaviour
{

    public TicketProxy _ticketProxy = new TicketProxy();
    public List<Ticket> itemList ;
    public Transform contentPanel;
    public TicketsScrollList otherShop;
    public Text myGoldDisplay;
    public SimpleObjectPool buttonObjectPool;
    public GameObject prefab;

    public float gold = 20f;


    // Use this for initialization
    void Start()
    {
        Ticket t1 = new Ticket();
        t1.id = 123;
        t1.description = "deneme";
        t1.status = "status";
        t1.subject = "subject";
        Ticket t2 = new Ticket();
        t2.id = 123;
        t2.description = "deneme2";
        t2.status = "status2";
        t1.subject = "subject2";
        List<Ticket> list = new List<Ticket>();
        list.Add(t1);
        list.Add(t2);
        itemList = list;
        //  itemList = _ticketProxy.List();
        RefreshDisplay();
    }

    void RefreshDisplay()
    {
        //myGoldDisplay.text = "Gold: " + gold.ToString();
        AddButtons();
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons()
    {
        List<GameObject> ll = new List<GameObject>();
        for (int i = 0; i < itemList.Count; i++)
        {
            Ticket item = itemList[i];
            //   GameObject newButton = buttonObjectPool.GetObject();

            GameObject obj = (GameObject)Instantiate(prefab);
            obj.transform.SetParent(contentPanel);
            ll.Add(obj);

            SampleButton sampleButton = obj.GetComponent<SampleButton>();
            sampleButton.Setup(item, this);
        }
    }

    public void TryTransferItemToOtherShop(Ticket item)
    {
        //if (otherShop.gold >= item.price)
        //{
        //    gold += item.price;
        //    otherShop.gold -= item.price;

        //    AddItem(item, otherShop);
        //    RemoveItem(item, this);

        //    RefreshDisplay();
        //    otherShop.RefreshDisplay();
        //    Debug.Log("enough gold");

        //}
        Debug.Log("attempted");
    }

    void AddItem(Ticket itemToAdd, TicketsScrollList shopList)
    {
        shopList.itemList.Add(itemToAdd);
    }

    private void RemoveItem(Ticket itemToRemove, TicketsScrollList shopList)
    {
        for (int i = shopList.itemList.Count - 1; i >= 0; i--)
        {
            if (shopList.itemList[i] == itemToRemove)
            {
                shopList.itemList.RemoveAt(i);
            }
        }
    }
}