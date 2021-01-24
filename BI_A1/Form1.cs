using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BI_A1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //使用List<>泛型集合填充DataGridView  
            List<DataModel> Data = new List<DataModel>();
            DataModel hat = new DataModel("Hathaway",12);
            DataModel peter = new DataModel("Peter",17);
            DataModel dell = new DataModel("Dell", 45);
            DataModel anne = new DataModel("Anne", 40);
            Data.Add(hat);
            Data.Add(peter);
            Data.Add(dell);
            Data.Add(anne);
            this.dataGridView1.DataSource = Data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataModel> newList=new List<DataModel>();
            for (int i=0; i < dataGridView1.Rows.Count; i++)
            {

                    string a = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    int b = Convert.ToInt32(dataGridView1.Rows[0].Cells[1].Value);
                    newList.Add(new DataModel(a,b));

            }
            MessageBox.Show(newList.Count().ToString());
            draw(newList);
        }

        public void draw(List<(int, int)> r)
        {
            chart1.Series.Clear();
            //Clear existed Series
            Series barSeries = new Series("Bar");             //new a Series
            Series lineSeries = new Series("Line");
            barSeries.ChartType = SeriesChartType.Column;
            lineSeries.ChartType = SeriesChartType.Line;  //Set chart type as Bar
            barSeries.IsValueShownAsLabel = true;                  //use Value as Tap

            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 0;    //Set up Grid（这里设成0.5，看得更直观一点）
            ////chart1.ChartAreas[0].AxisX.Maximum = 100;         //设定x轴的最大值
            //chart1.ChartAreas[0].AxisY.Maximum = 100;           //设定y轴的最大值
            //chart1.ChartAreas[0].AxisX.Minimum = 0;             //设定x轴的最小值
            //chart1.ChartAreas[0].AxisY.Minimum = 0;             //设定y轴的最小值
            chart1.ChartAreas[0].AxisY.Interval = 10;             //Setup Y axis interval
            int sum = 0;
            for (int i = 0; i < r.Count; i++)
            {
                sum += r[i].Item2;
                string reasonLable = DataConvert.GetReasonLable(r[i].Item1);
                barSeries.Points.AddXY(reasonLable, r[i].Item2);  //Setup Points value，X and Y 
                lineSeries.Points.AddXY(reasonLable, sum);
            }

            chart1.Series.Add(barSeries);
            chart1.Series.Add(lineSeries);  // Add series onto the chart

        }

    }
}
