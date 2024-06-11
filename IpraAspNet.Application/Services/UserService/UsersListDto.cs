namespace IpraAspNet.Application.Services.UserService
{
    public class UsersListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public string? Post { get; set; }
        
        public virtual string? UserMoName { get; set; }
        
        public string? UserRoleName { get; set; }
        
        public string? PersonPhoneNumber { get; set; }
        
        public string? Email { get; set; }
        
        public string? WorkPhoneNumber { get; set; }
    }
}
