using System.Linq;
using System.Windows;

namespace HomeWork_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void Comparison_with_the_alphabet(int num_of_let, int i, int j , char[] ch, char[] newTextArray, char[] textArray, char[] ch_punctuation)
        {
            if (textArray[i] == ch[j])
            {
                int number_for_encryption = num_of_let - j;
                newTextArray[i] = ch[number_for_encryption];
            }
            else if (j <= 4)
            {
                if (textArray[i] == ch_punctuation[j])
                {
                    newTextArray[i] = textArray[i];
                }
            }
        }
        void Brute_force(bool flag, string alph, char[] ch, char[] textArray, char[] newTextArray, int i, int num_of_let, char[] ch_punctuation)
        {
            if (flag == true)
            {
                for (int j = 0; j < alph.Length; j++)
                {
                    Comparison_with_the_alphabet(num_of_let, i, j, ch, newTextArray, textArray, ch_punctuation);
                }
            }
            else
            {
                for (int j = (alph.Length) - 1; j >= 0; j--)
                {
                    Comparison_with_the_alphabet(num_of_let, i, j, ch, newTextArray, textArray, ch_punctuation);
                }
            }


        }
        void Encryment_or_decryment(bool flag)
        {
            int number = 0; 
            string text = "";
            bool canConvert = false;
            if (flag == true)
            {
                text = tb_for_encryption.Text;
            }
            else
            {
                text = tb_for_decryption.Text;
            }
            canConvert = int.TryParse(text, out number);
            if (canConvert == false)
            {
                bool checkLanguage = false;
                bool check_registor_rus = false;
                bool check_registor_eng = false;
                tb_for_decryption.Visibility = Visibility.Visible;
                bt_decryption.Visibility = Visibility.Visible;
                l_decryption.Visibility = Visibility.Visible;
                l_encryption.Visibility = Visibility.Visible;
                tb_result.Visibility = Visibility.Visible;
                string alph_rus = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                string alph_eng = "abcdefghijklmnoprstuvwxyz";
                string high_registor_rus = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                string high_registor_eng = "ABCDEFGHIJKLMNOPRSTUVWXYZ";
                string punctuation = ",. !?";
                var ch_eng = alph_eng.ToArray();
                var ch_rus = alph_rus.ToArray();
                var ch_high_registor_rus = high_registor_rus.ToArray();
                var ch_high_registor_eng = high_registor_eng.ToArray();
                var ch_punctuation = punctuation.ToArray();
                var textArray = text.ToArray();
                char first_letter = textArray[0];
                char[] newTextArray = new char[textArray.Length];
                for (int i = 0; i < alph_rus.Length; i++)
                    if (first_letter == ch_rus[i] || first_letter == ch_high_registor_rus[i])
                        checkLanguage = true;
                for (char c = 'A'; c <= 'Z'; c++)
                    if (first_letter == c)
                        check_registor_eng = true;
                for (char c = 'А'; c<= 'Я'; c++)
                    if(first_letter == c)
                        check_registor_rus = true;
                int eng = 24;
                int rus = 32;
                for (int i = 0; i < text.Length; i++)
                {
                    if (checkLanguage == true && check_registor_rus == false)
                        Brute_force(flag, alph_rus, ch_rus, textArray, newTextArray, i, rus, ch_punctuation);
                    else if (checkLanguage == true && check_registor_rus == true)
                    {
                        Brute_force(flag, high_registor_rus, ch_high_registor_rus, textArray, newTextArray, i, rus, ch_punctuation);
                        check_registor_rus = false;
                    }
                    else if (checkLanguage == false && check_registor_eng == false)
                        Brute_force(flag, alph_eng, ch_eng, textArray, newTextArray, i, eng, ch_punctuation);
                    else if (checkLanguage == false && check_registor_eng == true)
                    {
                        Brute_force(flag, high_registor_eng, ch_high_registor_eng, textArray, newTextArray, i, eng, ch_punctuation);
                        check_registor_eng = false;
                    }
                }
                string newText = "";
                for (int i = 0; i < text.Length; i++)
                {
                    newText += newTextArray[i];
                }
                if (flag == true)
                    tb_for_decryption.Text = newText;
                else
                    tb_result.Text = newText;
            }
            else
                MessageBox.Show("Это число!!!");
        }
        private void bt_encryption_Click(object sender, RoutedEventArgs e)
        {
            if (tb_for_encryption.Text == "")
            {
                MessageBox.Show("Ты что-то забыл! :)");
            }
            else
            {
                bool flag = true;
                Encryment_or_decryment(flag);
            }
        }
        private void bt_decryption_Click(object sender, RoutedEventArgs e)
        {
            if (tb_for_decryption.Text == "")
            {
                MessageBox.Show("Ты что-то забыл! :)");
            }
            else
            {
                bool flag = false;
                Encryment_or_decryment(flag);
            }
        }
    }
}
