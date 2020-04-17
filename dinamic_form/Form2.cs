using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace dinamic_form
{
    public partial class Form2 : Form
    {
        public List<string[]> List { get; set; }
        public string user_data;
        string name;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || maskedTextBox3.Text == "" ||
                maskedTextBox9.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Заполните пустые поля");
            else
            {
                bool mail = proverka_emali_phone(textBox4.Text, "Email", @"\S*@\S*");
                bool phone = proverka_emali_phone(maskedTextBox4.Text, "Телефон", @"(?=.+7\d?\d?\d?\d?\d?\d?\d?\d?\d?\d?\b)|(?=.8\d?\d?\d?\d?\d?\d?\d?\d?\d?\b)");
                if (mail == true && phone == true)
                {
                    if (!(get_string() == user_data))
                    {
                        if (MessageBox.Show("Сохранить ваши данные?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            Properties.Settings.Default.us_dt = get_string();
                            Properties.Settings.Default.Save();
                        }
                    }
                    this.Hide();
                    Form3 form3 = new Form3();
                    form3.chek = get_chek();
                    form3.adres = "Адрес доставки ул " + textBox1.Text + " д " + textBox2.Text + " кв "
                        + textBox3.Text + " под " + maskedTextBox9.Text + " эт" + maskedTextBox10.Text 
                        + name;
                    form3.ShowDialog();
                }
            }
        }

        private Boolean proverka_emali_phone(string rez, string name, string pattern)
        {
            bool status = true;
            rez.Replace(" ", "");
            if (rez != "")
            {
                Regex regex = new Regex(pattern);
                if (!regex.IsMatch(rez))
                {
                    MessageBox.Show("Поле @ не соответствует формату".Replace("@", name));
                    status = false;
                }
            }
            else
            {
                MessageBox.Show("Поле @ обязательно к заполнению".Replace("@", name));
                status = false;
            }
            return status;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private int summ()
        {
            int rez = 0;
            foreach (var item in List)
                rez += Convert.ToInt32(item[1]) * Convert.ToInt32(item[4]);
            return rez;
        }

        private int skidka()
        {
            int skidka = 0;
            int day = (int)DateTime.Now.DayOfWeek;
            if (day == 5)
                skidka = summ() * 15 / 100;
            return skidka;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            user_data = Properties.Settings.Default.us_dt;
            if (!user_data.Contains("{}"))
                get_us_data();
            label11.Text = label11.Text.Replace("@", summ().ToString());
            Regex regex = new Regex(@"\s?@\s");
            label12.Text = regex.Replace(label12.Text, " " + skidka().ToString());
            label13.Text = regex.Replace(label13.Text, " " + (summ() - skidka()).ToString());
            regex = new Regex(@"[(]?@%?[)]?");
            if (skidka() > 0)
                label12.Text = regex.Replace(label12.Text, " (15%)");
            else
                label12.Text = regex.Replace(label12.Text, " (0%)");
        }

        private string get_string()
        {
            string fam = maskedTextBox1.Text, name = maskedTextBox2.Text, oth = maskedTextBox3.Text, phone = maskedTextBox4.Text, email = textBox4.Text;
            string street = textBox1.Text, house = textBox2.Text, kw = textBox3.Text, pd = maskedTextBox9.Text, etg = maskedTextBox10.Text;
            if (etg == "")
                etg = " ";
            return "fam={" + fam + "}; name={" + name + "}; oth={" + oth + "}; phone={" + phone + "}; email={" + email + "}; " +
                "street={" + street + "}; house={" + house + "}; kw={" + kw + "}; pd={" + pd + "}; etg={" + etg + "};";
        }

        private void get_us_data()
        {
            maskedTextBox1.Text = Regex.Match(user_data, @"fam={([а-яА-Яa-zA-Z0-9_-]+|\s+)*};").ToString().Replace("fam={", "").Replace("};", "");
            maskedTextBox2.Text = Regex.Match(user_data, @"name={([а-яА-Яa-zA-Z0-9_-]+|\s+)*};").ToString().Replace("name={", "").Replace("};", "");
            maskedTextBox3.Text = Regex.Match(user_data, @"oth={([а-яА-Яa-zA-Z0-9_-]+|\s+)*};").ToString().Replace("oth={", "").Replace("};", "");
            maskedTextBox4.Text = Regex.Match(user_data, @"phone={([а-яА-Яa-zA-Z0-9_-]+|\s+|[+])*};").ToString().Replace("phone={", "").Replace("};", "");
            textBox4.Text = Regex.Match(user_data, @"email={([а-яА-Яa-zA-Z0-9_-]+|\s+|[@]*|[.]*)*};").ToString().Replace("email={", "").Replace("};", "");
            textBox1.Text = Regex.Match(user_data, @"street={([а-яА-Яa-zA-Z0-9_-]+|\s+)*};").ToString().Replace("street={", "").Replace("};", "");
            textBox2.Text = Regex.Match(user_data, @"house={([а-яА-Яa-zA-Z0-9_-]+|\s+)*};").ToString().Replace("house={", "").Replace("};", "");
            textBox3.Text = Regex.Match(user_data, @"kw={([а-яА-Яa-zA-Z0-9_-]+|\s+)*};").ToString().Replace("kw={", "").Replace("};", "");
            maskedTextBox9.Text = Regex.Match(user_data, @"pd={([а-яА-Яa-zA-Z0-9_-]+|\s+)*};").ToString().Replace("pd={", "").Replace("};", "");
            maskedTextBox10.Text = Regex.Match(user_data, @"etg={([а-яА-Яa-zA-Z0-9_-]+|\s+)*};").ToString().Replace("etg={", "").Replace("};", "");
        }

        private string get_chek()
        {
            string chek = "КАССОВЫЙ ЧЕК\r\nЦАРЬ ПИЦЦА\r\nИНН 0000000000\r\n\r\n Чек №5907\r\n"
                + DateTime.Now + "\r\nСмена №5\r\nКассир Иванова М.А.\r\nРН ККТ631691218\r\nПермь\r\nМЕСТО РАСЧЕТОВ Офис\r\nПермь\r\n" 
                + "Заказчик " + maskedTextBox1.Text + " " + maskedTextBox2.Text + " " + maskedTextBox3.Text + " " + "\r\n" 
                + "Адрес доставки: ул. " + textBox1.Text + " д. " + textBox2.Text + " кв. " + textBox3.Text + " под. " + maskedTextBox9.Text 
                + " эт." + maskedTextBox10.Text + "\r\n\r\nТОВАР\r\n";
            foreach (var item in List)
            {
                if (Convert.ToInt32(item[4]) > 0)
                {
                    chek += item[4] + "x" + item[0] + " (" + item[3] + " см) " + item[1] + "р\r\n";
                    name += item[0] + " ";
                }
            }
            chek += "ИТОГО " + summ() + "р\r\n" + "СКИДКА " + skidka() + "р\r\n" + "К ОПЛАТЕ " + (summ() - skidka()) + "р\r\n\r\n" 
                + "ОПЛАЧЕНО " + (summ() - skidka()) + "р\r\n" + "СУММА НДС 20% " + (summ() * 20 / 120) + "р\r\n " +
                "САЙТ НДС www.nalog.ru\r\nФД954615742\r\nФН954615742\r\nФП954615742\r\n";
            return chek;
        }
    }
}
