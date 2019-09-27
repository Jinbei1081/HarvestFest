using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;


public class ScoreManager : SerializedMonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private static int score;

    public static int Score { get { return score; } }

    private void Start()
    {
        score = 0;
    }

    public void AddScore(int _score)
    {
        score += _score;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
    }
}
