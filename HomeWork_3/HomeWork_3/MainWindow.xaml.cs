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
                tb_for_decryption.Visibility = Visibility.Visible;
                bt_decryption.Visibility = Visibility.Visible;
                l_decryption.Visibility = Visibility.Visible;
                string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                var ch = alph.ToArray();
                var textArray = text.ToArray();
                char[] newTextArray = new char[textArray.Length];
                for (int i = 0; i < text.Length; i++)
                {
                    if (flag == true)
                    {
                        for (int j = 0; j < alph.Length; j++)
                        {
                            if (textArray[i] == ch[j])
                            {
                                int number_for_encryption = 32 - j;
                                newTextArray[i] = ch[number_for_encryption];
                            }
                        }
                    }
                    else
                    {
                        for (int j = (alph.Length) - 1; j >= 0; j--)
                        {
                            if (textArray[i] == ch[j])
                            {
                                int number_for_encryption = 32 - j;
                                newTextArray[i] = ch[number_for_encryption];
                            }
                        }
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
                    tb_for_encryption.Text = newText;
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
