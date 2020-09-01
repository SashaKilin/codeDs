using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using System.IO;


namespace just
{
    public partial class Form1 : Form
    {
        public long all_place;
        public long free_place;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                label1.BackColor = Color.Red;
            });

            this.Close();
        }

        Point lastPoint;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label3.Text = Convert.ToString(Environment.OSVersion);
            label7.Text = Convert.ToString(string.Join(", ", Environment.GetLogicalDrives())
                .TrimEnd(',', ' ')
                .Replace("\\", string.Empty));

            DriveInfo[] allDrive = DriveInfo.GetDrives();

            foreach (var d in allDrive)
            {
                if (d.Name == "C:\\")
                {
                    long all_place = d.TotalSize;
                    long free_place = d.TotalFreeSpace;

                    all_place = all_place / 1000000000;
                    free_place = free_place / 1000000000;

                    progressBar1.Maximum = Convert.ToInt32(all_place);
                    progressBar1.Value = Convert.ToInt32(all_place - free_place);
                    label9.Text = Convert.ToString(free_place + " GB / " + all_place) + " GB";
                }
                if (d.Name == "D:\\")
                {
                    long all_place = d.TotalSize;
                    long free_place = d.TotalFreeSpace;

                    all_place = all_place / 1000000000;
                    free_place = free_place / 1000000000;

                    progressBar2.Maximum = Convert.ToInt32(all_place);
                    progressBar2.Value = Convert.ToInt32(all_place - free_place);
                    label12.Text = Convert.ToString(free_place + " GB / " + all_place) + " GB";
                }
            }

            int counttt = 0;
            Process[] allProc = Process.GetProcesses();
            foreach (var i in allProc)
            {
                counttt++;
            }

            label5.Text = Convert.ToString(counttt);

            label14.Text = Environment.MachineName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = Convert.ToString(Environment.OSVersion);
            label7.Text = Convert.ToString(string.Join(", ", Environment.GetLogicalDrives())
                .TrimEnd(',', ' ')
                .Replace("\\", string.Empty));

            DriveInfo[] allDrive = DriveInfo.GetDrives();

            foreach (var d in allDrive)
            {
                if (d.Name == "C:\\")
                {
                    long all_place = d.TotalSize;
                    long free_place = d.TotalFreeSpace;

                    all_place = all_place / 1000000000;
                    free_place = free_place / 1000000000;

                    progressBar1.Maximum = Convert.ToInt32(all_place);
                    progressBar1.Value = Convert.ToInt32(all_place - free_place);
                    label9.Text = Convert.ToString(free_place + " GB / " + all_place) + " GB";
                }
                if (d.Name == "D:\\")
                {
                    long all_place = d.TotalSize;
                    long free_place = d.TotalFreeSpace;

                    all_place = all_place / 1000000000;
                    free_place = free_place / 1000000000;

                    progressBar2.Maximum = Convert.ToInt32(all_place);
                    progressBar2.Value = Convert.ToInt32(all_place - free_place);
                    label12.Text = Convert.ToString(free_place + " GB / " + all_place) + " GB";
                }
            }

            int countt = 0;
            Process[] allProc = Process.GetProcesses();
            foreach (var i in allProc)
            {
                countt++;
            }

            label5.Text = Convert.ToString(countt);

            label14.Text = Environment.MachineName;

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private string end;
        private int count;
        private void label5_Click(object sender, EventArgs e)
        {
            Process[] allProcces = Process.GetProcesses();
            foreach (var i in allProcces)
            {
                end = end + "    " + i;
                count++;
            }

            MessageBox.Show(end + "\n\nВсего " + count + " процессов(а)");

            end = "";
            count = 0;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\");
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Process.Start(@"D:\");
        }
    }
}