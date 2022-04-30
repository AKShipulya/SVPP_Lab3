using Microsoft.Win32;
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

namespace Project1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Driver driver = new Driver();
        public MainWindow()
        {
            InitializeComponent();
            //foreach(COLOR_EYES color in Enum.GetValues(typeof(COLOR_EYES)))
            //{
            //    comboBoxEyes.Items.Add(color);
            //}
        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files|*.jpg|PNG Files|*.png|All files|*.*";
            if(dialog.ShowDialog() == true)
            {
                driver.UriImage = dialog.FileName;
                image.Source = new BitmapImage(new Uri(driver.UriImage));
            }
        }
 
        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {

            driver.Name = "Daenerys Targaryen";
            driver.Clazz = 'A';
            driver.Address = "Dragonstone";
            driver.Number = 9847282;
            driver.Hgt = 168;
            driver.Gender = GENDER.female;
            radioButtonFemale.IsChecked = true;
            driver.ColoredEyes = COLOR_EYES.green;
            comboBoxEyes.SelectedItem = driver.ColoredEyes;
            driver.Dob = new DateTime(1992, 03, 13);
            datePickerDOB.SelectedDate = driver.Dob;
            driver.Iss = new DateTime(2015, 01, 22);
            datePickerISS.SelectedDate = driver.Iss;
            driver.Exp = new DateTime(2035, 01, 21);
            datePickerEXP.SelectedDate = driver.Exp;
            driver.Donor = false;
            checkBoxDonor.IsChecked = false;
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = System.IO.Path.Combine(sCurrentDirectory, @"..\..\Images\Daenerys.jpg");
            string filePath = System.IO.Path.GetFullPath(fullPath);
            driver.UriImage = filePath;
            image.Source = new BitmapImage(new Uri(driver.UriImage));
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            //int a;
            //Int32.TryParse(textBoxNumber.Text, out a);
            //driver.Number = a;
            //if (textBoxClass.Text.Length > 0)
            //{
            //    driver.Clazz = textBoxClass.Text[0];
            //}
            //else
            //{
            //    driver.Clazz = '-';
            //}
            //driver.Name = textBoxName.Text;
            //driver.Address = textBoxAddress.Text;
            //if (datePickerDOB.SelectedDate == null || datePickerDOB.SelectedDate.Value == DateTime.Now)
            //{
            //    driver.Dob = DateTime.Now;
            //}
            //else
            //{
            //    driver.Dob = (DateTime)(datePickerDOB.SelectedDate);
            //}
            //if (datePickerISS.SelectedDate == null || datePickerISS.SelectedDate.Value == DateTime.Now)
            //{
            //    driver.Iss = DateTime.Now;
            //}
            //else
            //{
            //    driver.Iss = (DateTime)(datePickerISS.SelectedDate);
            //}
            //if (datePickerEXP.SelectedDate == null || datePickerEXP.SelectedDate.Value == DateTime.Now)
            //{
            //    driver.Exp = DateTime.Now;
            //}
            //else
            //{
            //    driver.Exp = (DateTime)(datePickerEXP.SelectedDate);
            //}
            //driver.Gender = Driver.GENDER.variant;
            //if(radioButtonFemale.IsChecked == true)
            //{
            //    driver.Gender = Driver.GENDER.female;
            //}
            //else if(radioButtonMale.IsChecked == true)
            //{
            //    driver.Gender = Driver.GENDER.male;
            //}
            //if(comboBoxEyes.SelectedIndex > -1)
            //{
            //    driver.ColoredEyes = (Driver.COLOR_EYES)comboBoxEyes.SelectedItem;
            //}
            //driver.Hgt = sliderHGT.Value;
            //driver.Donor = (bool)checkBoxDonor.IsChecked;

            MessageBox.Show(driver.ToString());
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxName.Clear();
            textBoxAddress.Clear();
            textBoxNumber.Clear();
            textBoxClass.Clear();
            datePickerDOB.SelectedDate = null;
            datePickerISS.SelectedDate = null;
            datePickerEXP.SelectedDate = null;
            radioButtonFemale.IsChecked = false;
            radioButtonMale.IsChecked = false;
            radioButtonVariant.IsChecked = false;
            comboBoxEyes.SelectedIndex = 0;
            checkBoxDonor.IsChecked = false;
            sliderHGT.Value = 175;
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = System.IO.Path.Combine(sCurrentDirectory, @"..\..\Images\No-Image.png");
            string filePath = System.IO.Path.GetFullPath(fullPath);
            image.Source = new BitmapImage(new Uri(filePath));
        }

        private void newDriver()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = System.IO.Path.Combine(sCurrentDirectory, @"..\..\Images\Snow_photo.jpg");
            string filePath = System.IO.Path.GetFullPath(fullPath);

            driver.Name = "Jon Snow";
            driver.Clazz = 'B';
            driver.Address = "Winterfell";
            driver.Number = 654234098;
            driver.Hgt = 187;
            driver.Gender = GENDER.male;
            driver.ColoredEyes = COLOR_EYES.brown;
            driver.Dob = new DateTime(1989, 02, 22);
            driver.Iss = new DateTime(2018, 03, 14);
            driver.Exp = new DateTime(2038, 03, 13);
            driver.Donor = true;
            driver.UriImage = filePath;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            newDriver();
            grid.DataContext = driver;
        }
    }
}
