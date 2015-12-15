using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    // Use this for initialization
    int X;
    int Y;
    void Start()
    {

    }
   
    // Update is called once per frame
    void Update()
    {
        GameObject[] respawns = GameObject.FindGameObjectsWithTag("Astronauta");
        if(respawns.Length  == 0)
        SpawNew();
     
    }

    private void SpawNew()
    {
        X = Random.Range(-50, 60);
        Y = Random.Range(-92, 95);

        string Path = "Prefabs/astronaut";
        GameObject NewPre = (GameObject)Resources.Load(Path, typeof(GameObject));
        Vector2 Pos = new Vector2(X, Y);
        NewPre.transform.position = Pos;
        Instantiate(NewPre);

    }
}
