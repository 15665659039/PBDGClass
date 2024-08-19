using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public  interface IObserver
{
    List<string> ListNotificaiton();
    void HandlerNotificaiton(string messageName,params object[] objs);
}

