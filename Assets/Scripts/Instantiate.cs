using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Instantiate : MonoBehaviour
{
	public GameObject newDuck;		// передаём в скрипт gameObject Bird	
	float TimeSpawn = 2f;			// период появления 
	private float currentTime = 0;  // текущее время

	Vector2 PointSpawnDuck; // Вектор-точка в которой будет появляться утка 

    void Start()
    {
		PointSpawnDuck = new Vector2(Random.Range(-5f, 5f), 0f); // генерируем начальную точку
	}

    void Update()
	{
		currentTime += Time.deltaTime; 

		if (currentTime >= TimeSpawn)
		{
			// обнуляем время
			currentTime = 0f;

			// создать птичку точке в начеле координат
			//Instantiate(newDuck,new Vector2(0f,0f),Quaternion.identity);

			Instantiate(newDuck, PointSpawnDuck, Quaternion.identity);
			

			// генерируем новую точку
			PointSpawnDuck = new Vector2(Random.Range(-5f, 5f), 0f);
		}
	}
}