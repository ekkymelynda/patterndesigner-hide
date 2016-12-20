﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatternDesigner.Tools;
using System.Diagnostics;
using PatternDesigner.Commands;
using System.IO;
using System.Reflection;

namespace PatternDesigner
{
    public partial class MainWindow : Form
    {
        private IToolbox toolbox;
        private IEditor editor;
        public IPlugin[] plugins;
        //private IToolbar toolbar;
        private IMenubar menubar;

        public MainWindow()
        {
            InitializeComponent();
            LoadPlugins();
            InitUI();
        }

        private void LoadPlugins()
        {
            string path = Application.StartupPath + "\\Plugin";
            Debug.WriteLine(path);
            string[] pluginFiles = Directory.GetFiles(path, "*.dll");
            plugins = new IPlugin[pluginFiles.Length];

            for (int i = 0; i < pluginFiles.Length; i++)
            {
                Type type = null;

                try
                {
                    Assembly asm = Assembly.LoadFile(pluginFiles[i]);

                    if (asm != null)
                    {
                        var pluginInterface = typeof(IPlugin);

                        Type[] types = asm.GetTypes();

                        foreach (Type t in types)
                        {
                            if (pluginInterface.IsAssignableFrom(t))
                                type = t;
                        }

                    }

                    if (type != null)
                    {
                        plugins[i] = (IPlugin)Activator.CreateInstance(type);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private void InitUI()
        {
            Debug.WriteLine("Initializing UI objects.");

            #region Editor and Canvas

            Debug.WriteLine("Loading canvas...");
            this.editor = new DefaultEditor();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.editor);

            ICanvas canvas1 = new DefaultCanvas();
            canvas1.Name = "Untitled-1";
            this.editor.AddCanvas(canvas1);

            /*ICanvas canvas2 = new DefaultCanvas();
            canvas2.Name = "Untitled-2";
            this.editor.AddCanvas(canvas2);*/

            #endregion

            #region Commands

            ICanvas canvas = this.editor.GetSelectedCanvas();
            Undo undo = new Undo(canvas);
            Redo redo = new Redo(canvas);

            #endregion

            #region Menubar

            Debug.WriteLine("Loading menubar...");
            this.menubar = new DefaultMenubar();
            this.Controls.Add((Control)this.menubar);

            DefaultMenuItem fileMenuItem = new DefaultMenuItem("File");
            this.menubar.AddMenuItem(fileMenuItem);

            DefaultMenuItem eksportMenuItem = new DefaultMenuItem("Eksport");
            fileMenuItem.AddMenuItem(eksportMenuItem);

            DefaultMenuItem generateMenuItem = new DefaultMenuItem("Generate");
            this.menubar.AddMenuItem(generateMenuItem);

            DefaultMenuItem undoItem = new DefaultMenuItem("Undo");
            undoItem.SetCommand(undo);
            this.menubar.AddMenuItem(undoItem);

            DefaultMenuItem redoItem = new DefaultMenuItem("Redo");
            redoItem.SetCommand(redo);
            this.menubar.AddMenuItem(redoItem);

            if (plugins != null)
            {
                for (int i = 0; i < this.plugins.Length; i++)
                {
                    generateMenuItem.Register(plugins[i], canvas);
                }
            }


            #endregion

            #region Toolbox

            // Initializing toolbox
            Debug.WriteLine("Loading toolbox...");
            this.toolbox = new DefaultToolbox();
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);
            this.editor.Toolbox = toolbox;

            #endregion

            #region Tools

            // Initializing tools
            Debug.WriteLine("Loading tools...");
            this.toolbox.AddTool(new SelectionTool());
            this.toolbox.AddSeparator();
            //this.toolbox.AddTool(new LineTool());
            this.toolbox.AddTool(new ClassTool());
            this.toolbox.AddSeparator();
            this.toolbox.AddTool(new AssociationTool());
            this.toolbox.AddTool(new DirectedTool());
            this.toolbox.AddTool(new GeneralizationTool());
            this.toolbox.AddTool(new DependencyTool());
            this.toolbox.AddTool(new RealizationTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;

            #endregion

            #region Toolbar

            // Initializing toolbar
            /*Debug.WriteLine("Loading toolbar...");
            this.toolbar = new DefaultToolbar();
            this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control)this.toolbar);

            ExampleToolbarItem toolItem1 = new ExampleToolbarItem();
            //toolItem1.SetCommand(whiteCanvasBgCmd);
            ExampleToolbarItem toolItem2 = new ExampleToolbarItem();
            //toolItem2.SetCommand(blackCanvasBgCmd);

            this.toolbar.AddToolbarItem(toolItem1);
            this.toolbar.AddSeparator();
            this.toolbar.AddToolbarItem(toolItem2);*/

            #endregion

        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.editor != null)
            {
                Debug.WriteLine("Tool " + tool.Name + " is selected");
                ICanvas canvas = this.editor.GetSelectedCanvas();
                canvas.SetActiveTool(tool);
                tool.TargetCanvas = canvas;
            }
        }
    }
}
