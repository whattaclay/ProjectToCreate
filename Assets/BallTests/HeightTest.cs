using System;
using System.Collections;
using System.Collections.Generic;
using BallScripts;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TextCore.Text;
using Object = UnityEngine.Object;

public class HeightTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void HeightTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator HeightTestWithEnumeratorPasses()
    {
        var height = -2f;
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, -0.75f, 0);
        var ball = Ball();
        yield return new WaitForSeconds(0.5f);
        ball.Jump();
        for (; height <= ball.transform.position.y;)
        {
            height = ball.transform.position.y;
            yield return new WaitForFixedUpdate();
        }
        Debug.Log($"Test height: {height}, current {ball.maxHeight}");
        Assert.IsTrue(ball.maxHeight == height);
    }

    private Ball Ball()
    {
        var spherePrefab = (Resources.Load("Sphere") as GameObject);
        var ball = Object.Instantiate(spherePrefab, Vector3.zero, Quaternion.identity);
        return ball.GetComponent<Ball>();
    }
}
