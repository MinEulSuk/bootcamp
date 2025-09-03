namespace SensorMonitoring
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private LiveCharts.WinForms.CartesianChart chartTemp;
        private LiveCharts.WinForms.CartesianChart chartHumi;
        private LiveCharts.WinForms.CartesianChart chartDust;
        private System.Windows.Forms.TreeView treeViewLog;
        private System.Windows.Forms.Label lblAlarm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.chartTemp = new LiveCharts.WinForms.CartesianChart();
            this.chartHumi = new LiveCharts.WinForms.CartesianChart();
            this.chartDust = new LiveCharts.WinForms.CartesianChart();
            this.treeViewLog = new System.Windows.Forms.TreeView();
            this.lblAlarm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chartTemp
            // 
            this.chartTemp.Location = new System.Drawing.Point(12, 12);
            this.chartTemp.Name = "chartTemp";
            this.chartTemp.Size = new System.Drawing.Size(300, 200);
            this.chartTemp.TabIndex = 0;
            this.chartTemp.Text = "chartTemp";
            // 
            // chartHumi
            // 
            this.chartHumi.Location = new System.Drawing.Point(330, 12);
            this.chartHumi.Name = "chartHumi";
            this.chartHumi.Size = new System.Drawing.Size(300, 200);
            this.chartHumi.TabIndex = 1;
            this.chartHumi.Text = "chartHumi";
            // 
            // chartDust
            // 
            this.chartDust.Location = new System.Drawing.Point(648, 12);
            this.chartDust.Name = "chartDust";
            this.chartDust.Size = new System.Drawing.Size(300, 200);
            this.chartDust.TabIndex = 2;
            this.chartDust.Text = "chartDust";
            // 
            // treeViewLog
            // 
            this.treeViewLog.Location = new System.Drawing.Point(12, 230);
            this.treeViewLog.Name = "treeViewLog";
            this.treeViewLog.Size = new System.Drawing.Size(450, 200);
            this.treeViewLog.TabIndex = 3;
            // 
            // lblAlarm
            // 
            this.lblAlarm.AutoSize = true;
            this.lblAlarm.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAlarm.ForeColor = System.Drawing.Color.Black;
            this.lblAlarm.Location = new System.Drawing.Point(500, 240);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(184, 16);
            this.lblAlarm.TabIndex = 4;
            this.lblAlarm.Text = "현재 상태: 정상입니다.";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(964, 450);
            this.Controls.Add(this.lblAlarm);
            this.Controls.Add(this.treeViewLog);
            this.Controls.Add(this.chartDust);
            this.Controls.Add(this.chartHumi);
            this.Controls.Add(this.chartTemp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
