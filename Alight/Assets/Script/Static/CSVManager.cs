using System.IO;
using UnityEngine;

public static class CSVManager 
{

    private static string reportDirectoryName = "Report";
    private static string reportFileName = "Heartbeat Report.csv";
    private static string reportSeperator = ";";
    private static string reportHeader = "Heart Beat";
    private static string timeStampHeader = "Time Stamp";

    #region Interactions
    public static void AppendToReport(string strings)
    {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            if(finalString != "")
            {
                finalString += reportSeperator;
            }
            else
            {
                finalString += strings;
            }
            finalString += reportSeperator + GetTimeStamp();
            sw.WriteLine(finalString);

        }
    }
    
    public static void CreateReport()
    {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = "";
            
            if(finalString != "")
            {
                finalString += reportSeperator;
            }
            else
            {
                finalString += reportHeader;
            }
            finalString += reportSeperator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }
    #endregion

    #region Operation
    static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();

        if(!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFile()
    {
        string file = GetFilePath();
        if(!File.Exists(file))
        {
            CreateReport();
        }
    }
    #endregion

    #region Queries
    static string GetDirectoryPath()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName;
    }

    static string GetTimeStamp()
    {
        return System.DateTime.Now.ToString();
    }
    #endregion
}
