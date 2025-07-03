#region Namespaces
using System;
using System.Data;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
using System.Collections.Generic;
using System.Linq;
#endregion

public class SymbolState
{
    public List<decimal> PriceBuffer { get; set; }
    public List<decimal> GainBuffer { get; set; }
    public List<decimal> LossBuffer { get; set; }
    public decimal PreviousAvgGain { get; set; }
    public decimal PreviousAvgLoss { get; set; }

    public SymbolState()
    {
        PriceBuffer = new List<decimal>();
        GainBuffer = new List<decimal>();
        LossBuffer = new List<decimal>();
        PreviousAvgGain = 0;
        PreviousAvgLoss = 0;
    }
}


[Microsoft.SqlServer.Dts.Pipeline.SSISScriptComponentEntryPointAttribute]
public class ScriptMain : UserComponent
{
  
    private Dictionary<string, SymbolState> symbolStates;
    private const int rsiPeriod = 14;


    public override void PreExecute()
    {
        base.PreExecute();
    
        symbolStates = new Dictionary<string, SymbolState>();
    }

    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        string currentSymbol = Row.Copyofsymbol;

   
        if (!symbolStates.ContainsKey(currentSymbol))
        {
            symbolStates.Add(currentSymbol, new SymbolState());
        }

        SymbolState currentState = symbolStates[currentSymbol];

        currentState.PriceBuffer.Add(Row.Copyofclose);

        if (currentState.PriceBuffer.Count >= 7)
        {
            decimal ma7 = currentState.PriceBuffer.Skip(currentState.PriceBuffer.Count - 7).Take(7).Average();
            Row.CalculatedMA7 = ma7;
        }
        else
        {
            Row.CalculatedMA7_IsNull = true;
        }


        if (currentState.PriceBuffer.Count > 1)
        {
            decimal change = currentState.PriceBuffer.Last() - currentState.PriceBuffer[currentState.PriceBuffer.Count - 2];
            decimal gain = change > 0 ? change : 0;
            decimal loss = change < 0 ? -change : 0;

            currentState.GainBuffer.Add(gain);
            currentState.LossBuffer.Add(loss);

            if (currentState.GainBuffer.Count > rsiPeriod)
            {
                currentState.GainBuffer.RemoveAt(0);
                currentState.LossBuffer.RemoveAt(0);
            }

            if (currentState.GainBuffer.Count == rsiPeriod)
            {
                decimal currentAvgGain, currentAvgLoss;

                if (currentState.PreviousAvgGain == 0)
                {
                    currentAvgGain = currentState.GainBuffer.Average();
                    currentAvgLoss = currentState.LossBuffer.Average();
                }
                else 
                {
                    currentAvgGain = ((currentState.PreviousAvgGain * (rsiPeriod - 1)) + gain) / rsiPeriod;
                    currentAvgLoss = ((currentState.PreviousAvgLoss * (rsiPeriod - 1)) + loss) / rsiPeriod;
                }

                currentState.PreviousAvgGain = currentAvgGain;
                currentState.PreviousAvgLoss = currentAvgLoss;

                if (currentAvgLoss == 0)
                {
                    Row.CalculatedRSI = 100;
                }
                else
                {
                    decimal rs = currentAvgGain / currentAvgLoss;
                    Row.CalculatedRSI = 100 - (100 / (1 + rs));
                }
            }
            else
            {
                Row.CalculatedRSI_IsNull = true;
            }
        }
        else
        {
            Row.CalculatedRSI_IsNull = true;
        }
    }

    public override void PostExecute()
    {
        base.PostExecute();
    }
}