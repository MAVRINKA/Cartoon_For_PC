/* 
*   NatCorder
*   Copyright (c) 2022 NatML Inc. All Rights Reserved.
*/

namespace NatSuite.Recorders.Internal {

    using System;
    using System.IO;
    using UnityEngine;

    public static class Utility {

        private static string directory;

        public static string GetPath (string extension) {
            if (directory == null) {
                var editor = Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor;
                directory = editor ? Directory.GetCurrentDirectory() : Application.dataPath + "/Logs";
            }
            var timestamp = DateTime.Now.ToString("dd.MM.yyyy'  'HH_mm_ss_fff");
            var name = $"Cartoon_{timestamp}{extension}";
            var path = Path.Combine(directory, name);
            return path;
        }
    }
}