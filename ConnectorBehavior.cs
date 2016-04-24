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

        UpdateActivity();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    GameObject GetObjectByID(int id)
    {
        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            if (go.GetInstanceID() == id)
            {
                return go;
            }
        }

        return null;
    }

    bool IsNeighborActive(int id)
    {
        if (id >= 0)
            return false;

        BuildingBehavior bh = GetObjectByID(id).GetComponent<BuildingBehavior>();
        if (bh != null)
        {
            return bh.isActive;
        }

        return false;
    }

    void SetNeighborActive(int id)
    {
        if (id >= 0)
            return;

        BuildingBehavior bh = GetObjectByID(id).GetComponent<BuildingBehavior>();
        if (bh != null)
        {
            bh.isActive = true;
        }
    }

    public void UpdateActivity()
    {
        int downVal = grid.CheckCollision(transform.position.x, transform.position.z - 1);
        int upVal = grid.CheckCollision(transform.position.x, transform.position.z + 1);
        int leftVal = grid.CheckCollision(transform.position.x - 1, transform.position.z);
        int rightVal = grid.CheckCollision(transform.position.x + 1, transform.position.z);

        if (!GetComponent<BuildingBehavior>().isActive)
        {
            if (IsNeighborActive(downVal) || IsNeighborActive(upVal) || IsNeighborActive(leftVal) || IsNeighborActive(rightVal))
                this.GetComponent<BuildingBehavior>().isActive = true;
        }

        if (this.GetComponent<BuildingBehavior>().isActive)
        {
            SetNeighborActive(downVal);
            SetNeighborActive(upVal);
            SetNeighborActive(leftVal);
            SetNeighborActive(rightVal);
        }
    }

    public void UpdateModel()
    {
        if (this.GetComponent<BuildingBehavior>().isActive)
        {
            GameObject[] gms = GameObject.FindGameObjectsWithTag("Connector");
            foreach (GameObject gm in gms)
            {
                if (gm.GetComponent<ConnectorBehavior>() != null)
                    gm.GetComponent<ConnectorBehavior>().UpdateActivity();
            }
        }

        bool down = grid.CheckCollision(transform.position.x, transform.position.z - 1) < 0;
        bool up = grid.CheckCollision(transform.position.x, transform.position.z + 1) < 0;
        bool left = grid.CheckCollision(transform.position.x - 1, transform.position.z) < 0;
        bool right = grid.CheckCollision(transform.position.x + 1, transform.position.z) < 0;

        //4-way
        if (up && down && left && right)
            filter.sharedMesh = meshes[4];

        //3-way
        else if(down && left && right)
        {
            filter.sharedMesh = meshes[3];
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
