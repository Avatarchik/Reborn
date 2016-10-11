using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace spawnInvoSlot
{

    public class spawnNewItem : MonoBehaviour
    {
        public string[] itemsList;
        
        public RectTransform itemList;
        public RectTransform itemPos;

        static public RectTransform itemList1;
        static public RectTransform itemPos1;

        private string itemNameTemp;
        private int itemAmmountTemp;
        private int itemIDTemp;

        void Start()
        {
           

            itemList1 = itemList;
            itemPos1 = itemPos;
        }

        public void AddItem(string itemName, int itemAmmount, int itemID)
        {
            itemNameTemp = itemName;
            itemAmmountTemp = itemAmmount;
            itemIDTemp = itemID;
            spawnItemList();
        }

        public void spawnItemList()
        {
            
            if (transform.Find(itemIDTemp.ToString()) == null) //transform.Find(itemIDTemp.ToString()).GetComponent<RectTransform> != null
            {
                Debug.Log("Didn't find one");
            }else
            {
                Debug.Log("Found one with same name");
            }
            RectTransform itemListPre = Instantiate(itemList1);
            itemListPre.parent = itemPos1;

            setInvoName setName = itemListPre.GetComponent<setInvoName>();

            //  This spawns the UI, sets its name, text name & ammount  // 
            setName.name = itemIDTemp.ToString();
            setName.itemName.text = itemNameTemp;
            setName.itemAmmount.text = itemAmmountTemp.ToString();
            setName.itemID.name = itemIDTemp.ToString();
        }
    }
}
