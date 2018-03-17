using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class ScrollList : MonoBehaviour
{
     public Transform contentPanel;
     public ButtonObjectPool buttonObjectPool;

    void Start()
    {
        AddButtons();
    }

   
    private void AddButtons()
    {
        for (int i = 0; i < 500; i++)
        {
           
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            Buttons sampleButton = newButton.GetComponent<Buttons>();
          
            sampleButton.Setup(this);
        }
    }

   
}