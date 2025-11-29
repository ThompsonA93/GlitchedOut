using UnityEngine;
using UnityEngine.SceneManagement;

public class Playbutton : MonoBehaviour
{
    public void ChangeScene()

    {
        Debug.Log("Button clicked!");
        SceneManager.LoadScene("Level01");
    }
}

