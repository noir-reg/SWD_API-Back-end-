namespace SWD_API.Payload.Request.Account
{
    public class GetAccountRequest
    {
        public Guid Id {  get; set; }
         public string Role {  get; set; }

        public GetAccountRequest()
        {
        }

    }
}
