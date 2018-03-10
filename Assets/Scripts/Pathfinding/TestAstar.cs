
using System.Collections.Generic;
using UnityEngine;

public class TestAstar : MonoBehaviour
{

    [SerializeField]
    private TileScript start, finish;

    [SerializeField]
    private GameObject arrowPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ClickTile();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Astar.GetPath(start.GridPosition,finish.GridPosition);
        }
    }
    private void ClickTile()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                TileScript temp = hit.collider.GetComponent<TileScript>();

                if (temp != null)
                {
                    if (start == null)
                    {
                        start = temp;
                        start.SpriteRenderer.color = new Color32(255, 132, 0, 255);
                        start.Debugging = true;
                    }
                    else if (finish == null)
                    {
                        finish = temp;
                        finish.Debugging = true;
                        finish.SpriteRenderer.color = new Color32(255, 0, 0, 255);
                    }
                }
            }
        }
    }

    public void ShowPath(HashSet<Node> openList, HashSet<Node> closeList)
    {
        foreach (Node node in openList)
        {
            if (node.TileRef != start)
            {
                node.TileRef.SpriteRenderer.color = Color.blue;
            }

            PointParent(node, node.TileRef.WorldPosition);
        }
        foreach (Node node in closeList)
        {
            if (node.TileRef != start && node.TileRef != finish)
            {
                node.TileRef.SpriteRenderer.color = Color.cyan;  //which is in the close list
            }

        }
    }
    private void PointParent(Node node, Vector2 position)
    {
        if (node.Parent != null)
        {
            GameObject arrow = (GameObject)Instantiate(arrowPrefab, position, Quaternion.identity);
            //Right arrow
            if ((node.GridPosition.X < node.Parent.GridPosition.X) && (node.GridPosition.Y == node.Parent.GridPosition.Y))
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            //Left arrow
            else if ((node.GridPosition.X > node.Parent.GridPosition.X) && (node.GridPosition.Y == node.Parent.GridPosition.Y))
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 180);
            }
            //Up arrow
            else if ((node.GridPosition.X == node.Parent.GridPosition.X) && (node.GridPosition.Y > node.Parent.GridPosition.Y))
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 90);
            }
            //Bottom arrow
            else if ((node.GridPosition.X == node.Parent.GridPosition.X) && (node.GridPosition.Y < node.Parent.GridPosition.Y))
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 270);
            }
            //Top-Right arrow
            else if ((node.GridPosition.X < node.Parent.GridPosition.X) && (node.GridPosition.Y > node.Parent.GridPosition.Y))
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 45);
            }
            //Top-Left arrow
            else if ((node.GridPosition.X > node.Parent.GridPosition.X) && (node.GridPosition.Y > node.Parent.GridPosition.Y))
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 135);
            }
            //Bottom-Left
            else if ((node.GridPosition.X > node.Parent.GridPosition.X) && (node.GridPosition.Y < node.Parent.GridPosition.Y))
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 225);
            }
            //Bottom-right arrow
            else if ((node.GridPosition.X < node.Parent.GridPosition.X) && (node.GridPosition.Y < node.Parent.GridPosition.Y))
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 315);
            }
        }

    }
}
