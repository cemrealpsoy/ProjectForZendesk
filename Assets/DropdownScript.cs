using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using zendeskUnityDll;

public class DropdownScript : MonoBehaviour {

    Dropdown m_Dropdown;
    Dropdown.OptionData m_NewOption;
    TicketProxy _ticketProxy = new zendeskUnityDll.TicketProxy();
    List<Ticket> tickets;
    List<string> options = new List<string>(); 
    void Start()
    {
        Ticket t1 = new Ticket();
        t1.id = 123;
        t1.description = "deneme";
        t1.status = "status";
        t1.subject = "subject";
        Ticket t2 = new Ticket();
        t2.id = 234;
        t2.description = "deneme2";
        t2.status = "status2";
        t2.subject = "subject2";
        List<Ticket> list = new List<Ticket>();
        list.Add(t1);
        list.Add(t2);
        tickets = list;
        //tickets = _ticketProxy.List();
        foreach (var ticket in tickets)
        {
            options.Add(ticket.id.ToString());
        }
        if(tickets.Count > 0)
        {
            SetFields(tickets[0]);
        }
        //Fetch the Dropdown GameObject
        m_Dropdown = GetComponent<Dropdown>();
        m_Dropdown.ClearOptions();
        m_Dropdown.AddOptions(options);

        //Add listener for when the value of the Dropdown changes, to take action
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });

        //Initialise the Text to say the first value of the Dropdown
        Debug.Log("First Value : " + m_Dropdown.value);
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change)
    {
        for(int counter=0 ; counter < tickets.Count; counter++)
        {
            Ticket ticket = tickets[counter];
            if (counter == change.value)
            {
                SetFields(ticket);
            }
        }
    }
    void SetFields(Ticket ticket)
    {
        InputField txt_Input = GameObject.Find("StatusInputField").GetComponent<InputField>();
        txt_Input.text = ticket.status;
        txt_Input = GameObject.Find("SubjectInputField").GetComponent<InputField>();
        txt_Input.text = ticket.subject;
        txt_Input = GameObject.Find("DescriptionInputField").GetComponent<InputField>();
        txt_Input.text = ticket.description;
    }
}
