namespace BitcoinLogger.Data.Entities
{
    public class UserSQL : IUser
    {
        public int Id {get;set;}
        public string Username {get;set;}
        public string UserPassword {get;set;}

    }
}