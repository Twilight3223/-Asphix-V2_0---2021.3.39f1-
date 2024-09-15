using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public float maxTime = 40;
    public TMP_Text timeText;
    public GameObject Defeat;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (maxTime > 0)
        {
            maxTime -= Time.deltaTime;

            float minutes = Mathf.FloorToInt(maxTime / 60);
            float seconds = Mathf.FloorToInt(maxTime % 60);

            timeText.text = (string.Format("{0:00}:{1:00}", minutes, seconds));
        }

        if (maxTime <= 0)
        {
           Defeat.SetActive(true);
        }
    }
}
