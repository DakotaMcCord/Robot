using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys.send?view=windowsdesktop-6.0

namespace Robot {
    public partial class Main : Form {
        /*
         
        Class acts as main -> handels all UI interactions

         */

        #region Hotkey
        // VKey information for windows shortcut
        // overrides WndProc Call

        // inport user32.dll and create call to Register HotKey
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        // inport user32.dll and create call to UnRegister HotKey
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        #endregion
        public Main() {
            InitializeComponent();
        }

        // OnFormLoad and OnFormClosing:
        private void Form1_Load(object sender, EventArgs e) {
            this.MaximumSize = this.Size; // set max size to default size
            CountDown_GRPBOX.Visible = false; // set the countdown panel to invisible
            RunMacro_BTN.Enabled = false; // disable the run button

            CountDown_TIMER.Interval = 1000; // set GetMousePosition Counttown interval to 1 second.
            CountDown_TIMER.Tick += new EventHandler(GetCoordinatesCountDown); // set countdown trigger to get mouse position

            RegisterHotKey(this.Handle, 1, 0x0000, 0x60); // register the Activate/Deactivate HotKey to NumPad 0
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            // ask User to Confirm Close or Cancel
            if (MessageBox.Show("Are you sure you want to quit.\nAny unsaved changes will be lost.", "Warning.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) {
                e.Cancel = true;
            }
            UnregisterHotKey(this.Handle, 1); // OnFormClose, Unregister HotKey.
            MacroIsRunning = false;
        }

        // Controlls for the Parser, GetMousePos Button, and GetCoard.Countdown Tick timer.
        private void MacroParser_CMBBOX_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                // when the ENTER key is pressed while the Parser is Active:
                MacroEditor_TXTBOX.Text += (MacroParser_CMBBOX.Text + Environment.NewLine); // add Parser Text to editor with a newline
                MacroParser_CMBBOX.Text = string.Empty; // clear the Parser

                MacroEditor_TXTBOX.Select(MacroEditor_TXTBOX.Text.Length, 0); // set caret position to last position in editor
                MacroEditor_TXTBOX.ScrollToCaret(); // scroll to caret (bottom of Editor)

                e.Handled = true; // set key to handeld -> blocks further action and disables windows message Beep
            }
        }
        private void GetMousePos_BTN_Click(object sender, EventArgs e) {
            // when GetMousePos Button Pressed:
            CountDown_GRPBOX.Visible = true; // make coundown groupbox visible

            CountDown_LBL.Text = "3"; // reset countdown text to 3
            
            CountDown_TIMER.Start(); // start timer tick -> will count down for 3 seconds
            GetMousePos_BTN.Enabled = false; // disable Button until reset
        }
        private void GetCoordinatesCountDown(object sender, System.EventArgs e) {
           // on countdown trigger tick:
            int CurrentCount = Int32.Parse(CountDown_LBL.Text); // get label text and turn into int

            CurrentCount--; // subtract 1 from count
            CountDown_LBL.Text = CurrentCount.ToString(); // set label text to new count

            if (CurrentCount <= 0) { // on count less than or equal to 0
                CountDown_TIMER.Stop(); // stop counting

                // get mouse position and set parser to command with position pretyped
                MacroParser_CMBBOX.Text = "MoveMouse " + Commands.GetMousePosition().X + "," + Commands.GetMousePosition().Y;

                CountDown_GRPBOX.Visible = false; // make CountGroupBox Invisible
                GetMousePos_BTN.Enabled = true; // reenable getMousePos Button
            }
        }

