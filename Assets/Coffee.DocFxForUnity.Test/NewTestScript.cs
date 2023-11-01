using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;

namespace Coffee
{
    public class DocFxForUnityTest
    {
        [MenuItem("Development/Coffee.DocFxForUnity.SetupCsProj")]
        public static void SetupCsProjFromMenu()
        {
            DocFxForUnity.SetupCsProj();
        }

        [Test]
        public void SetupCsProj()
        {
            DocFxForUnity.SetupCsProj();
        }
    }
}
