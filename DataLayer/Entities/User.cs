using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

public class User
{
    [Key] public int UserId { get; set; }

    [StringLength(50)] [Unicode(false)] public string UserName { get; set; } = null!;

    [StringLength(50)] [Unicode(false)] public string? Surname { get; set; }

    [StringLength(50)] [Unicode(false)] public string? Name { get; set; }

    [StringLength(50)] [Unicode(false)] public string? Patronymic { get; set; }

    [StringLength(50)] [Unicode(false)] public string? Post { get; set; }

    [StringLength(50)] [Unicode(false)] public string? UserEmailAddress { get; set; }

    [StringLength(50)] [Unicode(false)] public string? MobileNumber { get; set; }

    [StringLength(50)] [Unicode(false)] public string? OfficialNumber { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    public bool AllMO { get; set; }

    public bool? IsLocal { get; set; }

    [Unicode(false)] public string? Password { get; set; }

    [InverseProperty("CreatedUser")]
    public virtual ICollection<AddressType> AddressTypeCreatedUsers { get; set; } = new List<AddressType>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<AddressType> AddressTypeModifiedUsers { get; set; } = new List<AddressType>();

    [InverseProperty("CreatedUser")] public virtual ICollection<Buro> BuroCreatedUsers { get; set; } = new List<Buro>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<Buro> BuroModifiedUsers { get; set; } = new List<Buro>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<Citizenship> CitizenshipCreatedUsers { get; set; } = new List<Citizenship>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<Citizenship> CitizenshipModifiedUsers { get; set; } = new List<Citizenship>();

    [ForeignKey("CreatedUserId")]
    [InverseProperty("InverseCreatedUser")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("CreatedUser")]
    public virtual ICollection<DocType> DocTypeCreatedUsers { get; set; } = new List<DocType>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<DocType> DocTypeModifiedUsers { get; set; } = new List<DocType>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<FuncCompensation> FuncCompensationCreatedUsers { get; set; } =
        new List<FuncCompensation>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<FuncCompensation> FuncCompensationModifiedUsers { get; set; } =
        new List<FuncCompensation>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<FuncRecovery> FuncRecoveryCreatedUsers { get; set; } = new List<FuncRecovery>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<FuncRecovery> FuncRecoveryModifiedUsers { get; set; } = new List<FuncRecovery>();

    [InverseProperty("User")] public virtual ICollection<GroupsTask> GroupsTasks { get; set; } = new List<GroupsTask>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<HelpCategory> HelpCategoryCreatedUsers { get; set; } = new List<HelpCategory>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<HelpCategory> HelpCategoryModifiedUsers { get; set; } = new List<HelpCategory>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<User> InverseCreatedUser { get; set; } = new List<User>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<User> InverseModifiedUser { get; set; } = new List<User>();

    [InverseProperty("CreatedUser")] public virtual ICollection<Ipra> IpraCreatedUsers { get; set; } = new List<Ipra>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<IpraHelpCategory> IpraHelpCategoryCreatedUsers { get; set; } =
        new List<IpraHelpCategory>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<IpraHelpCategory> IpraHelpCategoryModifiedUsers { get; set; } =
        new List<IpraHelpCategory>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<Ipra> IpraModifiedUsers { get; set; } = new List<Ipra>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<IpraMovesHistory> IpraMovesHistories { get; set; } = new List<IpraMovesHistory>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<IpraStatus> IpraStatusCreatedUsers { get; set; } = new List<IpraStatus>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<IpraStatus> IpraStatusModifiedUsers { get; set; } = new List<IpraStatus>();

    [InverseProperty("CreatedUser")] public virtual ICollection<MO> MOCreatedUsers { get; set; } = new List<MO>();

    [InverseProperty("ModifiedUser")] public virtual ICollection<MO> MOModifiedUsers { get; set; } = new List<MO>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("InverseModifiedUser")]
    public virtual User ModifiedUser { get; set; } = null!;

    [InverseProperty("CreatedUser")] public virtual ICollection<Move> MoveCreatedUsers { get; set; } = new List<Move>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<Move> MoveModifiedUsers { get; set; } = new List<Move>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<Patient> PatientCreatedUsers { get; set; } = new List<Patient>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<Patient> PatientModifiedUsers { get; set; } = new List<Patient>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<RecipientType> RecipientTypeCreatedUsers { get; set; } = new List<RecipientType>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<RecipientType> RecipientTypeModifiedUsers { get; set; } = new List<RecipientType>();

    [InverseProperty("CreatedUser")] public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    [InverseProperty("CreatedUser")] public virtual ICollection<Role> RoleCreatedUsers { get; set; } = new List<Role>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<Role> RoleModifiedUsers { get; set; } = new List<Role>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<Tasks> TaskCreatedUsers { get; set; } = new List<Tasks>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<Tasks> TaskModifiedUsers { get; set; } = new List<Tasks>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<UserMO> UserMOCreatedUsers { get; set; } = new List<UserMO>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<UserMO> UserMOModifiedUsers { get; set; } = new List<UserMO>();

    [InverseProperty("User")] public virtual ICollection<UserMO> UserMOUsers { get; set; } = new List<UserMO>();

    [InverseProperty("CreatedUser")]
    public virtual ICollection<UserRole> UserRoleCreatedUsers { get; set; } = new List<UserRole>();

    [InverseProperty("ModifiedUser")]
    public virtual ICollection<UserRole> UserRoleModifiedUsers { get; set; } = new List<UserRole>();

    [InverseProperty("User")] public virtual ICollection<UserRole> UserRoleUsers { get; set; } = new List<UserRole>();
}