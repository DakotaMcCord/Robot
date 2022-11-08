using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Robot {
    class Commands {
        /*
         
        Class Defines use and functionallity for command call functions.
         
         */


        // inport user32.dll and create a mouse event func. for handeling mouse clicks
        [DllImport("user32.dll")]
        private  static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        // default mouse event calls
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;      // m1 mouse down
        private const int MOUSEEVENTF_LEFTUP = 0x0004;             // m1 mouse up
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;   // m2 mouse down
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;           // m2 mouse up
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; // m3 mouse down
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;        // m13mouse up

        // store mouse down and mouse up valuse in a vector for simple acess
        private static Vector2 
            LEFT_MOUSE = new Vector2(MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP),   // M1
            RIGHT_MOUSE = new Vector2(MOUSEEVENTF_RIGHTDOWN, MOUSEEVENTF_RIGHTUP),   // M2
            MIDDLE_MOUSE = new Vector2(MOUSEEVENTF_MIDDLEDOWN, MOUSEEVENTF_MIDDLEUP);   // M3

        // define a dictionary to call mouse buttons from a string identifier
        private static Dictionary<string, Vector2> MouseKeys = new Dictionary<string, Vector2>() {
            {"m1", LEFT_MOUSE}, {"m2", RIGHT_MOUSE}, {"m3", MIDDLE_MOUSE}
        };

        // wait Command -> puts thread to sleep based on the int(time) passed
        public static void Wait(int time) {
            Thread.Sleep(time);
        }
        
        // use SndKeys API to output keypresses based on string(Key) passed
        public static void PressKey(string Key) {
            SendKeys.SendWait(Key);
        }
        
        // use preveously defined mouse event to send a mouse down and up event based on string(mouseKey) passed
        public static void PressMouse(string Mouse) {
            // mouse_event((int)MouseKeys[Mouse.ToLower()].X, 0, 0, 0, 0);
                  // get mouse key value from dictionary
                  // X(mouse Down) or Y(mouse Up)

            mouse_event((int)MouseKeys[Mouse.ToLower()].X, 0, 0, 0, 0); // key down event
            mouse_event((int)MouseKeys[Mouse.ToLower()].Y, 0, 0, 0, 0); // key up event
        }

        // use preveously defined mouse event to send a mouse down event based on string(mouseKey) passed
        public static void HoldMouse(string Mouse) {
            // mouse_event((int)MouseKeys[Mouse.ToLower()].X, 0, 0, 0, 0);
                    // get mouse key value from dictionary
                    // X(mouse Down) or Y(mouse Up)

            mouse_event((int)MouseKeys[Mouse.ToLower()].X, 0, 0, 0, 0); // key down event
        }

        // use preveously defined mouse event to send a mouse up event based on string(mouseKey) passed
        public static void ReleaseMouse(string Mouse) {
            // mouse_event((int)MouseKeys[Mouse.ToLower()].X, 0, 0, 0, 0);
                    // get mouse key value from dictionary
                    // X(mouse Down) or Y(mouse Up)

            mouse_event((int)MouseKeys[Mouse.ToLower()].Y, 0, 0, 0, 0); // key up event
        }

        // recieve and output pouseposition
        public static Point GetMousePosition() {
            return Cursor.Position;
        }

        // set mouse cursor X and Y based on Passed int(X) and int(Y) positions
        public static void SetMousePosition(int XPosition, int YPosition) {
            Cursor.Position = new Point(XPosition, YPosition);
        }

        // output a full string using Clipboard API and standard (sendkeys) Copy-Paste shortcut for windows besed on string(text) passed
        public static void TypeText(string Text) {
            Clipboard.SetText(Text);
            SendKeys.SendWait("^v");
        }
    }
}
