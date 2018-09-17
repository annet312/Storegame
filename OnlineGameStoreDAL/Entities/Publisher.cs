using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGameStoreDAL.Entities
{
    public class Publisher
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
