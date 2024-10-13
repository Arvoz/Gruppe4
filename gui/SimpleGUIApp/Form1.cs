using System;
using System.Windows.Forms;

namespace SimpleGUIApp
{
    public partial class Form1 : Form
    {
        private Button myButton;
        private Button secondButton;
        private TextBox screenTextBox;
        private TrackBar myTrackBar;

        public Form1()
        {
            // Initialize form and controls
            SetupButton();
            SetupSecondButton();
            SetupScreen();
            SetupTrackBar();
        }

        // Setup the first button
        private void SetupButton()
        {
            myButton = new Button();
            myButton.Text = "Button One";
            myButton.Size = new System.Drawing.Size(100, 50);
            myButton.Location = new System.Drawing.Point(100, 100);
            myButton.Click += new EventHandler(MyButton_Click);
            Controls.Add(myButton);
        }

        // Setup the second button
        private void SetupSecondButton()
        {
            secondButton = new Button();
            secondButton.Text = "Button Two";
            secondButton.Size = new System.Drawing.Size(100, 50);
            secondButton.Location = new System.Drawing.Point(250, 100);
            secondButton.Click += new EventHandler(SecondButton_Click);
            Controls.Add(secondButton);
        }

        // Setup the screen (TextBox)
        private void SetupScreen()
        {
            screenTextBox = new TextBox();
            screenTextBox.Multiline = true;
            screenTextBox.ReadOnly = true;
            screenTextBox.Size = new System.Drawing.Size(300, 100);
            screenTextBox.Location = new System.Drawing.Point(100, 200);
            screenTextBox.Font = new System.Drawing.Font("Consolas", 12);
            Controls.Add(screenTextBox);
        }

        // Setup the TrackBar (Slider)
        private void SetupTrackBar()
        {
            myTrackBar = new TrackBar();
            myTrackBar.Minimum = 1;
            myTrackBar.Maximum = 12;
            myTrackBar.Value = 1;
            myTrackBar.TickFrequency = 1;
            myTrackBar.Size = new System.Drawing.Size(200, 45);
            myTrackBar.Location = new System.Drawing.Point(100, 350);
            myTrackBar.Scroll += new EventHandler(TrackBar_Scroll);
            Controls.Add(myTrackBar);
        }

        // Event handler for the first button click
        private void MyButton_Click(object sender, EventArgs e)
        {
            screenTextBox.Text = "Button One has been pressed";
        }

        // Event handler for the second button click
        private void SecondButton_Click(object sender, EventArgs e)
        {
            screenTextBox.Text = "Button Two has been pressed";
        }

        // Event handler for TrackBar (Slider)
        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            screenTextBox.Text = "Slider value: " + myTrackBar.Value.ToString();
        }

        // Simplified Dispose method
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of any other resources if necessary (leave empty for now)
            }
            base.Dispose(disposing);
        }
    }
}
