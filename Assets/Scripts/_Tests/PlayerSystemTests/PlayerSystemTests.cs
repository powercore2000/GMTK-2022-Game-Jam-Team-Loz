using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DiceSystem;
using PlayerSystems;

public class PlayerSystemTests
{
    // Test to ensure d6 functions properly
    [Test]
    public void TestD6Rolls()
    {
        D6_Dice d6 = new D6_Dice();
        int result = d6.RollResult();
        Assert.IsTrue(1 <= result && result <= 6);
        //Debug.Log($"d6 rolled a {result}!");

    }
    //Test to see if player attack roll is in expected Value
    [Test]
    public void TestPlayerPersonalRolls()
    {
        PlayerStats stats = new PlayerStats();
        stats.SetCharacterStats(10);
        int attackResult = stats.RollPersonalDie();
        Assert.IsTrue(1 <= attackResult && attackResult <= 6);
        //Debug.Log($"Attack rolled a {attackResult}!");

    }


    //Test to see if player can take damage and Die
    [Test]
    public void TestPlayerDamageAndDeath()
    {
        PlayerStats stats = new PlayerStats();
        stats.SetCharacterStats(1);
        stats.TakeDamage(1);
        Assert.IsTrue(stats.IsDead);
        Assert.IsTrue(stats.Health == 0);


    }
    //Test if the player can heal to max and not beyond
    [Test]
    public void TestPlayerHeal()
    {
        PlayerStats stats = new PlayerStats();
        stats.SetCharacterStats(10);
        stats.TakeDamage(1);
        stats.Heal(2);
        Assert.IsTrue(stats.Health == 10);

    }

}
