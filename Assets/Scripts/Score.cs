using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public int score;
	Text scoreText;

    void Start() {

		scoreText = GetComponent<Text>();
    }
    void Update () {

		scoreText.text = "Score: " + score.ToString();
	}

}

