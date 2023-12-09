using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    public string someData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}