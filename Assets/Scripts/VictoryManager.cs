using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{
    public Text victorytext;

    // Start is called before the first frame update
    void Start()
    {
        victorytext.text = Dragon.PlayerWinner;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartGame()
    {
        Application.Quit();
        //SceneManager.LoadScene("Game_map");
    }
}
