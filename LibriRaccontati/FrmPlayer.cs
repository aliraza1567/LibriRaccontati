#region © Copyright 2012, Luca Farias
/* Copyright (c) 2012, Luca Farias 
L'autorizzazione è concessa, a titolo gratuito, a chiunque ottenga una copia
di questo software e dei file di documentazione associati , per utilizzare
il Software senza limitazioni, compresi, senza esclusione, i diritti
di usare, copiare, modificare, unire, pubblicare, distribuire, concedere in licenza e / o vendere
copie del Software, e di consentire alle persone a cui il software è
fornito le stesse, fatte salve le seguenti condizioni:

L'avviso di copyright e l'avviso di autorizzazione devono essere incluse in
tutte le copie o parti sostanziali del Software.

IL SOFTWARE VIENE FORNITO "COSÌ COM'È", SENZA GARANZIE DI ALCUN TIPO, ESPRESSE O
IMPLICITE, INCLUSE, MA NON SOLO, LE GARANZIE DI COMMERCIABILITÀ,
IDONEITÀ PER UN PARTICOLARE SCOPO E NON VIOLAZIONE. 
IN NESSUN CASO L'AUTORI O TITOLARI DEL COPYRIGHT POTRANNO ESSERE RITENUTI RESPONSABILI 
PER EVENTUALI RECLAMI, DANNI O ALTRE RESPONSABILITÀ, SIA IN UN'AZIONE DI CONTRATTO, 
TORTO O ALTRO, DERIVANTI DA ESSO, O IN CONNESSIONE CON IL SOFTWARE STESSO O L'USO 
 */
/* Copyright (c) 2012, Luca Farias 

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files , to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion

using LibriRaccontati.Player;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LibriRaccontati
{
    public partial class FrmPlayer : Form
    {
        private Audio _playFile;
        private readonly Timer _currentTimer = new Timer();
        private readonly string _bookDirectoy;
        private readonly string _imageDirectoy;
        public FrmPlayer()
        {
            InitializeComponent();
            FormClosing += FrmPlayer_FormClosing;
            Pan.ValueChanged += Pan_EditValueChanged;
            Volume.ValueChanged += Volume_EditValueChanged;
            _currentTimer.Tick += CurrentTime_Tick;
            Position.ValueChanged += Position_Scroll;
            _bookDirectoy = Application.StartupPath + "\\Books\\Audio";
            _imageDirectoy = Application.StartupPath + "\\Books\\Images\\";
        }

        private void Position_Scroll(object sender, EventArgs e)
        {
            if (_playFile != null)
            {
                _playFile.TimePosition = TimeSpan.FromSeconds(Position.Value);
            }
        }

        private void FrmPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _playFile?.Dispose();
            Application.Exit();
        }

        private void Pan_EditValueChanged(object sender, EventArgs e)
        {
            Debug.Print("PAN = " + (float)Pan.Value / 10);
            _playFile.Pan = (float)Pan.Value / 10;
        }

        private void Volume_EditValueChanged(object sender, EventArgs e)
        {
            var a = (float)(Volume.Value) / 10;
            _playFile.Volume = a;
        }

        private void CurrentTime_Tick(object sender, EventArgs e)
        {
            if (_playFile == null) return;
            var currentTime = (_playFile.State == Audio.PlayBackState.Stopped) ? TimeSpan.Zero : _playFile.TimePosition;

            Position.Value = (int)currentTime.TotalSeconds;
        }

        private void buPlay_Click(object sender, EventArgs e)
        {
            if (_playFile == null) return;

            switch (_playFile.State)
            {
                case Audio.PlayBackState.Paused:
                    btnPlay.Image = Properties.Resources.Pause;
                    _playFile.Play();
                    break;
                case Audio.PlayBackState.Playing:
                    btnPlay.Image = Properties.Resources.Play;
                    _playFile.Pause();
                    break;
                case Audio.PlayBackState.Stopped:
                    btnPlay.Image = Properties.Resources.Pause;
                    Pan.Minimum = -10;
                    Pan.Maximum = 10;

                    _currentTimer.Interval = 3000;
                    _currentTimer.Enabled = true;

                    Pan.Value = 0;

                    Position.Maximum = (int)_playFile.TotalDuration.TotalSeconds;
                    Position.TickFrequency = Position.Maximum / 30;

                    _playFile.Play();

                    Volume.Value = 5;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _playFile.Stop();
        }

        private void FrmPlayer_Load(object sender, EventArgs e)
        {
            try
            {
                var filePaths = Directory.GetFiles(_bookDirectoy);
                var locationY = 0;
                var locationX = 10;
                var albumCount = 0;
                foreach (var path in filePaths)
                {
                    var fileName = path.Replace(_bookDirectoy + "\\", "");
                    var imageName = _imageDirectoy + fileName.Replace(".mp3", ".jpg");

                    var btnBook = new Button
                    {
                        Width = 200,
                        Height = 160,
                        Location = new Point(locationX, locationY),
                        ForeColor = Color.Black,
                        Name = "btn" + fileName,
                        BackgroundImage = Image.FromFile(imageName),
                        BackgroundImageLayout = ImageLayout.Stretch,
                    };
                    btnBook.Click += BtnAudioButtonClick;
                    albumPanel.Controls.Add(btnBook);

                    var lblBook = new Label
                    {
                        BackColor = Color.Transparent,
                        Text = fileName.Replace(".mp3", ""),
                        Size = new Size(200, 25),
                        Location = new Point(locationX, locationY + 160),
                        ForeColor = Color.White,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular)
                    };

                    albumPanel.Controls.Add(lblBook);

                    locationX += 220;
                    if (albumCount == 3)
                    {
                        locationY += 220;
                        albumCount = -1;
                        locationX = 10;
                    }
                    albumCount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error While Loading Files");
            }
        }

        protected void BtnAudioButtonClick(object sender, EventArgs e)
        {
            var audioButton = (sender as Button);

            if (audioButton == null) return;
            _playFile = new Audio(_bookDirectoy + "\\" + audioButton.Name.Replace("btn", ""));
            Text = @"LibriRaccontati -" + _bookDirectoy + @"\" + audioButton.Name;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _playFile?.Dispose();
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
