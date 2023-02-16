using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTask
{
    [Flags]
    public enum State
    {
        Initial = 0,
        TableIsProcessing = 1,
        LineIsProcessing = 2,
        CellIsProcessing = 4,        
        Ok = 8,
        Error = 16
    }
}
