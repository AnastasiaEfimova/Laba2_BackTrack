namespace EmilGraph
{
    partial class TaskForm
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
            this.btCancel = new System.Windows.Forms.Button();
            this.btAct = new System.Windows.Forms.Button();
            this.tbDistance = new System.Windows.Forms.TextBox();
            this.lbY = new System.Windows.Forms.Label();
            this.tbTop = new System.Windows.Forms.TextBox();
            this.lbX = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(147, 108);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(125, 45);
            this.btCancel.TabIndex = 11;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btAct
            // 
            this.btAct.Location = new System.Drawing.Point(11, 108);
            this.btAct.Name = "btAct";
            this.btAct.Size = new System.Drawing.Size(125, 45);
            this.btAct.TabIndex = 10;
            this.btAct.Text = "ОК";
            this.btAct.UseVisualStyleBackColor = true;
            this.btAct.Click += new System.EventHandler(this.BtAct_Click);
            // 
            // tbDistance
            // 
            this.tbDistance.Location = new System.Drawing.Point(12, 73);
            this.tbDistance.Name = "tbDistance";
            this.tbDistance.Size = new System.Drawing.Size(260, 20);
            this.tbDistance.TabIndex = 9;
            // 
            // lbY
            // 
            this.lbY.AutoSize = true;
            this.lbY.Location = new System.Drawing.Point(9, 57);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(67, 13);
            this.lbY.TabIndex = 8;
            this.lbY.Text = "Расстояние";
            // 
            // tbTop
            // 
            this.tbTop.Location = new System.Drawing.Point(12, 27);
            this.tbTop.Name = "tbTop";
            this.tbTop.Size = new System.Drawing.Size(260, 20);
            this.tbTop.TabIndex = 7;
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(9, 11);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(52, 13);
            this.lbX.TabIndex = 6;
            this.lbX.Text = "Вершина";
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 166);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAct);
            this.Controls.Add(this.tbDistance);
            this.Controls.Add(this.lbY);
            this.Controls.Add(this.tbTop);
            this.Controls.Add(this.lbX);
            this.Name = "TaskForm";
            this.Text = "Главная задача";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btAct;
        private System.Windows.Forms.TextBox tbDistance;
        private System.Windows.Forms.Label lbY;
        private System.Windows.Forms.TextBox tbTop;
        private System.Windows.Forms.Label lbX;
    }
}