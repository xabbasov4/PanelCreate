using System.Media;
namespace PanelCreate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Oyundan çıxmaq istəyirsiniz?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }
        Random r = new Random();
        Random g = new Random();
        Random b = new Random();
        Random xL = new Random();
        Random yL = new Random();
        int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            Panel p = new Panel();
            p.Size = new Size(60, 60);
            p.BackColor = Color.FromArgb(r.Next(0, 256), g.Next(0, 256), b.Next(0, 256));
            p.Location = new Point(xL.Next(0, 636), yL.Next(0, 300));
            p.Tag = "panel";
            this.Controls.Add(p);
            p.BringToFront();
            label2.Text = count.ToString();
            if (p.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                OyunBitdi();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(xL.Next(0, 636), yL.Next(0, 300));
            foreach (Control c in this.Controls)
            {
                if (c is Panel && c.Tag != null && c.Tag.ToString() == "panel")
                {
                    if (pictureBox1.Bounds.IntersectsWith(c.Bounds))
                    {
                        OyunBitdi();
                        break;
                    }
                }
            }
        }
        void OyunBitdi()
        {
            SoundPlayer ses = new SoundPlayer("explosion.wav");
            ses.Play();
            DialogResult d = MessageBox.Show("Oyun bitdi! Yenidən başlamaq üçün OK basın.", "Oyun Bitdi", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (d == DialogResult.OK)
            {
                Oyunabasla();
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }
        void Oyunabasla()
        {
            count = 0;
            label2.Text = "0";
            List<Control> silinecekler = new List<Control>();
            foreach (Control c in this.Controls)
            {
                if (c is Panel && c.Tag != null && c.Tag.ToString() == "panel")
                {
                    silinecekler.Add(c);
                }
            }
            foreach (Control p in silinecekler)
            {
                this.Controls.Remove(p);
            }
            pictureBox1.Location = new Point(xL.Next(0, 636), yL.Next(0, 300));
            button1.Enabled = true;
            button2.Enabled = true;
        }
    }
}