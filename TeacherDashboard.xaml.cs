using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Assignment_4._2._1
{
    public partial class TeacherDashboard : Window
    {
        private List<Student> students = new List<Student>();

        public TeacherDashboard()
        {
            InitializeComponent();
        }

        // Add student event handler
        private void AddStudent_Button_Click(object sender, RoutedEventArgs e)
        {
            string studentId = StudentIdTextBox.Text;
            string name = StudentNameTextBox.Text;
            double gpa;

            if (double.TryParse(GPATextBox.Text, out gpa))
            {
                var student = new Student(studentId, name, gpa);
                students.Add(student);
                MessageBox.Show("Student added successfully");
                LoadStudents();
                CheckAndSaveTopStudent();
            }
            else
            {
                MessageBox.Show("Please enter a valid GPA.");
            }
        }

        // Load students into the listbox
        private void LoadStudents()
        {
            StudentsListBox.Items.Clear();
            foreach (var student in students)
            {
                StudentsListBox.Items.Add(student);
            }
        }

        // Delete student event handler
        private void DeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = StudentsListBox.SelectedItem as Student;
            if (selectedStudent != null)
            {
                students.Remove(selectedStudent);
                MessageBox.Show($"Deleted student: {selectedStudent.Name}");
                LoadStudents(); // Refresh list
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }

        // TextBox GotFocus event handler (to handle placeholder)
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && (textBox.Text == "Student ID" || textBox.Text == "Student Name" || textBox.Text == "GPA"))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = new SolidColorBrush(Colors.Black); // Reset text color to black when focused
            }
        }

        // TextBox LostFocus event handler (to restore placeholder)
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "StudentIdTextBox") textBox.Text = "Student ID";
                if (textBox.Name == "StudentNameTextBox") textBox.Text = "Student Name";
                if (textBox.Name == "GPATextBox") textBox.Text = "GPA";
                textBox.Foreground = new SolidColorBrush(Colors.Gray); // Placeholder color
            }
        }

        // Check if the top student changed and save the student with the highest GPA
        private void CheckAndSaveTopStudent()
        {
            var topStudent = students.OrderByDescending(s => s.GPA).FirstOrDefault();
            if (topStudent != null)
            {
                SaveTopStudentToFile(topStudent);
            }
        }

        // Save the top student to a text file
        private void SaveTopStudentToFile(Student topStudent)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TopStudent.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Top Student: {topStudent.Name}");
                writer.WriteLine($"Student ID: {topStudent.StudentId}");
                writer.WriteLine($"GPA: {topStudent.GPA}");
            }
            MessageBox.Show($"Top student {topStudent.Name} saved to file.");
        }
    }
}
