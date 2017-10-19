using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Tendani.Models
{
    public class Procedure
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuditProgram { get; set; }
        public string AuditEvidenceType { get; set; }
        public List<string> DA_AuditChampion { get; set; }
        public string DA_Level { get; set; }
        public List<Industry> Industries { get; set; }
        public List<Solution> Solutions { get; set; }
        public List<SignificantAccount> SignificantAccounts { get; set; }
        public List<Assertion> Assertion { get; set; }
        public List<ToolUsed> ToolsUsed { get; set; }
        public List<ClientTool> ClientTools { get; set; }

    }
}