using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;

namespace FotbollsStatReworkedOOP
{
    internal class Output
    {
        Lag lag = new Lag();

        public void Print()
        {
            lag.Sort();
            
            var tableData = new List<Lag> { };
            foreach(Lag x in Program.lagLista)
            {
                tableData.Add(x);
            }

            ConsoleTableBuilder
                .From(tableData)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine(TableAligntment.Center);

        }
    }
}
