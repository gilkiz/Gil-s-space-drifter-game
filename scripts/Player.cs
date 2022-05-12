using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text phaseDisplayText;
    private Touch theTouch;
    private float timeTouchEnded;
    private float displayTime = 0.5f;
    private SpriteRenderer spriteRenderer; 
    public Sprite[] sprites;
    private int currentSprite;
    public Vector3 direction;

    public float gravity= -9.8f;

    public float strength = 5f;
    public float half_strength = 2.5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); 
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.x = 437.6780f;
        position.y = 164.064f;
        transform.position = position;
        direction = Vector3.zero;
    }

    public void Update() 
    {
        //currentSprite = 1;
        currentSprite = 0;
        if(Input.GetKey("space") || Input.touchCount == 2){
            //currentSprite = 0;
            direction = Vector3.up * strength;
        }
        if(Input.GetKey("return") || Input.touchCount == 3){
            //currentSprite = 0;
            direction = Vector3.up * strength * 2;
        }
        if (Input.GetKey("a") || Input.touchCount == 1){
            direction = Vector3.up  * half_strength;
            //currentSprite = 0;
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {

        if(currentSprite >= sprites.Length){
            currentSprite=0;
        }

        spriteRenderer.sprite = sprites[currentSprite];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if(other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
        
    }
}
