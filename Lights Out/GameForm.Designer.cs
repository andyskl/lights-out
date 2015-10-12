namespace Lights_Out
{
    partial class GameForm
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.minMoves = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.stepsLabel = new System.Windows.Forms.Label();
            this.totalMoves = new System.Windows.Forms.Label();
            this.tipButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 17;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // minMoves
            // 
            this.minMoves.AutoSize = true;
            this.minMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minMoves.Location = new System.Drawing.Point(161, 11);
            this.minMoves.Name = "minMoves";
            this.minMoves.Size = new System.Drawing.Size(0, 24);
            this.minMoves.TabIndex = 2;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathLabel.Location = new System.Drawing.Point(12, 12);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(146, 20);
            this.pathLabel.TabIndex = 3;
            this.pathLabel.Text = "Кратчайший путь:";
            // 
            // stepsLabel
            // 
            this.stepsLabel.AutoSize = true;
            this.stepsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepsLabel.Location = new System.Drawing.Point(202, 12);
            this.stepsLabel.Name = "stepsLabel";
            this.stepsLabel.Size = new System.Drawing.Size(106, 20);
            this.stepsLabel.TabIndex = 5;
            this.stepsLabel.Text = "Всего ходов:";
            // 
            // totalMoves
            // 
            this.totalMoves.AutoSize = true;
            this.totalMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalMoves.Location = new System.Drawing.Point(311, 11);
            this.totalMoves.Name = "totalMoves";
            this.totalMoves.Size = new System.Drawing.Size(0, 24);
            this.totalMoves.TabIndex = 4;
            // 
            // tipButton
            // 
            this.tipButton.Location = new System.Drawing.Point(487, 43);
            this.tipButton.Name = "tipButton";
            this.tipButton.Size = new System.Drawing.Size(74, 29);
            this.tipButton.TabIndex = 1;
            this.tipButton.Text = "Подсказка";
            this.tipButton.UseVisualStyleBackColor = true;
            this.tipButton.Click += new System.EventHandler(this.tipButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(487, 78);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(74, 29);
            this.resetButton.TabIndex = 6;
            this.resetButton.Text = "Заново";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 522);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.stepsLabel);
            this.Controls.Add(this.totalMoves);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.minMoves);
            this.Controls.Add(this.tipButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "Lights Out Game";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label minMoves;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label stepsLabel;
        private System.Windows.Forms.Label totalMoves;
        private System.Windows.Forms.Button tipButton;
        private System.Windows.Forms.Button resetButton;

    }
}

