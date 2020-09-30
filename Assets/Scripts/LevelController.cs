using UnityEngine;
public class LevelController : MonoBehaviour
{
    public static LevelController Reference;
    public GameObject PlayerPrefab;
    //public GameObject BlockPrefab;
    private GameObject prefab;
    public int PlayerMovementSpeed=4;
    public int PlayerJumpForce=20000;
    private void Awake()
    {
        Reference = this;
        /*for(int i=-10;i<=10;i++)
        {
            prefab = Instantiate(BlockPrefab, new Vector3(i, -1, 0), Quaternion.identity);
            prefab.name = "Block";
        }*/
        //prefab = Instantiate(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        //prefab.name = "Player";
    }
}
