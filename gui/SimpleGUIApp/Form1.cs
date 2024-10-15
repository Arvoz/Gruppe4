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
            this.Text = "Dynamic Resizing Example";
            this.Size = new System.Drawing.Size(600, 400);  // Initial window size
            this.MinimumSize = new System.Drawing.Size(400, 300);  // Minimum form size

            SetupButton();
            SetupSecondButton();
            SetupScreen();
            SetupTrackBar();

            // Enable dynamic resizing for controls
            this.Resize += new EventHandler(Form1_Resize);
        }

        // Setup the first button
        private void SetupButton()
        {
            myButton = new Button();
            myButton.Text = "Press Me";
            myButton.Size = new System.Drawing.Size(100, 50);
            myButton.Location = new System.Drawing.Point(50, 50);
            Controls.Add(myButton);
        }

        // Setup the second button
        private void SetupSecondButton()
        {
            secondButton = new Button();
            secondButton.Text = "Second Button";
            secondButton.Size = new System.Drawing.Size(100, 50);
            secondButton.Location = new System.Drawing.Point(200, 50);
            Controls.Add(secondButton);
        }

        // Setup the screen (TextBox)
        private void SetupScreen()
        {
            screenTextBox = new TextBox();
            screenTextBox.Multiline = true;
            screenTextBox.ReadOnly = true;
            screenTextBox.Text = "Screen Output";
            screenTextBox.Font = new System.Drawing.Font("Consolas", 12);
            screenTextBox.Location = new System.Drawing.Point(50, 150);
            screenTextBox.Size = new System.Drawing.Size(500, 100);  // Initial size
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
            myTrackBar.Size = new System.Drawing.Size(500, 45);  // Initial size
            myTrackBar.Location = new System.Drawing.Point(50, 300);
            Controls.Add(myTrackBar);
        }

        // Event handler for dynamically resizing the controls
        private void Form1_Resize(object sender, EventArgs e)
        {
            // Get current form size
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Dynamically resize and reposition controls based on form size
            myButton.Location = new System.Drawing.Point(formWidth / 20, formHeight / 20);
            myButton.Size = new System.Drawing.Size(formWidth / 6, formHeight / 10);

            secondButton.Location = new System.Drawing.Point(formWidth / 5, formHeight / 20);
            secondButton.Size = new System.Drawing.Size(formWidth / 6, formHeight / 10);

            screenTextBox.Location = new System.Drawing.Point(formWidth / 20, formHeight / 3);
            screenTextBox.Size = new System.Drawing.Size(formWidth - (formWidth / 10), formHeight / 5);

            myTrackBar.Location = new System.Drawing.Point(formWidth / 20, formHeight - (formHeight / 5));
            myTrackBar.Size = new System.Drawing.Size(formWidth - (formWidth / 10), 45);  // TrackBar fixed height, dynamic width
        }

        // Event handler for the first button click
        private void MyButton_Click(object sender, EventArgs e)
        {
            screenTextBox.Text = "Button has been pressed";
        }

        // Event handler for the second button click
        private void SecondButton_Click(object sender, EventArgs e)
        {
            screenTextBox.Text = "Second button has been pressed";
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
