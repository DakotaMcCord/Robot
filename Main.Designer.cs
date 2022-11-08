
namespace Robot {
    partial class Main {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.New_BTN = new System.Windows.Forms.Button();
            this.Load_BTN = new System.Windows.Forms.Button();
            this.Save_BTN = new System.Windows.Forms.Button();
            this.MacroEditor_TXTBOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MacroParser_CMBBOX = new System.Windows.Forms.ComboBox();
            this.GetMousePos_BTN = new System.Windows.Forms.Button();
            this.Check_BTN = new System.Windows.Forms.Button();
            this.RunMacro_BTN = new System.Windows.Forms.Button();
            this.CountDown_TIMER = new System.Windows.Forms.Timer(this.components);
            this.CountDown_GRPBOX = new System.Windows.Forms.GroupBox();
            this.CountDown_LBL = new System.Windows.Forms.Label();
            this.MainUI_GRPBOX = new System.Windows.Forms.GroupBox();
            this.CountDown_GRPBOX.SuspendLayout();
            this.MainUI_GRPBOX.SuspendLayout();
            this.SuspendLayout();
            // 
            // New_BTN
            // 
            this.New_BTN.Location = new System.Drawing.Point(146, 22);
            this.New_BTN.Name = "New_BTN";
            this.New_BTN.Size = new System.Drawing.Size(65, 23);
            this.New_BTN.TabIndex = 7;
            this.New_BTN.TabStop = false;
            this.New_BTN.Text = "New";
            this.New_BTN.UseVisualStyleBackColor = true;
            this.New_BTN.Click += new System.EventHandler(this.New_BTN_Click);
            // 
            // Load_BTN
            // 
            this.Load_BTN.Location = new System.Drawing.Point(81, 22);
            this.Load_BTN.Name = "Load_BTN";
            this.Load_BTN.Size = new System.Drawing.Size(59, 23);
            this.Load_BTN.TabIndex = 8;
            this.Load_BTN.TabStop = false;
            this.Load_BTN.Text = "Load";
            this.Load_BTN.UseVisualStyleBackColor = true;
            this.Load_BTN.Click += new System.EventHandler(this.Load_BTN_Click);
            // 
            // Save_BTN
            // 
            this.Save_BTN.Location = new System.Drawing.Point(15, 22);
            this.Save_BTN.Name = "Save_BTN";
            this.Save_BTN.Size = new System.Drawing.Size(60, 23);
            this.Save_BTN.TabIndex = 9;
            this.Save_BTN.TabStop = false;
            this.Save_BTN.Text = "Save";
            this.Save_BTN.UseVisualStyleBackColor = true;
            this.Save_BTN.Click += new System.EventHandler(this.Save_BTN_Click);
            // 
            // MacroEditor_TXTBOX
            // 
            this.MacroEditor_TXTBOX.AutoCompleteCustomSource.AddRange(new string[] {
            "Wait #",
            "PressKeys @",
            "PressMouse @",
            "HoldMouse @",
            "MoveMouse #,#",
            "Type @"});
            this.MacroEditor_TXTBOX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.MacroEditor_TXTBOX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.MacroEditor_TXTBOX.Location = new System.Drawing.Point(15, 51);
            this.MacroEditor_TXTBOX.Multiline = true;
            this.MacroEditor_TXTBOX.Name = "MacroEditor_TXTBOX";
            this.MacroEditor_TXTBOX.PlaceholderText = "type your script here....";
            this.MacroEditor_TXTBOX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MacroEditor_TXTBOX.Size = new System.Drawing.Size(458, 362);
            this.MacroEditor_TXTBOX.TabIndex = 15;
            this.MacroEditor_TXTBOX.TabStop = false;
            this.MacroEditor_TXTBOX.TextChanged += new System.EventHandler(this.MacroEditor_TXTBOX_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Parser >";
            // 
            // MacroParser_CMBBOX
            // 
            this.MacroParser_CMBBOX.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.MacroParser_CMBBOX.AutoCompleteCustomSource.AddRange(new string[] {
            "GoTo @,#",
            "HoldMouse @",
            "MoveMouse #,#",
            "PressKeys @",
            "PressMouse @",
            "ReleaseMouse @",
            "Type @",
            "Wait #"});
            this.MacroParser_CMBBOX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.MacroParser_CMBBOX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.MacroParser_CMBBOX.FormattingEnabled = true;
            this.MacroParser_CMBBOX.Items.AddRange(new object[] {
            "GoTo @,#",
            "HoldMouse @",
            "MoveMouse #,#",
            "PressKeys @",
            "PressMouse @",
            "ReleaseMouse @",
            "Type @",
            "Wait #"});
            this.MacroParser_CMBBOX.Location = new System.Drawing.Point(67, 422);
            this.MacroParser_CMBBOX.Name = "MacroParser_CMBBOX";
            this.MacroParser_CMBBOX.Size = new System.Drawing.Size(301, 23);
            this.MacroParser_CMBBOX.TabIndex = 17;
            this.MacroParser_CMBBOX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MacroParser_CMBBOX_KeyDown);
            // 
            // GetMousePos_BTN
            // 
            this.GetMousePos_BTN.Location = new System.Drawing.Point(374, 422);
            this.GetMousePos_BTN.Name = "GetMousePos_BTN";
            this.GetMousePos_BTN.Size = new System.Drawing.Size(99, 23);
            this.GetMousePos_BTN.TabIndex = 20;
            this.GetMousePos_BTN.TabStop = false;
            this.GetMousePos_BTN.Text = "Get Mouse X, Y";
            this.GetMousePos_BTN.UseVisualStyleBackColor = true;
            this.GetMousePos_BTN.Click += new System.EventHandler(this.GetMousePos_BTN_Click);
            // 
            // Check_BTN
            // 
            this.Check_BTN.Location = new System.Drawing.Point(246, 22);
            this.Check_BTN.Name = "Check_BTN";
            this.Check_BTN.Size = new System.Drawing.Size(136, 23);
            this.Check_BTN.TabIndex = 19;
            this.Check_BTN.TabStop = false;
            this.Check_BTN.Text = "Check Errors";
            this.Check_BTN.UseVisualStyleBackColor = true;
            this.Check_BTN.Click += new System.EventHandler(this.Check_BTN_Click);
            // 
            // RunMacro_BTN
            // 
            this.RunMacro_BTN.Location = new System.Drawing.Point(388, 22);
            this.RunMacro_BTN.Name = "RunMacro_BTN";
            this.RunMacro_BTN.Size = new System.Drawing.Size(85, 23);
            this.RunMacro_BTN.TabIndex = 18;
            this.RunMacro_BTN.TabStop = false;
            this.RunMacro_BTN.Text = "Run";
            this.RunMacro_BTN.UseVisualStyleBackColor = true;
            this.RunMacro_BTN.Click += new System.EventHandler(this.RunMacro_BTN_Click);
            // 
            // CountDown_TIMER
            // 
            this.CountDown_TIMER.Interval = 1000;
            // 
            // CountDown_GRPBOX
            // 
            this.CountDown_GRPBOX.Controls.Add(this.CountDown_LBL);
            this.CountDown_GRPBOX.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CountDown_GRPBOX.Location = new System.Drawing.Point(12, 12);
            this.CountDown_GRPBOX.Name = "CountDown_GRPBOX";
            this.CountDown_GRPBOX.Size = new System.Drawing.Size(490, 462);
            this.CountDown_GRPBOX.TabIndex = 21;
            this.CountDown_GRPBOX.TabStop = false;
            this.CountDown_GRPBOX.Text = "Getting mouse coordinates in:";
            this.CountDown_GRPBOX.Visible = false;
            // 
            // CountDown_LBL
            // 
            this.CountDown_LBL.AutoSize = true;
            this.CountDown_LBL.Font = new System.Drawing.Font("Segoe UI", 200F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CountDown_LBL.Location = new System.Drawing.Point(102, 39);
            this.CountDown_LBL.Name = "CountDown_LBL";
            this.CountDown_LBL.Size = new System.Drawing.Size(293, 355);
            this.CountDown_LBL.TabIndex = 0;
            this.CountDown_LBL.Text = "3";
            // 
            // MainUI_GRPBOX
            // 
            this.MainUI_GRPBOX.Controls.Add(this.GetMousePos_BTN);
            this.MainUI_GRPBOX.Controls.Add(this.Save_BTN);
            this.MainUI_GRPBOX.Controls.Add(this.Check_BTN);
            this.MainUI_GRPBOX.Controls.Add(this.Load_BTN);
            this.MainUI_GRPBOX.Controls.Add(this.label1);
            this.MainUI_GRPBOX.Controls.Add(this.MacroEditor_TXTBOX);
            this.MainUI_GRPBOX.Controls.Add(this.RunMacro_BTN);
            this.MainUI_GRPBOX.Controls.Add(this.New_BTN);
            this.MainUI_GRPBOX.Controls.Add(this.MacroParser_CMBBOX);
            this.MainUI_GRPBOX.Location = new System.Drawing.Point(12, 12);
            this.MainUI_GRPBOX.Name = "MainUI_GRPBOX";
            this.MainUI_GRPBOX.Size = new System.Drawing.Size(490, 462);
            this.MainUI_GRPBOX.TabIndex = 22;
            this.MainUI_GRPBOX.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 487);
            this.Controls.Add(this.CountDown_GRPBOX);
            this.Controls.Add(this.MainUI_GRPBOX);
            this.Name = "Main";
            this.Text = "Robot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CountDown_GRPBOX.ResumeLayout(false);
            this.CountDown_GRPBOX.PerformLayout();
            this.MainUI_GRPBOX.ResumeLayout(false);
            this.MainUI_GRPBOX.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button New_BTN;
        private System.Windows.Forms.Button Load_BTN;
        private System.Windows.Forms.Button Save_BTN;
        private System.Windows.Forms.TextBox MacroEditor_TXTBOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox MacroParser_CMBBOX;
        private System.Windows.Forms.Button RunMacro_BTN;
        private System.Windows.Forms.Button Check_BTN;
        private System.Windows.Forms.Button GetMousePos_BTN;
        private System.Windows.Forms.Timer CountDown_TIMER;
        private System.Windows.Forms.GroupBox CountDown_GRPBOX;
        private System.Windows.Forms.Label CountDown_LBL;
        private System.Windows.Forms.GroupBox MainUI_GRPBOX;
    }
}

