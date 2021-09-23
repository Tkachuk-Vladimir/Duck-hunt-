using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameScript : MonoBehaviour
{
    public void NewGameFunction()
    {
        SceneManager.LoadScene(1); // переход на вторую сцену
    }
}
