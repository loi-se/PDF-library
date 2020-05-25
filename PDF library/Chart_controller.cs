using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Windows.Forms.Calendar;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Collections;

namespace PDF_library
{
    class Chart_controller
    {

        public Chart Chart1;
        public string PixelPointWidth = "8";

        // Determines the interval when a scrollbar is active in a chart! With a value of 20 all labels are readable.
        public int _blockSize = 30;



        public Chart Plot_String_Int(int _width, int _height, Dictionary<string, int> _Collection, Dictionary<string, string> _ChartTexts)
        {

            try
            {

                // yearmonth = year_month_Between(startdate, enddate);
               // yearmonth.Reverse();
                //

                // First get unique project names in Agenda:

                string Chartarea1_AxisY_Title = _ChartTexts["AxisY_Title"];
                Chart1 = new Chart();
                int blockSize = _blockSize;


                ChartArea Chartarea1 = new ChartArea();

                DataPoint dp = default(DataPoint);
                Font chartfont = new Font("Arial Bold", 12, FontStyle.Bold);

                Chart1.Name = "Chart1";
                int chartwidth = _width - 100;
                int chartheight = _height - 100;
                int offsetX = 10;
                int offsetY = 10;


                Chartarea1_AxisY_Title = _ChartTexts["AxisY_Title"];
                //Chart1.Titles.Add("Income per client from " + startdate.ToString() + " to " + enddate.ToString());
                Chartarea1.AxisY.TitleFont = chartfont;
                Chartarea1.AxisY.TitleAlignment = StringAlignment.Center;


                Chartarea1.AxisY.Title = _ChartTexts["AxisY_Title"];
                Chart1.Titles.Add(_ChartTexts["title"]);

                //------------------------------------------------------------------


                Chartarea1.AxisY.MinorGrid.Enabled = true;
                //chartArea1.AxisY.MajorGrid.Enabled = Tru
                Chartarea1.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

                Chartarea1.AxisX.TitleFont = chartfont;
                Chartarea1.AxisX.TitleAlignment = StringAlignment.Center;
                Chartarea1.AxisX.Title = _ChartTexts["AxisX_Title"]; 
                Chartarea1.AxisX.TextOrientation = TextOrientation.Horizontal;
                Chartarea1.AxisX.MajorGrid.Enabled = true;
                //Chartarea1.AxisX.IntervalType = IntervalAutoMode.FixedCount

                //Chartarea1.AxisX.IsLabelAutoFit = True
                //Chartarea1.AxisX.IntervalOffsetType = IntervalAutoMode.VariableCount

                //Chartarea1.AxisX.LabelStyle.IntervalType = IntervalAutoMode.VariableCount

                Chartarea1.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;


                Chart1.ChartAreas.Add(Chartarea1);
                //Chart1.ChartAreas("ChartArea1").AxisX.ScrollBar.Size = 10
                Chart1.Legends.Add(new Legend("Second"));

                Series series1 = new Series();
                series1.Name = "Agenda_items";


                int i = 0;

                foreach (KeyValuePair<string, int> writernofbooks in _Collection)
                {
      
                    dp = new DataPoint();
                    dp.Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Regular);

             
                    dp.Label = writernofbooks.Value.ToString();
                              
                    dp.SetValueXY(i, writernofbooks.Value);
                    dp.AxisLabel = writernofbooks.Key.ToString(); ;
                    //dp.Label = totalincome.ToString();
                    //dp.Label = "€" + totalincome.ToString();
                    //dp.Label = "€" + totalincome.ToString();
                    dp.LabelAngle = -90;
                    dp.LegendText = writernofbooks.Key.ToString();

                    series1.Points.Add(dp);
                    i = i + 1;
                    // do stuff with your Model / Style objects here...

                }

                Chart1.Series.Add(series1);
                Chart1.Series[series1.Name].ChartType = SeriesChartType.Column;
                Chart1.Series[series1.Name].SmartLabelStyle.Enabled = true;
                Chart1.Series[series1.Name].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Partial;
                Chart1.Series[series1.Name]["PieLabelStyle"] = "Outside";
                Chart1.Series[series1.Name]["PieLineColor"] = "Black";

                //Chart1.Series[series1.Name].SmartLabelStyle = LabelCalloutStyle.

                Chart1.Series[series1.Name].SmartLabelStyle.CalloutLineColor = Color.Red;
                Chart1.Series[series1.Name].SmartLabelStyle.CalloutLineWidth = 2;
                Chart1.Series[series1.Name].SmartLabelStyle.CalloutStyle = LabelCalloutStyle.Box;
                Chart1.Series[series1.Name].LegendText = _ChartTexts["LegendText"];
                Chart1.Series[series1.Name].Legend = "Second";
                Chart1.Series[series1.Name].BorderWidth = 2;
                // Chart1.Series[series1.Name]["PixelPointWidth"] = PixelPointWidth;

                Chart1.Series[series1.Name].IsXValueIndexed = true;



                Chart1.Size = new System.Drawing.Size(chartwidth, chartheight);

                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;

                //Chart1 = _MyGraph.plot_graphs(_selectedgraphs, _xmin, _xmax, Xaxistext, Yaxistext.ToString, _ymax, _ymin);
                //    //Bcalculate.Enabled = true;

                //Chart1 = _MyGraph.Plot_derivative_graph(_selectedgraphs, _xmin, _xmax, Xaxistext, Yaxistext, _ymax, _ymin);

                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                Chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = false;
                Chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoomable = false;


                //--------------------------------------------------------------------------------------------------scrollbar
                Chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
                Chart1.ChartAreas["ChartArea1"].AxisX.Maximum = _Collection.Count() + 1;

                // enable autoscroll
                Chart1.ChartAreas["ChartArea1"].CursorX.AutoScroll = true;

                // let's zoom to [0,blockSize] (e.g. [0,100])
                //Chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
                Chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
                int position = 0;
                int size = blockSize;
                Chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoom(position, size);

                //Chart1.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = true;
                //Chart1.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;
                //Chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
                //Chart1.ChartAreas["ChartArea1"].AxisX.ScrollBar.IsPositionedInside = true;


                // disable zoom-reset button (only scrollbar's arrows are available)
                Chart1.ChartAreas["ChartArea1"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

                // set scrollbar small change to blockSize (e.g. 100)
                Chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.SmallScrollSize = blockSize;
                //----------------------------------------------------------------------------------------------scrollbar

                Chart1.ChartAreas["ChartArea1"].CursorX.AutoScroll = true;
                Chart1.ChartAreas["ChartArea1"].CursorY.AutoScroll = true;


                Chart1.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;

                Chart1.ChartAreas["ChartArea1"].CursorX.Interval = 0.01;
                Chart1.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = true;
                Chart1.ChartAreas["ChartArea1"].CursorY.Interval = 0.01;

                Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                Chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = false;
                Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                Chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = false;

                Chart1.ChartAreas["ChartArea1"].AxisX.ScrollBar.IsPositionedInside = true;
                //Chart1.ChartAreas("ChartArea1").AxisX.ScrollBar.Enabled = False
                Chart1.ChartAreas["ChartArea1"].AxisY.ScrollBar.IsPositionedInside = true;
                //Chart1.ChartAreas["ChartArea1"].AxisX.IsMarksNextToAxis = false;

                //Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -90;
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 10;





                //Chart1.Size = AutoSize
                Chart1.Location = new Point(offsetX, offsetY);
                Chart1.Dock = DockStyle.Fill;
            }
            catch (Exception e2)
            {
                MessageBox.Show("An error occurred: '{0}':  " + e2);
            }

            return Chart1;
            
        }

    }
}
