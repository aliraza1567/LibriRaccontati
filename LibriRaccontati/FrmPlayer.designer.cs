using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LibriRaccontati
{
    partial class FrmPlayer
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlayer));
            this.btnPlay = new System.Windows.Forms.Button();
            this.Volume = new System.Windows.Forms.TrackBar();
            this.Pan = new System.Windows.Forms.TrackBar();
            this.Position = new System.Windows.Forms.TrackBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.albumPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Position)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.BackgroundImage = global::LibriRaccontati.Properties.Resources.Background;
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Image = global::LibriRaccontati.Properties.Resources.Play;
            this.btnPlay.Location = new System.Drawing.Point(348, 509);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(79, 74);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.buPlay_Click);
            // 
            // Volume
            // 
            this.Volume.Location = new System.Drawing.Point(671, 504);
            this.Volume.Name = "Volume";
            this.Volume.Size = new System.Drawing.Size(227, 45);
            this.Volume.TabIndex = 3;
            this.Volume.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // Pan
            // 
            this.Pan.Location = new System.Drawing.Point(662, 568);
            this.Pan.Name = "Pan";
            this.Pan.Size = new System.Drawing.Size(227, 45);
            this.Pan.TabIndex = 4;
            this.Pan.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Pan.Value = 5;
            // 
            // Position
            // 
            this.Position.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Position.Location = new System.Drawing.Point(90, 586);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(453, 45);
            this.Position.TabIndex = 9;
            this.Position.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BackgroundImage = global::LibriRaccontati.Properties.Resources.Background;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(168, 513);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(79, 67);
            this.btnStop.TabIndex = 11;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.BackgroundImage = global::LibriRaccontati.Properties.Resources.Background;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPrevious.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(263, 513);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(79, 67);
            this.btnPrevious.TabIndex = 12;
            this.btnPrevious.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BackgroundImage = global::LibriRaccontati.Properties.Resources.Background;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(433, 513);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(79, 67);
            this.btnNext.TabIndex = 13;
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // btnMute
            // 
            this.btnMute.BackColor = System.Drawing.Color.Transparent;
            this.btnMute.BackgroundImage = global::LibriRaccontati.Properties.Resources.Background;
            this.btnMute.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMute.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMute.FlatAppearance.BorderSize = 0;
            this.btnMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMute.Image = global::LibriRaccontati.Properties.Resources.Sound;
            this.btnMute.Location = new System.Drawing.Point(604, 529);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(38, 35);
            this.btnMute.TabIndex = 14;
            this.btnMute.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::LibriRaccontati.Properties.Resources.Background;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::LibriRaccontati.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(857, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(41, 47);
            this.btnExit.TabIndex = 15;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BackgroundImage = global::LibriRaccontati.Properties.Resources.Background;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::LibriRaccontati.Properties.Resources.Minimize;
            this.btnMinimize.Location = new System.Drawing.Point(810, 1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(41, 47);
            this.btnMinimize.TabIndex = 16;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // albumPanel
            // 
            this.albumPanel.AutoScroll = true;
            this.albumPanel.BackColor = System.Drawing.Color.Transparent;
            this.albumPanel.Location = new System.Drawing.Point(1, 54);
            this.albumPanel.Name = "albumPanel";
            this.albumPanel.Size = new System.Drawing.Size(908, 430);
            this.albumPanel.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "label1";
            // 
            // FrmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibriRaccontati.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(910, 638);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.albumPanel);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.Position);
            this.Controls.Add(this.Volume);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.Pan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player";
            this.Load += new System.EventHandler(this.FrmPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Position)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnPlay;
        private TrackBar Volume;
        private TrackBar Pan;
        private TrackBar Position;
        private Button btnStop;
        private Button btnPrevious;
        private Button btnNext;
        private Button btnMute;
        private Button btnExit;
        private Button btnMinimize;
        private Panel albumPanel;
        private Label label1;
    }
}

