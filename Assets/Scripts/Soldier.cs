using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Soldier : MonoBehaviour
{
    
    [SerializeField]
    private float speed;

    
    private Stack<Node> path;

    
    public Coordinate GridPosition { get; set; }

   
    public bool IsActive { get; set; }

    
    private Vector3 destination;

    private void Update()
    {
        Move();
    }


    public void Spawn()
    {
        transform.position = Map.Instance.SoldierSpawn.transform.position;


        //Starts to scale the soldier
        StartCoroutine(Scale(new Vector3(0.1f, 0.1f), new Vector3(1, 1)));

        //Sets the monsters path
        SetPath(Map.Instance.Path, false);
    }

    public IEnumerator Scale(Vector3 from, Vector3 to)
    {
        //The scaling progress
        float progress = 0;

        //As long as the progress is les than 1, then we need to keep scaling
        while (progress <= 1)
        {
            //Scales themonster
            transform.localScale = Vector3.Lerp(from, to, progress);
            progress += Time.deltaTime;
            yield return null;
        }

        //Makes sure that is has the correct scale after scaling
        transform.localScale = to;

        IsActive = true;
    }

   
    public void Move()
    {
        if (IsActive)
        {
            //Move the unit towards the next destination
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);

            //Checks if we arrived at the destination
            if (transform.position == destination)
            {
                //If we have a path and we have more nodes, then we need to keep moving
                if (path != null && path.Count > 0)
                {
                    //Sets the new gridPosition
                    GridPosition = path.Peek().GridPosition;

                    //Sets a new destination
                    destination = path.Pop().WorldPosition;

                }
            }
        }

    }

    
    public void SetPath(Stack<Node> newPath, bool active)
    {
        if (newPath != null) //If we have a path
        {
            //Sets the new path as the current path
            this.path = newPath;

            //Sets the new gridPosition
            GridPosition = path.Peek().GridPosition;

            //Sets a new destination
            destination = path.Pop().WorldPosition;
        }
    }

   

}
