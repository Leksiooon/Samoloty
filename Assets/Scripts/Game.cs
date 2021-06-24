using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public string textValue;
    public Text textElement;

    void Start()
    {
        textElement.text = "";
    }

    void Update()
    {
        var enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyList.Length == 1)
        {
            var lastEnemy = enemyList[0].GetComponent<EnemyBehavior>();
            if (lastEnemy.myDestroyEffectsProp.isPlaying)
            {
                textElement.text = textValue;
                Invoke("ExecuteAfterTime", 2f);
            }
        }
    }

    void ExecuteAfterTime()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
