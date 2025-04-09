using System;
using System.Collections.Generic;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using System.IO;

namespace _1st_UWP_App
{
    public sealed partial class MainPage : Page
    {
        private List<Student> students = new List<Student>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Basic input validation
                if (string.IsNullOrWhiteSpace(IdBox.Text) ||
                    string.IsNullOrWhiteSpace(FirstNameBox.Text) ||
                    string.IsNullOrWhiteSpace(LastNameBox.Text) ||
                    string.IsNullOrWhiteSpace(ClassBox.Text) ||
                    string.IsNullOrWhiteSpace(GradeBox.Text))
                {
                    throw new Exception("All fields must be filled out.");
                }

                var student = new Student(
                    IdBox.Text,
                    FirstNameBox.Text,
                    LastNameBox.Text,
                    ClassBox.Text,
                    GradeBox.Text
                );

                students.Add(student);
                StudentList.Items.Add(student.ToString());

                // Clear input fields
                IdBox.Text = FirstNameBox.Text = LastNameBox.Text = ClassBox.Text = GradeBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                var dialog = new ContentDialog
                {
                    Title = "Input Error",
                    Content = ex.Message,
                    CloseButtonText = "OK"
                };
                _ = dialog.ShowAsync();
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var savePicker = new FileSavePicker();
                savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                savePicker.FileTypeChoices.Add("CSV", new List<string>() { ".csv" });
                savePicker.SuggestedFileName = "StudentGrades";

                StorageFile file = await savePicker.PickSaveFileAsync();
                if (file != null)
                {
                    using (StreamWriter writer = new StreamWriter(await file.OpenStreamForWriteAsync()))
                    {
                        foreach (var student in students)
                        {
                            string csvLine = $"{student.ID},{student.FirstName},{student.LastName},{student.ClassName},{student.Grade}";
                            writer.WriteLine(csvLine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await ShowMessageAsync("Save Error", ex.Message);
            }
        }

        private async void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openPicker = new FileOpenPicker();
                openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                openPicker.FileTypeFilter.Add(".csv");

                StorageFile file = await openPicker.PickSingleFileAsync();
                if (file != null)
                {
                    students.Clear();
                    StudentList.Items.Clear();

                    using (StreamReader reader = new StreamReader(await file.OpenStreamForReadAsync()))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split(',');
                            if (parts.Length == 5)
                            {
                                var student = new Student(parts[0], parts[1], parts[2], parts[3], parts[4]);
                                students.Add(student);
                                StudentList.Items.Add(student.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await ShowMessageAsync("Load Error", ex.Message);
            }
        }

        private async Task ShowMessageAsync(string title, string content)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
        }
    }
}
