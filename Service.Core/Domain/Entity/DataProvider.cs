using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Core.Domain.Entity
{

    public class Column
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Columns
    {
        public List<Column> Column { get; set; }
    }

    public class Dataset2
    {
        public Columns Columns { get; set; }
        public string Rows { get; set; }
    }

    public class Dataset
    {
        public Dataset2 Dataset2 { get; set; }
    }

    public class DataProvider
    {
        public int Duration { get; set; }
        public string OperationName { get; set; }
        public Dataset Dataset { get; set; }
        public string ErrorCode { get; set; }
        public string EndService { get; set; }
        public string BeginService { get; set; }
        public bool ErrorOccurred { get; set; }
        public string ServiceName { get; set; } 
        public string StatusMessage { get; set; }

    }
}
