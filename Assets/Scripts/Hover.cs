using UnityEngine;

public class Hover : Singleton<Hover>
{

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        //setting sprite renderer
        this.spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        FollowingToMouse();
		
	}

    private void FollowingToMouse()
    {
        if (spriteRenderer.enabled)
        {
            //set mouse position into a world position
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        
    }

    public void ShowHover(Sprite sprite)
    {
        this.spriteRenderer.sprite = sprite;
        spriteRenderer.enabled = true;
    }

    public void HideHover()
    {
        spriteRenderer.enabled = false;

        GameManager.Instance.ClickedButton = null;
    }

}
