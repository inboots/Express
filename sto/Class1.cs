using System;
using System.Collections.Generic;
using System.Text;


    public class Query:IQuery
    {
        public string GetExpressStatus(string no)
        {
            return "通过申通查编号"+no;
        }

        public string ExpressName
        {
            get { return "申通"; }
        }
    }

