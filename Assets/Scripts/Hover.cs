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
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //set the z value to "0"
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
    }

}
