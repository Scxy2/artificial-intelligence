namespace Astar_ile_Sudoku
{
    partial class Form1
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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel9 = new Panel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(150, 150);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(162, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(150, 150);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(312, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(150, 150);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Location = new Point(12, 162);
            panel4.Name = "panel4";
            panel4.Size = new Size(150, 150);
            panel4.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Location = new Point(162, 162);
            panel5.Name = "panel5";
            panel5.Size = new Size(150, 150);
            panel5.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Location = new Point(312, 162);
            panel6.Name = "panel6";
            panel6.Size = new Size(150, 150);
            panel6.TabIndex = 5;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Location = new Point(12, 312);
            panel7.Name = "panel7";
            panel7.Size = new Size(150, 150);
            panel7.TabIndex = 6;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Location = new Point(162, 312);
            panel8.Name = "panel8";
            panel8.Size = new Size(150, 150);
            panel8.TabIndex = 7;
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Location = new Point(312, 312);
            panel9.Name = "panel9";
            panel9.Size = new Size(150, 150);
            panel9.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(468, 12);
            button1.Name = "button1";
            button1.Size = new Size(90, 40);
            button1.TabIndex = 9;
            button1.Text = "A*";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(468, 58);
            button2.Name = "button2";
            button2.Size = new Size(90, 40);
            button2.TabIndex = 10;
            button2.Text = "GA";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(468, 422);
            button3.Name = "button3";
            button3.Size = new Size(90, 40);
            button3.TabIndex = 0;
            button3.Text = "0";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(468, 376);
            button4.Name = "button4";
            button4.Size = new Size(90, 40);
            button4.TabIndex = 11;
            button4.Text = "Check";
            button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(564, 473);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sudoku";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
