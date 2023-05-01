using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTesting
{
    public interface ICalcTesting : IDisposable
    {
        void SetupLogging();
        void StartCalculatorDriver();
        void RunCalculatorTest();
        void QuitCalculatorDriver();
        void StopWindowsApplicationDriver();
    }
}
