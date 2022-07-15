using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DiceSystem;

public class DiceSystemTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestIfD4DiceWorks()
    {
        D4_Dice d4 = new D4_Dice();
        int result = d4.RollResult();
        Assert.IsTrue(0 < result && result < 5);
        Debug.Log($"d4 rolled a {result}!");

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator DiceSystemTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
