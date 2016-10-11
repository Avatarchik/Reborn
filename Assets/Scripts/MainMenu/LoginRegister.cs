using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoginRegister : MonoBehaviour {

    //Stuff For Login
    [Header("Login UI")]
    public Text username;
    public Text password;
    //Stuff For Reg
    [Header("Register UI")]
    public Text usernamereg;
    public Text passwordreg;
    public Text pincode;
    [Header("Continue Login")]
    public Text InGameName;
    [Header("Different Areas")]
    public GameObject LoginArea;
    public GameObject RegisterArea;
    public GameObject ContinueArea;

    private bool LoginActive = true;
    private bool RegisterActive = false;

    private bool SuccessLogin = false;
    private bool Registed = false;

    public string LoginStore;

    private string[] details;

    [Header("For Testing")]
    public string inputUserName;
    public string inputPassword;
    public string inputPin;

    string CreateUserURL = "http://rpgame.pe.hu/instertPlayerData.php";
    string LoginURL = "http://rpgame.pe.hu/login.php";

    #region Old Start()
    //IEnumerator Start() {

    //WWW itemsdata = new WWW("http://localhost/rpgame/receivePlayerData.php");

    //yield return itemsdata;

    //string itemsDataString = itemsdata.text;
    //Debug.Log(itemsDataString);

    //details = itemsDataString.Split(';');
    //print(GetDataValue(details[0], "ID:"));

    //SuccessLogin = false;
    //}
    #endregion

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
        return value;
    }

    public void CreateUser(string inputUserName, string inputPassword, string pin)
    {
        inputUserName = usernamereg.text;
        inputPassword = passwordreg.text;
        inputPin = pincode.text;

        WWWForm form = new WWWForm();
        form.AddField("usernamePost", inputUserName);
        form.AddField("passwordPost", inputPassword);
        form.AddField("pinPost", inputPin);

        WWW www = new WWW(CreateUserURL, form);
    }

    public IEnumerator Login(string inputUserName, string inputPassword)
    {
        inputUserName = username.text;
        inputPassword = password.text;

        WWWForm form = new WWWForm();
        form.AddField("usernamePost", inputUserName);
        form.AddField("passwordPost", inputPassword);

        WWW www = new WWW(LoginURL, form);
        yield return www;
        Debug.Log(www.text);
        if (www.text == "success")
        {
            SuccessLogin = true;
            LoginStore = username.text;

            if (SuccessLogin == true)
            {
                username.color = Color.green;
                PlayerPrefs.SetString("playerName", LoginStore);
                ShowContinue();
            }
        }
    }

    public void LoginRun()
    {
            StartCoroutine(Login(inputUserName, inputPassword));
    }

    public void RegRun()
    {
        CreateUser(inputUserName, inputPassword, inputPin);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) CreateUser(inputUserName, inputPassword, inputPin);
    }

    public void OpenLoginArea()
    {
        if(LoginActive == true)
        {
            return;
        }
        else if(LoginActive == false && RegisterActive == true)
        {
            RegisterArea.SetActive(false);
            RegisterActive = false;
            LoginActive = true;
            LoginArea.SetActive(true);
        }
    }

    public void OpenRegArea()
    {
        if (RegisterActive == true)
        {
            return;
        }
        else if (RegisterActive == false && LoginArea == true)
        {
            LoginArea.SetActive(false);
            LoginActive = false;
            RegisterArea.SetActive(true);
            RegisterActive = true;
            
        }
    }

    void ShowContinue()
    {
        if(SuccessLogin == true)
        {
            InGameName.text = LoginStore.ToString();
            LoginArea.SetActive(false);
            ContinueArea.SetActive(true);
            
        }
    }


}
