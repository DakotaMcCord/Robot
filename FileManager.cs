using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Robot {
    class FileManager {
        /*
         
        Class defines functions for saving and loading macros in text documents
         
         */

        // save file Func.
        public static void SaveFile(string[] Contents) {
            string ThisPath = Directory.GetCurrentDirectory(); // get directory of EXE

            // Create File Dialog and set paramiters
            SaveFileDialog FileDialog = new SaveFileDialog();

            FileDialog.InitialDirectory = ThisPath + @"/Saves";
            FileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            FileDialog.FilterIndex = 1;
            FileDialog.DefaultExt = "txt";
            FileDialog.FileName = "newFile";

            // ask user to confirm file write -> write passed data to file if confirmed
            if (FileDialog.ShowDialog() == DialogResult.OK) {
                File.WriteAllLines(FileDialog.FileName, Contents);
            }
        }

        // load file Func.
        public static string[] OpenFile() {
            string ThisPath = Directory.GetCurrentDirectory(); // get directory of EXE

            // Create File Dialog and set paramiters
            OpenFileDialog FileDialog = new OpenFileDialog();

            FileDialog.InitialDirectory = ThisPath + @"/Saves";
            FileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            FileDialog.FilterIndex = 1;
            FileDialog.DefaultExt = "txt";
            FileDialog.FileName = "newFile";

            // ask user to confirm file open -> open and output file data if confirmed
            if (FileDialog.ShowDialog() == DialogResult.OK) {
                return File.ReadAllLines(FileDialog.FileName);
            }
            return null; // return nothing if confirm failed
        }
    }
}
