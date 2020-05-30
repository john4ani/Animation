namespace Animation
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._roomWidth = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._roomHeight = new System.Windows.Forms.TrackBar();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this._numberOfParticles = new System.Windows.Forms.NumericUpDown();
            this._framesInterval = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._roomWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._roomHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numberOfParticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._framesInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(248, 403);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "Ok";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(353, 403);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _roomWidth
            // 
            this._roomWidth.Location = new System.Drawing.Point(130, 25);
            this._roomWidth.Minimum = 1;
            this._roomWidth.Name = "_roomWidth";
            this._roomWidth.Size = new System.Drawing.Size(104, 45);
            this._roomWidth.TabIndex = 2;
            this._roomWidth.Value = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Room Width (meters)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Room Height (meters)";
            // 
            // _roomHeight
            // 
            this._roomHeight.Location = new System.Drawing.Point(468, 25);
            this._roomHeight.Minimum = 1;
            this._roomHeight.Name = "_roomHeight";
            this._roomHeight.Size = new System.Drawing.Size(104, 45);
            this._roomHeight.TabIndex = 4;
            this._roomHeight.Value = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Number of Particles";
            // 
            // _numberOfParticles
            // 
            this._numberOfParticles.Location = new System.Drawing.Point(130, 92);
            this._numberOfParticles.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this._numberOfParticles.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numberOfParticles.Name = "_numberOfParticles";
            this._numberOfParticles.Size = new System.Drawing.Size(104, 20);
            this._numberOfParticles.TabIndex = 7;
            this._numberOfParticles.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // _framesInterval
            // 
            this._framesInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._framesInterval.Location = new System.Drawing.Point(468, 90);
            this._framesInterval.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this._framesInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._framesInterval.Name = "_framesInterval";
            this._framesInterval.Size = new System.Drawing.Size(104, 20);
            this._framesInterval.TabIndex = 9;
            this._framesInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Interval Between Frames (miliseconds)";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 449);
            this.Controls.Add(this._framesInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._numberOfParticles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._roomHeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._roomWidth);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Name = "Options";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this._roomWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._roomHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numberOfParticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._framesInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TrackBar _roomWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar _roomHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _numberOfParticles;
        private System.Windows.Forms.NumericUpDown _framesInterval;
        private System.Windows.Forms.Label label4;
    }
}