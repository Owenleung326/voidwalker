using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleSystemManager : MonoBehaviour
{   
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOST }

    private GameObject enemy;
    private GameObject player;

    public Transform enemyBattlePosition;
    public Transform playerBattlePosition;

    public Characters playerStatus;
    public Characters enemyStatus;

    public TMP_Text text;

    private BattleState battleState;

    private bool hasClicked = true;

    public int enemyMoves;

    public CursorLock Cursors;

    public void Start()
    {
        battleState = BattleState.START;
        StartCoroutine(BeginBattle());
    }

    IEnumerator BeginBattle()
    {
        //spawn characters on the platforms
        enemy = Instantiate(enemyStatus.characterGameObject, enemyBattlePosition); enemy.SetActive(true);
        player = Instantiate(playerStatus.characterGameObject.transform.GetChild(0).gameObject, playerBattlePosition); player.SetActive(true);

        text.text = "The battle begin";

        yield return new WaitForSeconds(2);

        battleState = BattleState.PLAYERTURN;

        yield return StartCoroutine(PlayerTurn());
    }

    IEnumerator PlayerTurn()
    {
        Debug.Log("Player's turn");
        yield return new WaitForSeconds(1);

        text.text = "Player's turn";

        hasClicked = false;
    }

    public void OnNormalAttackButtonPress()
    {
        if (battleState != BattleState.PLAYERTURN)
            return;

        if (!hasClicked)
        {
            StartCoroutine(PlayerNormalAttack());
            hasClicked = true;
        }
    }

    public void OnHeavyAttackButtonPress()
    {
        if (battleState != BattleState.PLAYERTURN)
            return;

        if (!hasClicked)
        {
            StartCoroutine(PlayerHeavyAttack());
            hasClicked = true;
        }
    }

    public void OnSplashButtonPress()
    {
        if (battleState != BattleState.PLAYERTURN)
            return;

        if (!hasClicked)
        {
            StartCoroutine(PlayerSplash());
            hasClicked = true;
        }
    }

    public void OnEscapeButton()
    {
        if (battleState != BattleState.PLAYERTURN)
            return;

        if (!hasClicked)
        {
            StartCoroutine(PlayerEscape());
            hasClicked = true;
        }
    }

    IEnumerator PlayerNormalAttack()
    {
        Debug.Log("player normal attacked");

        text.text = "Player normal attacked";

        yield return new WaitForSeconds(2);

        enemyStatus.health -= 10;
        Debug.Log("Enemy losses 10 health, current health, " + enemyStatus.health);

        if (enemyStatus.health <= 0)
        {
            battleState = BattleState.WIN;
            yield return StartCoroutine(EndBattle());
        }
        else
        {
            battleState = BattleState.ENEMYTURN;
            yield return StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerHeavyAttack()
    {
        Debug.Log("player heavy attacked");

        text.text = "Player heavy attacked";

        yield return new WaitForSeconds(2);

        enemyStatus.health -= 999999;
        Debug.Log("Enemy losses 999999 health, current health, " + enemyStatus.health);

        if (enemyStatus.health <= 0)
        {
            battleState = BattleState.WIN;
            yield return StartCoroutine(EndBattle());
        }
        else
        {
            battleState = BattleState.ENEMYTURN;
            yield return StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerSplash()
    {
        Debug.Log("player used Splash");

        text.text = "Player splashed!";

        yield return new WaitForSeconds(2);

        enemyStatus.health -= 0;
        Debug.Log("But nothing happened! current health, " + enemyStatus.health);

        if (enemyStatus.health <= 0)
        {
            battleState = BattleState.WIN;
            yield return StartCoroutine(EndBattle());
        }
        else
        {
            battleState = BattleState.ENEMYTURN;
            yield return StartCoroutine(EnemyTurn());
        }
    }

   
    IEnumerator EnemyTurn()
    {
        text.text = "Enemy's Turn";

        enemyMove();

        yield return new WaitForSeconds(2);

        if (playerStatus.health <= 0)
        {
            battleState = BattleState.LOST;
            yield return StartCoroutine(EndBattle());
        }
        else
        {
            battleState = BattleState.PLAYERTURN;
            yield return StartCoroutine(PlayerTurn());
        }
    }

    IEnumerator PlayerEscape()
    {   
        yield return new WaitForSeconds(2);
        text.text = "Player Escaped!";
        Debug.Log("Player Escaped!");
        LevelLoader.instance.LoadLevel("MainScene");
    }

    void enemyMove()
    {
        int randomNumber = Random.Range(1, 5);
        switch (randomNumber)
        {
            case 5:
                playerStatus.health -= 10;
                text.text = "Player losses 10 health, current health " + playerStatus.health;
                Debug.Log("Player losses 10 health, current health, " + playerStatus.health);
                break;
            case 4:
                playerStatus.health -= 20;
                text.text = "Player losses 20 health, current health, " + playerStatus.health;
                Debug.Log("Player losses 20 health, current health, " + playerStatus.health);
                break;
            case 3:
                playerStatus.health -= 15;
                text.text = "Player losses 15 health, current health, " + playerStatus.health;
                Debug.Log("Player losses 15 health, current health, " + playerStatus.health);
                break;
            case 2:
                enemyStatus.health += 20;
                text.text = "Enemy restored 20 health, current health, " + enemyStatus.health;
                Debug.Log("Enemy restored 20 health, current health, " + enemyStatus.health);
                break;
            case 1:
                enemyStatus.health += 10;
                text.text = "Enemy restored 10 health, current health, " + enemyStatus.health;
                Debug.Log("Enemy restored 10 health, current health, " + enemyStatus.health);
                break;
            default:
                Debug.Log("error");
                break;
        }
    }

    IEnumerator EndBattle()
    {
        if (battleState == BattleState.WIN)
        {
            Debug.Log("Player Win");
            text.text = "Player Win!";
            yield return new WaitForSeconds(1);
            LevelLoader.instance.LoadLevel("MainScene");

        } else if (battleState == BattleState.LOST)
        {
            Debug.Log("Player Loses");
            text.text = "Player losses";
            yield return new WaitForSeconds(1);

            LevelLoader.instance.LoadLevel("TestLevel");
        }
    }
}
