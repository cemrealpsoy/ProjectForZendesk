
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using zendeskUnityDll;

public class SampleButton : MonoBehaviour
{

    public Button buttonComponent;
    public Text nameLabel;
    public Text statusText;


    private Ticket ticket;
    private TicketsScrollList scrollList;

    // Use this for initialization
    void Start()
    {
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void Setup(Ticket currentItem, TicketsScrollList currentScrollList)
    {
        ticket = currentItem;
        nameLabel.text = ticket.id.ToString();
        statusText.text = ticket.status;
        scrollList = currentScrollList;

    }

    public void HandleClick()
    {
        scrollList.TryTransferItemToOtherShop(ticket);
    }
}