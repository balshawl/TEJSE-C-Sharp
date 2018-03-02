using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SaveFile f;
        private Boolean changed = false;
        private String title = "Italian Job Save Editor";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }



        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            Close();


        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "res_data.dat"; // Default file name
            dlg.DefaultExt = ".dat"; // Default file extension
            dlg.Filter = "Text documents|*.dat"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                mainEditor.IsEnabled = true;
                all.IsEnabled = true;
                f = new SaveFile(filename);
                SetTicked();
                if (allChecked())
                {
                    setAllChecked(true);

                }
                
            }
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void change() {
            changed = true;
            Saver.IsEnabled = true;
            this.Title = title + "*";
        }

        private void SetTicked()
        {
            Boolean[] IJSet = f.isIJMissionsSet();
            if (IJSet[0] == true)
            {
                ijlondon.IsChecked = true;
            }
            if (IJSet[1] == true)
            {
                ijturin.IsChecked = true;
            }
            if (IJSet[2] == true)
            {
                ijalps.IsChecked = true;
            }
            Boolean[] DSet = f.isDMissionsSet();
            if (DSet[0] == true)
            {
                dlondon.IsChecked = true;
            }
            if (DSet[1] == true)
            {
                dturin.IsChecked = true;
            }
            Boolean[] CSet = f.isCMissionsSet();
            if (CSet[0] == true)
            {
                clondon.IsChecked = true;
            }
            if (CSet[1] == true)
            {
                cturin.IsChecked = true;
            }
            

            Boolean[] ChallengeSet = f.isChallengeMissionsSet();
            if (ChallengeSet[0] == true)
            {
                challenges.IsChecked = true;
            }
            //setAllChecked();
        }

        private void Challenges(object sender, RoutedEventArgs e)
        {


            bool b;
            if (((CheckBox)e.Source).IsChecked == true)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            if (e.Source.Equals(challenges))
            {
                f.setChallengeMissions(b, 0);
            }
        }

        private void Checkpoint(object sender, RoutedEventArgs e)
        {


            bool b;
            if (((CheckBox)e.Source).IsChecked == true)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            if (e.Source.Equals(clondon))
            {
                f.setCheckpointMissions(b, 0);

            }
            else if (e.Source.Equals(cturin))
            {
                f.setCheckpointMissions(b, 1);

            }
        }

        private void Destructor(object sender, RoutedEventArgs e)
        {

            bool b;
            if (((CheckBox)sender).IsChecked == true)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            if (sender.Equals(dlondon))
            {
                f.setDestructorMissions(b, 0);

            }
            else if (sender.Equals(dturin))
            {
                f.setDestructorMissions(b, 1);

            }

        }

        private void ItalianJob(object sender, RoutedEventArgs e)
        {

            bool b;
            if (((CheckBox)sender).IsChecked == true)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            if (sender.Equals(ijlondon))
            {
                f.setIJMissions(b, 0);

            }
            else if (sender.Equals(ijturin))
            {
                f.setIJMissions(b, 1);

            }
            else if (sender.Equals(ijalps))
            {
                f.setIJMissions(b, 2);
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }


        private Boolean allChecked()
        {
            Boolean isChecked = true;
            foreach (CheckBox tb in FindVisualChildren<CheckBox>(this))
            {
                if (tb.IsChecked == false && !tb.Name.Equals("all"))
                {
                    isChecked = false;
                    break;

                }
            }
            return isChecked;
        }

        private void setAllChecked (Boolean set){
            if(set == true)
            {
                foreach (GroupBox tb in FindVisualChildren<GroupBox>(mainEditor))
                {
                    
                    tb.IsEnabled = false;
                    
                }
                foreach (CheckBox tb in FindVisualChildren<CheckBox>(mainEditor))
                {
                    tb.IsChecked = true;

                }

                all.IsChecked = true;

            }
            else
            {
                foreach (GroupBox tb in FindVisualChildren<GroupBox>(mainEditor))
                {

                    tb.IsEnabled = true;

                }
                foreach (CheckBox tb in FindVisualChildren<CheckBox>(mainEditor))
                {
                    tb.IsChecked = false;

                }

                all.IsChecked = false;
            }
        }

        private void Checkbox_Click(object sender, RoutedEventArgs e)
        {
            change();
            if (!((CheckBox)sender).Name.Equals("all"))
            {
                if (allChecked())
                {
                    setAllChecked(true);
                }
               
            }
            
            

        }


        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            f.Write();
            changed = false;
            Saver.IsEnabled = false;
            this.Title = title;
        }
        private void OnClosing(object sender, CancelEventArgs e)
        {
            
            if (changed == true)
            {
                MessageBoxResult result = MessageBox.Show("Would you like to save changes to the file before exiting?", title, MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        f.Write();
                       
                        break;
                    case MessageBoxResult.No:
                       
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;

                        break;
                }

            }
            else
            {
                

            }
            //Do whatever you want here..
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            bool b;
            if (((CheckBox)sender).IsChecked == true)
            {
                b = true;
            }
            else
            {
                b = false;
            }

            if(b == true)
            {
                setAllChecked(true);
            }
            else
            {
                setAllChecked(false);
            }
            f.setAll(b,0);

        }
    }

    
}
