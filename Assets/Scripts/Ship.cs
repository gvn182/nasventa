using UnityEngine;
using System.Collections;
using System;

public class Ship : MonoBehaviour
{
    public Camera MyCamera;
    public int speed = 0;
    DateTime OldTime;
    public float MyLife = 40;
    public Sprite[] Sprites;
    int CurrentAnimation = 0;
    SpriteRenderer myRenderer;
    public bool Started = false;
    public int collected;

    void Start()
    {

        myRenderer = GetComponent<SpriteRenderer>(); 
        OldTime = DateTime.Now;
    }
    void OnGUI()
    {
        float defaultResolutionHeight = 480;
        float defaultFontSize = 20;
        GUI.skin.label.fontSize = (int)(Screen.height / defaultResolutionHeight * defaultFontSize); // ...then

        GUI.Label(new Rect(10f, 10f, Screen.width * 0.5f, Screen.height * 0.3f), "Collected: " + collected);

    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            if (CurrentAnimation == 0)
                CurrentAnimation++;

            rigidbody2D.AddForce(MyCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            if ((DateTime.Now - OldTime).TotalMilliseconds > 1000)
            {
                if (CurrentAnimation < Sprites.Length - 1)
                    CurrentAnimation++;

                OldTime = DateTime.Now;
            }
        }
        else
        {
            OldTime = DateTime.Now;
            CurrentAnimation = 0;
        }
        if (MyLife <= 0)
        {
            Debug.Log("dead man");
        }
        myRenderer.sprite = Sprites[CurrentAnimation];
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Astronauta"))
        {
            audio.Play();
            collected++;
            Destroy(col.gameObject);
            Started = true;

        }
        

    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag.Equals("Player"))
            Destroy(this.gameObject);

        //float Velocity = (col.relativeVelocity.x + col.relativeVelocity.y);
        //MyLife -= Math.Abs(Velocity);
        ////if (col.gameObject.name == "Plataform Start")
        ////{

            
        ////}


        //this.rigidbody2D.velocity = Vector2.zero;
    }
}
