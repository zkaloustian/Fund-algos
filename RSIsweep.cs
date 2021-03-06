namespace QuantConnect 
{   
    /*
    *   Basic Template Algorithm
    *
    *   The underlying QCAlgorithm class has many methods which enable you to use QuantConnect.
    *   We have explained some of these here, but the full base class can be found at:
    *   https://github.com/QuantConnect/Lean/tree/master/Algorithm
    */
    public class BasicTemplateAlgorithm : QCAlgorithm
    {
    	// rsi
        private decimal spyLow = 0.0m; 
        private decimal spyHi = 0.0m;
        
        private static List<Symbol> _symbols = new List<Symbol> (){
       		QuantConnect.Symbol.Create("SPY", SecurityType.Equity, Market.USA),
       		QuantConnect.Symbol.Create("SRI", SecurityType.Equity, Market.USA),
       		QuantConnect.Symbol.Create("LUV", SecurityType.Equity, Market.USA),
       		QuantConnect.Symbol.Create("UA", SecurityType.Equity, Market.USA),
       		QuantConnect.Symbol.Create("CCH", SecurityType.Equity, Market.USA),
       		QuantConnect.Symbol.Create("BIOA", SecurityType.Equity, Market.USA),
       		QuantConnect.Symbol.Create("GOOG", SecurityType.Equity, Market.USA),
       		QuantConnect.Symbol.Create("HD", SecurityType.Equity, Market.USA)
        };
        
        private Dictionary<Symbol, RelativeStrengthIndex> _rsi;
        
        public override void Initialize() 
        {
        	// backtest parameters
            SetStartDate(2011, 1, 1);         
            SetEndDate(2013, 1, 1);
            
            // cash allocation
            SetCash(5000);
            
            _rsi = new Dictionary<Symbol, RelativeStrengthIndex>();
            
            // request specific equities
            foreach (Symbol s in _symbols){
            	AddEquity(s, Resolution.Hour);
            	_rsi[s] = new RelativeStrengthIndex(14);
            }
            
        }

        /* 
        *	New data arrives here.
        *	The "Slice" data represents a slice of time, it has all the data you need for a moment.	
        */ 
        public override void OnData(Slice data) 
        {
        	foreach (Symbol s in _symbols){
        		if (! data.ContainsKey(s) )
        			continue;
        			
        		TradeBar equity_bar = data[s];
        		//_rsi[s].AddSample(equity_bar);
        		
        		if (!_rsi[s].Ready) 
            	{
            		continue;
            	}
            }
        	
        	//Update calculation for SPY-RSI:
        	//Debug(data.ToString());
        	//TradeBar SPY = data[_spy];
        	/*TradeBar SRI = data["SRI"];
        	TradeBar LUV = data["LUV"];
        	TradeBar UA = data["UA"];
        	TradeBar CCH = data["CCH"];
        	TradeBar BIOA = data["BIOA"];
        	TradeBar GOOG = data["GOOG"];
        	TradeBar HD = data["HD"];
        	
        	
        	if(SPY == null){
        		Debug("Was null!");
        		return;
        	}
        	
            //rsi.AddSample(SPY);
            /*rsi.AddSample(SRI);
            rsi.AddSample(LUV);
            rsi.AddSample(UA);
            rsi.AddSample(CCH);
            rsi.AddSample(BIOA);
            rsi.AddSample(GOOG);
            rsi.AddSample(HD);*/
            
            /*
            if (!rsi.Ready) 
            {
            	return;
            }
        	
        	// slice has lots of useful information
        	TradeBars bars = data.Bars;
        	Splits splits = data.Splits;
        	Dividends dividends = data.Dividends;
        	
        	//Get just this bar.
        	TradeBar bar;
        	if (bars.ContainsKey("SPY")) bar = bars["SPY"];
        	
        	// calculate rsi shit
            decimal spyCurr = rsi.RSI;
        	
            if (!Portfolio.HoldStock) 
            {
                // place an order, positive is long, negative is short.
                // Order("SPY",  quantity);
                
                // set holdings here - should be able to detect when equities 
                // break RSI of 60 and buy those on positive momentum
                
                // or request a fixed fraction of a specific asset. 
                // +1 = 100% long. -2 = short all capital with 2x leverage.
                 
                Debug("RSI(SPY) before holdings set " + spyCurr.ToString());
                if (spyCurr < 30)
                {
                	SetHoldings("SPY", 1);
                	spyLow = spyCurr;
                	spyHi = spyCurr;
                	Debug("beginning at " + spyCurr.ToString());
                }
                
                // debug message to your console. Time is the algorithm time.
                // send longer messages to a file - these are capped to 10kb
                Debug("Purchased SPY on " + Time.ToShortDateString());
                //Log("This is a longer message send to log.");
            }
            else 
            {
            	// hold unitl specified time 
            	// get price at point it breaks 60 - this is our new low.
            	// get current price, this is our new high - update if necessary
            	
            	//decimal sellPoint = (highPoint + lowPoint) / 2; 
            	decimal sellPoint = 50.0m;
            	
            	if (spyCurr > spyHi) 
            	{ 
            		spyHi = spyCurr; 
            	} 
            	
            	Debug("sellpoint is " + sellPoint.ToString());
            	if (spyCurr > sellPoint) 
            	{ 
            		SetHoldings("SPY", 0);
            		Debug("ending");
            	} 
            }*/
        }
    }
}
