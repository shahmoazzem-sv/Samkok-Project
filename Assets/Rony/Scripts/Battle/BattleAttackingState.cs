using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleAttackingState : IState
{
    List<Player> players;
    List<Enemy> enemies;
    BattleManager battleManager;
    public BattleAttackingState(BattleManager battleManager)
    {
        this.battleManager = battleManager;
        players = battleManager.players;
        enemies = battleManager.enemies;
    }
    public void Enter()
    {
        Debug.Log("In Battle Mode");
        //setting palyers target(enemy)

        if (enemies.Count > players.Count)
        {
            int i = 0;
            foreach (Player player in players)
            {
                player.SetTarget(enemies[i]);
                i++;
            }
            //player done(i =3)
            int j = 0;
            foreach (Enemy enemy in enemies)
            {
                enemy.SetTarget(players[j]);
                j++;
                if (j >= i) j = 0;
            }

        }
        else
        {
            int i = 0;
            foreach (Enemy enemy in enemies)
            {
                enemy.SetTarget(players[i]);
                i++;
            }
            //player done(i =3)
            int j = 0;
            foreach (Player player in players)
            {
                player.SetTarget(enemies[j]);
                j++;
                if (j >= i) j = 0;
            }
        }

        //Todo for all player and enemy , change their state to FightState
        foreach ((Player player, Enemy enemy) in players.Zip(enemies, (player, enemy) => (player, enemy)))
        {
            player.ChangeState(EntityState.GotoOpponent);
            enemy.ChangeState(EntityState.GotoOpponent);
        }

    }

    public void Exit()
    {
    }

    public void Update()
    {
        bool allPlayerDead = players.All((player) => player.life <= 0);
        bool allEnemiesDead = enemies.All((enemy) => enemy.life <= 0);
        if (allPlayerDead || allEnemiesDead) battleManager.ChangeState(BattleState.Finish);
    }
}