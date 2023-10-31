using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

public class TestRunnerExecution : MonoBehaviour
{
    [MenuItem("Development/Run Tests")]
    static void Start()
    {
        var testRunnerApi = ScriptableObject.CreateInstance<TestRunnerApi>();
        var filter = new Filter()
        {
            testMode = TestMode.PlayMode | TestMode.EditMode,
        };
        testRunnerApi.Execute(new ExecutionSettings(filter));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
