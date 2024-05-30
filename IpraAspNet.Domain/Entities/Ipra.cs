using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpraAspNet.Domain.Entities;

[Table("Ipra")]
public class Ipra
{
    [Key] public int id { get; set; }

    public int PatientId { get; set; }

    [StringLength(50)] public string Number { get; set; } = null!;

    [StringLength(50)] public string? ProtocolNumber { get; set; }

    public DateOnly? ProtocolDate { get; set; }

    public bool IsForChild { get; set; }

    public DateOnly IssueDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsFirst { get; set; }

    public int? LifeRestrictionSelfCare { get; set; }

    public int? LifeRestrictionMoving { get; set; }

    public int? LifeRestrictionOrientation { get; set; }

    public int? LifeRestrictionCommunication { get; set; }

    public int? LifeRestrictionLearn { get; set; }

    public int? LifeRestrictionWork { get; set; }

    public int? LifeRestrictionBehaviorControl { get; set; }

    public bool? IsAgreed { get; set; }

    public bool? IsRepresentativeSign { get; set; }

    [StringLength(36)] public string GuidMse { get; set; } = null!;

    public int StatusId { get; set; }

    public int? MoId { get; set; }

    public bool AllowedWebAccess { get; set; }

    public bool MedRehabNeed { get; set; }

    public DateOnly? MedRehabPeriodFrom { get; set; }

    public DateOnly? MedRehabPeriodTo { get; set; }

    public bool MedRehabIsEndless { get; set; }

    public string? MedRehabExecutor { get; set; }

    public bool? ProsthesisNeed { get; set; }

    public DateOnly? ProsthesisPeriodFrom { get; set; }

    public DateOnly? ProsthesisPeriodTo { get; set; }

    public bool? ReconsSurgeryNeed { get; set; }

    public DateOnly? ReconsSurgeryPeriodFrom { get; set; }

    public DateOnly? ReconsSurgeryPeriodTo { get; set; }

    public bool? ResortNeed { get; set; }

    public DateOnly? ResortPeriodFrom { get; set; }

    public DateOnly? ResortPeriodTo { get; set; }

    public int? PrognozRecoveryId { get; set; }

    public int? PrognozCompensationId { get; set; }

    public int BuroId { get; set; }

    public string? RecipientName { get; set; }

    public string? RecipientAddress { get; set; }

    public int? PreviousIpraId { get; set; }

    [StringLength(50)] public string? RepresentativeSurname { get; set; }

    [StringLength(50)] public string? RepresentativeName { get; set; }

    [StringLength(50)] public string? RepresentativeLastname { get; set; }

    public int? RepresentativeIdentDocType { get; set; }

    [StringLength(50)] public string? RepresentativeIdentDocSeries { get; set; }

    [StringLength(50)] public string? RepresentativeIdentDocNumber { get; set; }

    public string? RepresentativeIdentDocIssuer { get; set; }

    public DateOnly? RepresentativeIdentDocDate { get; set; }

    public int? RepresentativeAuthDocType { get; set; }

    [StringLength(50)] public string? RepresentativeAuthDocSeries { get; set; }

    [StringLength(50)] public string? RepresentativeAuthDocNumber { get; set; }

    public string? RepresentativeAuthDocIssuer { get; set; }

    public DateOnly? RepresentativeAuthDocDate { get; set; }

    [StringLength(50)] public string? BuroHeadSurname { get; set; }

    [StringLength(50)] public string? BuroHeadName { get; set; }

    [StringLength(50)] public string? BuroHeadLastname { get; set; }

    public string? SenderMoName { get; set; }

    public int? SenderMoId { get; set; }

    public DateOnly? DevelopDate { get; set; }

    [StringLength(50)] public string? PatientSurnameMse { get; set; }

    [StringLength(50)] public string? PatientNameMse { get; set; }

    [StringLength(50)] public string? PatientLastnameMse { get; set; }

    [StringLength(50)] public string? PatientBirthdayMse { get; set; }

    public int? PatientAgeYearsMse { get; set; }

    public int? PatientAgeMonthsMse { get; set; }

    public int? CitizenshipId { get; set; }

    public bool? HasNoLivingAddress { get; set; }

    public bool? HasNoRegAddress { get; set; }

    [StringLength(36)] public string? PatientGuidMse { get; set; }

    public DateOnly? IdentDocDate { get; set; }

    public string? IdentDocIssuer { get; set; }

    [StringLength(50)] public string? IdentDocSeries { get; set; }

    [StringLength(50)] public string? IdentDocNumber { get; set; }

    [StringLength(100)] public string? IdentDocTitle { get; set; }

