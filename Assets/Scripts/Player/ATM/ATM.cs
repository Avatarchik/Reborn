using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ATM : MonoBehaviour {

    private string CardName;
    private string Balance;
    private int MoneyCarrying;

    private int WithdrawAmmount;
    private int DepositAmmount;

    public Text NameTxt;
    public Text BalTxt;
    public Text MoneyCarry;
    public InputField Withdraw;
    public InputField Deposit;

    private GameObject PlayerTemp;

    private int UploadNew;

    private string GetMoneyURL = "http://rpgame.pe.hu/receiveMoneyAmount.php";
    private string MoneyURL = "http://rpgame.pe.hu/WithdrawMoney.php";

    public void Start() {
        StartCoroutine(GetMoneyForPlayer());
        CardName = PlayerPrefs.GetString("playerName");
        NameTxt.text = CardName.ToString();
    }
    public IEnumerator GetMoneyForPlayer()
    {
        string playerName = PlayerPrefs.GetString("playerName");//This is the players name

        WWWForm form = new WWWForm();
        form.AddField("playerName", playerName); // This sends the players name to the php file.

        WWW www = new WWW(GetMoneyURL, form);
        yield return www;
        Balance = www.text.ToString();
        BalTxt.text = Balance;
        Debug.Log(www.text);        
        
    }
    public void WithdrawMon()
    {
        string withdrawam;
        withdrawam = Withdraw.text;

        int IntBal = int.Parse(Balance);
        int IntWithDraw = int.Parse(withdrawam);

        UploadNew = IntBal - IntWithDraw;
        Balance = UploadNew.ToString();


        string playerName = PlayerPrefs.GetString("playerName"); // This gets the playername
        string NewMoney = UploadNew.ToString(); //This is the number that will be uploaded
        WithDrawMonFromAcc(playerName, NewMoney); //This calls the funtion to upload the number

        Debug.Log(UploadNew);
        BalTxt.text = NewMoney;
        MoneyCarry.text = withdrawam.ToString();
    }
    public void DepositMon()
    {
        
        string depositAm; //This is where v v v is stored

        depositAm = Deposit.text; // Gets the money I want to deposit from the Inputfield

        int DeposAm = int.Parse(depositAm); // This turns it into a interger
        int CurBal = int.Parse(Balance);
        int MonCar = int.Parse(MoneyCarry.text);
        int NewMonCar = MonCar - DeposAm;

        int CheckAm = int.Parse(MoneyCarry.text);

        if(CheckAm >= 1)
        {
            UploadNew = DeposAm + CurBal;
            Balance = UploadNew.ToString();

            string playerName = PlayerPrefs.GetString("playerName"); // This gets the playername
            string NewMoney = UploadNew.ToString(); //This is the number that will be uploaded
            DepositToAcc(playerName, NewMoney); //This calls the funtion to upload the number

            Debug.Log(UploadNew);
            BalTxt.text = NewMoney;
            MoneyCarry.text = NewMonCar.ToString();
        }        
    }
    public void WithDrawMonFromAcc(string playerName, string NewMoney)
    {

        WWWForm form = new WWWForm();
        form.AddField("playerName", playerName);
        form.AddField("NewMoney", NewMoney);

        WWW www = new WWW(MoneyURL, form);
    }
    public void DepositToAcc(string playerName, string NewMoney)
    {
        WWWForm form = new WWWForm();
        form.AddField("playerName", playerName);
        form.AddField("NewMoney", NewMoney);

        WWW www = new WWW(MoneyURL, form);
    }
    public void CloseUI()
    {
        //PlayerTemp.GetComponent<bl_MouseLook>().enabled = true;
        PlayerTemp.GetComponentInChildren<bl_MouseLook>().enabled = true;

        bl_RoomController.ChangeResumeBool();

        bl_CoopUtils.LockCursor(true);
        bl_RoomController.NoResume = false;

        //Withdraw.text = "";
        //Deposit.text = "";
        Destroy(this.gameObject);
    }
}
