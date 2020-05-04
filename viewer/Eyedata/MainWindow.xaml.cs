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

namespace Eyedata
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
        private string SamplePath { get; set; } = "";

        private void log(object text)
        {
            //Console.WriteLine(text);
            //Txt_conversion.Text += text.ToString();
        }

        private double GetTraceTime(string line)
        {
            double result = -1;
            int start = line.IndexOf("time=")+6;
            int end = line.IndexOf("Class=") - 2;
            log(line);
            log(start);
            log(end);
            string time = line.Substring(start, end - start);
            log(time);
            result = Convert.ToSingle(time)*1000;
            return result;
        }

        private int GetScroll(string line)
        {
            int result = -1;
            int start = line.IndexOf("scroll=") + 8;
            int end = line.IndexOf("height=") - 2;
            string time = line.Substring(start, end - start);
            result = (int)double.Parse(time,System.Globalization.CultureInfo.InvariantCulture) * 1000;
            return result;
        }

        private List<double> GetEyeData(string path)
        {
            List<double> result = new List<double>();
            string pre = System.IO.File.ReadAllText(path);
            string[] lines = System.IO.File.ReadAllLines(path);
            for(int x = 0; x < lines.Length; x++)
            {
                result.Add(double.Parse(lines[x], System.Globalization.CultureInfo.InvariantCulture));
            }
            return result;
        }

        List<double> x_values;
        List<double> y_values;
        List<double> time_values;
        List<double> tracetime_values = new List<double>();
        List<double> scroll_values = new List<double>();
        List<string> trace_lines;
        List<string> final_trace = new List<string>();

        private List<string> ArrayToList(string[] input)
        {
            List<string> output = new List<string>();
            for (int x = 0; x < input.Length; x++)
            {
                output.Add(input[x]);
            }
            return output;
        }


       private string ReplaceInField(string source, string start, string end, object value)
        {
            string result;
            int begin = source.IndexOf(start) + start.Length+1;
            int last = source.IndexOf(end) - 3;
            string pre = source.Substring(0, begin);
            string pos = source.Substring(last+1, source.Length-(last+1));
            result = pre + value.ToString() + pos;
            return result;
        }

        private string LineForge(string line, double time, double x, double y)
        {
            string newline = ReplaceInField(line,"time=","Class=",Math.Round((time/1000),4));
            newline = ReplaceInField(newline, "X=", "Y=", x);
            newline = ReplaceInField(newline, "Y=", "keys=", y+GetScroll(line));
            return newline;
        }

        private void Cmd_start_Click(object sender, RoutedEventArgs e)
        {
            SamplePath = Txt_path.Text;
            Cmd_start.IsEnabled = false;

            trace_lines = ArrayToList(System.IO.File.ReadAllLines(SamplePath + "\\trace.xml"));

            #region nomore
            //x_values = GetEyeData(SamplePath + "\\traceX.txt");
            //y_values = GetEyeData(SamplePath + "\\traceY.txt");
            //time_values = GetEyeData(SamplePath + "\\traceTime.txt");

            //#region Get tracetime_values
            //for(int x = 0; x < trace_lines.Count; x++)
            //{
            //    tracetime_values.Add(GetTraceTime(trace_lines[x]));
            //    scroll_values.Add(GetScroll(trace_lines[x]));
            //}
            //#endregion

            //#region clean lists

            //for(int x= 0; x < x_values.Count; x++)
            //{
            //    if(x_values[x]<0 || y_values[x] < 0)
            //    {
            //        x_values.RemoveAt(x);
            //        y_values.RemoveAt(x);
            //        time_values.RemoveAt(x);
            //        x--;
            //    }
            //}
            //#endregion

            //#region get start
            //int start = 0;
            //while (time_values[0] > tracetime_values[start])
            //{
            //    start++;
            //}
            //#endregion
            //start--;
            //#region get end
            //int end = tracetime_values.Count-1;
            //while (time_values[time_values.Count-1] < tracetime_values[end])
            //{
            //    if (end == 0)
            //        break;
            //    end--;
            //}
            //#endregion

            //#region remove blind traces

            //while (tracetime_values.Count > end)
            //{
            //    trace_lines.RemoveAt(end);
            //    tracetime_values.RemoveAt(end);
            //}

            //for(int x = 0; x < start; x++)
            //{
            //    trace_lines.RemoveAt(0);
            //    tracetime_values.RemoveAt(0);
            //}

            //#endregion

            //#region Create New Lines
            ////for runs in each line
            ////contains a for that add a eyeline while eyetime is minor than next tracetime
            //int y = 0;
            //int size = time_values.Count;
            //for (int x = 0; x < tracetime_values.Count; x++)
            //{
            //    log("line " + (x + 1) + "/" + tracetime_values.Count);
            //    double comp = double.MaxValue;
            //    if (x != tracetime_values.Count - 1)
            //    {
            //        comp = tracetime_values[x + 1];
            //    }

            //    try
            //    {
            //        while (time_values[y] < comp)
            //        {
            //            log("eye " + (y+1) + "/"+size);
            //            final_trace.Add(LineForge(trace_lines[x], time_values[y], x_values[y], y_values[y]));
            //            if (y < time_values.Count-1)
            //            {
            //                y++;
            //            }
            //            else { break; }
            //        }
            //    }
            //    catch
            //    {
            //        //Console.WriteLine("FALHOU.");
            //        //Console.WriteLine("time_values.Count " + time_values.Count);
            //        //Console.WriteLine("y " + y);
            //        return;

            //    }
            //}

            //#endregion

            //#region save new tracefile

            //System.IO.File.Move(SamplePath + "\\trace.xml", SamplePath + "\\trace.xml.bak");

            //string newFile = "";
            #endregion
            string newFile = "";
            foreach (string line in trace_lines)
            {
                if(line.IndexOf("type=\"eye\"")>-1)
                    newFile += line+"\n";
            }
            System.IO.File.WriteAllText(SamplePath + "\\trace.xml",newFile);
            Txt_conversion.Text = "DONE!";
            // V get first time of eyedata
            // V if theres no equal on trace, get next trace time, and cut on eyedata.
            // V in the end, get last time of eyedata.
            // V if theres no equal on trace, get previous trace time, and cut on eyedata.
            // V REPLACE X AND Y
            //ADD NEW LINES TO TRACE IF THERE IS MANY EYE DATA TO TRACE FILE
            //SAVE AS NEW TRACE FILE
        }

        private void Cmd_browse_Click(object sender, RoutedEventArgs e)
        {
            //SELECT_FOLDER
            using (var fbd = new FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    SamplePath = fbd.SelectedPath;
                    //IF_SELECTED_ENABLE_START
                    Cmd_start.IsEnabled = true;
                    Txt_path.Text = SamplePath;
                }
            }
        }
    }
}