        // Save, Load, and New File Functions:
        private void Save_BTN_Click(object sender, EventArgs e) {
            // Call Save Function from FileManager -> pass Editor Contents
            FileManager.SaveFile(MacroEditor_TXTBOX.Text.Split(Environment.NewLine));
        }
        private void Load_BTN_Click(object sender, EventArgs e) {
            // ask user to confirm overrite
            if (MessageBox.Show("Are you sure you want to load a new file?\nAny unsaved changes will be lost.", "Warning.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) {
                return; // exit func. of user declines
            }
            string[] Contents = FileManager.OpenFile(); // create array with contents of file being opened.
            if (Contents != null) { // if array is not empty
                MacroEditor_TXTBOX.Text = string.Empty; // set editor text to null
                
                // add each line from file to editor
                foreach (string Line in Contents) {
                    MacroEditor_TXTBOX.Text += $"{Line}{Environment.NewLine}";
                }
            }
        }
        private void New_BTN_Click(object sender, EventArgs e) {
            // ask user to confirm reset
            if (MessageBox.Show("Are you sure you want to create a new file?\nAny unsaved changes will be lost.", "Warning.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                MacroEditor_TXTBOX.Text = string.Empty; // on agree -> set Editor text to null
            }
        }

        // Editor TextChanged func.:
        private void MacroEditor_TXTBOX_TextChanged(object sender, EventArgs e) {
            RunMacro_BTN.Enabled = false; // disable Run Button
            MacroIsRunning = false; // set macro to not running
        }

        // run and manage macro funcs.
        bool MacroIsRunning = false; // create bool to determine macro is running -> instanciate to false (not running)
        private void RunMacro_BTN_Click(object sender, EventArgs e) {
            Thread MacroThread = new Thread(new ThreadStart(MacroToRun)); // create thread to run macro in
            MacroThread.SetApartmentState(ApartmentState.STA); // set thread to STA for use with Clipboard

            // Check if macro is running -> toggle run state:
            if (!MacroIsRunning) { // not running
                MacroIsRunning = !MacroIsRunning; // set to run
                MacroThread.Start(); // start thread (starts macro)
            } 
            else { // is running
                MacroIsRunning = !MacroIsRunning; // stop running
            }
        }
        protected override void WndProc(ref Message m) {
            // overrides default windows function -> detecs hotkey press -> continue default windows function

            // if hotkey is pressed
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == 1 && RunMacro_BTN.Enabled == true) {
                RunMacro_BTN_Click(null, null); // mimic run macro button click
            }

            base.WndProc(ref m); // continue to do default Windows function
        }
        private void MacroToRun() {
            string[] MacroContents = MacroEditor_TXTBOX.Text.Split($"{Environment.NewLine}"); // load macro for running -> loads in array

            // for each command -> execute
            for (int i = 0; i < MacroContents.Length; i++) {
                if (!MacroIsRunning) { // check macro is supposed to be running
                    return; // exit run if false.
                }
                Thread.Sleep(100); // add delay to thread to keep from (horibly) burning the processor

                string[] Reader = MacroContents[i].Split(' '); // split each line at a space
                string[] SubReader = null; // sub reader used for specific commands

                // for each line parsed -> execute
                switch (Reader[0].ToLower()) {
                    #region GOTO
                    // on goto command:
                    case "goto":
                        SubReader = Reader[1].Split(','); // split line for format - GoTo FLAG,100

                        if (Int32.Parse(SubReader[1]) == -9 || Int32.Parse(SubReader[1]) > 1) { // if Subreader 1 == -9 or greater than 1:
                            if (SubReader[1] != "-9") { // if subreader 1 is != -9 -> -9 would Loop Forever
                                SubReader[1] = $"{Int32.Parse(SubReader[1]) - 1}"; // subtract 1 from count
                                MacroContents[i] = $"{Reader[0]} {SubReader[0]},{SubReader[1]}"; // change line contents to new int
                            }
                            i = Array.IndexOf(MacroContents, $":{SubReader[0]}"); // set i to index of FLAG to loop through index

                            //Debug.WriteLine($"Jumped: {SubReader[1]}"); // debug line
                        }
                        break;
                    #endregion
                    #region HOLDMOUSE
                    // on holdmouse call:
                    case "holdmouse":
                        Commands.HoldMouse(Reader[1]); // call Cammand to holdmouse
                        break;
                    #endregion
                    #region MOVEMOUSE
                    // on movemouse call:
                    case "movemouse":
                        SubReader = Reader[1].Split(','); // split line for Format - MOVEMOUSE X,Y

                        Commands.SetMousePosition(Int32.Parse(SubReader[0]), Int32.Parse(SubReader[1])); // call setMousePos Command
                        break;
                    #endregion
                    #region PRESSKEYS
                    // on press keys:
                    case "presskeys":
                        string KeysToPress = ""; // set temp string to null
                        for (int n = 1; n < Reader.Length; n++) { // for each entry in reader after first:
                            KeysToPress += Reader[n]; // add to keysToPress
                            // if not at end -> add space back to keypress
                            if (n != Reader.Length -1) {
                                KeysToPress += " ";
                            }
                        }
                        Commands.PressKey(KeysToPress); // call press keys Command -> pass KeysToPress
                        break;
                    #endregion
                    #region PRESSMOUSE
                    // on pressmouse call:
                    case "pressmouse":
                        Commands.PressMouse(Reader[1]); // call pressmouse command
                        break;
                    #endregion
                    #region RELEASEMOUSE
                    // on releasemouse call:
                    case "releasemouse":
                        Commands.ReleaseMouse(Reader[1]); // Cakk release mouse command
                        break;
                    #endregion
                    #region TYPE
                    // on type call:
                    case "type":
                        string TextToType = ""; // creat temp string -> set to null
                        for (int n = 1; n < Reader.Length; n++) { // for each entry after first:
                            TextToType += Reader[n]; // add to TextToType
                            // if not last entry -> re add space
                            if (n != Reader.Length) { 
                                TextToType += " ";
                            }
                        }
                        Commands.TypeText(TextToType); // call TypeText Command
                        break;
                    #endregion
                    #region WAIT
                    // on wait call:
                    case "wait":
                        Commands.Wait(Int32.Parse(Reader[1])); // Call Wait Command
                        break;
                    #endregion
                    #region Default
                    // default call:
                    default:
                        // if empty or command does not start with :
                        if (Reader[0] != string.Empty && Reader[0][0] != ':') {
                            // show Error
                            MessageBox.Show($"Unknown Command: {Reader[0]}", "CRITICAL ERROR");
                            return; // exit loop
                        }
                        break;
                        #endregion
                }
            }

            MacroIsRunning = false; // end of macro -> set macro run to stop (false)
        }

        // check editor func
        private void Check_BTN_Click(object sender, EventArgs e) {
            if (MacroEditor_TXTBOX.Text == string.Empty) {
                MessageBox.Show("Editor is Empty.");
                return;
            } // editor is null/empty -> message and return
            string Macro = MacroEditor_TXTBOX.Text; // set macro contents to editor contents
            string[] MacroContents = Macro.Split($"{Environment.NewLine}"); // split on newline

            // for each line in macro -> check valid command
            foreach (string Line in MacroContents) {
                string[] Reader = Line.Split(' '); // split command on space
                string[] SubReader = null; // sub reader for special commands

                if (Reader[0] != string.Empty && (Reader[0][0] != ':' && Reader.Length < 2)) {
                    ErrorMessages.ShowError_Default_Notation(Reader[0]);
                    return;
                } // command too short -> show error, return

                // process each request based on command
                switch (Reader[0].ToLower()) {
                    #region GOTO
                    case "goto":
                        SubReader = Reader[1].Split(','); // split line for Format - GOTO FLAG,COUNT

                        if (SubReader.Length < 2) {
                            ErrorMessages.ShowError_GOTO_Notation($"{Reader[0]} {Reader[1]}");
                            return;
                        } // line length too short -> show error, return | Format: GOTO FLAG,COUNT
                        else if (!Macro.Contains($":{SubReader[0]}")) {
                            ErrorMessages.ShowError_GOTO_FlagError(Reader[1], SubReader[0]);
                            return;
                        } // flag reference not found -> show error, return | Format: :FLAG
                        else if (!Int32.TryParse(SubReader[1], out int counter)) {
                            ErrorMessages.ShowError_GOTO_CountError(Reader[1], SubReader[0]);
                            return;
                        } // out number not found -> show error, return | Format: GOTO FLAG,COUNT
                        else if (Int32.Parse(SubReader[1]) == -9) {
                            ErrorMessages.ShowWarning_GOTO_EndlessLoop();
                        } // goto loop is endless -> show warning
                        else if (Int32.Parse(SubReader[1]) < 0 && Int32.Parse(SubReader[1]) != -9) {
                            ErrorMessages.ShowError_GOTO_LoopError();
                            return;
                        } // goto count non positive -> show error, return

                        break;
                    #endregion
                    #region HOLDMOUSE
                    case "holdmouse":
                        if (Reader[1].ToLower() != "m1" && Reader[1].ToLower() != "m2" && Reader[1].ToLower() != "m3") {
                            ErrorMessages.ShowError_HoldMouse_KeyError($"{Reader[0]} {Reader[1]}");
                            return;
                        } // correct mouseKey not entered -> show error, return
                        ErrorMessages.ShowWarning_HoldMouse_ReleaseMouse($"{Reader[0]} {Reader[1]}");
                        break;
                    #endregion
                    #region MOVEMOUSE
                    case "movemouse":
                        SubReader = Reader[1].Split(','); // split line for Format - MOVEMOUSE X,Y

                        if (SubReader.Length < 2) {
                            ErrorMessages.ShowError_MoveMouse_Notation($"{Reader[0]} {Reader[1]}");
                            return;
                        } // line length too short -> show error, return | Format: MOVEMOUSE X,Y
                        else if (!Int32.TryParse(SubReader[0], out int X)) {
                            ErrorMessages.ShowError_MoveMouse_XYError($"{Reader[0]} {Reader[1]}", SubReader[0]);
                            return;
                        } // out number not found -> show error, return | Format: MOVEMOUSE X,Y
                        else if (!Int32.TryParse(SubReader[1], out int Y)) {
                            ErrorMessages.ShowError_MoveMouse_XYError($"{Reader[0]} {Reader[1]}", SubReader[1]);
                            return;
                        } // out number not found -> show error, return | Format: MOVEMOUSE X,Y
                        break;
                    #endregion
                    #region PRESSKEYS
                    case "presskeys":
                        // check for nothing
                        break;
                    #endregion
                    #region PRESSMOUSE
                    case "pressmouse":
                        if (Reader[1].ToLower() != "m1" && Reader[1].ToLower() != "m2" && Reader[1].ToLower() != "m3") {
                            ErrorMessages.ShowError_PressMouse_KeyError($"{Reader[0]} {Reader[1]}");
                            return;
                        } // correct mouseKey not entered -> show error, return
                        break;
                    #endregion
                    #region RELEASEMOUSE
                    case "releasemouse":
                        if (Reader[1].ToLower() != "m1" && Reader[1].ToLower() != "m2" && Reader[1].ToLower() != "m3") {
                            ErrorMessages.ShowError_ReleaseMouse_KeyError($"{Reader[0]} {Reader[1]}");
                            return;
                        } // correct mouseKey not entered -> show error, return
                        break;
                    #endregion
                    #region TYPE
                    case "type":
                        // check for nothing
                        break;
                    #endregion
                    #region WAIT
                    case "wait":
                        if (!Int32.TryParse(Reader[1], out int waitTime) || waitTime < 0) {
                            ErrorMessages.ShowError_Wait_IntError($"{Reader[0]} {Reader[1]}");
                            return;
                        } // number not found -> show error, return

                        break;
                    #endregion
                    #region Default
                    default:
                        if (Reader[0] != string.Empty && Reader[0][0] != ':') {
                            ErrorMessages.ShowError_Default_Notation(Reader[0]);
                            return;
                        } // unknown command -> show error, return
                        break;
                        #endregion
                }
            }
            ErrorMessages.Show_Default_AllClear(); // display all good
            RunMacro_BTN.Enabled = true; // set run button to active
        }
    }
}