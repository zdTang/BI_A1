/*===============================================================
 * File: Forml.cs
 * Project:  BI_A1
 * Programmer: Zhendong Tang
 * First Version: Jan 24, 2021 
 * Description: this project will demo how to use chart control
 ===============================================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BI_A1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            List<DataModel> Data = new List<DataModel>();
            
            Data.Add(new DataModel("Mike", 20));
            Data.Add(new DataModel("Peter", 10));
            Data.Add(new DataModel("Rose", 4));
            Data.Add(new DataModel("Russ", 8));
            Data.Add(new DataModel("Jerry", 2));
            Data.Add(new DataModel("John", 6));

            this.dataGridView1.DataSource = Data;         // initiate data for data grid view
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataModel> newList=new List<DataModel>();
            // collect data from data grid view and add into a List
            for (int i=0; i < dataGridView1.Rows.Count; i++)
            {

                 string a = dataGridView1.Rows[i].Cells[0].Value.ToString();
                 int b = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                 newList.Add(new DataModel(a,b));

            }
            draw(newList);         // draw chart based on data of grid view
        }
        /*========================================================================
         * Function: draw
         * Description: this function will draw chart based on given data collection
         * Parameters: List<DataModel> list: a data source for drawing a chart
         * Return: None
         ==========================================================================*/
        public void draw(List<DataModel> list)
        {
            chart1.Series.Clear();                                // Clear old chart
            chart1.Titles.Clear();                                // Clear old title
            chart1.Titles.Add("Total Output Chart");              // Draw title

            Series barSeries = new Series("Personal output");                 //new a Series
            Series lineSeries = new Series("cumulated percentage");               //new another series   
            barSeries.ChartType = SeriesChartType.Column;         //set chart type as Bar
            lineSeries.ChartType = SeriesChartType.Line;          //Set chart type as Line
            barSeries.IsValueShownAsLabel = true;                 //use Value as Tap
            lineSeries.IsValueShownAsLabel = true;                 //use Value as Tap
            lineSeries.LabelFormat = "0%";                        // setup value display format as percentage
            barSeries.YAxisType = AxisType.Primary;               //Bar use the primary Y axis
            lineSeries.YAxisType = AxisType.Secondary;            //Line use the Secondary Y axis
            lineSeries.MarkerStyle = MarkerStyle.Circle;          //Display the point
            
            chart1.ChartAreas[0].AxisX.Title = "Name";            //Setup Y1 axis title 
            chart1.ChartAreas[0].AxisY.Title = "Personal Output";          //Setup X axis title
            chart1.ChartAreas[0].AxisY2.Title = "Cumulated Percentage";        //Setup Y2 axis's title
            chart1.ChartAreas[0].AxisY2.LabelStyle.Format = "0%"; //Setup Y2 axis's format as %
            chart1.ChartAreas[0].AxisY2.Maximum = 1;              //Setup Y2 axis's maximum value
            chart1.ChartAreas[0].RecalculateAxesScale();          //Setup the chart will recalculate axes scale
            lineSeries.Color = System.Drawing.Color.FromArgb(255, 0, 0);//Setup the Line chart's color as red
            List <DataModel> r = list.OrderByDescending(O => O.Output).ToList();    // resort the List
            
            double sumPartial = 0;                                                   // partial cumulated value for line chart
            double sum = r.Sum(s => s.Output);                                       // Summary output
 
            // here to add value of List into Points
            for (int i = 0; i < r.Count; i++)
            {
                sumPartial += r[i].Output;
                double ratio = sumPartial / sum;                                     // ratio of partial cumulated output           
                barSeries.Points.AddXY(r[i].Name, r[i].Output);                      // Setup Points value for Bar chart
                lineSeries.Points.AddXY(r[i].Name, ratio);                           // Setup Points value for Line chart
            }
            
            // Add two series onto the chart
            chart1.Series.Add(barSeries);
            chart1.Series.Add(lineSeries);  

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
