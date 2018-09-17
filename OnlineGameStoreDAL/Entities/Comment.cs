using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGameStoreDAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }

        public int? ParrentId { get; set; } //null if it is not answer

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
