using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	float fallSpeed = 3f; // скорость падения
	float speed = 2f;    // скорость полёта
	bool direction = true;  // напрвление 
	bool BirdLive;          // статус птицы

	

	private Vector2 mousePos;  //координаты указателя мыши
	float distance;             // переменная, в которой мы будем хранить расстояние от утки до указателя мышки 
	float timer;

	Score Score;


	Animator BirdAnim;      // поле аниматор
	Animator DogAnim;

	GameObject Dog;

	// получаем доступ к аниматору до запуска игры
	void Awake()
	{
		BirdAnim = GetComponent<Animator>();
	}

	void Start(){

		// находим скрипт Score на Объекте Score
		Score = GameObject.Find("Score").GetComponent<Score>(); 

		BirdAnim.enabled = true;// включаем аниматор
		BirdLive = true;        // устанавливаем статус - птица жива
		ResetDirection();       // подключаем функию направления полёта

		// в зависимости от направления, устанавливается анимация  
		if (direction)
        {
			BirdAnim.SetBool("isFlyLeft", false);
		}
        else
        {
			BirdAnim.SetBool("isFlyLeft", true);
		}

		DogAnim = GameObject.Find("Dog Mock").GetComponent<Animator>();

		Dog = GameObject.Find("Dog Mock");
	}

	void Update()
	{
		Dog.transform.rotation = Quaternion.Euler(0, 0, 0);

		if (BirdLive) // условие жива ли птичка
		{
			if (direction)// летит в право вверх
			{
				if (distance < 3f && distance > 0.8f)
                {
					transform.Translate(new Vector2(1f, 1f) * Time.deltaTime * speed * 20f); // летит вверх и вправа, рывок
					distance = 0;
				}
				else
					transform.Translate(new Vector2(1, 1) * Time.deltaTime * speed); // летит вверх и вправа
			}
			else // иначе летит в право вверх
			{
				if (distance < 3f && distance > 0.8f)
				{
					transform.Translate(new Vector2(-1f, 1f) * Time.deltaTime * speed * 20f); // летит вверх и влево, рывок
					distance = 0;
				}
				else
					transform.Translate(new Vector2(-1, 1) * Time.deltaTime * speed); // лети вверх и влево
			}
		}
		else // если не жива
		{
			transform.Translate(new Vector2(1, 0) * Time.deltaTime * fallSpeed); //падает вниз

			BirdAnim.SetTrigger("isDead"); // включается анимация смерти- падения
		}

		DestroyBird();

		//timer += Time.deltaTime; // подсчёт времени между выстрелами
		//if (timer >= 0.5f)
       // {
			if (Input.GetMouseButtonDown(0))
			{
				// находим координату указателя мышки внутри mainCamera
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

				// вычисляем расстояние
				distance = Vector2.Distance(mousePos, (Vector2)transform.position);

				// выводим в кансоль
				Debug.Log(distance);

				//timer = 0;
	
			}	
		//}
	}

	void DestroyBird()
	{

		if (transform.position.y >= 6f || transform.position.y <= -2f)
		{
			Object.Destroy(this.gameObject);
		}
	}

	void ResetDirection()// перезадаём направление
	{
		direction = (Random.value < .5);
	}

	// если мы кликаем курсором мышки на GameObject c Collider
	void OnMouseDown()
	{
		
			//  если птица жива и её подбили, прибавить +1 
			if (BirdLive == true)
			{
				BirdLive = false;   // or !BirdLive; Птицу подбили
				Score.score++;      // добавляем +1 к score

				DogAnim.SetTrigger("BirdMiss");// on animation

				//transform.Rotate( new Vector3(0,0,0), Space.Self);

				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,0),Time.deltaTime );
		}
		
	}

}
//transform.Rotate(Vector2.up,Time.deltaTime *5f, Space.Self);
