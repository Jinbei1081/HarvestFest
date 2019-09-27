using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Tree : SerializedMonoBehaviour
{
    [SerializeField]
    private List<GameObject> foods;

    [SerializeField]
    private float interval;

    private float elapsedTime;

    private GameManagerScript _GMCS;

    // Start is called before the first frame update
    void Start()
    {
        _GMCS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (_GMCS.IsGenerate)
        {
            if ((interval * (_GMCS.LimitTime / 60)) <= elapsedTime)
            {
                Instantiate(foods[Random.Range(0, foods.Count)], new Vector2(Random.Range(-18.5f, 18.5f), Random.Range(11f, 21.7f)), Quaternion.identity);
                elapsedTime = 0;
            }
        }
    }
}
