using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class BuildingPlacerBehavior : MonoBehaviour {
    [SerializeField]
    List<GameObject> buildings;
    int building = 0;

    GridBehavior grid;
    MeshFilter filter;
    Terrain terrain;
    float[,] heights;

    bool currentMouseState = false;
    bool lastMouseState = false;
    bool isBuilding = false;

    // Use this for initialization
    void Start () {
        grid = GameObject.FindGameObjectsWithTag("Grid")[0].GetComponent<GridBehavior>(); 

        terrain = FindObjectsOfType<Terrain>()[0];
        heights = terrain.terrainData.GetHeights(0,0,terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapWidth);

        filter = gameObject.AddComponent<MeshFilter>();
    }
	
	// Update is called once per frame
	void Update () {
        currentMouseState = Input.GetMouseButton(0);

        for (int i = 49; i < 58; i++)
        {
            if (Input.GetKey((KeyCode)i))
            {
                building = i - 49;
                isBuilding = true;
            }
        }


        if (Input.GetMouseButton(1) && isBuilding)
        {
            isBuilding = false;
            transform.position = Vector3.down * 100.0f;
        }

        if (isBuilding)
        {
            filter.sharedMesh = buildings[building].GetComponent<MeshFilter>().sharedMesh;

            RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));

            foreach (RaycastHit h in hits)
            {
                if (h.collider.gameObject.GetComponents<Terrain>().Length > 0)
                {
                    Vector3 worldPosition = h.point;
                    worldPosition.x = Mathf.Round(worldPosition.x) - 0.5f;
                    worldPosition.z = Mathf.Round(worldPosition.z) - 0.5f;
                    this.transform.position = worldPosition;

                    bool isPlacable = true;
                    int extendsX = buildings[building].GetComponent<BuildingBehavior>().extendsX;
                    int extendsZ = buildings[building].GetComponent<BuildingBehavior>().extendsZ;

                    for (int x = -extendsX / 2; x <= extendsX / 2; x++)
                    {
                        for (int z = -extendsZ / 2; z <= extendsZ / 2; z++)
                        {
                            float ix = (((Mathf.Round(worldPosition.x + x + 0.5f)) * terrain.terrainData.heightmapWidth / terrain.terrainData.size.x) + terrain.terrainData.heightmapWidth / 2) / terrain.terrainData.heightmapWidth;
                            float iz = (((Mathf.Round(worldPosition.z + z + 0.5f)) * terrain.terrainData.heightmapHeight / terrain.terrainData.size.z) + terrain.terrainData.heightmapHeight / 2) / terrain.terrainData.heightmapHeight;

                            float steepness = terrain.terrainData.GetSteepness(ix, iz);
                            if (grid.CheckCollision(worldPosition.z + z, worldPosition.x + x) != 0 || steepness > 20f)
                            {
                                isPlacable = false;
                                break;
                            }
                        }
                    }

                    if (isPlacable)
                    {
                        GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", Color.green);
                        if (currentMouseState && !lastMouseState)
                        {
                            Instantiate(buildings[building], worldPosition, Quaternion.identity);
                            for (int x = -extendsX / 2; x <= extendsX / 2; x++)
                            {
                                for (int z = -extendsZ / 2; z <= extendsZ / 2; z++)
                                {
                                    grid.SetCollision(worldPosition.x + x, worldPosition.z + z, (int)GridBehavior.GridElement.Building);

                                    int ix = (int)((Mathf.Round(worldPosition.x + x + 0.5f)) * terrain.terrainData.heightmapWidth / terrain.terrainData.size.x) + terrain.terrainData.heightmapWidth / 2;
                                    int iz = (int)((Mathf.Round(worldPosition.z + z + 0.5f)) * terrain.terrainData.heightmapHeight / terrain.terrainData.size.z) + terrain.terrainData.heightmapHeight / 2;
                                    heights[iz, ix] = worldPosition.y / terrain.terrainData.size.y;
                                }
                            }
                            //terrain.terrainData.SetHeights(0, 0, heights);

                            //Destroy(gameObject);
                        }
                    }
                    else
                        GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", Color.red);
                }
            }
        }
        lastMouseState = currentMouseState;
    }

    void OnCollisionStay()
    {
        Debug.Log(gameObject.name + "collided with another object");
    }

    bool CheckCollision()
    {
        

        return true;
    }


    void GetBuildingExtends()
    {

    }
}
