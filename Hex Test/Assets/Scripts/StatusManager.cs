using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public Characters playerStatus;
    public Characters enemyStatus;
    public bool isAttacked;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("player encountered an enemy");
            if (this.playerStatus.health > 0)
            {
                Debug.Log("player health > 0 ");
                if (!isAttacked)
                {
                    isAttacked = true;
                    setBattleData(other);
                    LevelLoader.instance.LoadLevel("BattleScene");
                    Debug.Log("player loaded to new scene");
                }
            }
        }
    }

    private void setBattleData(Collider other)
    {
        //player Data
        playerStatus.position[0] = this.transform.position.x;
        playerStatus.position[1] = this.transform.position.y;
        playerStatus.position[2] = this.transform.position.z;

        //Enemy Data
        Characters status = other.gameObject.GetComponent<EnemyStatus>().enemyStatus;
        enemyStatus.charName = status.charName;
        enemyStatus.characterGameObject = status.characterGameObject.transform.GetChild(0).gameObject;
        enemyStatus.health = status.health;
        enemyStatus.maxHealth = status.maxHealth;
    }
}
