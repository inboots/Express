using System;
using System.Collections.Generic;
using System.Text;


public interface IQuery
{

    string GetExpressStatus(string no);
    string ExpressName { get; }

}

