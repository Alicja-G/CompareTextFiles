using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ComparingStringsWPF
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

        private void btnLoadFirstFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                lblFirstFile.Content = openFileDialog.FileName;

           
            }
        }

        private void btnLoadSecondFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                lblSecondFile.Content = openFileDialog.FileName;

            }
        }

        private void btnCompareFiles_Click(object sender, RoutedEventArgs e)
        {
            #region loading files

            if (lblFirstFile.Content.ToString() != "ścieżka pliku 1" && lblSecondFile.Content.ToString() != "ścieżka pliku 2")
            {
                string firstFilePath = lblFirstFile.Content.ToString();
                string secondFilePath = lblSecondFile.Content.ToString();


                FileRead firstFile = new FileRead();
                firstFile.ListOfLines = File.ReadAllLines(firstFilePath).ToList();
                List<string> firstFileListOfStrings = firstFile.ListOfLines;


                FileRead secondFile = new FileRead();
                secondFile.ListOfLines = File.ReadAllLines(secondFilePath).ToList();
                List<string> secondFileListOfStrings = secondFile.ListOfLines;


                #endregion




                int numberOfLinesInTheFirstFile = firstFile.ListOfLines.Count;
                int numberOfLinesIntheSecondFile = secondFile.ListOfLines.Count;

                List<string> listOfResults = new List<string>();

                if (numberOfLinesInTheFirstFile >= numberOfLinesIntheSecondFile)
                {

                    for (int i = 0; i < numberOfLinesInTheFirstFile; i++)
                    {



                        #region if lines are the same
                        if (firstFileListOfStrings[i].Equals(secondFileListOfStrings[i]))
                        {
                            listOfResults.Add("Linia " + (i + 1) + " jest taka sama w obydwu plikach");
                        }
                        #endregion
                        #region if line is empty
                        else if (firstFileListOfStrings[i].Length == 0 && secondFileListOfStrings[i].Length != 0)
                        {
                            listOfResults.Add("Linia " + (i + 1) + " w pliku 1 jest pusta, a w pliku 2 nie.");
                        }
                        else if (firstFileListOfStrings[i].Length != 0 && secondFileListOfStrings[i].Length == 0)
                        {
                            listOfResults.Add("Linia " + (i + 1) + " w pliku 2 jest pusta, a w pliku 1 nie.");
                        }
                        #endregion
                        #region if one line is the same but with only upper letters
                        else if (firstFileListOfStrings[i].ToUpper().Equals(secondFileListOfStrings[i]))
                        {
                            listOfResults.Add("Linia " + (i + 1) + " zawiera ten sam ciąg znaków, ale w pliku 2 jest zapisany wielkimi literami. ");
                        }
                        else if (secondFileListOfStrings[i].ToUpper().Equals(firstFileListOfStrings[i]))
                        {
                            listOfResults.Add("Linia " + (i + 1) + " zawiera ten sam ciąg znaków, ale w pliku 1 jest zapisany wielkimi literami. ");
                        }
                        #endregion
                        #region same lines but different size of letters
                        else if (firstFileListOfStrings[i].ToUpper().Equals(secondFileListOfStrings[i].ToUpper()))
                        {
                            listOfResults.Add("Linia " + (i + 1) + " zawiera ten sam ciąg znaków w obydwu plikach, ale zapisany literami o różnej wielkości.");
                        }
                        #endregion
                        #region lines are different
                        else
                        {
                            listOfResults.Add("Linia " + (i + 1) + " zawiera różne znaki w obydwu plikach, których różnice nie pasują do jednego ze schematów.");
                        }
                        #endregion

                    }
                }

                else
                {
                    for (int i = 0; i < numberOfLinesIntheSecondFile; i++)
                    {

                        #region if lines are the same
                        if (firstFileListOfStrings[i].Equals(secondFileListOfStrings[i]))
                        {
                            listOfResults.Add("Linia " + (i + 1) + " jest taka sama w obydwu plikach");
                        }
                        #endregion
                        #region if line is empty
                        else if (firstFileListOfStrings[i].Length == 0 && secondFileListOfStrings[i].Length != 0)
                        {
                            listOfResults.Add("Linia " + (i + 1) + " w pliku 1 jest pusta, a w pliku 2 nie.");
                        }
                        else if (firstFileListOfStrings[i].Length != 0 && secondFileListOfStrings[i].Length == 0)
                        {
                            listOfResults.Add("Linia " + (i + 1) + " w pliku 2 jest pusta, a w pliku 1 nie.");
                        }
                        #endregion
                        #region if one line is the same but with only upper letters
                        else if (firstFileListOfStrings[i].ToUpper().Equals(secondFileListOfStrings[i]))
                        {
                            listOfResults.Add("Linia " + (i + 1) + " zawiera ten sam ciąg znaków, ale w pliku 2 jest zapisany wielkimi literami. ");
                        }
                        else if (secondFileListOfStrings[i].ToUpper().Equals(firstFileListOfStrings[i]))
                        {
                            listOfResults.Add("Linia " + (i + 1) + " zawiera ten sam ciąg znaków, ale w pliku 1 jest zapisany wielkimi literami. ");
                        }
                        #endregion
                        #region same lines but different size of letters
                        else if (firstFileListOfStrings[i].ToUpper().Equals(secondFileListOfStrings[i].ToUpper()))
                        {
                            listOfResults.Add("Linia " + (i + 1) + " zawiera ten sam ciąg znaków w obydwu plikach, ale zapisany literami o różnej wielkości.");
                        }
                        #endregion

                        #region lines are different
                        else
                        {
                            listOfResults.Add("Linia " + (i + 1) + " zawiera różne znaki w obydwu plikach, których różnice nie pasują do jednego ze schematów.");
                        }
                        #endregion
                    }
                }


                txtboxComparingResults.Text = String.Join(Environment.NewLine, listOfResults);
            }
            else
            {
                MessageBox.Show("Wybierz pliki.");
            }
        }

        
    }
}
