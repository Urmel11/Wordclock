namespace Wordclock.Ui.Win
{
	partial class Demo
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnClock = new Button();
			btnKnightRider = new Button();
			btnTogglePowerState = new Button();
			SuspendLayout();
			// 
			// btnClock
			// 
			btnClock.Location = new Point(962, 68);
			btnClock.Name = "btnClock";
			btnClock.Size = new Size(92, 23);
			btnClock.TabIndex = 0;
			btnClock.Text = "Clock";
			btnClock.UseVisualStyleBackColor = true;
			btnClock.Click += btnClock_Click;
			// 
			// btnKnightRider
			// 
			btnKnightRider.Location = new Point(962, 97);
			btnKnightRider.Name = "btnKnightRider";
			btnKnightRider.Size = new Size(92, 23);
			btnKnightRider.TabIndex = 1;
			btnKnightRider.Text = "KnightRider";
			btnKnightRider.UseVisualStyleBackColor = true;
			btnKnightRider.Click += btnKnightRider_Click;
			// 
			// btnTogglePowerState
			// 
			btnTogglePowerState.Location = new Point(962, 126);
			btnTogglePowerState.Name = "btnTogglePowerState";
			btnTogglePowerState.Size = new Size(141, 23);
			btnTogglePowerState.TabIndex = 2;
			btnTogglePowerState.Text = "Toggle PowerState";
			btnTogglePowerState.UseVisualStyleBackColor = true;
			btnTogglePowerState.Click += btnTogglePowerState_Click;
			// 
			// Demo
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1309, 679);
			Controls.Add(btnTogglePowerState);
			Controls.Add(btnKnightRider);
			Controls.Add(btnClock);
			Name = "Demo";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion

		private Button btnClock;
		private Button btnKnightRider;
        private Button btnTogglePowerState;
    }
}