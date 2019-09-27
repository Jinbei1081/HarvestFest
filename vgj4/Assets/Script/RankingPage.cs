using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using NCMB;
using TMPro;
using System;

public class RankingPage : SerializedMonoBehaviour
{
    [SerializeField]
    List<TextMeshProUGUI> nameList;
    [SerializeField]
    List<TextMeshProUGUI> scoreList;

    [SerializeField]
    TextMeshProUGUI bestText;

    [SerializeField]
    TextMeshProUGUI failText;

    // Start is called before the first frame update
    void Start()
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("Later_v12_Ranking");

        query.Limit = 10;
        query.OrderByDescending("Score");

        query.FindAsync((List<NCMBObject> objList, NCMBException e) => {

            if (e == null)
            {
                for(int i = 0; i < objList.Count; i++)
                {
                    nameList[i].text = objList[i]["Name"].ToString();
                    scoreList[i].text = objList[i]["Score"].ToString();
                }

            }
            else
            {
                failText.text = "ランキングの取得に失敗しました";
            }
        });

        if (!PlayerPrefs.HasKey("BestScore")) return;

        bestText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}
