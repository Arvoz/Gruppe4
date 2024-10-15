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
        private Label sliderLabel;
        private GroupBox buttonGroup;
        private GroupBox sliderGroup;

        public Form1()
        {
            this.Text = "Dynamic Resizing Example";
            this.Size = new System.Drawing.Size(600, 500);  // Initial window size
            this.MinimumSize = new System.Drawing.Size(500, 400);  // Minimum form size

            SetupButtonGroup();
            SetupSliderGroup();
            SetupScreen();

            // Enable dynamic resizing for controls
            this.Resize += new EventHandler(Form1_Resize);
        }

        // Setup the screen (TextBox)
        private void SetupScreen()
        {
            screenTextBox = new TextBox();
            screenTextBox.Multiline = true;
            screenTextBox.ReadOnly = true;
            screenTextBox.Text = "Screen Output";
            screenTextBox.Font = new System.Drawing.Font("Consolas", 12);
            screenTextBox.Location = new System.Drawing.Point(50, 300);
            screenTextBox.Size = new System.Drawing.Size(500, 100);  // Initial size
            Controls.Add(screenTextBox);
        }

        // Setup button group
        private void SetupButtonGroup()
        {
            buttonGroup = new GroupBox();
            buttonGroup.Text = "Buttons";
            buttonGroup.Size = new System.Drawing.Size(350, 100);
            buttonGroup.Location = new System.Drawing.Point(50, 50);

            myButton = new Button();
            myButton.Text = "Button One";
            myButton.Size = new System.Drawing.Size(100, 50);
            myButton.Location = new System.Drawing.Point(10, 30);
            myButton.Click += new EventHandler(MyButton_Click);
            buttonGroup.Controls.Add(myButton);

            secondButton = new Button();
            secondButton.Text = "Button Two";
            secondButton.Size = new System.Drawing.Size(100, 50);
            secondButton.Location = new System.Drawing.Point(150, 30);
            secondButton.Click += new EventHandler(SecondButton_Click);
            buttonGroup.Controls.Add(secondButton);

            Controls.Add(buttonGroup);
        }

        // Setup slider group
        private void SetupSliderGroup()
        {
            sliderGroup = new GroupBox();
            sliderGroup.Text = "Slider Control";
            sliderGroup.Size = new System.Drawing.Size(350, 120);
            sliderGroup.Location = new System.Drawing.Point(50, 160);

            sliderLabel = new Label();
            sliderLabel.Text = "Slider value: 1";
            sliderLabel.Font = new System.Drawing.Font("Arial", 10);
            sliderLabel.Location = new System.Drawing.Point(10, 20);
            sliderLabel.AutoSize = true;
            sliderGroup.Controls.Add(sliderLabel);

            myTrackBar = new TrackBar();
            myTrackBar.Minimum = 1;
            myTrackBar.Maximum = 12;
            myTrackBar.Value = 1;
            myTrackBar.TickFrequency = 1;
            myTrackBar.Size = new System.Drawing.Size(300, 45);
            myTrackBar.Location = new System.Drawing.Point(10, 50);
            myTrackBar.Scroll += new EventHandler(TrackBar_Scroll);
            sliderGroup.Controls.Add(myTrackBar);

            Controls.Add(sliderGroup);
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            sliderLabel.Text = "Slider value: " + myTrackBar.Value.ToString();
            UpdateSliderValueOnScreen();
        }

        private void UpdateSliderValueOnScreen()
        {
            string[] lines = screenTextBox.Lines;
            if (lines.Length > 0 && lines[lines.Length - 1].StartsWith("Slider value:"))
            {
                screenTextBox.Lines = lines[0..^1];  // Remove last line
            }
            UpdateScreen("Slider value: " + myTrackBar.Value.ToString());
        }

        private void UpdateScreen(string message)
        {
            screenTextBox.AppendText(Environment.NewLine + message);
        }

        // Event handler for dynamically resizing the controls
        private void Form1_Resize(object sender, EventArgs e)
        {
            screenTextBox.Width = this.ClientSize.Width - 100;  // Adjust dynamically
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            UpdateScreen("Button has been pressed");
        }

        private void SecondButton_Click(object sender, EventArgs e)
        {
            UpdateScreen("Second button has been pressed");
        }
    }
}
