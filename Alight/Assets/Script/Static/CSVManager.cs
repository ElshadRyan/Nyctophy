using System.IO;
using UnityEngine;

public static class CSVManager 
{

    private static string reportDirectoryName = "Report";
    private static string reportHeartbeatName = "Heartbeat Report.csv";
    private static string reportCompletedChalengesName = "Chalenge Report.csv";
    private static string reportSeperator = ";";
    private static string reportHeaderHB = "Heart Beat";
    private static string[] reportHeaderCH = new string[3]
    {
        "Status Chalenge",
        "Kode Chalenge",
        "Waktu Selesai/Keluar"
    };

    #region Interactions
    public static void AppendToReportHB(string strings)
    {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetHeartbeatFilePath()))
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
            sw.WriteLine(finalString);

        }
    }

    public static void AppendToReportCH(string strings)
    {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetCompletedChalengesFilePath()))
        {
            string finalString = "";
            if (finalString != "")
            {
                finalString += reportSeperator;
            }
            else
            {
                finalString += strings;
            }
            sw.WriteLine(finalString);

        }
    }
    
    public static void CreateReport()
    {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetHeartbeatFilePath()))
        {
            string finalString = "";
            
            if(finalString != "")
            {
                finalString += reportSeperator;
            }
            else
            {
                finalString += reportHeaderHB;
            }
            sw.WriteLine(finalString);
        }

        using (StreamWriter sw = File.CreateText(GetCompletedChalengesFilePath()))
        {
            string finalString = "";
            for (int i = 0; i<reportHeaderCH.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeperator;
                }
                finalString += reportHeaderCH[i];
                
            }            
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
        string file = GetHeartbeatFilePath();
        string file1 = GetCompletedChalengesFilePath();
        if (!File.Exists(file) && !File.Exists(file1))
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

    static string GetHeartbeatFilePath()
    {
        return GetDirectoryPath() + "/" + reportHeartbeatName;
    }

    static string GetCompletedChalengesFilePath()
    {
        return GetDirectoryPath() + "/" + reportCompletedChalengesName;
    }
        
    #endregion
}
