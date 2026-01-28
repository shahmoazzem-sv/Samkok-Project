using System.Collections.Generic;
using UnityEngine;

public class BattleAttackingState : IState
{
    List<Player> players;
    List<Enemy> enemies;
    public BattleAttackingState(BattleManager battleManager, List<Player> allPlayers, List<Enemy> allEnemies)
    {
        this.players = allPlayers;
        this.enemies = allEnemies;
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

    }

    public void Exit()
    {
    }

    public void Update()
    {

    }
}