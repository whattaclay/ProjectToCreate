using System.Collections;
using System.Collections.Generic;
using BallScripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class IntervalTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator IntervalTestWithEnumeratorPasses()
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(3, -0.75f, 0);
        var ball = Ball();
        for (int count = 0; count < 10; count++)
        {
            var startHeight = ball.transform.position.y;
            ball.Jump();
            yield return new WaitForSeconds(0.5f);
            Assert.IsTrue(ball.worldSpaceHeight > startHeight);
            Debug.Log($"start height{startHeight} ,ball height{ball.worldSpaceHeight}");
            yield return new WaitForSeconds(1.5f);
        }
    }

    private Ball Ball()
    {
        var position = new Vector3(3f, 0f, 0f);
        var spherePrefab = (Resources.Load("Sphere") as GameObject);
        var ball = Object.Instantiate(spherePrefab, position, Quaternion.identity);
        return ball.GetComponent<Ball>();
    }
}
