using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.Commands
{
    public class ApplyRelationshipProperties : ICommand
    {
        private Edge edge;
        private string oldName;
        private string newName;
        private string oldRelationStart;
        private string newRelationStart;
        private string oldRelationEnd;
        private string newRelationEnd;


        public ApplyRelationshipProperties(Edge edge, string oldName, string newName, string oldRelationStart, string newRelationStart, string oldRelationEnd, string newRelationEnd)
        {
            this.edge = edge;
            this.oldName = oldName;
            this.newName = newName;
            this.oldRelationStart = oldRelationStart;
            this.newRelationStart = newRelationStart;
            this.oldRelationEnd = oldRelationEnd;
            this.newRelationEnd = newRelationEnd;
        }

        public void Execute()
        {
            edge.name = newName;
            edge.relationStart = newRelationStart;
            edge.relationEnd = newRelationEnd;  
        }

        public void Unexecute()
        {
            edge.name = oldName;
            edge.relationStart = oldRelationStart;
            edge.relationEnd = oldRelationEnd;
        }

        public ICommand MakeCommand(ICanvas canvas)
        {
            throw new NotImplementedException();
        }

        public string GetCommandName()
        {
            throw new NotImplementedException();
        }
    }
}
