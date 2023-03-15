using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Editor
{
    [InitializeOnLoad]
    public sealed class InitJennyServer
    {
        const string SESSION_SERVER_KEY = "IsServerInit";
        const string JENNY_PATH = "Jenny-Server.bat";
        
        static InitJennyServer()
        {
            if (SessionState.GetBool(SESSION_SERVER_KEY , false))
                return;
            
            StartServer();
        }

        private static void StartServer()
         {
             string fullPathToJennyServer = Path.Combine(
                 Path.GetDirectoryName(Application.dataPath) ?? 
                 throw new InvalidOperationException("Error occured!!\nRun Jenny-Server manually"),
                 JENNY_PATH);
             
             Process.Start(fullPathToJennyServer);
             SessionState.SetBool(SESSION_SERVER_KEY , true);
             Debug.Log("Jenny Server is running!");
         }
    }
}
