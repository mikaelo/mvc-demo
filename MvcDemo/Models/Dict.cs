using System.Collections.Generic;

namespace MvcDemo.Models
{
    public class Dict
    {
        public List<DictItem> Get(string prefix)
        {
            var dict = new List<DictItem>();

            for (var i = 1; i < 10; i++)
            {
                dict.Add(new DictItem {Id = i, Name = string.Format("{0} {1} name", prefix, i)});
            }

            return dict;
        } 
    }
}