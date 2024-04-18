/**********************************************************************************************************
**                                               SAKARYA ÜNİVERSİTESİ
**                                     BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**                                         BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**                                        NESNEYE DAYALI PROGRAMLAMA DERSİ 
**                                             2023-2024 BAHAR DÖNEMİ
**
**                                 ÖDEV NUMARASI..........: 1
**                                 ÖĞRENCİ ADI SOYADI.....: MUHAMMED EMİN BARKOÇ
**                                 ÖĞRENCİ NUMARASI.......: G231210452
**                                 DERSİN ALINDIĞI GRUP...: 2. ÖĞRETİM A 
**
************************************************************************************************************/

using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ödev
{
    public partial class Form1 : Form
    {
        private bool degisiklikVarMi; // Yeni dosya oluşturmak için kullanıyorum.
        private bool dosyaYeniMi;     // Eğer dosya yeni değilse veya değişiklik yoksa yeni dosya oluşturmuyor.

        public Form1() 
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kesToolStripMenuItem.Enabled = false;
            kopyalaToolStripMenuItem.Enabled = false;
            yapıştırToolStripMenuItem.Enabled = false;

            richTextBox1.ContextMenuStrip = ContextMenuStrip1;
            degisiklikVarMi = false;
            dosyaYeniMi = false;
        }


        // Kaydetmek isteyip istemediğini sorar. Eğer kaydetmek isterse eder, istemezse etmez.
        #region Yeni Butonu
        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (degisiklikVarMi)
            {

                this.Text = "Yeni Kaydedilmemiş Metin Dosyası";
                dosyaYeniMi = true;

                DialogResult dr = MessageBox.Show("Yapılan değişiklikleri kaydetmek ister misiniz ?", "Dosya Kadet", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Metin Dosyası |*.txt";
                    save.OverwritePrompt = true;
                    save.CreatePrompt = true;

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter Kayit = new StreamWriter(save.FileName);
                        Kayit.WriteLine(richTextBox1.Text);
                        Kayit.Close();
                    }
                    degisiklikVarMi = false;
                    this.Text = "Metin Dosyası";
                    richTextBox1.Clear();
                }
                else if (dr == DialogResult.No)
                {
                    degisiklikVarMi = false;
                    this.Text = "Metin Dosyası";
                    richTextBox1.Clear();
                }
            }
        }
        #endregion

        #region Kaydet Butonu
        private void dosyaKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Metin Dosyası |*.txt";
            save.OverwritePrompt = true;
            save.CreatePrompt = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Kayit = new StreamWriter(save.FileName);
                Kayit.WriteLine(richTextBox1.Text);
                Kayit.Close();
            }
        }
        #endregion

        // Kullanıcı uygulama içerisine dosya import edebilir. Uzantısı .txt olma koşulu vardır.
        #region DosyaAç Butonu
        private void dosyaAçToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog1.FileName) == ".txt")
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    degisiklikVarMi = true;
                }
                else
                {
                    MessageBox.Show("Açmak istediğiniz dosyanın uzantısı txt olmalıdır.");
                }

                this.Text = Path.GetFileName(openFileDialog1.FileName) + " Muhammed Emin BARKOÇ";

            }

        }
        #endregion

        // Kullanıcıya dosyada eğer değişiklik varsa kaydetmek isteyip istemediğini sorar ve ona göre kaydeder.
        #region Çıkış Butonu
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (degisiklikVarMi)
            {
                DialogResult dr = MessageBox.Show("Yapılan değişiklikler kaydedilsin mi ?", "Dosya Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Metin Dosyası |*.txt";
                    save.OverwritePrompt = true;
                    save.CreatePrompt = true;

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter Kayit = new StreamWriter(save.FileName);
                        Kayit.WriteLine(richTextBox1.Text);
                        Kayit.Close();
                    }

                    Application.Exit();
                }
                else if (dr == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }
        #endregion

        // Çıkış butonu ile aynı çalışır.
        #region Sağ Üstteki Çarpı Butonu
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dr = MessageBox.Show("Yapılan değişiklikler kaydedilsin mi ?", "Dosya Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Metin Dosyası |*.txt";
                    save.OverwritePrompt = true;
                    save.CreatePrompt = true;

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter Kayit = new StreamWriter(save.FileName);
                        Kayit.WriteLine(richTextBox1.Text);
                        Kayit.Close();
                    }

                    Application.Exit();
                }
                else if (dr == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }
        #endregion

        // Yazı rengi değiştirmek içindir. Hem buton hem sağ tıklama ile.
        #region Yazı Rengi Değiştirme
        private void yazıRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog yaziRenkDegistir = new ColorDialog();

            if (yaziRenkDegistir.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = yaziRenkDegistir.Color;
            }

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog yaziRenkDegistir = new ColorDialog();

            if (yaziRenkDegistir.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = yaziRenkDegistir.Color;
            }
        }
        #endregion

        // Yazı fontu değiştirmek içindir. Hem buton hem sağ tıklama ile.
        #region Yazı Fontu Değiştime
        private void yazıÇeşidiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog yaziFontDegistir = new FontDialog();

            if (yaziFontDegistir.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = yaziFontDegistir.Font;
            }
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog yaziFontDegistir = new FontDialog();

            if (yaziFontDegistir.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = yaziFontDegistir.Font;
            }
        }
        #endregion

        // Yazı arka plan rengini değiştirmek içindir. Hem buton hem arka plan ile.
        #region Yazı Arka Plan Rengi Değiştirme
        private void zeminRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog zeminRenkDegistir = new ColorDialog();

            if (zeminRenkDegistir.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionBackColor = zeminRenkDegistir.Color;
            }
        }
        private void yazıArkaPlanRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog zeminRenkDegistir = new ColorDialog();

            if (zeminRenkDegistir.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionBackColor = zeminRenkDegistir.Color;
            }
        }
        #endregion

        // Kes fonksiyonudur. Ayrıca butonların aktif olup olmamasını da kontrol ediyorum. Yine hem buton hem sağ tık ile.
        #region Kes Fonksiyonu
        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";
            }
            else
            {
                kesToolStripMenuItem.Enabled = false;
            }
        }
        private void kesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";
            }
            else
            {
                kesToolStripMenuItem.Enabled = false;
            }
        }
        #endregion

        // Kopyala fonksiyonudur...
        #region Kopyala Fonksiyonu
        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                kopyalaToolStripMenuItem.Enabled = true;
                Clipboard.SetText(richTextBox1.SelectedText);
            }
            else
            {
                kopyalaToolStripMenuItem.Enabled = false;
            }
        }
        private void kopyalaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                kopyalaToolStripMenuItem.Enabled = true;
                Clipboard.SetText(richTextBox1.SelectedText);
            }
            else
            {
                kopyalaToolStripMenuItem.Enabled = false;
            }
        }
        #endregion

        // Yapıştır Fonksiyonudur...
        #region Yapıştır Fonksiyonu
        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.SelectedText = Clipboard.GetText();
            }
        }
        private void yapıştırToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.SelectedText = Clipboard.GetText();
            }
        }
        #endregion


        // Herhangi bir değişiklik olduğunda bool tipindeki değerlerimi ayarlamak için bu ikisini kullanıyorum.
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            degisiklikVarMi = true;

            if (dosyaYeniMi == false && degisiklikVarMi == true)
            {
                this.Text = "Kaydedilmemiş Metin Dosyası";
            }

            if (richTextBox1.SelectionLength > 0)
            {
                kesToolStripMenuItem.Enabled = true;
            }

        }
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                kesToolStripMenuItem.Enabled = true;
                kopyalaToolStripMenuItem.Enabled = true;
                yapıştırToolStripMenuItem.Enabled = true;
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hangi dil için şablon dosyası oluşturmak istiyorsunuz? (c/cpp/csharp)");
            string dil = Console.ReadLine().ToLower();

            // Şablon dosyasını kopyalayacak fonksiyonu çağır
            CopyTemplate(dil);
        }

        static void CopyTemplate(string dil)
        {
            string templateDosyaAdi = "";
            switch (dil)
            {
                case "c":
                    templateDosyaAdi = "template_c.cs";
                    break;
                case "cpp":
                    templateDosyaAdi = "template_cpp.cs";
                    break;
                case "csharp":
                    templateDosyaAdi = "template_csharp.cs";
                    break;
                default:
                    Console.WriteLine("Geçersiz dil seçimi!");
                    return;
            }

            string kaynakDosyaYolu = Path.Combine("Templates", templateDosyaAdi);
            string hedefDosyaYolu = Path.Combine(Environment.CurrentDirectory, templateDosyaAdi);

            if (File.Exists(hedefDosyaYolu))
            {
                Console.WriteLine($"{templateDosyaAdi} zaten var!");
            }
            else
            {
                File.Copy(kaynakDosyaYolu, hedefDosyaYolu);
                Console.WriteLine($"{templateDosyaAdi} oluşturuldu.");
            }
        }
    }
}   
