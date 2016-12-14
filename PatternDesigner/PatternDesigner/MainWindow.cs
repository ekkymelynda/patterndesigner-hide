using System;
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
using PatternDesigner.ToolbarItems;


namespace PatternDesigner
{
    public partial class MainWindow : Form
    {
        private IToolbox toolbox, toolboxTop;
        private IEditor editor;
        private IToolbar toolbar;
        private IMenubar menubar;

        public MainWindow()
        {
            InitializeComponent();
            InitUI();
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
            AddPattern1 addPattern1 = new AddPattern1(canvas);
            AddFactoryPattern addFactoryPattern = new AddFactoryPattern(canvas);
            AddCommandPattern addCommandPattern = new AddCommandPattern(canvas);
            AddCompositePattern addCompositePattern = new AddCompositePattern(canvas);
            AddFacadePattern addFacadePattern = new AddFacadePattern(canvas);
            AddMementoPattern addMementroPattern = new AddMementoPattern(canvas);
            AddSingletonPattern addSingletonPattern = new AddSingletonPattern(canvas);
            GenerateFile addGenerateFile = new GenerateFile(canvas);

            Undo undo = new Undo(canvas);
            Redo redo = new Redo(canvas);
            Copy copy = new Copy(canvas);
            Paste paste = new Paste(canvas);
   

            #endregion

            #region Menubar

            Debug.WriteLine("Loading menubar...");
            this.menubar = new DefaultMenubar();
            this.Controls.Add((Control)this.menubar);

            DefaultMenuItem fileMenuItem = new DefaultMenuItem("File");
            this.menubar.AddMenuItem(fileMenuItem);

            DefaultMenuItem eksportMenuItem = new DefaultMenuItem("Eksport");
            fileMenuItem.AddMenuItem(eksportMenuItem);

            DefaultMenuItem generateFile = new DefaultMenuItem("Generate");
            generateFile.SetCommand(addGenerateFile);
            fileMenuItem.AddMenuItem(generateFile);

            DefaultMenuItem generateMenuItem = new DefaultMenuItem("Generate");
            this.menubar.AddMenuItem(generateMenuItem);

            DefaultMenuItem creationalSubMenu = new DefaultMenuItem("Creational Pattern");
            generateMenuItem.AddMenuItem(creationalSubMenu);

            DefaultMenuItem structuralSubMenu = new DefaultMenuItem("Structural Pattern");
            generateMenuItem.AddMenuItem(structuralSubMenu);

            DefaultMenuItem behavioralSubMenu = new DefaultMenuItem("Behavioral Pattern");
            generateMenuItem.AddMenuItem(behavioralSubMenu);

            DefaultMenuItem factoryMenuItem = new DefaultMenuItem("Factory Pattern");
            factoryMenuItem.SetCommand(addFactoryPattern);
            creationalSubMenu.AddMenuItem(factoryMenuItem);

            DefaultMenuItem singletonMenuItem = new DefaultMenuItem("Singleton Pattern");
            singletonMenuItem.SetCommand(addSingletonPattern);
            creationalSubMenu.AddMenuItem(singletonMenuItem);

            DefaultMenuItem compositeMenuItem = new DefaultMenuItem("Composite Pattern");
            compositeMenuItem.SetCommand(addCompositePattern);
            structuralSubMenu.AddMenuItem(compositeMenuItem);

            DefaultMenuItem facadeMenuItem = new DefaultMenuItem("Facade Pattern");
            facadeMenuItem.SetCommand(addFacadePattern);
            structuralSubMenu.AddMenuItem(facadeMenuItem);

            DefaultMenuItem commandMenuItem = new DefaultMenuItem("Command Pattern");
            commandMenuItem.SetCommand(addCommandPattern);
            behavioralSubMenu.AddMenuItem(commandMenuItem);

            DefaultMenuItem mementoMenuItem = new DefaultMenuItem("Memento Pattern");
            mementoMenuItem.SetCommand(addMementroPattern);
            behavioralSubMenu.AddMenuItem(mementoMenuItem);


            DefaultMenuItem editMenuItem = new DefaultMenuItem("Edit");
            this.menubar.AddMenuItem(editMenuItem);

            DefaultMenuItem undoItem = new DefaultMenuItem("Undo");
            undoItem.SetCommand(undo);
            editMenuItem.AddMenuItem(undoItem);

            DefaultMenuItem redoItem = new DefaultMenuItem("Redo");
            redoItem.SetCommand(redo);
            editMenuItem.AddMenuItem(redoItem);

            DefaultMenuItem copyItem = new DefaultMenuItem("Copy");
            copyItem.SetCommand(copy);
            editMenuItem.AddMenuItem(copyItem);

            DefaultMenuItem pasteItem = new DefaultMenuItem("Paste");
            pasteItem.SetCommand(paste);
            editMenuItem.AddMenuItem(pasteItem);


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
	        this.toolbox.AddSeparator();
            this.toolbox.AddTool(new DeleteTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;

            #endregion

            #region Toolbar

            // Initializing toolbar
            Debug.WriteLine("Loading toolbar...");
            this.toolbar = new DefaultToolbar();
            this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control)this.toolbar);

            UndoToolItem undoToolItem = new UndoToolItem(canvas);
            undoToolItem.SetCommand(undo);
            RedoToolItem redoToolItem = new RedoToolItem(canvas);
            redoToolItem.SetCommand(redo);
            SaveToolbarItem saveToolItem = new SaveToolbarItem(canvas);
            ExportToolItem exportToolItem = new ExportToolItem(canvas);

            

            this.toolbar.AddToolbarItem(undoToolItem);
            this.toolbar.AddToolbarItem(redoToolItem);
            this.toolbar.AddSeparator();
            this.toolbar.AddToolbarItem(saveToolItem);
            this.toolbar.AddToolbarItem(exportToolItem);


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
