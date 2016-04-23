using UnityEngine;
using System.Collections;
using System.Reflection;

public class BuildingPlacerBehavior : MonoBehaviour {
    [SerializeField]
    GameObject building;

    GridBehavior grid;
    Renderer renderer;

    bool currentMouseState = false;
    bool lastMouseState = false;


    // Use this for initialization
    void Start () {
        grid = GameObject.FindGameObjectsWithTag("Grid")[0].GetComponent<GridBehavior>(); 

        MeshFilter slaveFilter = building.GetComponent<MeshFilter>();
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        filter.sharedMesh = slaveFilter.sharedMesh;

        MeshCollider collider = gameObject.AddComponent<MeshCollider>();
        collider.convex = true;

        renderer = gameObject.GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        currentMouseState = Input.GetMouseButton(0);
        RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));

        foreach (RaycastHit h in hits)
        {
            if (h.collider.gameObject.GetComponents<Terrain>().Length > 0) {
                Vector3 worldPosition = h.point;
                worldPosition.x = Mathf.Round(worldPosition.x) - 0.5f;
                worldPosition.z = Mathf.Round(worldPosition.z) - 0.5f;
                this.transform.position = worldPosition;

                bool isPlacable = true;
                for (int x = 0; x < building.GetComponent<BuildingBehavior>().extendsX; x++)
                {
                    for (int z = 0; z < building.GetComponent<BuildingBehavior>().extendsZ; z++)
                    {
                        if (grid.CheckCollision(worldPosition.x + x, worldPosition.z + z))
                        {
                            isPlacable = false;
                            break;
                        }
                    }
                }

                if (isPlacable)
                {
                    renderer.materials[0].SetColor("_EmissionColor", Color.green);
                    if (currentMouseState && !lastMouseState)
                    {
                        Instantiate(building, worldPosition, Quaternion.identity);
                        for (int x = 0; x < building.GetComponent<BuildingBehavior>().extendsX; x++)
                        {
                            for (int z = 0; z < building.GetComponent<BuildingBehavior>().extendsZ; z++)
                            {
                                grid.SetCollision(worldPosition.x + x, worldPosition.z + z, true);
                            }
                        }
                        //Destroy(gameObject);
                    }
                }
                else
                    renderer.materials[0].SetColor("_EmissionColor", Color.red);
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
