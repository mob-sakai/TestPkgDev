using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using Is = UnityEngine.TestTools.Constraints.Is;
namespace EditModeTests
{
    public class NewTestScript
    {
        [Test]
        public void AllocatingGCMemory()
        {
            Assert.That(() =>
            {
                Debug.Log(Vector3.one);
            }, Is.AllocatingGCMemory());
        }

        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
