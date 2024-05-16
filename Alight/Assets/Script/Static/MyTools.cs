using UnityEditor;
using UnityEngine;

public static class MyTools 
{
    
    [MenuItem("My Tools/Add Defaults To Report %F1")] 
    static void DEV_AppendDefaultToReport()
    {
        CSVManager.AppendToReportCH(new string("Heartbeat"));
        //EditorApplication.Beep();
        Debug.Log("Report Updated Successfully");
    }

    [MenuItem("My Tools/Reset Report %F12")]
    static void DEV_ResetReport()
    {
        CSVManager.CreateReport();
        //EditorApplication.Beep();
        Debug.Log("Report Has Been Reset");
    }

    public static void DEV_AppendSpesificsToReport(string strings)
    {
        CSVManager.AppendToReportHB(strings);
        //EditorApplication.Beep();
        Debug.Log("Report Updated Successfully");
    }


}
