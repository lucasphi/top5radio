using System;
using System.Collections.Generic;
using System.Text;

namespace Top5Radio.Shared.MongoDb
{
    public interface IDocument
    {
        public string Id { get; set; }
    }
}
