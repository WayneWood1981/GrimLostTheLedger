using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Texture2D zombieCursor;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(zombieCursor, Vector2.zero, cursorMode: CursorMode.ForceSoftware);
    }

    public void PlayPressed()
    {

        SceneManager.LoadScene(1);
    }

    public void HowToPressed()
    {
        Debug.Log("How");
    }
}

    
