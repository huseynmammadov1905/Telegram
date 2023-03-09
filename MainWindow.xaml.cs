using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Telegram__
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Faker xowuma gelmedi ozum Person class yaratdim
        public List<Person> People { set; get; } = new()
        {
            new(){Avatar = "https://static.tvtropes.org/pmwiki/pub/images/caillou_the_grownup.png",FullName= "Bahruz Nezerli",Time = DateTime.Now.ToString() },
            new(){Avatar = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQHe0e93kw-9om0uFsm3o9UuUuH4cWFvTIgkw&usqp=CAU",FullName= "Sarxan Tanriverdiyev", Time = DateTime.Now.ToString() },
            new(){Avatar = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThKTopWlgUOMcd4y5mT--kwo8UQ26MmUkcrw&usqp=CAU",FullName= "Rustam Mammadov",Time = DateTime.Now.ToString() },
        };

        public List<Message> messages = new();
        public MainWindow()
        {
            InitializeComponent();
            //People = new Bogus.Faker<Person>().RuleFor(p => p.Avatar, f => f.Person.Avatar).RuleFor(p=> p.FullName,f=>f.Person.FullName).RuleFor(p=> p.Time,DateTime.Now).RuleFor(p=> p.message,temp1).Generate(3); 
            DataContext = this;
        }

        public void Foo()
        {


            Stckpnl.Children.Clear();

            for (int i = 0; i < messages.Count; i++)

            {
                if (messages[i].name == tbl_Name.Text)
                {
                    StackPanel stackPanel = new();
                    stackPanel.MaxWidth = 500;
                    stackPanel.Margin = new Thickness(5);
                    stackPanel.Background = new SolidColorBrush(Colors.White);

                    TextBlock textBlock = new TextBlock();
                    textBlock.TextWrapping = TextWrapping.Wrap;
                    textBlock.FontSize = 26;
                    textBlock.FontStyle = FontStyles.Italic;
                    textBlock.Text = messages[i].message;

                    Label lblTime = new Label();
                    lblTime.FontSize = 10;
                    lblTime.HorizontalAlignment = HorizontalAlignment.Right;
                    lblTime.Content = messages[i].Time.ToString();

                    stackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                    stackPanel.Children.Add(textBlock);
                    stackPanel.Children.Add(lblTime);
                    Stckpnl.Children.Add(stackPanel);
                }
                else if (messages[i].name == "Huseyn")
                {
                    if (messages[i + 1].name == tbl_Name.Text)
                    {
                        StackPanel stackPanel = new();
                        stackPanel.MaxWidth = 500;
                        stackPanel.Margin = new Thickness(5);
                        stackPanel.Background = new SolidColorBrush(Colors.LightGreen);

                        TextBlock textBlock = new TextBlock();
                        textBlock.TextWrapping = TextWrapping.Wrap;
                        textBlock.FontSize = 26;
                        textBlock.FontStyle = FontStyles.Italic;
                        textBlock.Text = messages[i].message;

                        Label lblTime = new Label();
                        lblTime.FontSize = 10;
                        lblTime.HorizontalAlignment = HorizontalAlignment.Right;
                        lblTime.Content = messages[i].Time.ToString();

                        stackPanel.HorizontalAlignment = HorizontalAlignment.Right;
                        stackPanel.Children.Add(textBlock);
                        stackPanel.Children.Add(lblTime);
                        Stckpnl.Children.Add(stackPanel);
                    }

                }
            }

        }

        private void tb_search_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.Focusable = true;
                if (tb.Text == "Search" || tb.Text == "Write a message")
                {
                    tb.Text = null;
                }
            }
        }

        private void tb_search_MouseLeave(object sender, MouseEventArgs e)
        {
            if (tb_message.Text.Length == 0 || tb_search.Text.Length == 0)
            {
                tb_message.Text = "Write a message";
                tb_message.Foreground = new SolidColorBrush(Colors.Gray);
                tb_search.Text = "Search";
                tb_search.Foreground = new SolidColorBrush(Colors.Gray);
                tb_message.Focusable = false;
            }
            else
            {
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                if (tb_message.Text == "Write a message")
                    tb_message.Text = null;

                if (tb_message.Text?.Length > 0)
                {

                    string? messageYou = tb_message.Text;
                    string? messageUser = null;

                    if (tbl_Name.Text != "Name")
                    {
                        if (messageYou.ToLower() == "salam")
                        {
                            messageUser = "Aleykum Salam";
                        }
                        else
                        {
                            messageUser = "Iwim var,sonra daniwariq";
                        }

                        Message you = new("Huseyn", false, DateTime.Now.ToShortTimeString(), messageYou);
                        Message user = new(tbl_Name.Text, true, DateTime.Now.ToShortTimeString(), messageUser);

                        messages.Add(you);
                        messages.Add(user);

                        Foo();
                        tb_message.Text = null;
                    }
                    else
                    {
                        tb_message.Text = null;
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void lv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Stckpnl.Children.Clear();
            if (sender is ListView listView)
            {
                var person = listView.SelectedItem as Person;
                tbl_Name.Text = person.FullName;
            }
            Foo();
        }

        private void emoji_picker_Picked(object sender, Emoji.Wpf.EmojiPickedEventArgs e)
        {
            var emoji = emoji_picker.Selection;
            if (tb_message.Text == "Write a message")
            {
                tb_message.Text = "";
            }
            tb_message.Text += emoji;
        }
    }
}