    public bool? PatientIsMale { get; set; }

    public int? LivingAddressTypeId { get; set; }

    public string? LivingAddressString { get; set; }

    [StringLength(6)] public string? LivingAddressZipcode { get; set; }

    public string? LivingAddressCountry { get; set; }

    [StringLength(50)] public string? LivingAddressTerritoryIdMse { get; set; }

    public string? LivingAddressTerritoryName { get; set; }

    [StringLength(36)] public string? LivingAddressTerritoryGuidMse { get; set; }

    public string? LivingAddressDistrict { get; set; }

    [StringLength(36)] public string? LivingAddressDistrictGuidMse { get; set; }

    [StringLength(50)] public string? LivingAddressPlaceTypeIdMse { get; set; }

    [StringLength(100)] public string? LivingAddressPlaceTypeName { get; set; }

    [StringLength(50)] public string? LivingAddressPlaceKindIdMse { get; set; }

    [StringLength(100)] public string? LivingAddressPlaceKindName { get; set; }

    [StringLength(100)] public string? LivingAddressCityDistrict { get; set; }

    public string? LivingAddressStreet { get; set; }

    [StringLength(36)] public string? LivingAddressStreetGuidMse { get; set; }

    [StringLength(50)] public string? LivingAddressHouse { get; set; }

    [StringLength(36)] public string? LivingAddressHouseGuidMse { get; set; }

    [StringLength(50)] public string? LivingAddressCorpus { get; set; }

    [StringLength(50)] public string? LivingAddressBuilding { get; set; }

    [StringLength(50)] public string? LivingAddressAppartment { get; set; }

    public int? RegAddressTypeId { get; set; }

    public string? RegAddressString { get; set; }

    [StringLength(6)] public string? RegAddressZipcode { get; set; }

    public string? RegAddressCountry { get; set; }

    [StringLength(50)] public string? RegAddressTerritoryIdMse { get; set; }

    public string? RegAddressTerritoryName { get; set; }

    [StringLength(36)] public string? RegAddressTerritoryGuidMse { get; set; }

    [StringLength(100)] public string? RegAddressDistrict { get; set; }

    [StringLength(36)] public string? RegAddressDistrictGuidMse { get; set; }

    [StringLength(50)] public string? RegAddressPlaceTypeIdMse { get; set; }

    [StringLength(100)] public string? RegAddressPlaceTypeName { get; set; }

    [StringLength(100)] public string? RegAddressPlaceKindIdMse { get; set; }

    [StringLength(100)] public string? RegAddressPlaceKindName { get; set; }

    [StringLength(100)] public string? RegAddressCityDistrict { get; set; }

    public string? RegAddressStreet { get; set; }

    [StringLength(36)] public string? RegAddressStreetGuidMse { get; set; }

    [StringLength(50)] public string? RegAddressHouse { get; set; }

    [StringLength(36)] public string? RegAddressHouseGuidMse { get; set; }

    [StringLength(50)] public string? RegAddressCorpus { get; set; }

    [StringLength(50)] public string? RegAddressBuilding { get; set; }

    [StringLength(50)] public string? RegAddressAppartment { get; set; }

    public string? PatientPhone { get; set; }

    [StringLength(50)] public string? PatientSnilsMse { get; set; }

    public int? RecipientTypeId { get; set; }

    public int FileId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    public bool IsEndless { get; set; }

    [StringLength(50)] public string? PatientEmail { get; set; }

    public bool? ProsthesisIsEndless { get; set; }

    [StringLength(200)] public string? ProsthesisExecutor { get; set; }

    public bool? ReconsSurgeryIsEndless { get; set; }

    [StringLength(200)] public string? ReconsSurgeryExecutor { get; set; }

    public bool? ResortIsEndless { get; set; }

    [StringLength(200)] public string? ResortExecutor { get; set; }

    [StringLength(100)] public string? LivingAddressPlace { get; set; }

    [StringLength(36)] public string? LivingAddressPlaceGuidMse { get; set; }

    [StringLength(100)] public string? RegAddressPlace { get; set; }

    [StringLength(36)] public string? RegAddressPlaceGuidMse { get; set; }

    public int? PatientAgeYears { get; set; }

    public int? PatientAgeMonths { get; set; }

