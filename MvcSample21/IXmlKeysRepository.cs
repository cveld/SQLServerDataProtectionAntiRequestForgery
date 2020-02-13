using MvcSample21.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSample21
{
    public interface IXmlKeysRepository
    {
        IEnumerable<XmlKey> FindAll();
        int Add(XmlKey key);
    }
}
