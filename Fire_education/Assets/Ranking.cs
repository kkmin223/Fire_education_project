using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{

    public TextMesh VRText;
    public TextMesh AutoText;
    public TextMesh RankingText;
    public GameObject RankingMenu;
    bool was = true;
    public Text Rank;
    private int num = 0;
    private float score = 0;
    //public int score=0;
    // Use this for initialization
    void Awake()
    {

    }
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        // score = PlayerPrefs.GetFloat("Score");
        // PlayerPrefs.SetFloat("score", score);

        InsertRank();
        // RankingMenu.SetActive(true);

        //for (int i = 0; i < 5; i++)
        //{
        //    Rank.text =
        //        "Rank       Score\n" +
        //        "1.             " + PlayerPrefs.GetFloat("0") + "\n" +
        //        "2.             " + PlayerPrefs.GetFloat("1") + "\n" +
        //        "3.             " + PlayerPrefs.GetFloat("2") + "\n" +
        //        "4.             " + PlayerPrefs.GetFloat("3") + "\n" +
        //        "5.             " + PlayerPrefs.GetFloat("4");

        //}
        //PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update()
    {
        if (was)
        {
            was = false;
            score = TotalScore.totalScoreInstance.n + TotalTime.totalTimeInstance.m * 100;
            //PlayerPrefs.SetFloat("Score", score);
            score = PlayerPrefs.GetFloat("Score");
            InsertRank();
        }

        //Debug.Log(score);
    }
    public void InsertRank()
    {
        //score = PlayerPrefs.GetFloat("Score");
        //PlayerPrefs.SetFloat("0", score);
        // Console.WriteLine(PlayerPrefs.GetFloat("0"));
        for (int i = 0; i < 5; i++)
        {
            //PlayerPrefs.SetFloat(i.ToString(), score);
            if (score > PlayerPrefs.GetFloat(i.ToString()))
            {
                for (int j = 4; j >= i; j--)
                {
                    PlayerPrefs.SetFloat((j + 1).ToString(), PlayerPrefs.GetFloat((j).ToString()));

                }
                PlayerPrefs.SetFloat(i.ToString(), score);
                //PlayerPrefs.Save();
                break;
            }
        }
        PlayerPrefs.DeleteKey("Score");
        for (int i = 0; i < 5; i++)
        {
            Rank.text =
                "Rank       Score\n" +
                "1.             " + PlayerPrefs.GetFloat("0") + "\n" +
                "2.             " + PlayerPrefs.GetFloat("1") + "\n" +
                "3.             " + PlayerPrefs.GetFloat("2") + "\n" +
                "4.             " + PlayerPrefs.GetFloat("3") + "\n" +
                "5.             " + PlayerPrefs.GetFloat("4");

        }
        PlayerPrefs.Save();
    }
}