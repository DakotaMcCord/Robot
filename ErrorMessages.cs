using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Robot {
    public class ErrorMessages {
        /*
         
        Class defines string returns for potential errors

         */

        public static void Show_Default_AllClear() {
            MessageBox.Show("No Errors were found.", "Notification");
        }
        public static void ShowError_Default_Notation(string errorItem) {
            MessageBox.Show(
                "Command notation error found.\n" +
                $"   Please verify that \"{errorItem}\" is a valid command.\n" +
                $"   Valid commands consist of a Keyword and at least one Atribute.\n\n" +
                $"Example:\n" +
                $"   KEYWORD ATRIBUTE,ATRIBUTE\n" +
                $"   MoveMouse 100,100", "Error");
        }

        public static void ShowError_GOTO_Notation(string errorItem) {
            MessageBox.Show(
                "Command notation error found.\n" +
                $"   Please verify that \"{errorItem}\" is a valid command.\n" +
                $"   Valid GoTo commands consist of a Keyword and two Atributes.\n\n" +
                $"Example:\n" +
                $"   KEYWORD ATRIBUTE,ATRIBUTE\n" +
                $"   GoTo FLAG,-9", "Error");
        }
        public static void ShowError_GOTO_FlagError(string errorItem1, string errorItem2) {
            MessageBox.Show(
                $"\"goto\" must contain a flag reference.\n" +
                $"   Error from \"goto {errorItem1}\"" +
                $"   Flag required \":{errorItem2}\"\n\n" +
                $"Example:\n" +
                $"   :FLAG\n" +
                $"   . . .\n" +
                $"   . . .\n" +
                $"   . . .\n" +
                $"   goto FLAG,-9", "Error");
        }
        public static void ShowError_GOTO_CountError(string errorItem1, string errorItem2) {
            MessageBox.Show(
                $"\"goto\" must contain a count reference.\n" +
                $"   Error from \"goto {errorItem1}\"" +
                $"   Count required \"{errorItem2},NUMBER\"\n\n" +
                $"Example:\n" +
                $"   :FLAG\n" +
                $"   . . .\n" +
                $"   . . .\n" +
                $"   . . .\n" +
                $"   goto FLAG,-9", "Error");
        }
        public static void ShowWarning_GOTO_EndlessLoop() {
            MessageBox.Show(
                $"goto count of -9 will loop FOREVER.\n" +
                $"   if this is a mistake, make the count a positive number.\n" +
                $"   a positive count will will loop only that number of times.\n", "Warning.");
        }
        public static void ShowError_GOTO_LoopError() {
            MessageBox.Show(
                $"goto count less than 0 must be -9.\n" +
                $"   you must make the count a positive number or:\n" +
                $"   you must make the count -9 to loop FOREVER.\n", "Error.");
        }

        public static void ShowError_HoldMouse_KeyError(string errorItem1) {
            MessageBox.Show(
                "HoldMouse expecting a mouse key to be entered.\n" +
                $"   Error from: \"{errorItem1}\"\n" +
                $"   Valid mouse keys are: \"M1\", \"M2\", or \"M3\"\n\n" +
                $"Example: \n" +
                $"   HoldMouse M1\n" +
                $"   HoldMouse M2\n" +
                $"   HoldMouse M3\n", "Error");
        }
        public static void ShowWarning_HoldMouse_ReleaseMouse(string errorItem1) {
            MessageBox.Show(
                "HoldMouse expecting a RealeaseMouse call.\n" +
                $"   \"{errorItem1}\" may be held forever.\n" +
                $"   If you do not want the chosen mouse key to be held forever use a ReleaseMouse Call.\n" +
                $"   If you already have a ReleaseMouse Call for the given mouse key, you may ignore this message.\n\n" +
                $"Example: \n" +
                $"   ReleaseMouse M1\n" +
                $"   ReleaseMouse M2\n" +
                $"   ReleaseMouse M3\n", "Warning");
        }

        public static void ShowError_MoveMouse_Notation(string errorItem1) {
            MessageBox.Show(
                "Command notation error found.\n" +
                $"   Please verify that \"{errorItem1}\" is a valid command.\n" +
                $"   Valid MoveMouse commands consist of a Keyword and two Atributes.\n\n" +
                $"Example:\n" +
                $"   KEYWORD ATRIBUTE,ATRIBUTE\n" +
                $"   MoveMouse 000,-000", "Error");
        }
        public static void ShowError_MoveMouse_XYError(string errorItem1, string errorItem2) {
            MessageBox.Show(
                "Command notation error found.\n" +
                $"   Error From: \"{errorItem1}\".\n" +
                $"   Make sure that \"{errorItem2}\" is a whole number.\n\n" +
                $"Example:\n" +
                $"   MoveMouse -000,000\n" +
                $"   MoveMouse 000,-000", "Error");
        }

        public static void ShowError_PressMouse_KeyError(string errorItem1) {
            MessageBox.Show(
                "PressMouse expecting a mouse key to be entered.\n" +
                $"   Error from: \"{errorItem1}\"\n" +
                $"   Valid mouse keys are: \"M1\", \"M2\", or \"M3\"\n\n" +
                $"Example: \n" +
                $"   PressMouse M1\n" +
                $"   PressMouse M2\n" +
                $"   PressMouse M3\n", "Error");
        }

        public static void ShowError_ReleaseMouse_KeyError(string errorItem1) {
            MessageBox.Show(
                "ReleaseMouse expecting a mouse key to be entered.\n" +
                $"   Error from: \"{errorItem1}\"\n" +
                $"   Valid mouse keys are: \"M1\", \"M2\", or \"M3\"\n\n" +
                $"Example: \n" +
                $"   ReleaseMouse M1\n" +
                $"   ReleaseMouse M2\n" +
                $"   ReleaseMouse M3\n", "Error");
        }

        public static void ShowError_Wait_IntError(string errorItem1) {
            MessageBox.Show(
                "Wait command expecting a positive whole number to be entered.\n" +
                $"   Error from: \"{errorItem1}\"\n" +
                $"   Number must be positive.\n" +
                $"   *NOTE: number will be counted in milliseconds.\n" +
                $"       -> 1 Second is 1000 miliseconds.\n\n" +
                $"Example: \n" +
                $"   Wait 0 (0 seconds)\n" +
                $"   Wait 1000 (1 second)\n" +
                $"   Wait 5000 (5 seconds)\n", "Error");
        }
    }
}
