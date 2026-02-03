
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BattleFinishState : IState
{
    BattleManager battleManager;
    public BattleFinishState(BattleManager battleManager)
    {
        this.battleManager = battleManager;
    }
    public void Enter()
    {
        List<Player> players = battleManager.players;
        List<Enemy> enemies = battleManager.enemies;

        float playerScore = players.Sum((player) => player.life);
        float enemyScore = enemies.Sum((enemy) => enemy.life);
        if (playerScore > enemyScore)
        {
            battleManager.ShowWinner("Player Wins");
        }
        if (enemyScore > playerScore)
        {
            battleManager.ShowWinner("Enemy Wins");
        }
    }

    public void Exit()
    {

    }

    public void Update()
    {

    }
}