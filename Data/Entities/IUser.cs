namespace BitcoinLogger.Data.Entities
{
    public interface IUser
    {
        public int Id {get;set;}
        public string Firstname {get;set;}
        public string Lastname {get;set;}
        public string Username {get;set;}
        public string Password {get;set;}

    }
}