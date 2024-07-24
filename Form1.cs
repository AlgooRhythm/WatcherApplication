using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System;
using Newtonsoft.Json;

namespace WatcherApplication
{
    public partial class Form1 : Form
    {
        private FileSystemWatcher fileSystemWatcher;
        private string oldInputFolderPath;

        public Form1()
        {
            InitializeComponent();
            InitializeFileSystemWatcher();
        }

        private void InitializeFileSystemWatcher() { }

        private void WatchActivity()
        {
            string newInputFolderPath = InputFolderPath.Text;

            if (fileSystemWatcher == null || oldInputFolderPath != newInputFolderPath)
            {
                string InitialWatchMessage = $"Initial Watch folder {InputFolderPath.Text}";
                LogMessage(InitialWatchMessage);

                fileSystemWatcher = new FileSystemWatcher
                {
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                    Filter = "*.*" // Watch all files
                };

                oldInputFolderPath = newInputFolderPath;
            }
            else
            {
                string ReWatchMessage = $"Re-Watch Folder {InputFolderPath.Text}";
                LogMessage(ReWatchMessage);
            }

            // Unsubscribe from the previous event handler if it was set
            fileSystemWatcher.Created -= OnNewFileDetected;
            fileSystemWatcher.Renamed -= OnFileRenamed;
            fileSystemWatcher.Deleted -= OnFileDeleted;

            // Update the path to monitor
            fileSystemWatcher.Path = InputFolderPath.Text;

            // Subscribe to the Created event
            fileSystemWatcher.Created += OnNewFileDetected;
            fileSystemWatcher.Renamed += OnFileRenamed;
            fileSystemWatcher.Deleted += OnFileDeleted;

            // Start monitoring
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void Watch_Click(object sender, EventArgs e)
        {
            fileSystemWatcher = new FileSystemWatcher();

            if (Directory.Exists(InputFolderPath.Text))
            {
                WatchActivity();
            }
            else //Create directory if not exist yet
            {
                Directory.CreateDirectory(InputFolderPath.Text);

                string logMessage = $"New Folder created in: {InputFolderPath.Text} at {DateTime.Now}";
                LogMessage(logMessage);

                WatchActivity();
            }
        }

        private void OnNewFileDetected(object sender, FileSystemEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                string logMessage = $"New File detected in: {e.FullPath} at {DateTime.Now}";
                LogMessage(logMessage);
            }
            else
            {
                string logMessage = $"Path {e.FullPath} not exist. Please specify path that exist";
                LogMessage(logMessage);
            }
        }

        private void OnFileRenamed(object source, RenamedEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                string logMessage = $"Existing file rename from {e.OldFullPath} to {e.FullPath} at {DateTime.Now}";
                LogMessage(logMessage);
            }
            else
            {
                string logMessage = $"Path {e.FullPath} not exist. Please specify path that exist";
                LogMessage(logMessage);
            }
        }

        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            string logMessage = $"File deleted in: {e.FullPath} at {DateTime.Now}";
            LogMessage(logMessage);
        }

        private void LogToFile(string message)
        {
            string logFilePath = String.Concat(InputFolderPath.Text, $"\\LogFiles\\LOGFILE-{DateTime.Now.ToString("yyyyMMdd")}.txt");
            string logDirectory = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Check for file existence and attributes
            if (File.Exists(logFilePath))
            {
                FileAttributes attributes = File.GetAttributes(logFilePath);
                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    MessageBox.Show("The log file is read-only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Include the date and time before the message
            string logEntry = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {message}";

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(logEntry);
            }
        }

        private void LogToTextBox(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(LogToTextBox), message);
            }
            else
            {
                string displayMessage = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {message}";

                textBoxLog.AppendText(displayMessage + Environment.NewLine + Environment.NewLine);
            }
        }

        private void LogMessage(string logMessage)
        {
            try
            {
                LogToFile(logMessage);
                LogToTextBox(logMessage);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Access denied to the log file path: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialize components on form load
        }

        private void CreateASampleFiles_Click(object sender, EventArgs e)
        {
            CreateJsonFile();
        }

        private void CreateJsonFile()
        {
            try
            {
                string directoryPath = InputFolderPath.Text;
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);

                    string logMessage = $"New folder created in: {directoryPath}";
                    LogMessage(logMessage);
                }

                string filePath = Path.Combine(directoryPath, $"{DateTime.Now.ToString("yyyyMMdd")}-sample.json");

                #region Sample data
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                var sampleData = new
                {
                    CreatedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Name = "Muhaimin Khamsan",
                    Age = 27,
                    Occupation = "Software Developer"
                };
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                #endregion

                string jsonContent = JsonConvert.SerializeObject(sampleData, Formatting.Indented);

                // Check if file exists
                if (File.Exists(filePath))
                {
                    // Append data to the file
                    File.AppendAllText(filePath, jsonContent + Environment.NewLine);

                    string logMessage = $"Existing file append in: {filePath}";
                    LogMessage(logMessage);
                }
                else
                {
                    // Write new data to the file
                    File.WriteAllText(filePath, jsonContent + Environment.NewLine);

                    string logMessage = $"New file created in: {filePath}";
                    LogMessage(logMessage);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Access denied to the JSON file path: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearLog_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
        }
    }
}
