using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load1 : MonoBehaviour
{
    public enum LoadType
    {
        One,
        Two,
        


    }
    public LoadType type;
    private void Start()
    {
        switch (type)
        {
            case LoadType.One:
                StartCoroutine(LoadOne());
                break;
            case LoadType.Two:
                StartCoroutine(LoadTwo());
                break;
            
        }
        
    }


    
    IEnumerator LoadOne()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Dungeon");
        
    }
    IEnumerator LoadTwo()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Lobby");

    }
}
