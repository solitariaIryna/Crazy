using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [SerializeField] private  Apple _applePrefab;
    private float _speed = 15f;
    private float _LeftAndRightEdge = 10f;
    private float _chanceToChangeDirections = 0.1f;
    private float _secondsBetweenAppleDrops = 1f;


    void Start()
    {
        //Скидати яблука раз в секунду

        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        Apple apple = Instantiate(_applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", _secondsBetweenAppleDrops);
    }

    
    void Update()
    {
        //Переміщення
        transform.Translate(new Vector3(transform.position.x, 0, 0) * _speed * Time.deltaTime);
        
        //pos.x += _speed * Time.deltaTime;
        //transform.position = pos;

        //Зміна напрямку
        if (transform.position.x < -_LeftAndRightEdge)
        {
            _speed = Mathf.Abs(_speed);
        }
        else if (transform.position.x > _LeftAndRightEdge)
        {
            _speed = -Mathf.Abs(_speed);
        }
        
        
    }
    void FixedUpdate()
    {
        if (Random.value < _chanceToChangeDirections)
        {
            _speed *= -1;
        }
    }
}
