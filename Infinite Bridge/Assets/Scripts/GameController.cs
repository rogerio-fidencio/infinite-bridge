using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{

    private PlayerController _playerController;

    [Header("Globals")]
    public float posXPlayer;
    public int score;
    public TextMeshProUGUI txtScore;

    [Header("Config. Player")]
    public float moveSpeed;
    public float limitMaxY;
    public float limitMinY;
    public float limitMaxX;
    public float limitMinX;

    [Header("config. Objects")]
    public float bridgeSpeed;
    public float destroyDistance;
    public float bridgeSize;
    public GameObject bridgePrefab;

    [Header("config. Barrel")]
    public float posYTop;
    public float posYDown;
    public int orderTop;
    public int orderDown;
    public float barrelSpeed;
    public float spawnTime;
    public GameObject barrelPrefab;

    [Header("FX Sound")]
    public AudioSource fxSource;
    public AudioClip fxScore;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnBarrel");
        _playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        posXPlayer = _playerController.transform.position.x;
    }


    IEnumerator spawnBarrel()
    {
        float posY;
        int order;

        yield return new WaitForSeconds(spawnTime);
        int rand = Random.Range(0, 100);
        if (rand > 50)
        {
            posY = posYTop;
            order = orderTop;
        }
        else
        {
            posY = posYDown;
            order = orderDown;
        }

        GameObject temp = Instantiate(barrelPrefab);
        temp.transform.position = new Vector2(temp.transform.position.x, posY);
        temp.GetComponent<SpriteRenderer>().sortingOrder = order;
        StartCoroutine("spawnBarrel");
    }

    public void addScore(int value)
    {
        score += value;
        txtScore.text = score.ToString();
        fxSource.PlayOneShot(fxScore);
    }

    public void changeScene(string destinationScene)
    {
        SceneManager.LoadScene(destinationScene);
    }

}
