using UnityEngine;
using System.Collections;

public class Script_Meteor : MonoBehaviour {

	// Use this for initialization
    Vector3 Direction;
    bool left = false;
    bool top = false;
    bool right = false;
    bool bottom = false;
    int MinSpeed = 5;
    int MaxSpeed = 25;
    int Speed = 0;
    public Ship ship_script;
    bool Started = false;
    void Start()
    {
        DoRandom();
       

    }
	
	// Update is called once per frame
    void Update()
    {
        if (ship_script.Started)
        {

            Vector3 NewDir = new Vector3();
            if (left)
            {
                NewDir = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y);
            }
            else if (right)
            {
                NewDir = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y);
            }
            else if (bottom)
            {

                NewDir = new Vector3(transform.position.x, transform.position.y + Speed * Time.deltaTime);
            }
            else if (top)
            {
                NewDir = new Vector3(transform.position.x, transform.position.y - Speed * Time.deltaTime);

            }

            Vector3 diff = NewDir - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            transform.position = NewDir;



        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("Finish"))
        DoRandom();

    }
    void DoRandom()
    {
        int yInicial = 84;
        int yFinal = -76;
        int xInicial = 72;
        int xFinal = -60;
        int size = Random.Range(15, 40);

        Speed = Random.Range(MinSpeed, MaxSpeed);

        var x = Random.Range(xInicial, xFinal);
        var y = Random.Range(yInicial, yFinal);

        Direction = new Vector3(x, y, 0f);

        int RandomDirection = Random.Range(0, 3);
        transform.localScale = new Vector3(size, size);

        left = false;
        top = false;
        right = false;
        bottom = false;

        if (RandomDirection == 0)
            left = true;
        else if (RandomDirection == 1)
            top = true;

        else if (RandomDirection == 2)
            right = true;

        else if (RandomDirection == 3)
            bottom = true;

        if(left)
        Direction = new Vector2(-93, y);

        if(right)
        Direction = new Vector2(97, y);

        if (bottom)
            Direction = new Vector2(x, -123);

        if (top)
            Direction = new Vector2(x, 129);

        transform.position = Direction;

    }
}
