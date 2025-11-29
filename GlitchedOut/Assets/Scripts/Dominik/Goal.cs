using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    public string nextLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //Load next level if player touches goal
        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("Player touched Goal!!");

            SceneManager.LoadScene(nextLevel);
        }
    }


}
