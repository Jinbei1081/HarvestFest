using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScript : SerializedMonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI Timetext;
    [SerializeField]
    private TextMeshProUGUI Counttext;

    [SerializeField]
    private float limitTime = 60;
    public float LimitTime { get { return limitTime; } }

    [SerializeField]
    private bool isGenerate;
    public bool IsGenerate { get { return isGenerate;} }

    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        limitTime += 4;
        isGenerate = false;
    }

    // Update is called once per frame
    void Update()
    {
        limitTime -= Time.deltaTime;
        Timetext.text = Mathf.FloorToInt(Mathf.Clamp(limitTime, 0, 60)).ToString();

        if (limitTime <= 60)
        {
            isGenerate = true;
        }
        if (limitTime <= 0)
        {
            isGenerate = false;
            if (!gameOver)
            {
                SceneManager.LoadScene("Result", LoadSceneMode.Additive);
                gameOver = true;
            }
        }

        if (limitTime <= 60) return;
        Counttext.text = Mathf.FloorToInt((limitTime - 60)).ToString();
        if (limitTime <= 61)
        {
            Counttext.text = "GO";
            Counttext.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, limitTime - 60));
        }
        

    }

}