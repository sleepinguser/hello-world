using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;

namespace example
{
    public partial class Form1 : Form
    {

        FileSystemWatcher _fileWatcher;
        public Form1()
        {
            InitializeComponent();
            Watcher();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Watcher()
        {
            _fileWatcher = new FileSystemWatcher(@"C:\libra");
            _fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            _fileWatcher.Filter = "temp.txt";
            _fileWatcher.Changed += OnChanged;
            _fileWatcher.EnableRaisingEvents = true;
        }

        public void OnChanged(object source, FileSystemEventArgs e)
        {
            try
            {
                string nomerpath = @"C:\libra\temp.txt";
                string Numbers;
                using (StreamReader sr = new StreamReader(nomerpath))
                {
                    Numbers = sr.ReadLine();
                    MessageBox.Show(Numbers);
                }
                comboBox1.Text = Numbers;
                _fileWatcher.EnableRaisingEvents = false;
            }

            catch (Exception ex)
            {
                _fileWatcher.EnableRaisingEvents = true;
            }
        }
    }
}
