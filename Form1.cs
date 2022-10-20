using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace runtimeKontrolOlusturma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<int, int> xyLer = new Dictionary<int, int>();

        int sayac = 1;

        private void btnUret_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Width = 50;
            btn.Height = 50;

            btn.Text = sayac.ToString();
            //btn.BringToFront();

            int donguSayisi = 0;
            int x = 0, y = 0;
            Random rnd = new Random();

            bool uygunMu = false;
            while (uygunMu == false)
            {
                do
                {
                    x = rnd.Next(0, this.ClientSize.Width - btn.Width);
                }
                while (xyLer.ContainsKey(x));

                y = rnd.Next(0, this.ClientSize.Height - btn.Height);

                donguSayisi++;
                uygunMu = true;

                foreach (var item in xyLer)
                {
                    //item.Key => x
                    //item.Value => y

                    //if (((x < item.Key && x + 50 > item.Key) || (x > item.Key && x < item.Key + 50) || (x == item.Key)) && ((y < item.Value && y + 20 > item.Value) || (y > item.Value && y < item.Value + 20) || (y == item.Value)))

                    if (((x < item.Key && x + 50 > item.Key) || (x > item.Key && x < item.Key + 50) || (x == item.Key)) && ((y < item.Value && y + 50 > item.Value) || (y > item.Value && y < item.Value + 50) || (y == item.Value)))
                    {
                        uygunMu = false;
                        break;
                    }

                }

                if (donguSayisi > 500000)
                {
                    MessageBox.Show("yer kalmadı");
                    break;
                }
            }

            btn.Left = x;
            btn.Top = y;

            //+= tab diyerek controle ait event oluşturulur
            btn.Click += Btn_Click;

            btn.MouseHover += Btn_MouseHover;
            btn.MouseLeave += Btn_MouseLeave;

            if (uygunMu == true)
            {
                xyLer.Add(x, y); //key: x, value: y

            sayac++;
            this.Controls.Add(btn);
            }
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btnTiklanan = (Button)sender;
            btnTiklanan.BackColor = Color.White;
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button btnTiklanan = (Button)sender;
            btnTiklanan.BackColor = Color.Red;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            //sender içeriisnde event i çalıştıran kontrol var

            Button btnTiklanan = (Button)sender;

            MessageBox.Show("merhaba " + btnTiklanan.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if(item is Button)
                {
                    xyLer.Add(item.Location.X, item.Location.Y);
                }
            }
            
        }
    }
}
