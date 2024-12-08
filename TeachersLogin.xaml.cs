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
using System.Windows.Shapes;

namespace Assignment_4._2._1
{
    /// <summary>
    /// Interaction logic for TeachersLogin.xaml
    /// </summary>
    public partial class TeachersLogin : Window
    {
        public TeachersLogin()
        {
            InitializeComponent();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Username")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = new SolidColorBrush(Colors.Black); // Reset text color to black when focused
            }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Username"; // Placeholder text
                textBox.Foreground = new SolidColorBrush(Colors.Gray); // Placeholder color
            }
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (username == "Teacher" && password == "Admin")
            {
                // If login is successful, open the Teacher Dashboard
                TeacherDashboard dashboard = new TeacherDashboard();
                dashboard.Show();
                this.Close(); // Close the login window
            }
            else
            {
                MessageBox.Show("Invalid credentials, please try again.");
            }
        }
    }
}
