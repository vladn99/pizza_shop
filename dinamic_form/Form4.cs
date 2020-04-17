using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ClassLibrary1;

namespace dinamic_form
{
    public partial class Form4 : Form
    {
        int cl = 0, btn_id, time_cena = 0, time_ves = 0, time_razmer;
        string data_save;
        Panel pn;
        Button plus, minus;
        PictureBox pb;
        TextBox kol;
        Label nazv, cena, ves;
        TextBox txt = new TextBox();
        List<string []> cheklist = new List<string[]>();
        List<string[]> mix = new List<string[]>();
        public List<string[]> get_cheklist { get; set; }

        private void btnminus1_Click(object sender, EventArgs e)
        {
            btn_id = Convert.ToInt32((sender as Button).Name.Replace("btnminus", ""));
            txt = (TextBox)Controls.Find("txt" + btn_id, true)[0];
            if (Convert.ToInt32(txt.Text) > 0)
                txt.Text = (Convert.ToInt32(txt.Text) - 1).ToString();
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            int id_el = Convert.ToInt32((sender as TextBox).Name.Replace("txt", ""));
            txt = sender as TextBox;
            if (txt.Text != "")
            {
                if (Convert.ToInt32(txt.Text) > 15)
                    txt.Text = "15";
                Label lb = (Label)Controls.Find("ves" + id_el, true)[0];
                Label name = (Label)Controls.Find("name" + id_el, true)[0];
                lb.Text = txt.Text + "г.";
                izm_mix(id_el);
                summ();
                if (data_save.Contains(name.Text))
                {
                    data_save = data_save.Replace(Regex.Match(data_save, name.Text + @"={[0-9]*}").ToString(), name.Text + "={" + txt.Text + "}");
                }
                else
                    data_save += name.Text + "={" + txt.Text + "};";
            }
        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }

        private void btnplus1_Click(object sender, EventArgs e)
        {
            btn_id = Convert.ToInt32((sender as Button).Name.Replace("btnplus", ""));
            txt = (TextBox)Controls.Find("txt" + btn_id, true)[0];
            txt.Text = (Convert.ToInt32(txt.Text) + 1).ToString();
        }

