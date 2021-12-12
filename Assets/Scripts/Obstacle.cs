using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;
    private float difficultyFactor = 0.4f;
    private Score score;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        var scoreGM = GameObject.Find("GameController");
        score = scoreGM.GetComponent<Score>();
    }

    private void Update()
    {
        CheckOutOfBoard();
    }

    public void Shoot(float additionalForce)
    {
        additionalForce *= difficultyFactor;
        m_Thrust += Random.Range(0, additionalForce);
        m_Rigidbody.AddForce(0, 0, -m_Thrust, ForceMode.Impulse);
    }

    private void CheckOutOfBoard()
    {
        if (transform.localPosition.z < -10)
        {
            if (CompareTag("trash"))
                score.Minus();
            Destroy(gameObject);
        }
    }
}