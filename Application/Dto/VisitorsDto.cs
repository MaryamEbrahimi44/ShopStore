using Domain.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class VisitorsDto
    {
        public string Id { get; set; }
        public string Ip { get; set; }
        public string CurrentLink { get; set; }
        public string RefferLink { get; set; }
        public DateTime Time { get; set; }
        public bool IsSpider { get; set; }


        public VisitorVersion Browser { get; set; }
        public VisitorVersion OperationSystem { get; set; }
    }
}
