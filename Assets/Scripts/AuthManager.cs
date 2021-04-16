using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AuthManager : MonoBehaviour
{
    public static AuthManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }


    readonly string BASE_URL = "https://jameelqureshi.xyz/UnicronBird/";

    public GameObject signUpPanel;
    public GameObject signInPanel;

    public static int UserId
    {
        set
        {
            PlayerPrefs.SetInt("UserId",value);
        }
        get
        {
            return PlayerPrefs.GetInt("UserId");
        }
    }

    private void Start()
    {
        //CreateUser("Jameel");
        //LoginUser("");
        //UpdateScore("");
        //GetScores();
    }


    public void CreateUser(string name ,string email, string password)
    {
        Debug.Log("Creeating User");
        StartCoroutine(PostCreateUserRequest(name,email,password));
    }

    public void LoginUser(string email,string password)
    {
        Debug.Log("Login User");
        StartCoroutine(PostLoginUserRequest(email,password));
    }

    public void UpdateScore(int score)
    {
        Debug.Log(" Updating score");
        StartCoroutine(PostUpdateScoreRequest(UserId.ToString(),score.ToString()));
    }

    public void GetScores()
    {
       
        StartCoroutine(GetScoreRequest());
    }

    IEnumerator PostCreateUserRequest(string name, string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
        form.AddField("name", name);
        
        string requestName = "CreateUser.php";
        using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL + requestName, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "Error")
                {
                    ConsoleManager.instance.ShowMessage("Please try again");
                    Debug.Log("Something Went Wrong!");
                }
                else if (www.downloadHandler.text == "Duplicate Email")
                {
                    ConsoleManager.instance.ShowMessage("Email Already Registered");
                    Debug.Log("Email Already Registered!");
                }
                else
                {
                    Debug.Log("User Created");
                    int.TryParse(www.downloadHandler.text, out int id);
                    UserId = id;
                    Debug.Log(UserId);
                    signUpPanel.SetActive(false);
                }

            }
        }
    }


    IEnumerator PostLoginUserRequest(string email , string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
        

        string requestName = "Login.php";
        using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL + requestName, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "Error")
                {
                    ConsoleManager.instance.ShowMessage("Email or Password is incorrect");
                    Debug.Log("Email or Password is incorrect!");
                }
                else
                {
                    Debug.Log("User Logged In");
                    int.TryParse(www.downloadHandler.text, out int id);
                    UserId = id;
                    Debug.Log(UserId);
                    signInPanel.SetActive(false);
                }

            }
        }
    }


    IEnumerator PostUpdateScoreRequest(string Id, string score)
    {
        WWWForm form = new WWWForm();
        form.AddField("Id", Id);
        form.AddField("score", score);


        string requestName = "UpdateScore.php";
        using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL + requestName, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "Error")
                {
                    Debug.Log("Error Updating Score!");
                }
                else
                {
                    Debug.Log("Score Updated!");
                }

            }
        }
    }


    IEnumerator GetScoreRequest()
    {
      
        string requestName = "GetScores.php";
        using (UnityWebRequest www = UnityWebRequest.Get(BASE_URL + requestName))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "Error")
                {
                    Debug.Log("Error Updating Score!");
                }
                else
                {
                    Debug.Log("Scores: "+ www.downloadHandler.text);
                }

            }
        }
    }

}