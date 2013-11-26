using System;
using System.Collections.Generic;
using System.Text;


public class Query : IQuery
{

   

    public string GetExpressStatus(string no)
    {
        //throw new NotImplementedException();
        Random r = new Random();
        string api = "http://www.kuaidi100.com/query?type=shunfeng&postid="+no+"&id=1&valicode=&temp="+r.NextDouble().ToString();
        Http.WebClient wc = new Http.WebClient();
        wc.Encoding = Encoding.UTF8;
        string s = wc.GetHtml(api);
        SFModel m = LitJson.JsonMapper.ToObject<SFModel>(s);

        return m.Condition;
        
    }


    public string ExpressName
    {
        get { return "顺丰"; }
    }
}

