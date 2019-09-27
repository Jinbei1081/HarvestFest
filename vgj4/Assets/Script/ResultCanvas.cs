using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultCanvas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private TextMeshProUGUI besttext;

    private CanvasGroup canvas;

    private float alpha;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        alpha = 0;
        text.text = ScoreManager.Score.ToString();

        if (!PlayerPrefs.HasKey("BestScore")) return;
        if (PlayerPrefs.GetInt("BestScore") < ScoreManager.Score)
        {
            besttext.text = "BEST SCORE!!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        canvas.alpha =alpha;
        alpha += 0.01f;
    }

    private void OnDestroy()
    {
        if (PlayerPrefs.GetInt("BestScore") < ScoreManager.Score)
        {
            PlayerPrefs.SetInt("BestScore", ScoreManager.Score);
        }
    }
}
