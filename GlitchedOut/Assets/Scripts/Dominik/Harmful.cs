using UnityEngine;
using UnityEngine.SceneManagement;

public class Harmful : MonoBehaviour
{
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
        //Harm player if he touches this object
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit spike!");
            //TODO: Reduce HP by 1 or kill player

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
