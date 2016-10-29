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

namespace lab1
{
    public partial class Form1 : Form
    {
        private Additional.Buffer bufferInstance;
        private int[] ipermKey;
        private int[] jpermKey;
        private string temporaryFile;
        bool stopped = false;

        public Form1()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox.Checked == false)
            {
                labelDecryption.Visible = false;
                labelEncryption.Visible = true;
            }
            else
            {
                labelEncryption.Visible = false;
                labelDecryption.Visible = true;
            }
        }

        private void buttonSource_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                textBoxSource.Text = folderBrowserDialog.SelectedPath;

            fileSystemWatcher.Path = textBoxSource.Text;

            bufferInstance = new Additional.Buffer(Directory.GetFiles(fileSystemWatcher.Path));
            startMonitoring();
        }

        private void buttonDestination_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                textBoxDestination.Text = folderBrowserDialog.SelectedPath;
        }

        private void buttonMonitorStart_Click(object sender, EventArgs e)
        {
            startMonitoring();
        }

        private void startMonitoring()
        {
            fileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged);
            fileSystemWatcher.Created += new FileSystemEventHandler(OnCreated);
            fileSystemWatcher.Deleted += new FileSystemEventHandler(OnDeleted);

            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void buttonMonitorStop_Click(object sender, EventArgs e)
        {
            fileSystemWatcher.EnableRaisingEvents = false;
        }

        //functions for checking key

        private bool checkKeyDT()
        {
            if(parseKeyDT() == false)
            {
                return false;
            }

            //provera za iperm
            List<int> temp = new List<int>(); //preko liste cu izvrsiti proveru da li su validne zadate permutacije u smislu {1, 2, 4} netacno {3, 1, 2} tacno

            for(int i = 1; i < ipermKey.Length + 1; i++)
            {
                temp.Add(i);
            }

            for(int i = 0; i < ipermKey.Length; i++)
            {
                temp.Remove(ipermKey[i]);
            }

            if(temp.Count != 0)
            {
                return false;
            }

            //provera za jperm
            temp = new List<int>();

            for (int i = 1; i < jpermKey.Length + 1; i++)
            {
                temp.Add(i);
            }

            for (int i = 0; i < jpermKey.Length; i++)
            {
                temp.Remove(jpermKey[i]);
            }

            if (temp.Count != 0)
            {
                return false;
            }

            return true;
        }
        
        private bool parseKeyDT()
        {
            string temp = textBoxKey.Text;
            string rowPerm;
            string columnPerm;

            if (File.Exists(temp))
            {
                using (StreamReader sr = File.OpenText(temp))
                {
                    rowPerm = sr.ReadLine();
                    columnPerm = sr.ReadLine();
                }

                ipermKey = parseKeyDT2(rowPerm);
                jpermKey = parseKeyDT2(columnPerm);

                if(ipermKey == null || jpermKey == null)
                {
                    return false;
                }

                return true;
            }
            else
            {
                int i = temp.IndexOf(';');

                if(i >= 0)
                {
                    rowPerm = temp.Substring(0, i); //izdvajam sve pre ;
                    columnPerm = temp.Substring(i + 1); //izdvajam sve nakon ;

                    ipermKey = parseKeyDT2(rowPerm);
                    jpermKey = parseKeyDT2(columnPerm);

                    if (ipermKey == null || jpermKey == null)
                    {
                        return false;
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private int[] parseKeyDT2(string textToParse)
        {
            char[] tempChar = textToParse.ToCharArray();
            string tempString = string.Empty;
            int[] tempInt = new int[textToParse.Length]; //nece sigurno od ovoga duze da bude
            int k = 0;

            for(int i = 0; i < textToParse.Length; i++)
            {
                if(tempChar[i] == ',')
                {
                    tempInt[k] = Int32.Parse(tempString);
                    k++;
                    tempString = string.Empty;
                }
                else
                {
                    if(char.IsNumber(tempChar[i]))
                    {
                        tempString = tempString.Insert(tempString.Length, tempChar[i].ToString());
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            tempInt[k] = Int32.Parse(tempString);
            k++; //koristim retValue da bih izbacio visak nula iz niza

            int[] retValue = new int[k];

            for(int i = 0; i < k; i++)
            {
                retValue[i] = tempInt[i];
            }

            return retValue;
        }
        
        //END functions

        //event handler functions
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            bufferInstance.deletedFile(e.FullPath); //ako je fajl promenjen, pri kopiji npr, brise se stari sa bafera i dodaje se novi na bafer, svakako se mora ovo uraditi da se npr ne bi desilo da ako se overwriteuje fajl sa istim imenom da se misli da je on vec obradjen
            bufferInstance.createdFile(e.FullPath);
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            bufferInstance.createdFile(e.FullPath); //ako je fajl kreiran ubacuje se na bafer, kada se obradi moramo ga izbrisati iz bafera
        }

        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            bufferInstance.deletedFile(e.FullPath); //ako je fajl obrisan, brise se iz bafera, isto na drugom mestu nakon obrade ga moram obrisati iz bafera (posto je obrada zavrsena)
        }
        //END handlers

        private void buttonSelectKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBoxKey.Text = openFileDialog.FileName;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox.SelectedItem.ToString() == "Double transposition")
            {
                labelKey.Visible = true;
                textBoxKey.Visible = true;
                buttonSelectKey.Visible = true;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                stopped = false;

                if (comboBox.SelectedItem.ToString() == "Double transposition")
                {
                    if (checkKeyDT() == false) return;

                    int mode;

                    if (checkBox.Checked == false)
                    {
                        mode = 0;
                    }
                    else
                    {
                        mode = 1;
                    }

                    while (bufferInstance.isEmpty() == false && stopped == false)
                    {
                        temporaryFile = bufferInstance.getAndDeleteFirst();

                        Algorithms.DoubleTranspositionCipher obj = new Algorithms.DoubleTranspositionCipher(ipermKey, jpermKey, temporaryFile, textBoxDestination.Text);
                        obj.encryptionDecryption(mode);
                    }
                }
            }
            catch { }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            stopped = true;
            if(temporaryFile != null)
            {
                bufferInstance.createdFile(temporaryFile);
            }
        }
    }
}
