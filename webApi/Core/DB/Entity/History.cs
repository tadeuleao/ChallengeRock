using System;

namespace Core.DB.Entity
{
    public class History
    {
        public int Id { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}
