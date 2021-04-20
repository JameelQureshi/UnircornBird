using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LeaderBoardManager : MonoBehaviour
{


    public static LeaderBoardManager instance = null;

    public void Awake()
    {

        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    public GameObject[] lines;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject line in lines)
        {
            line.SetActive(false);
        }
        AuthManager.instance.GetScores();

    }

    public void CreateScoreBoard(string result)
    {
        Debug.Log("In Create Score:"+result);
        string[] scoreData = result.Split(',');

        User[] users = new User[scoreData.Length - 1];
        for (int i=0;i<users.Length;i++)
        {
            string[] score = scoreData[i].Split(':');
            User user = new User
            {
                name = score[0],
                score = score[1]
            };

            users[i] = user;
        }

        SortUserScores(users);

        int loopCount;
        if (scoreData.Length<9)
        {
            loopCount = scoreData.Length - 1;
        }
        else
        {
            loopCount = 8;
        }

        


        for (int i=0;i<loopCount;i++)
        {
            //string[] score = scoreData[i].Split(':');
            lines[i].SetActive(true);
            lines[i].transform.GetChild(1).GetComponent<Text>().text = users[i].name;
            lines[i].transform.GetChild(2).GetComponent<Text>().text = users[i].score;
        }

    }
    public void SortUserScores(User[] data)
    {
        int i, j;
        int N = data.Length;

        for (j = N - 1; j > 0; j--)
        {
            for (i = 0; i < j; i++)
            {

                int.TryParse(data[i].score, out int firstScore);
                int.TryParse(data[i + 1].score, out int secondScore);

                if (firstScore < secondScore)
                {
                    Exchange(data, i, i + 1);
                }
                   
            }
        }
    }

    public void Exchange(User[] data, int m, int n)
    {
        User temporary;

        temporary = data[m];
        data[m] = data[n];
        data[n] = temporary;
    }


}

public class User
{
    public string name;
    public string score;
}
