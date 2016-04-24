using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class StatScreen : MonoBehaviour
{
    [SerializeField]
    Texture faceImage;
    [SerializeField]
    Texture progressImage;
    [SerializeField]
    Texture foodImage;
    [SerializeField]
    Texture waterImage;
    [SerializeField]
    Texture happinessImage;

    Resource resource;
    Dropdown dp, db;

    string[] sfLabels = 
    {
        "Scientist",
        "Engineer",
        "Farmer",
        "Tourist",
        "Astronaut"
    };

    public Rect windowRect = new Rect(200, 200, 200, 150);

    void Start()
    {
        resource = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceBehavior>().resource;
        dp = GameObject.Find("Dropdown_People").GetComponent<Dropdown>();
        db = GameObject.Find("Dropdown_Buildings").GetComponent<Dropdown>();
    }

    void OnGUI()
    {
        windowRect = GUI.Window(0, windowRect, UpdateWindow, "Character Sheet");
    }

    void UpdateWindow(int windowID)
    {
        windowRect.x = Screen.width - 225;
        windowRect.y = Screen.height - 120;
        windowRect.width = 225;
        windowRect.height = 120;
        //GUI.Button(new Rect(10, 20, 100, 20), "Can't drag me");
        //

        if (resource.people.Count > 0)
        {
            int sf = (int)resource.people.ElementAt(dp.value).scfield.scfield;
            float eng = resource.people.ElementAt(dp.value).scfield.getSkillset().engineering;
            float farm = resource.people.ElementAt(dp.value).scfield.getSkillset().farming;
            float sci = resource.people.ElementAt(dp.value).scfield.getSkillset().science;

            double food = resource.people.ElementAt(dp.value).health.food;
            double water = resource.people.ElementAt(dp.value).health.water;
            double happ = resource.people.ElementAt(dp.value).health.happiness;

            int D = resource.people.ElementAt(dp.value).personality.getD();
            int I = resource.people.ElementAt(dp.value).personality.getI();
            int S = resource.people.ElementAt(dp.value).personality.getS();
            int C = resource.people.ElementAt(dp.value).personality.getC();

            GUI.DrawTexture(new Rect(10, 20, 50, 50), faceImage);
            GUI.Label(new Rect(10, 70, 50, 50), resource.people.ElementAt(dp.value).name + ",");
            GUI.Label(new Rect(10, 85, 60, 50), sfLabels[sf]);
            if (resource.people.ElementAt(dp.value).currentBuilding != null)
                GUI.Label(new Rect(10, 100, 100, 50), resource.people.ElementAt(dp.value).currentBuilding.buildingType.ToString());
            GUI.Label(new Rect(65, 20, 60, 50), "E: ");
            GUI.Label(new Rect(65, 35, 60, 50), "F: ");
            GUI.Label(new Rect(65, 50, 60, 50), "S: ");
            GUI.DrawTexture(new Rect(85, 25, eng * 10.0f, 10), progressImage);
            GUI.DrawTexture(new Rect(85, 40, farm * 10.0f, 10), progressImage);
            GUI.DrawTexture(new Rect(85, 55, sci * 10.0f, 10), progressImage);

            GUI.Label(new Rect(190, 20, 60, 50), "D: " + D);
            GUI.Label(new Rect(190, 45, 60, 50), "I:  " + I);
            GUI.Label(new Rect(190, 70, 60, 50), "S: " + S);
            GUI.Label(new Rect(190, 95, 60, 50), "C: " + C);

            GUI.DrawTexture(new Rect(85, 70, 10, 10), foodImage);
            GUI.DrawTexture(new Rect(85, 85, 10, 10), waterImage);
            GUI.DrawTexture(new Rect(85, 100, 10, 10), happinessImage);

            GUI.DrawTexture(new Rect(100, 70, (float)food * 0.8f, 10), progressImage);
            GUI.DrawTexture(new Rect(100, 85, (float)water * 0.8f, 10), progressImage);
            GUI.DrawTexture(new Rect(100, 100, (float)happ * 8.0f, 10), progressImage);

            GUI.DragWindow();
        }
    }
}
