using NUnit.Framework;
using UnityEditor;

public class DocFxForUnityTest
{
    [MenuItem("Development/DocFxForUnity.SetupCsProj")]
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
