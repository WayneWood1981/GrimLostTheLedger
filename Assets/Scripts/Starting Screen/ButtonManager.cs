using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Texture2D chickenLeg;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(chickenLeg, Vector2.zero, cursorMode: CursorMode.ForceSoftware);
    }

    public void PlayPressed()
    {
        
        SceneManager.LoadScene(1);
    }

    public void HowToPressed()
    {
        Debug.Log("How");
    }

    public void SettingsPressed()
    {
        Debug.Log("Settings");
    }
}
