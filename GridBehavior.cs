using UnityEngine;
using System.Collections;

public class GridBehavior : MonoBehaviour {
    public static int nx = 500, nz = 500;
    int[,] collisionGrid = new int[nx,nz];

    public enum GridElement
    {
        Free,
        Connector,
        Building
    }

    void Start()
    {
    }

    public int CheckCollision(float x, float z)
    {
        int ix = (int)Mathf.Round(x + 0.5f) + nx / 2 - 1;
        int iz = (int)Mathf.Round(z + 0.5f) + nz / 2 - 1;

        return collisionGrid[ix, iz];
    }

    public void SetCollision(float x, float z, int val)
    {
        int ix = (int)Mathf.Round(x + 0.5f) + nx / 2 - 1;
        int iz = (int)Mathf.Round(z + 0.5f) + nz / 2 - 1;

        collisionGrid[ix, iz] = val;
    }

    /*void OnDrawGizmos()
    {
        for (int x = 0; x < nx; x++)
        {
            for (int z = 0; z < nx; z++)
            {
                if (collisionGrid[x, z] == (int)GridBehavior.GridElement.Connector)
                    Gizmos.color = Color.blue;
                else if (collisionGrid[x,z] != 0)
                    Gizmos.color = Color.red;
                else
                    Gizmos.color = Color.green;

                Gizmos.DrawCube(new Vector3(x - nx / 2 + 0.5f, 3, z - nx / 2 + 0.5f), Vector3.one * 0.5f);
            }
        }

    }*/
}

