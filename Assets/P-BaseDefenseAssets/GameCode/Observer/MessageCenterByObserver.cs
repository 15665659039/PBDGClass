using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MessageCenterByObserver
{
    private static MessageCenterByObserver _instance;

    public static MessageCenterByObserver Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MessageCenterByObserver();
            return _instance;
        }
    }

    private Dictionary<string, List<IObserver>> messageDic = new Dictionary<string, List<IObserver>> ();

    //private Dictionary<string,Action>

    private Action action;

    public void AddMessage(List<string> keys, IObserver value)
    {

        for (int i = 0; i < keys.Count; i++)
        {
            if (messageDic.ContainsKey(keys[i]))
            {
                if (!messageDic[keys[i]].Contains(value))
                    messageDic[keys[i]].Add(value);

            }
            else
            {
                List<IObserver> list = new List<IObserver>();
                list.Add(value);
                messageDic.Add(keys[i], list);
            }
        }

       

    }

    public void RemveMessage(string key, IObserver value)
    {
        if (messageDic.ContainsKey(key))
        {
            if (messageDic[key].Contains(value))
                messageDic[key].Remove(value);

            if (messageDic[key].Count == 0)
                messageDic.Remove(key);
        }
    }

    public void DispatchMessage(string key,params object[] objs)
    {
        if (messageDic.ContainsKey(key))
        {
            for (int i = 0; i < messageDic[key].Count; i++)
            {
                messageDic[key][i].HandlerNotificaiton(key, objs);
            }
        }
    }



}

