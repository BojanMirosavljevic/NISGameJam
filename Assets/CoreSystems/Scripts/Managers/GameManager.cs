using TMPro;
using UnityEngine;

public class GameManager : StaticInstance<GameManager>
{
    [SerializeField] private TextMeshProUGUI killCounterText;

    private void Start()
    {
        DUMMY_RefreshEnemyKillCounter();
    }

    //referenced by button in scene
    public void DUMMY_GoToGameScene()
    {
        SceneSystem.Instance.LoadScene(
            Scene.Loading,
            () =>
            {
                Debug.LogError("SceneChanged");
            }
        );
    }

    //referenced by button in scene
    public void DUMMY_KillEnemy()
    {
        SaveSystem.Instance.Player.EnemyKillCounter++;
        DUMMY_RefreshEnemyKillCounter();
    }

    private void DUMMY_RefreshEnemyKillCounter()
    {
        killCounterText.text = "Counter: " + SaveSystem.Instance.Player.EnemyKillCounter;
    }
}
