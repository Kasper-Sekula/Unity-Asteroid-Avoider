using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;

    private bool isCounting = true;
    private float score;

    void Update()
    {
        if(!isCounting) { return; }

        score+= Time.deltaTime * scoreMultiplier;
        
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public int StopCounting()
    {
        isCounting = false;

        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);
    } 
}
