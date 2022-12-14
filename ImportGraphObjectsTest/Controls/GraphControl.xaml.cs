using ImportGraphObjectsTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ImportGraphObjectsTest.Controls
{
    /// <summary>
    /// Interaction logic for PraghControl.xaml
    /// </summary>
    public partial class GraphControl : UserControl
    {
        public double FrameHeight => 12;
        public double FrameWidth => 20;

        const double BORDER_SIZE_HEIGHT = 45;
        const int LIMIT_DRAW_OBJECTS = 500;
        private double m_sizeFactor = 1;
        private Window m_parentWindow;
        
        public GraphControl()
        {
            InitializeComponent();

            CompositionTarget.Rendering += RenderFrame;

            Loaded += (s, e) =>
            {
                m_parentWindow = Window.GetWindow(this);
                CalculateSizeFactor(CanvasDraw.ActualWidth);
            };
        }

        public ObjectsCollection ObjectsDraw
        {
            get { return (ObjectsCollection)GetValue(PlacementProperty); }
            set { SetValue(PlacementProperty, value); }
        }

        public static readonly DependencyProperty PlacementProperty =
            DependencyProperty.Register("ObjectsDraw", typeof(ObjectsCollection), typeof(GraphControl));

        private void RenderFrame(object sender, EventArgs e)
        {
            CrearDraw();
            DrawBorder();
            DrawGrid();

            if (ObjectsDraw == null || !ObjectsDraw.Any())
                return;

            double x = 0;
            double y = 0;
            double width = 0;
            double height = 0;
            SolidColorBrush color;
            SolidColorBrush colorBorder;

            int count = 0;
            
            foreach (var obj in ObjectsDraw)
            {
                if (count > LIMIT_DRAW_OBJECTS)
                    return;

                x = obj.Distance;
                y = FrameHeight - obj.Angle;
                width = obj.Width;
                height = obj.Hegth;

                if (obj.IsSelected)
                {
                    color = Brushes.Yellow;
                    colorBorder = Brushes.OrangeRed;
                }
                else
                {
                    color = Brushes.LimeGreen;
                    colorBorder = Brushes.Black;
                }

                DrawRect(x, y, width, height, color, colorBorder);
                count++;
            }
        }

        private void DrawRect(double x, double y, double width, double height, SolidColorBrush color, SolidColorBrush colorBorder, int strokeThickness = 1)
        {
            x *= m_sizeFactor;
            y *= m_sizeFactor;
            width *= m_sizeFactor;
            height *= m_sizeFactor;

            RectangleGeometry rectangleGeometry = new RectangleGeometry();
            rectangleGeometry.Rect = new Rect(x, y, width, height);

            Path objDraw = new Path();
            objDraw.Fill = color;
            objDraw.Stroke = colorBorder;
            objDraw.StrokeThickness = strokeThickness;
            objDraw.Data = rectangleGeometry;
            objDraw.SnapsToDevicePixels = true;
            objDraw.UseLayoutRounding = true;

            CanvasDraw.Children.Add(objDraw);
        }

        private void DrawBorder()
        {
            DrawRect(0, 0, FrameWidth, FrameHeight, Brushes.LightBlue, Brushes.Black, 2);
        }

        private void DrawGrid()
        {
            SolidColorBrush color = Brushes.DarkGray;
            foreach (var x in Enumerable.Range(1, (int)FrameWidth))
                DrawLine(x, 0, x, FrameHeight, color, 1);

            foreach (var y in Enumerable.Range(1, (int)FrameHeight))
                DrawLine(0, y, FrameWidth, y, color, 1);
        }

        private void DrawLine(double x, double y, double x2, double y2, SolidColorBrush color, int strokeThickness = 1)
        {
            x *= m_sizeFactor;
            y *= m_sizeFactor;
            x2 *= m_sizeFactor;
            y2 *= m_sizeFactor;

            LineGeometry lineGeometry = new LineGeometry();
            lineGeometry.StartPoint = new Point(x, y);
            lineGeometry.EndPoint = new Point(x2, y2);

            Path objDraw = new Path();
            objDraw.Stroke = color;
            objDraw.StrokeThickness = strokeThickness;
            objDraw.Data = lineGeometry;

            CanvasDraw.Children.Add(objDraw);
        }

        private void CrearDraw()
        {
            CanvasDraw.Children.Clear();
        }

        private void CanvasDraw_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CalculateSizeFactor(e.NewSize.Width);
        }

        private void CalculateSizeFactor(double widthCanvas)
        {
            var heightLimit = HeightLimit();
            var sizeFactor = widthCanvas / (FrameWidth);
            if (sizeFactor * FrameHeight > heightLimit)
                sizeFactor = heightLimit / (FrameHeight);

            m_sizeFactor = sizeFactor < 1 ? 1 : sizeFactor;
        }

        private double HeightLimit()
        {
            if (m_parentWindow == null)
                return FrameHeight;
            Point point = this.TransformToAncestor(m_parentWindow).Transform(new Point(0, 0));
            return m_parentWindow.ActualHeight - (point.Y + BORDER_SIZE_HEIGHT);
        }
    }
}
