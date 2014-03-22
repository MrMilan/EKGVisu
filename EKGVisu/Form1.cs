using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace EKGVisu
{
    public partial class Form1 : Form
    {
        #region private walues
        private string[] dataFromCSVFile;
        private double senzitivita;
        private double vzorkovaciFrekvence;
        private string[] dataFromTxTFile;
        private string nameRowEKG = "EKG";
        private string nameRowRR = "RR";
        private string nameRowKPeak = "Peak";
        private string nameRorTacho = "Tachogram";
        #endregion

        //Inicializacni cast pro grafy
        public Form1()
        {
            // inicializace grafu
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            chart1.ChartAreas[0].CursorX.AutoScroll = true;
            chart1.ChartAreas[0].CursorY.AutoScroll = true;

            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            chart2.ChartAreas[0].CursorX.AutoScroll = true;
            chart2.ChartAreas[0].CursorY.AutoScroll = true;

            chart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        }

        ///Tlacitko pro nacteni TxT 
        private void btnReadTxT_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ReadDataFromFileTxT(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Pojebalo se to nekde pri nacitani Puvodni error: " + ex.Message);
                }
            }
        }

        ///Tlacitko pro nacteni CSV
        private void btnReadCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ReadDataFromFileCSV(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Pojebalo se to nekde pri nacitani Puvodni error: " + ex.Message);
                }
            }

        }

        /// Tlacitko pro vykresleni dat
        private void Draw_Click(object sender, EventArgs e)
        {
            // foreach (var series in chart1.Series)
            // {
            //     series.Points.Clear();
            // }
            double treshold = 1.5; // je to v mV

            double[] doubleArrayCSV = ConvertToDoubleArray(dataFromCSVFile);
            double[] filtredSignal = Convolution(ConvertToDoubleArray(dataFromCSVFile), ConvertToDoubleArray(ReplaceSeparator(dataFromTxTFile, ".", ",")));
            DrawEKG(doubleArrayCSV, nameRowEKG);
            DrawEKG(filtredSignal, nameRowRR);
            List<double> peaks = NumeratePeaks(filtredSignal, treshold*senzitivita);
            DrawPeak(peaks, nameRowKPeak);
            DrawTacho(peaks, nameRorTacho);
        }

        /// <summary>
        /// Funkce pro nacitani dat ze souboru s koncovkou csv
        /// </summary>
        /// <param name="route">Cesta k souboru</param>
        private void ReadDataFromFileCSV(string route)
        {
            string[] rawDataFromCSVFile = File.ReadAllLines(route);
            senzitivita = Convert.ToDouble(rawDataFromCSVFile[1].Split(',')[1]);
            vzorkovaciFrekvence = Convert.ToDouble(rawDataFromCSVFile[1].Split(',')[0]);
            nameRowEKG += (" from " + rawDataFromCSVFile[0]);
            dataFromCSVFile = rawDataFromCSVFile[2].Split(',');
        }

        /// <summary>
        /// Funkce pro nacitani dat ze souboru s koncovkou txt
        /// </summary>
        /// <param name="route">Cesta k souboru</param>
        private void ReadDataFromFileTxT(string route)
        {
            dataFromTxTFile = System.IO.File.ReadAllLines(route);
        }

        /// <summary>
        /// Pretypovani dat ze stringoveho pole na double pole 
        /// </summary>
        /// <param name="inputStringArray">Vstupni stringove pole</param>
        /// <returns>Vracime double pole</returns>
        private double[] ConvertToDoubleArray(string[] inputStringArray)
        {
            double[] arraysOfDouble = new double[inputStringArray.Length];
            for (int i = 0; i < inputStringArray.Length - 1; i++)
            {
                arraysOfDouble[i] = Convert.ToDouble(inputStringArray[i]);
            }
            return arraysOfDouble;
        }

        /// <summary>
        /// Predelani separatoru pro budouci praci
        /// </summary>
        /// <param name="inputStringArray">Vstupni stringove pole</param>
        /// <param name="oldSeparator">Separator kterz ma byt nahrazen</param>
        /// <param name="newSeparator">Cim ma byt nahrazen</param>
        /// <returns>Vraci pole stringu s novym separatorem</returns>
        private string[] ReplaceSeparator(string[] inputStringArray, string oldSeparator, string newSeparator)
        {
            string[] newArrayWithNewSeparator = new string[inputStringArray.Length];
            for (int i = 0; i < inputStringArray.Length - 1; i++)
            {
                newArrayWithNewSeparator[i] = inputStringArray[i].Replace(oldSeparator, newSeparator);
            }
            return newArrayWithNewSeparator;
        }

        /// <summary>
        /// Vykresli EKG data
        /// </summary>
        /// <param name="ArrayCSV">Vstupni pole double s EKG Daty</param>
        /// <param name="nameLine">Nazev rady</param>
        private void DrawEKG(double[] ArrayCSV, string nameLine)
        {
            chart1.Series.Add(nameLine);
            chart1.Series[nameLine].ChartType = SeriesChartType.FastLine;
            DrawData(ArrayCSV, nameLine);
        }

        ///// <summary>
        ///// Funkce pro vykresleni vyfiltrovaneho signalu
        ///// </summary>
        ///// <param name="inputStringArrayFromTxT">Vstupni pole</param>
        ///// <param name="arrayCSV">Pole double se signalem</param>
        ///// <param name="nameLine">Nazev rady</param>
        //private void DrawKFiltredSignal(string[] inputStringArrayFromTxT, double[] arrayCSV, string nameLine)
        //{
        //    string[] replacedArrayTxT = ReplaceSeparator(inputStringArrayFromTxT, ".", ",");
        //    double[] arrayTxT = ConvertToDoubleArray(replacedArrayTxT);
        //    chart1.Series.Add(nameLine);
        //    chart1.Series[nameLine].ChartType = SeriesChartType.FastLine;
        //    DrawData(convolutedSignalos, nameLine);
        //}

        private void DrawPeak(List<double> peaks, string nameLine)
        {
            chart1.Series.Add(nameLine);
            chart1.Series[nameLine].ChartType = SeriesChartType.Point;
            foreach (int y in peaks)
            {
                chart1.Series[nameLine].Points.AddXY(y/vzorkovaciFrekvence, 10);  
            }          
        }

        private void DrawTacho(List<double> peaks, string nameLine)
        {

            chart2.Series.Add(nameLine);
            chart2.Series[nameLine].ChartType = SeriesChartType.Line;
            List<double> tachogarm = Tachogram(peaks);
            for (int i = 0; i < tachogarm.Count(); i++)
            {
                chart2.Series[nameLine].Points.AddXY(peaks[i]/vzorkovaciFrekvence, tachogarm[i]/vzorkovaciFrekvence*1000);
            }
            

        }

        /// <summary>
        /// Funkce pro vykresleni dat
        /// </summary>
        /// <param name="inputDataArray">Nacita vstupni double pole</param>
        /// <param name="nameLine">Nazev rady</param>
        private void DrawData(double[] inputDataArray, string nameLine)
        {
            for (int i = 0; i < inputDataArray.Length - 1; i++)
            {
                chart1.Series[nameLine].Points.AddXY(i / vzorkovaciFrekvence, inputDataArray[i] / senzitivita);
            }
        }

        private static double[] Convolution(double[] inputSignalDataArray, double[] filterData)
        {
            double[] convolutedSignal = new double[inputSignalDataArray.Length + filterData.Length - 1];

        #region convoluce
            if (inputSignalDataArray.Length >= filterData.Length)
            {
                for (int k = 0; k < inputSignalDataArray.Length + filterData.Length - 1; k++)
                {
                    double pom = 0f;
                    if (k < filterData.Length - 1)
                    {
                        for (int i = 0; i <= k; i++)
                            pom += inputSignalDataArray[k - i] * filterData[i];
                    }
                    else if (k >= filterData.Length - 1 & k <= inputSignalDataArray.Length - 1)
                    {
                        for (int i = 0; i <= filterData.Length - 1; i++)
                            pom += inputSignalDataArray[k - i] * filterData[i];
                    }
                    else if (k > inputSignalDataArray.Length - 1)
                    {
                        for (int i = (k + 1) - inputSignalDataArray.Length; i <= filterData.Length - 1; i++)
                            pom += inputSignalDataArray[k - i] * filterData[i];
                    }
                    convolutedSignal[k] = pom;
                }
            }

            if (inputSignalDataArray.Length < filterData.Length)
            {
                for (int k = 0; k < filterData.Length + inputSignalDataArray.Length - 1; k++)
                {
                    double pom = 0f;
                    if (k < inputSignalDataArray.Length - 1)
                    {
                        for (int i = 0; i <= k; i++)
                            pom += filterData[k - i] * inputSignalDataArray[i];
                    }
                    else if (k >= inputSignalDataArray.Length - 1 & k <= filterData.Length - 1)
                    {
                        for (int i = 0; i <= inputSignalDataArray.Length - 1; i++)
                            pom += filterData[k - i] * inputSignalDataArray[i];
                    }
                    else if (k > filterData.Length - 1)
                    {
                        for (int i = (k + 1) - filterData.Length; i <= inputSignalDataArray.Length - 1; i++)
                            pom += filterData[k - i] * inputSignalDataArray[i];
                    }
                    convolutedSignal[k] = pom;
                }
            }
#endregion

            int pomItera = 0;
            double [] finalConvolutedSignal = new double[inputSignalDataArray.Length];
            for (int i = (int)(filterData.Length/2); i < inputSignalDataArray.Length; i++)
            {
                 finalConvolutedSignal[pomItera]  =  convolutedSignal[i];
                 pomItera++;
            }


            return finalConvolutedSignal;
        }

        public List<double> NumeratePeaks(double[] inputSignalDataArray, double threshold)
        {
            List<double> spice = new List<double>();
            for (int i = 1; i < inputSignalDataArray.Length - 1; i++)
            {
                if (inputSignalDataArray[i] > threshold)
                {
                    if (inputSignalDataArray[i - 1] < inputSignalDataArray[i] && inputSignalDataArray[i] > inputSignalDataArray[i + 1])
                    {
                        spice.Add(i);
                    }
                }
            }
            return spice;
        }

        private static List<double> Tachogram(List<double> peaks)
        {
            List<double> tachogram = new List<double>();
            for (int i = 0; i < peaks.Count()-1; i++)
            {
                tachogram.Add(peaks[i+1] - peaks[i]);
            }
            return tachogram;
        }


    }
}
