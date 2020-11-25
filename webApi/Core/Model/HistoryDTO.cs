using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class HistoryDTO
    {
        public int Id { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        public int Action { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}
