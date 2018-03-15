using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public Button buttonComponent;
    public Text nameLabel;
  
    private ScrollList scrollList;
    
    public void Setup(ScrollList currentScrollList)
    {
      
        scrollList = currentScrollList;

    }

}