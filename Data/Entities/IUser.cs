namespace BitcoinLogger.Data.Entities
{
    public interface IUser
    {
        public int Id {get;set;}
        public string Username {get;set;}
        public string UserPassword {get;set;}

    }
}