        public Form4()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath.Replace(@"\bin\Debug", ""));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            get_cena_ves();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            get_cena_ves();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            get_cena_ves();
        }

        private void paint_form(string name, int vs, int cn, string txt_val)
        {
            Panel nwpn = new Panel();
            nwpn.Name = "panel" + (cl + 3);
            nwpn.Height = pn.Height;
            nwpn.Width = pn.Width;
            if (cl == 0)
                nwpn.Location = new Point(pn.Location.X, pn.Location.Y);
            else
                nwpn.Location = new Point(pn.Location.X, pn.Location.Y + pn.Height + 10);
            nwpn.BorderStyle = pn.BorderStyle;
            nwpn.BackColor = pn.BackColor;
            panel1.Controls.Add(nwpn);
            pn = nwpn;
            Button newplus = new Button();
            newplus.Name = "btnplus" + (cl + 2);
            newplus.Height = plus.Height;
            newplus.Width = plus.Width;
            newplus.Location = new Point(plus.Location.X, plus.Location.Y);
            newplus.Text = plus.Text;
            newplus.FlatStyle = plus.FlatStyle;
            newplus.FlatAppearance.BorderColor = plus.FlatAppearance.BorderColor;
            newplus.FlatAppearance.BorderSize = plus.FlatAppearance.BorderSize;
            newplus.ForeColor = plus.ForeColor;
            newplus.BackColor = plus.BackColor;
            newplus.Font = plus.Font;
            newplus.Click += new EventHandler(btnplus1_Click);
            nwpn.Controls.Add(newplus);
            plus = newplus;
            Button newminus = new Button();
            newminus.Name = "btnminus" + (cl + 2);
            newminus.Height = minus.Height;
            newminus.Width = minus.Width;
            newminus.Location = new Point(minus.Location.X, minus.Location.Y);
            newminus.Text = minus.Text;
            newminus.FlatStyle = minus.FlatStyle;
            newminus.FlatAppearance.BorderColor = minus.FlatAppearance.BorderColor;
            newminus.FlatAppearance.BorderSize = minus.FlatAppearance.BorderSize;
            newminus.ForeColor = minus.ForeColor;
            newminus.BackColor = minus.BackColor;
            newminus.Font = minus.Font;
            newminus.Click += new EventHandler(btnminus1_Click);
            nwpn.Controls.Add(newminus);
            minus = newminus;
            TextBox newkol = new TextBox();
            newkol.Name = "txt" + (cl + 2);
            newkol.Height = kol.Height;
            newkol.Width = kol.Width;
            newkol.Location = new Point(kol.Location.X, kol.Location.Y);
            newkol.Text = kol.Text;
            newkol.ForeColor = kol.ForeColor;
            newkol.BackColor = kol.BackColor;
            newkol.BorderStyle = kol.BorderStyle;
            newkol.TextAlign = kol.TextAlign;
            newkol.Font = kol.Font;
            newkol.Text = txt_val;
            newkol.KeyPress += new KeyPressEventHandler(txt1_KeyPress);
            newkol.TextChanged += new EventHandler(txt1_TextChanged);
            pn.Controls.Add(newkol);
            kol = newkol;
            Label newnaz = new Label();
            newnaz.Height = nazv.Height;
            newnaz.Width = nazv.Width;
            newnaz.Location = new Point(nazv.Location.X, nazv.Location.Y);
            newnaz.TextAlign = nazv.TextAlign;
            newnaz.Font = nazv.Font;
            newnaz.Name = "name" + (cl + 2);
            newnaz.AutoSize = nazv.AutoSize;
            newnaz.Text = name;
            pn.Controls.Add(newnaz);
            nazv = newnaz;
            Label newcn = new Label();
            newcn.Height = cena.Height;
            newcn.Width = cena.Width;
            newcn.Location = new Point(cena.Location.X, cena.Location.Y);
            newcn.TextAlign = cena.TextAlign;
            newcn.Font = cena.Font;
            newcn.Name = "cena" + (cl + 2);
            newcn.AutoSize = cena.AutoSize;
            newcn.Text = cn.ToString() + "р.";
            pn.Controls.Add(newcn);
            cena = newcn;
            Label newvs = new Label();
            newvs.Height = ves.Height;
            newvs.Width = ves.Width;
            newvs.Location = new Point(ves.Location.X, ves.Location.Y);
            newvs.TextAlign = ves.TextAlign;
            newvs.Font = ves.Font;
            newvs.Name = "ves" + (cl + 2);
            newvs.AutoSize = ves.AutoSize;
            newvs.Text = txt_val + "г.";
            pn.Controls.Add(newvs);
            ves = newvs;
            PictureBox nwpb = new PictureBox();
            nwpb.Height = pb.Height;
            nwpb.Width = pb.Width;
            nwpb.Location = new Point(pb.Location.X, pb.Location.Y);
            nwpb.BorderStyle = pb.BorderStyle;
            nwpb.Image = pb.Image;
            nwpb.SizeMode = pb.SizeMode;
            pn.Controls.Add(nwpb);
            pb = nwpb;
            cl++;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            cheklist.Add(new string[] { "Пицца составная:", "200", "150", "25", 0.ToString() });
            cheklist.Add(new string[] { "Пицца составная:", "400", "300", "30", 0.ToString() });
            cheklist.Add(new string[] { "Пицца составная:", "600", "450", "40", 0.ToString() });
            init_components();
            for_paint("select name, ves, cena from ingridient");
            get_cena_ves();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            clear_form();
            init_components();
            for_paint("select name, ves, cena from ingridient where name like N'%" + textBox1.Text + "%'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
                foreach (var item in mix)
                {
                    if (item[3] != "0")
                    {
                        for (int i = 0; i < cheklist.Count; i++)
                        {
                            if (cheklist[i][3] == time_razmer.ToString() && cheklist[i][0].Contains("Пицца составная:"))
                            {
                                cheklist[i][0] += item[0] + "; ";
                                cheklist[i][1] = (Convert.ToUInt32(cheklist[i][1]) + Convert.ToUInt32(item[1]) * Convert.ToUInt32(item[3])).ToString();
                                cheklist[i][2] = (Convert.ToUInt32(cheklist[i][2]) + Convert.ToUInt32(item[2]) * Convert.ToUInt32(item[3])).ToString();
                                cheklist[i][4] = 1.ToString();
                            }
                        }
                    }
                }
            if (data_save != Properties.Settings.Default.pz_dt)
            {
                if (MessageBox.Show("Сохранить данные?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Properties.Settings.Default.pz_dt = data_save;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            cheklist.AddRange(get_cheklist.ToArray());
            form1.mix = cheklist;
            form1.Show();
            form1.pereschet();
        }

        private void get_cena_ves()
        {
            if (radioButton1.Checked == true)
            {
                time_razmer = 25;
                time_cena = 200;
                time_ves = 150;
                summ();
                insert_razmer();
            }
            else if (radioButton2.Checked == true)
            {
                time_razmer = 30;
                time_cena = 400;
                time_ves = 300;
                summ();
                insert_razmer();
            }
            else
            {
                time_razmer = 40;
                time_cena = 600;
                time_ves = 450;
                summ();
                insert_razmer();
            }
        }

        private void init_components()
        {
            panel2.Visible = true;
            cl = 0;
            pn = panel2;
            plus = btnplus1;
            minus = btnminus1;
            pb = pictureBox1;
            kol = txt1;
            nazv = label4;
            cena = cena1;
            ves = ves1;
        }

        private void for_paint(string qwery)
        {
            data_save = Properties.Settings.Default.pz_dt;
            get_razmer();
            for_base obj = new for_base(qwery, @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory.Replace(@"\bin\Debug", "") 
                + "\\Database1.mdf;Integrated Security=True;");
            obj.connection_open();
            obj.proverka_znachenei_v_bd();
            if (obj.reader.HasRows)
            {
                int vs = 0, cn = 0;
                string name = "", kol = "0";
                while (obj.reader.Read())
                {
                    name = obj.reader.GetString(0);
                    vs = obj.reader.GetInt32(1);
                    cn = obj.reader.GetInt32(2);
                    if (!qwery.Contains("like"))
                    {
                        if (data_save.Contains(name))
                        {
                            kol = Regex.Match(data_save, name + @"={[0-9]*}").ToString().Replace(name + "={", "").Replace("}", "");
                        }
                        else
                            kol = "0";
                        mix.Add(new string[] { name, cn.ToString(), vs.ToString(), kol });
                    }
                    foreach (var item in mix)
                        if (item[0] == name)
                            kol = item[3];
                    paint_form(name, vs, cn, kol);
                }
            }
            panel2.Visible = false;
            obj.connection_close();
        }

        private void clear_form()
        {
            Panel panel;
            for (int i = 0; i < cl; i++)
            {
                panel = (Panel)panel1.Controls.Find("panel" + (i + 3), true)[0];
                panel1.Controls.Remove(panel);
                panel.Dispose();
            }
        }

        private void izm_mix(int id_el)
        {
            string name = Controls.Find("name" + id_el, true)[0].Text;
            for (int i = 0; i < mix.Count; i++)
            {
                if (mix[i][0] == name)
                    mix[i][3] = Controls.Find("txt" + id_el, true)[0].Text;
            }
        }

        private void summ()
        {
            int cn = 0, vs = 0;
            foreach (var item in mix)
            {
                cn += Convert.ToInt32(item[1]) * Convert.ToInt32(item[3]);
                vs += Convert.ToInt32(item[2]) * Convert.ToInt32(item[3]);
            }
            label1.Text = $"Цена: {cn + time_cena}р";
            label2.Text = $"Вес: {vs + time_ves}г.";
        }

        private void get_razmer()
        {
            data_save = Properties.Settings.Default.pz_dt;
            string razmer;
            if (!data_save.Contains("{}"))
            {
                razmer = Regex.Match(data_save, @"razmer={[0-9]*}").ToString().Replace("razmer={", "").Replace("}", "");
                if (radioButton1.Text.Contains(razmer))
                    radioButton1.Checked = true;
                else if (radioButton2.Text.Contains(razmer))
                    radioButton2.Checked = true;
                else if (radioButton3.Text.Contains(razmer))
                    radioButton3.Checked = true;
                time_razmer = Convert.ToInt32(razmer);
            }
        }
        private void insert_razmer()
        {
            if (!data_save.Contains("{}"))
                data_save = data_save.Replace(Regex.Match(data_save, @"razmer={[0-9]*}").ToString(), "razmer={" + time_razmer + "}");
            else
                data_save = data_save.Replace(Regex.Match(data_save, @"razmer={}").ToString(), "razmer={" + time_razmer + "} ");
        }
    }
}