    [StringLength(50)] public string? PatientAgeText { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CompliteRepportDate { get; set; }

    [StringLength(200)] public string? SectorNumber { get; set; }

    [StringLength(200)] public string? SectorName { get; set; }

    [StringLength(200)] public string? SectorType { get; set; }

    [Column(TypeName = "datetime")] public DateTime? DecisionDate { get; set; }

    public string? SenderMoNameMSE { get; set; }

    public string? SenderMoOgrnMSE { get; set; }

    public string? SenderMoAddressMSE { get; set; }

    public int? RehabPotential { get; set; }

    public int? RehabPrognoz { get; set; }

    public bool? IsDisabilityGroupPrimary { get; set; }

    [Column(TypeName = "datetime")] public DateTime? DisabilityGroupDate { get; set; }

    public bool? IsIntramural { get; set; }

    public bool? NeedCarConclusion { get; set; }

    public int? DDId { get; set; }

    public int? PRId { get; set; }

    public int? Vision { get; set; }

    public int? Hearing { get; set; }

    public int? VisionAndHearing { get; set; }

    public int? UpperLimbs { get; set; }

    public int? BottomLimbs { get; set; }

    public int? WheelChair { get; set; }

    public int? Intellect { get; set; }

    public int? Lingual { get; set; }

    public int? BloodCirculation { get; set; }

    public int? Breath { get; set; }

    public int? Digestive { get; set; }

    public int? Metabolism { get; set; }

    public int? BloodAndImmune { get; set; }

    public int? Excretory { get; set; }

    public int? Skin { get; set; }

    public int? PhisicalDysfunction { get; set; }

    public int? FuncRecovery { get; set; }

    public int? FuncCompensation { get; set; }

    public int? SelfService { get; set; }

    public int? MoveIndependently { get; set; }

    public int? Orientate { get; set; }

    public int? Communicate { get; set; }

    public int? BehaviorControl { get; set; }

    public int? Learning { get; set; }

    public int? Work { get; set; }

    public string? DisabilityGroup { get; set; }

    public string? DisabilityCause { get; set; }

    public string? DisabilityEndDate { get; set; }

    [ForeignKey("BuroId")]
    [InverseProperty("Ipras")]
    public virtual Buro Buro { get; set; } = null!;

    [ForeignKey("CitizenshipId")]
    [InverseProperty("Ipras")]
    public virtual Citizenship? Citizenship { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("IpraCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [ForeignKey("DDId")]
    [InverseProperty("Ipras")]
    public virtual DysfunctionsDegree? DD { get; set; }

    [ForeignKey("FileId")]
    [InverseProperty("Ipras")]
    public virtual Files Files { get; set; } = null!;

    [InverseProperty("Ipra")]
    public virtual ICollection<IpraHelpCategory> IpraHelpCategories { get; set; } = new List<IpraHelpCategory>();

    [InverseProperty("Ipra")]
    public virtual ICollection<IpraMovesHistory> IpraMovesHistories { get; set; } = new List<IpraMovesHistory>();

    [ForeignKey("LivingAddressTypeId")]
    [InverseProperty("IpraLivingAddressTypes")]
    public virtual AddressType? LivingAddressType { get; set; }

    [ForeignKey("MoId")]
    [InverseProperty("IpraMos")]
    public virtual MO? Mo { get; set; }

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("IpraModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;

    [ForeignKey("PRId")]
    [InverseProperty("Ipras")]
    public virtual PrognozResult? PR { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Ipras")]
    public virtual Patient Patient { get; set; } = null!;

    [ForeignKey("PrognozCompensationId")]
    [InverseProperty("Ipras")]
    public virtual FuncCompensation? PrognozCompensation { get; set; }

    [ForeignKey("PrognozRecoveryId")]
    [InverseProperty("Ipras")]
    public virtual FuncRecovery? PrognozRecovery { get; set; }

    [ForeignKey("RecipientTypeId")]
    [InverseProperty("Ipras")]
    public virtual RecipientType? RecipientType { get; set; }

    [ForeignKey("RegAddressTypeId")]
    [InverseProperty("IpraRegAddressTypes")]
    public virtual AddressType? RegAddressType { get; set; }

    [InverseProperty("Ipra")] public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    [ForeignKey("RepresentativeAuthDocType")]
    [InverseProperty("IpraRepresentativeAuthDocTypeNavigations")]
    public virtual DocType? RepresentativeAuthDocTypeNavigation { get; set; }

    [ForeignKey("RepresentativeIdentDocType")]
    [InverseProperty("IpraRepresentativeIdentDocTypeNavigations")]
    public virtual DocType? RepresentativeIdentDocTypeNavigation { get; set; }

    [ForeignKey("SenderMoId")]
    [InverseProperty("IpraSenderMos")]
    public virtual MO? SenderMo { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Ipras")]
    public virtual IpraStatus Status { get; set; } = null!;
}