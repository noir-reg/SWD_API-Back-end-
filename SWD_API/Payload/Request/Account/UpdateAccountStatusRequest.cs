namespace SWD_API.Payload.Request.Account
{
    public class UpdateAccountStatusRequest
    {
        public UpdateAccountStatusRequest()
        {
        }
       public Guid Id { get; set; }
       public int Status { get; set; }
       public string Role { get; set; }  
    }
}
