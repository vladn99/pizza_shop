using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ClassLibrary1;

namespace dinamic_form
{
    public partial class Form1 : Form
    {
        int cl = 0;
        Panel pn;
        Button plus, minus;
        PictureBox pb;
        RadioButton fr, sc, th;
        TextBox kol;
        Label nazv, opis, ingrid, cena, ves;
        CheckBox checkBox;
        List<string[]> ls = new List<string[]>();
        public List<string[]> checklist = new List<string[]>();
        public List<string[]> mix { get; set; } 
        TextBox txt = new TextBox();
        int btn_id;

        public Form1()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath.Replace(@"\bin\Debug", ""));
            pn = panel1;
            plus = btnplus1;
            minus = btnminus1;
            pb = pictureBox1;
            fr = first1;
            sc = second1;
            th = threeth1;
            kol = txt1;
            nazv = label4;
            opis = label3;
            ingrid = label2;
            cena = cena1;
            ves = ves1;
            checkBox = checkBox1;
        }
        private void paint_form(string name, string ops, string img, string ing, int razmer1, int razmer2, int razmer3, int vs, int cn)
        {
            Panel nwpn = new Panel();
            nwpn.Height = pn.Height;
            nwpn.Width = pn.Width;
            if (cl == 0)
                nwpn.Location = new Point(pn.Location.X, pn.Location.Y);
            else
                nwpn.Location = new Point(pn.Location.X, pn.Location.Y + pn.Height + 10);
            nwpn.BorderStyle = pn.BorderStyle;
            nwpn.BackColor = pn.BackColor;
            Controls.Add(nwpn);
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
            newkol.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
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
            Label newops = new Label();
            newops.Height = opis.Height;
            newops.Width = opis.Width;
            newops.MaximumSize = opis.MaximumSize;
            newops.Location = new Point(opis.Location.X, opis.Location.Y);
            newops.TextAlign = opis.TextAlign;
            newops.Font = opis.Font;
            newops.AutoSize = opis.AutoSize;
            newops.Text = ops;
            pn.Controls.Add(newops);
            opis = newops;
            Label newingr = new Label();
            newingr.Height = ingrid.Height;
            newingr.Width = ingrid.Width;
            newingr.Location = new Point(ingrid.Location.X, ingrid.Location.Y);
            newingr.TextAlign = ingrid.TextAlign;
            newingr.Font = ingrid.Font;
            newingr.AutoSize = ingrid.AutoSize;
            newingr.Text = ing;
            pn.Controls.Add(newingr);
            ingrid = newingr;
            Label newcn = new Label();
            newcn.Height = cena.Height;
            newcn.Width = cena.Width;
            newcn.Location = new Point(cena.Location.X, cena.Location.Y);
            newcn.TextAlign = cena.TextAlign;
            newcn.Font = cena.Font;
            newcn.Name = "cena" + (cl + 2);
            newcn.AutoSize = cena.AutoSize;
            newcn.Text = "Цена: " + cn.ToString() + " р.";
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
            newvs.Text = "Вес: " + vs.ToString() + " г.";
            pn.Controls.Add(newvs);
            ves = newvs;
            CheckBox newcheckBox = new CheckBox();
            newcheckBox.Name = "checkBox" + (cl + 2).ToString();
            newcheckBox.Height = checkBox.Height;
            newcheckBox.Width = checkBox.Width;
            newcheckBox.Location = new Point(checkBox.Location.X, ves.Location.Y);
            newcheckBox.Text = checkBox.Text;
            newcheckBox.Enabled = checkBox.Enabled;
            newcheckBox.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
            pn.Controls.Add(newcheckBox);
            checkBox = newcheckBox;
            PictureBox nwpb = new PictureBox();
            nwpb.Height = pb.Height;
            nwpb.Width = pb.Width;
            nwpb.Location = new Point(pb.Location.X, pb.Location.Y);
            nwpb.BorderStyle = pb.BorderStyle;
            try
            {
                nwpb.Load(Application.StartupPath + @"\img\" + img);
            }
            catch
            {

                nwpb.Load(Application.StartupPath + @"\img\img_4831562.png");
            }
            nwpb.SizeMode = pb.SizeMode;
            pn.Controls.Add(nwpb);
            pb = nwpb;
            RadioButton nwf = new RadioButton(), nws = new RadioButton(), nwt = new RadioButton();
            nwf.Appearance = fr.Appearance;
            nwf.Height = fr.Height;
            nwf.Width = fr.Width;
            nwf.Location = new Point(fr.Location.X, fr.Location.Y);
            nwf.FlatStyle = fr.FlatStyle;
            nwf.FlatAppearance.BorderColor = fr.FlatAppearance.BorderColor;
            nwf.FlatAppearance.BorderSize = fr.FlatAppearance.BorderSize;
            nwf.Checked = fr.Checked;
            nwf.Text = fr.Text;
            nwf.ForeColor = fr.ForeColor;
            nwf.BackColor = fr.BackColor;
            nwf.Name = "first" + (cl + 2);
            nwf.TextAlign = fr.TextAlign;
            nwf.Text = razmer1.ToString() + " см.";
            nwf.Click += new EventHandler(first1_Click);
            pn.Controls.Add(nwf);
            fr = nwf;
            nws.Appearance = sc.Appearance;
            nws.Height = sc.Height;
            nws.Width = sc.Width;
            nws.Location = new Point(sc.Location.X, sc.Location.Y);
            nws.FlatStyle = sc.FlatStyle;
            nws.FlatAppearance.BorderColor = sc.FlatAppearance.BorderColor;
            nws.FlatAppearance.BorderSize = sc.FlatAppearance.BorderSize;
            nws.Checked = sc.Checked;
            nws.TextAlign = sc.TextAlign;
            nws.Text = razmer2.ToString() + " см.";
            nws.ForeColor = sc.ForeColor;
            nws.BackColor = sc.BackColor;
            nws.Name = "second" + (cl + 2);
            nws.Click += new EventHandler(second1_Click);
            pn.Controls.Add(nws);
            sc = nws;
            nwt.Appearance = th.Appearance;
            nwt.Height = th.Height;
            nwt.Width = th.Width;
            nwt.Location = new Point(th.Location.X, th.Location.Y);
            nwt.FlatStyle = th.FlatStyle;
            nwt.FlatAppearance.BorderColor = th.FlatAppearance.BorderColor;
            nwt.FlatAppearance.BorderSize = th.FlatAppearance.BorderSize;
            nwt.Checked = th.Checked;
            nwt.TextAlign = th.TextAlign;
            nwt.Text = razmer3.ToString() + " см.";
            nwt.ForeColor = th.ForeColor;
            nwt.BackColor = th.BackColor;
            nwt.Name = "threeth" + (cl + 2);
            nwt.Click += new EventHandler(threeth1_Click);
            pn.Controls.Add(nwt);
            th = nwt;
            cl++;
        }

        private void btnplus1_Click(object sender, EventArgs e)
        {
            btn_id = Convert.ToInt32((sender as Button).Name.Replace("btnplus", ""));
            txt = (TextBox)Controls.Find("txt" + btn_id, true)[0];
            txt.Text = (Convert.ToInt32(txt.Text) + 1).ToString();
        }

        private void btnminus1_Click(object sender, EventArgs e)
        {
            btn_id = Convert.ToInt32((sender as Button).Name.Replace("btnminus", ""));
            txt = (TextBox)Controls.Find("txt" + btn_id, true)[0];
            if (Convert.ToInt32(txt.Text) > 0)
                txt.Text = (Convert.ToInt32(txt.Text) - 1).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for_base obj = new for_base("" +
                "select Bludo.Id, Bludo.name, Bludo.opisanie, Bludo.img, ingridient.name/*, ingridient.ves, ingridient.cena*/, razmer.razmer, razmer.ves, razmer.cena  " +
                "from Bludo, bludo_ing, ingridient, razmer " +
                "where Bludo.Id = razmer.bludo_Id and Bludo.Id = bludo_ing.bludo_Id and bludo_ing.ingrid_Id = ingridient.Id", 
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory.Replace(@"\bin\Debug", "") + "\\Database1.mdf;Integrated Security=True;");
            obj.connection_open();
            obj.proverka_znachenei_v_bd();
            if (obj.reader.HasRows)
            {
                int id = 0, razmer1 = 0, razmer2 = 0, razmer3 = 0, vs = 0, vs2 = 0, vs3 = 0, cn = 0, cn2 = 0, cn3 = 0, time_per = 0, time_razm = 0, time_cn = 0, time_vs = 0;
                string name = "", ops = "", img = "", ing = "", time_ingr = "";
                while (obj.reader.Read())
                {
                    if (obj.reader.GetInt32(0) != id)
                    {
                        if (time_per == 0)
                        {
                            id = obj.reader.GetInt32(0);
                            razmer1 = obj.reader.GetInt32(5);
                            time_razm = obj.reader.GetInt32(5);
                            vs = obj.reader.GetInt32(6);
                            cn = obj.reader.GetInt32(7);
                            name = obj.reader.GetString(1);
                            ops = obj.reader.GetString(2);
                            img = obj.reader.GetString(3);
                            ing = obj.reader.GetString(4);
                            time_ingr = obj.reader.GetString(4);
                            time_per += 1;
                        }
                        else
                        {
                            ing += ".";
                            ls.Add(new string[] { cn + "@" + vs, cn2 + "@" + vs2, cn3 + "@" + vs3 });
                            create_checklist(name, cn, vs, cn2, vs2, cn3, vs3, razmer1, razmer2, razmer3);
                            paint_form(name, ops, img, ing, razmer1, razmer2, razmer3, vs, cn);
                            razmer2 = 0; vs2 = 0; cn2 = 0;
                            id = obj.reader.GetInt32(0);
                            razmer1 = obj.reader.GetInt32(5);
                            vs = obj.reader.GetInt32(6);
                            cn = obj.reader.GetInt32(7);
                            name = obj.reader.GetString(1);
                            ops = obj.reader.GetString(2);
                            img = obj.reader.GetString(3);
                            ing = obj.reader.GetString(4);
                            time_ingr = obj.reader.GetString(4);
                        }

                    }
                    else
                    {
                        if (time_ingr != obj.reader.GetString(4))
                        {
                            ing += ", " + obj.reader.GetString(4);
                            time_ingr = obj.reader.GetString(4);
                        }
                        if (time_razm != obj.reader.GetInt32(5))
                        {
                            if (razmer2 == 0)
                                razmer2 = obj.reader.GetInt32(5);
                            else
                                razmer3 = obj.reader.GetInt32(5);
                            time_razm = obj.reader.GetInt32(5);
                        }
                        if (time_vs != obj.reader.GetInt32(6))
                        {
                            if (vs2 == 0)
                                vs2 = obj.reader.GetInt32(6);
                            else
                                vs3 = obj.reader.GetInt32(6);
                            time_vs = obj.reader.GetInt32(6);
                        }
                        if (time_cn != obj.reader.GetInt32(7))
                        {
                            if (cn2 == 0)
                                cn2 = obj.reader.GetInt32(7);
                            else
                                cn3 = obj.reader.GetInt32(7);
                            time_cn = obj.reader.GetInt32(7);
                        }
                    }
                }
                ls.Add(new string[] { cn + "@" + vs, cn2 + "@" + vs2, cn3 + "@" + vs3 });
                create_checklist(name, cn, vs, cn2, vs2, cn3, vs3, razmer1, razmer2, razmer3);
                paint_form(name, ops, img, ing, razmer1, razmer2, razmer3, vs, cn);
                panel1.Visible = false;
            }
            obj.connection_close();
            radio_btn();
            btn_zakaz();
        }

        private void radio_btn()
        {
            RadioButton rb = new RadioButton();
            for (int i = 0; i <= cl; i++)
            {
                rb = (RadioButton)Controls.Find("first" + (i + 1), true)[0];
                proverca_rb(rb);
                rb = (RadioButton)Controls.Find("second" + (i + 1), true)[0];
                proverca_rb(rb);
                rb = (RadioButton)Controls.Find("threeth" + (i + 1), true)[0];
                proverca_rb(rb);
            }
        }

        private void first1_Click(object sender, EventArgs e)
        {
            radio_btn();
            btn_id = Convert.ToInt32((sender as RadioButton).Name.Replace("first", ""));
            izm_cen_ves(btn_id, 0);
            izm_checklist(btn_id, "neschet");
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            int id_el = Convert.ToInt32((sender as TextBox).Name.Replace("txt", ""));
            txt = sender as TextBox;
            if (txt.Text != "")
            {
                if (Convert.ToInt32(txt.Text) > 15)
                    txt.Text = "15";
                CheckBox chb = (CheckBox)Controls.Find("checkBox" + txt.Name.Replace("txt", ""), true)[0];
                if (txt.Text != "1" && txt.Text != "0" && txt.Text != "")
                    chb.Enabled = true;
                if (Convert.ToInt32(txt.Text) == 1 || txt.Text == "0")
                {
                    izm_checklist(id_el, "schet");
                    btn_zakaz();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int id_el = Convert.ToInt32((sender as CheckBox).Name.Replace("checkBox", ""));
            if ((sender as CheckBox).Checked == true)
            {
                izm_checklist(id_el, "schet");
                btn_zakaz();
            }
            else if ((sender as CheckBox).Checked == false)
                button4.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.List = checklist;
            form2.ShowDialog();
        }

        private void second1_Click(object sender, EventArgs e)
        {
            radio_btn();
            btn_id = Convert.ToInt32((sender as RadioButton).Name.Replace("second", ""));
            izm_cen_ves(btn_id, 1);
            izm_checklist(btn_id, "neschet");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.get_cheklist = checklist;
            form4.Show();
        }

        private void threeth1_Click(object sender, EventArgs e)
        {
            radio_btn();
            btn_id = Convert.ToInt32((sender as RadioButton).Name.Replace("threeth", ""));
            izm_cen_ves(btn_id, 2);
            izm_checklist(btn_id, "neschet");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void proverca_rb(RadioButton rb)
        {
            if (rb.Checked == false)
            {
                rb.BackColor = Color.Red;
                rb.ForeColor = Color.White;
            }
            else
            {
                rb.BackColor = Color.White;
                rb.ForeColor = Color.Red;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }
       
        private void izm_cen_ves(int id_str, int id_el)
        {
            Label label1;
            string[] arr = ls[id_str - 2][id_el].Split('@');
            label1 = (Label)Controls.Find("cena" + id_str, true)[0];
            label1.Text = "Цена: " + arr[0] + " р.";
            label1 = (Label)Controls.Find("ves" + id_str, true)[0];
            label1.Text = "Вес: " + arr[1] + " г.";
        }

        private void izm_checklist(int id_el, string par)
        {
            RadioButton rb1, rb2, rb3;
            string name = Controls.Find("name" + id_el, true)[0].Text;
            string cena = Controls.Find("cena" + id_el, true)[0].Text.Replace("Цена: ", "").Replace(" р.", "");
            string ves = Controls.Find("ves" + id_el, true)[0].Text.Replace("Вес: ", "").Replace(" г.", "");
            rb1 = (RadioButton)Controls.Find("first" + id_el, true)[0];
            rb2 = (RadioButton)Controls.Find("second" + id_el, true)[0];
            rb3 = (RadioButton)Controls.Find("threeth" + id_el, true)[0];
            string razmer = "";
            if (rb1.Checked == true)
                razmer = rb1.Text.Replace(" см.", "");
            else if(rb2.Checked == true)
                razmer = rb2.Text.Replace(" см.", "");
            else if(rb3.Checked == true)
                razmer = rb3.Text.Replace(" см.", "");
            for (int i = 0; i < checklist.Count; i++)
            {
                if (checklist[i][0] == name && checklist[i][1] == cena && checklist[i][2] == ves && checklist[i][3] == razmer)
                {
                    if (par == "schet")
                        checklist[i][4] = Controls.Find("txt" + id_el, true)[0].Text;
                    else if (par == "neschet")
                        Controls.Find("txt" + id_el, true)[0].Text = checklist[i][4];
                    else if (par == "unschet" && Convert.ToInt32(checklist[i][4]) != 0)
                        checklist[i][4] = (Convert.ToInt32(checklist[i][4]) - 1).ToString();
                }
            }
        }

        public int summ()
        {
            int rez = 0;
            foreach (var item in checklist)
                rez += Convert.ToInt32(item[1]) * Convert.ToInt32(item[4]);
            return rez;
        }

        private void create_checklist(string name, int cn, int vs, int cn2, int vs2, int cn3, int vs3, int razmer1, int razmer2, int razmer3)
        {
            checklist.Add(new string[] { name, cn.ToString(), vs.ToString(), razmer1.ToString(), 0.ToString() });
            checklist.Add(new string[] { name, cn2.ToString(), vs2.ToString(), razmer2.ToString(), 0.ToString() });
            checklist.Add(new string[] { name, cn3.ToString(), vs3.ToString(), razmer3.ToString(), 0.ToString() });
        }

        public void pereschet()
        {
            checklist.Clear();
            checklist.AddRange(mix.ToArray());
            btn_zakaz();
            for (int i = 2; i < cl + 2; i++)
                izm_checklist(i, "neschet");
        }

        private void btn_zakaz()
        {
            int rez = summ();
            Regex regex = new Regex(@"{\S*}");
            button4.Text = regex.Replace(button4.Text, "{" + rez + "}");
            if (rez > 0)
                button4.Enabled = true;
            else
                button4.Enabled = false;
        }
    }
}
