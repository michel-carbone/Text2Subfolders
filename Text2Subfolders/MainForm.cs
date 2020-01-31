/*
 * Created by SharpDevelop.
 * User: michel
 * Date: 24/01/2020
 * Time: 18:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Text2Subfolders
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1.ShowDialog();
			textBox2.Text = folderBrowserDialog1.SelectedPath;
			rootPath = textBox2.Text;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string[] subfolderNames = textBox1.Lines;
			// get OS folder delimiter
			string delimiter = System.IO.Path.DirectorySeparatorChar.ToString();
			
			foreach (string name in subfolderNames)
			{
				// TODO check for empty lines
				// TODO check for legal characters
				System.IO.Directory.CreateDirectory(rootPath + delimiter + name);
			}
		}

		private string path = "";

		public string rootPath {
			get { return path; }
			set { path = value;
			Properties.Settings.Default.rootPath = path;
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			path = Properties.Settings.Default.rootPath;
			textBox1.Text = Properties.Settings.Default.subFolders;
			this.Size = Properties.Settings.Default.mainFormSize;
			this.Location = Properties.Settings.Default.mainFormLocation;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.rootPath = this.rootPath;
			Properties.Settings.Default.subFolders = this.textBox1.Text;
			Properties.Settings.Default.mainFormLocation = this.Location;
			Properties.Settings.Default.mainFormSize = this.Size;
			Properties.Settings.Default.Save();
		}
	}
}
