public class GameSystem : PersistentSingleton<GameSystem>
{
    public int Level;

    public void LoadLevel(int level)
    {
        Level = level;
        SceneSystem.Instance.LoadScene(Scene.Game);
    }
}