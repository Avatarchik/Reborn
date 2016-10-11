using UnityEngine;
using System.Collections.Generic;

namespace LifeResources
{
    public class ResourcesLoad : MonoBehaviour
    {
        public static Dictionary<string, GameObject> vehicles;
        public static Dictionary<string, GameObject> ui;

        public static void InitializeGameplay()
        {
            // Units
            vehicles = new Dictionary<string, GameObject>();

            //vehicles.Add("ResourcePoint", Resources.Load("Units/ResourcePoint") as GameObject);
            

            // UI
            ui = new Dictionary<string, GameObject>();
            ui.Add("item_Entry_UI", Resources.Load("Prefabs/UI/Item_Entry") as GameObject);
        }
    }
}
