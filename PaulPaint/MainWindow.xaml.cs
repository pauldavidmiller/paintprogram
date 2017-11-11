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
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace PaulPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            initializeCanvas();
            m_ColorList.SelectedItem = m_ColorList.Items[0];
            m_ThicknessList.SelectedItem = m_ThicknessList.Items[0];
        }

        public string imageFilePath = "";
        private Point currentPoint;
        private ObservableCollection<Line> lines = new ObservableCollection<Line>();

        public class DisplayedImagePath
        {
            public string imagePath { get; set; }
        }
        DisplayedImagePath myImage;

        //initialize the canvas
        public void initializeCanvas()
        {
            importImage.Source = null;
            paintSurface.UpdateLayout();

            myImage = new DisplayedImagePath() { imagePath = "pack://application:,,,/Images/white.jpg" };
            BitmapImage insertImage = new BitmapImage();
            insertImage.BeginInit();
            insertImage.UriSource = new Uri(myImage.imagePath);
            insertImage.EndInit();
            importImage.Source = insertImage;
        }

        //open or save the image
        public void getFilePath()//getting the image which will be opened
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            System.Windows.Forms.DialogResult result = openFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                imageFilePath = openFileDialog.FileName;

            }
            else
            {

            }

        }
        private void btnOpenImage_Click(object sender, RoutedEventArgs e)
        {
            clearCanvas();
            importImage.Source = null;
            paintSurface.UpdateLayout();
            imageFilePath = "";
            getFilePath();

            if (imageFilePath != "")
            {

                myImage = new DisplayedImagePath() { imagePath = imageFilePath };
                BitmapImage insertImage = new BitmapImage();
                insertImage.BeginInit();
                insertImage.UriSource = new Uri(myImage.imagePath);
                insertImage.EndInit();
                importImage.Source = insertImage;
            }
        }
        private void btnSaveImage_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap rtb;
            if ((int)importImage.RenderSize.Width < (int)paintSurface.RenderSize.Width && (int)importImage.RenderSize.Height < (int)paintSurface.RenderSize.Height)
            {
                rtb = new RenderTargetBitmap((int)importImage.RenderSize.Width, (int)importImage.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            }
            else
            {
                rtb = new RenderTargetBitmap((int)paintSurface.RenderSize.Width, (int)paintSurface.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            }

            rtb.Render(paintSurface);

            //var crop = new CroppedBitmap(rtb, new Int32Rect(0,0,250,250)); use this to crop for an icon

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            SaveFileDialog saveFile = new SaveFileDialog();
            //saveFile.FileName = savefileName.Text.ToString() + ".png";
            //<TextBox Name="savefileName" HorizontalAlignment="Right" VerticalAlignment="Center" Width="100" Height="20" Margin="0,0,70,0"/>
            saveFile.Filter = "Images|*.png;*.bmp;*.jpg";

            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (var fs = System.IO.File.OpenWrite(saveFile.FileName))
                {
                    pngEncoder.Save(fs);
                }
            }


        }
        private void btnClearImage_Click(object sender, RoutedEventArgs e)
        {
            clearCanvas();
        }
        private void clearCanvas()
        {
            for (int i = 0; i < Lines.Count - 1; i++)
            {
                paintSurface.Children.Remove(Lines[i]);
            }
        }

        //pick color and thickness of brush
        SolidColorBrush brush;
        private double brushThickness;

        public ObservableCollection<Line> Lines { get => lines; set => lines = value; }

        private void importImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }
        private void importImage_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();

                line.Stroke = brush;
                line.StrokeThickness = brushThickness;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                currentPoint = e.GetPosition(this);
                Lines.Add(line);

                paintSurface.Children.Add(Lines[Lines.Count - 1]);
            }
        }
        private void ListBoxItem_Selected_Edit(object sender, RoutedEventArgs e)
        {
            brush = new SolidColorBrush(Colors.Transparent);
        }
        private void ListBoxItem_Selected_Black(object sender, RoutedEventArgs e)
        {
            brush = new SolidColorBrush(Colors.Black);
        }
        private void ListBoxItem_Selected_Blue(object sender, RoutedEventArgs e)
        {
            brush = new SolidColorBrush(Colors.Blue);
        }
        private void ListBoxItem_Selected_Red(object sender, RoutedEventArgs e)
        {
            brush = new SolidColorBrush(Colors.Red);
        }
        private void ListBoxItem_Selected_Green(object sender, RoutedEventArgs e)
        {
            brush = new SolidColorBrush(Colors.Green);
        }
        private void ListBoxItem_Selected_Yellow(object sender, RoutedEventArgs e)
        {
            brush = new SolidColorBrush(Colors.Yellow);
        }
        private void ListBoxItem_Selected_Thickness1(object sender, RoutedEventArgs e)
        {
            brushThickness = 1.0;
        }
        private void ListBoxItem_Selected_Thickness2(object sender, RoutedEventArgs e)
        {
            brushThickness = 2.0;
        }
        private void ListBoxItem_Selected_Thickness3(object sender, RoutedEventArgs e)
        {
            brushThickness = 3.0;
        }

    }
}
