using UnityEngine;
using System.Collections.Generic;

namespace LifeResources
{
    public class ResourcesLoad : MonoBehaviour
    {
        public static Dictionary<string, GameObject> vehicles;
        public static Dictionary<string, GameObject> ui;

        void Start()
        {
            InitializeGameplay();
        }

        public static void InitializeGameplay()
        {
            // Units
            vehicles = new Dictionary<string, GameObject>();
            //vehicles.Add("ResourcePoint", Resources.Load("Units/ResourcePoint") as GameObject);
            

            // UI
            ui = new Dictionary<string, GameObject>();
            ui.Add("atm_ui", Resources.Load("Prefabs/UI/ATM_UI") as GameObject);
            ui.Add("onoffduty", Resources.Load("Prefabs/UI/police_On_Off") as GameObject); 
        }
    }
}
