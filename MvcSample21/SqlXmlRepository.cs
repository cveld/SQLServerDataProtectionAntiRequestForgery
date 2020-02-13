using Microsoft.AspNetCore.DataProtection.Repositories;
using MvcSample21.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcSample21
{
    // Based on the implementation in https://github.com/defining-technology/read-more-api.
    // Dapper is used to help with executing SQL queries, but you could use any
    // abstraction over IDbConnection that you prefer.
    public class SqlXmlRepository : IXmlRepository
    {
        private readonly IXmlKeysRepository _repo;

        public SqlXmlRepository(IXmlKeysRepository repo)
        {
            _repo = repo;
        }

        public IReadOnlyCollection<XElement> GetAllElements()
        {
            return _repo.FindAll()
                .Select(x => XElement.Parse(x.Xml))
                .ToList();
        }

        public void StoreElement(XElement element, string friendlyName)
        {
            _repo.Add(new XmlKey
            {
                Xml = element.ToString(SaveOptions.DisableFormatting)
            });
        }
    }
}
