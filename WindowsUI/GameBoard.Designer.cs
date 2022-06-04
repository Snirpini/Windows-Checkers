namespace WindowsUI
{
    partial class GameBoard
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
            this.SuspendLayout();
            // 
            // GameBoard
            // 
            int size = 6;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "GameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkers";
            this.Load += new System.EventHandler(this.GameBoard_Load);
            this.ResumeLayout(false);

            // 
            // boardButtons
            //
            this.boardButtons = new System.Windows.Forms.Button[size, size];


            for()
            {
                button = new System.Windows.Forms.Button();
                button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                button.Location = new System.Drawing.Point(207, 225);
                button.Name = "doneButton";
                button.Size = new System.Drawing.Size(98, 29);
                button.TabIndex = 4;
                button.Text = "Done";
                button.UseVisualStyleBackColor = true;
                //button.Click += new System.EventHandler(this.doneButton_Click);
            }
        }

        #endregion

        private System.Windows.Forms.Button[,] boardButtons;
    }
}