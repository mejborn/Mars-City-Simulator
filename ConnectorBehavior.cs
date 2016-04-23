using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConnectorBehavior : MonoBehaviour {
    [SerializeField]
    List<Mesh> meshes;

    GridBehavior grid;
    MeshFilter filter;

    // Use this for initialization
    void Start ()
    {
        grid = GameObject.FindGameObjectsWithTag("Grid")[0].GetComponent<GridBehavior>();
        filter = gameObject.GetComponent<MeshFilter>();

        GameObject[] gms = GameObject.FindGameObjectsWithTag("Connector");
        foreach (GameObject gm in gms)
        {
            if (gm.GetComponent<ConnectorBehavior>() != null)
                gm.GetComponent<ConnectorBehavior>().UpdateModel();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateModel()
    {
        bool down   = grid.CheckCollision(transform.position.x, transform.position.z - 1)     == (int)GridBehavior.GridElement.Building;
        bool up     = grid.CheckCollision(transform.position.x, transform.position.z + 1)     == (int)GridBehavior.GridElement.Building;
        bool left   = grid.CheckCollision(transform.position.x - 1, transform.position.z)     == (int)GridBehavior.GridElement.Building;
        bool right  = grid.CheckCollision(transform.position.x + 1, transform.position.z)     == (int)GridBehavior.GridElement.Building;

        //4-way
        if (up && down && left && right)
            filter.sharedMesh = meshes[4];

        //3-way
        else if(down && left && right)
        {
            filter.sharedMesh = meshes[3];
            //transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else if (up && left && right)
        {
            filter.sharedMesh = meshes[3];
            transform.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
        }
        else if (up && down && right)
        {
            filter.sharedMesh = meshes[3];
        }
        else if (up && down && left)
        {
            filter.sharedMesh = meshes[3];
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

        }

        //Straight
        else if (up && down)
        {
            filter.sharedMesh = meshes[1];
        }
        else if (left && right)
        {
            filter.sharedMesh = meshes[1];
            transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        }

        //Corner
        else if (up && left)
        {
            filter.sharedMesh = meshes[2];
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else if (up && right)
        {
            filter.sharedMesh = meshes[2];
            transform.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
        }
        else if (down && left)
        {
            filter.sharedMesh = meshes[2];
            transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        }
        else if (down && right)
        {
            filter.sharedMesh = meshes[2];
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        //Straight
        else if (up && down)
        {
            filter.sharedMesh = meshes[1];
        }
        else if (left && right)
        {
            filter.sharedMesh = meshes[1];
        }

        //Dead-end
        else if (up)
        {
            filter.sharedMesh = meshes[0];
        }
        else if (down)
        {
            filter.sharedMesh = meshes[0];
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else if (left)
        {
            filter.sharedMesh = meshes[0];
            transform.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
        }
        else if (right)
        {
            filter.sharedMesh = meshes[0];
            transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        }

        //No entrances
        else
            filter.sharedMesh = meshes[5];
    }
}
