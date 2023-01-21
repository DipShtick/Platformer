using UnityEngine;

public class Quit : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        Debug.Log("You win!");
        Application.Quit();
    }
}
