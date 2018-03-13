
using UnityEngine;

public class BuildingButton : MonoBehaviour {

    [SerializeField]
    private GameObject buildingPrefab;

    [SerializeField]
    private Sprite sprite;

    public GameObject BuildingPrefab
    {
        get
        {
            return buildingPrefab;
        }
    }

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
     }

    
}
