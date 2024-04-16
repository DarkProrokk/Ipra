using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "DysfunctionsDegrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vision = table.Column<int>(type: "int", nullable: true),
                    Hearing = table.Column<int>(type: "int", nullable: true),
                    VisionAndHearing = table.Column<int>(type: "int", nullable: true),
                    UpperLimbs = table.Column<int>(type: "int", nullable: true),
                    BottomLimbs = table.Column<int>(type: "int", nullable: true),
                    WheelChair = table.Column<int>(type: "int", nullable: true),
                    Intellect = table.Column<int>(type: "int", nullable: true),
                    Lingual = table.Column<int>(type: "int", nullable: true),
                    BloodCirculation = table.Column<int>(type: "int", nullable: true),
                    Breath = table.Column<int>(type: "int", nullable: true),
                    Digestive = table.Column<int>(type: "int", nullable: true),
                    Metabolism = table.Column<int>(type: "int", nullable: true),
                    BloodAndImmune = table.Column<int>(type: "int", nullable: true),
                    Excretory = table.Column<int>(type: "int", nullable: true),
                    Skin = table.Column<int>(type: "int", nullable: true),
                    PhisicalDysfunction = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DysfunctionsDegrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true),
                    ShortName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Executors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shortname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Fullname = table.Column<string>(type: "varchar(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrognozResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncRecovery = table.Column<int>(type: "int", nullable: true),
                    FuncCompensation = table.Column<int>(type: "int", nullable: true),
                    SelfService = table.Column<int>(type: "int", nullable: true),
                    MoveIndependently = table.Column<int>(type: "int", nullable: true),
                    Orientate = table.Column<int>(type: "int", nullable: true),
                    Communicate = table.Column<int>(type: "int", nullable: true),
                    BehaviorControl = table.Column<int>(type: "int", nullable: true),
                    Learning = table.Column<int>(type: "int", nullable: true),
                    Work = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrognozResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RehabPotential",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMse = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "varchar(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RehabPotential", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RehabPrognoz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMse = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "varchar(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RehabPrognoz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true),
                    ShortName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    MseName = table.Column<string>(type: "nchar(1024)", fixedLength: true, maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Patronymic = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Post = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserEmailAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MobileNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OfficialNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    AllMO = table.Column<bool>(type: "bool", nullable: false),
                    IsLocal = table.Column<bool>(type: "bool", nullable: true),
                    Password = table.Column<string>(type: "varchar(4000)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "fk_UsersCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_UsersModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "EventSubtype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true),
                    ShortName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSubtype", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSubtype_EventType",
                        column: x => x.TypeId,
                        principalTable: "EventType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IdMse = table.Column<int>(type: "int", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                    table.ForeignKey(
                        name: "fk_AddressTypeCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_AddressTypeModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Buro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(4000)", nullable: false),
                    Shortname = table.Column<string>(type: "varchar(4000)", nullable: true),
                    Fullname = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IdMse = table.Column<int>(type: "int", nullable: true),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buro", x => x.Id);
                    table.ForeignKey(
                        name: "fk_BuroCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_BuroModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Citizenship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IdMse = table.Column<int>(type: "int", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizenship", x => x.Id);
                    table.ForeignKey(
                        name: "fk_CitizenshipCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_CitizenshipModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "DocType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocType", x => x.Id);
                    table.ForeignKey(
                        name: "fk_DocTypeCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_DocTypeModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "FuncCompensation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IdMse = table.Column<int>(type: "int", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncCompensation", x => x.Id);
                    table.ForeignKey(
                        name: "fk_FuncCompensationCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_FuncCompensationModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "FuncRecovery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IdMse = table.Column<int>(type: "int", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncRecovery", x => x.Id);
                    table.ForeignKey(
                        name: "fk_FuncRecoveryCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_FuncRecoveryModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "GroupsTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FolderName = table.Column<string>(type: "varchar(4000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DroupTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupsTasks_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "HelpCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(4000)", nullable: false),
                    IdMse = table.Column<int>(type: "int", nullable: true),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpCategory", x => x.Id);
                    table.ForeignKey(
                        name: "fk_HelpCategoryCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_HelpCategoryModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "IpraStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpraStatus", x => x.Id);
                    table.ForeignKey(
                        name: "fk_IpraStatusCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_IpraStatusModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "MO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shortname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Fullname = table.Column<string>(type: "varchar(4000)", nullable: false),
                    LevelOmp = table.Column<int>(type: "int", nullable: true),
                    FomsCode = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: true),
                    DbName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    IsInMiac = table.Column<bool>(type: "bool", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    OidEgisz = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Ogrn = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MO", x => x.Id);
                    table.ForeignKey(
                        name: "fk_MOCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_MOModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Move",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Move", x => x.Id);
                    table.ForeignKey(
                        name: "fk_MoveCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_MoveModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    Snils = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    ENP = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    DeathDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
                    table.ForeignKey(
                        name: "fk_PatientsCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_PatientsModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "RecipientType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(4000)", nullable: false),
                    IdMse = table.Column<int>(type: "int", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipientType", x => x.Id);
                    table.ForeignKey(
                        name: "fk_RecipientTypeCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_RecipientTypeModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RoleDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                    table.ForeignKey(
                        name: "fk_RolesCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_RolesModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserMOs",
                columns: table => new
                {
                    UserMOsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MOId = table.Column<int>(type: "int", nullable: true),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMOs", x => x.UserMOsId);
                    table.ForeignKey(
                        name: "FK_UserMOs_MO",
                        column: x => x.MOId,
                        principalTable: "MO",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMOs_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_UserMOsCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_UserMOsModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "varchar(4000)", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.id);
                    table.ForeignKey(
                        name: "fk_FilePatient",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRolesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRolesId);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_UserRolesCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_UserRolesModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Ipra",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ProtocolNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ProtocolDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsForChild = table.Column<bool>(type: "bool", nullable: false),
                    IssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsFirst = table.Column<bool>(type: "bool", nullable: false),
                    LifeRestrictionSelfCare = table.Column<int>(type: "int", nullable: true),
                    LifeRestrictionMoving = table.Column<int>(type: "int", nullable: true),
                    LifeRestrictionOrientation = table.Column<int>(type: "int", nullable: true),
                    LifeRestrictionCommunication = table.Column<int>(type: "int", nullable: true),
                    LifeRestrictionLearn = table.Column<int>(type: "int", nullable: true),
                    LifeRestrictionWork = table.Column<int>(type: "int", nullable: true),
                    LifeRestrictionBehaviorControl = table.Column<int>(type: "int", nullable: true),
                    IsAgreed = table.Column<bool>(type: "bool", nullable: true),
                    IsRepresentativeSign = table.Column<bool>(type: "bool", nullable: true),
                    GuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    MoId = table.Column<int>(type: "int", nullable: true),
                    AllowedWebAccess = table.Column<bool>(type: "bool", nullable: false),
                    MedRehabNeed = table.Column<bool>(type: "bool", nullable: false),
                    MedRehabPeriodFrom = table.Column<DateOnly>(type: "date", nullable: true),
                    MedRehabPeriodTo = table.Column<DateOnly>(type: "date", nullable: true),
                    MedRehabIsEndless = table.Column<bool>(type: "bool", nullable: false),
                    MedRehabExecutor = table.Column<string>(type: "varchar(4000)", nullable: true),
                    ProsthesisNeed = table.Column<bool>(type: "bool", nullable: true, defaultValue: false),
                    ProsthesisPeriodFrom = table.Column<DateOnly>(type: "date", nullable: true),
                    ProsthesisPeriodTo = table.Column<DateOnly>(type: "date", nullable: true),
                    ReconsSurgeryNeed = table.Column<bool>(type: "bool", nullable: true, defaultValue: false),
                    ReconsSurgeryPeriodFrom = table.Column<DateOnly>(type: "date", nullable: true),
                    ReconsSurgeryPeriodTo = table.Column<DateOnly>(type: "date", nullable: true),
                    ResortNeed = table.Column<bool>(type: "bool", nullable: true, defaultValue: false),
                    ResortPeriodFrom = table.Column<DateOnly>(type: "date", nullable: true),
                    ResortPeriodTo = table.Column<DateOnly>(type: "date", nullable: true),
                    PrognozRecoveryId = table.Column<int>(type: "int", nullable: true),
                    PrognozCompensationId = table.Column<int>(type: "int", nullable: true),
                    BuroId = table.Column<int>(type: "int", nullable: false),
                    RecipientName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    RecipientAddress = table.Column<string>(type: "varchar(4000)", nullable: true),
                    PreviousIpraId = table.Column<int>(type: "int", nullable: true),
                    RepresentativeSurname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RepresentativeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RepresentativeLastname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RepresentativeIdentDocType = table.Column<int>(type: "int", nullable: true),
                    RepresentativeIdentDocSeries = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RepresentativeIdentDocNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RepresentativeIdentDocIssuer = table.Column<string>(type: "varchar(4000)", nullable: true),
                    RepresentativeIdentDocDate = table.Column<DateOnly>(type: "date", nullable: true),
                    RepresentativeAuthDocType = table.Column<int>(type: "int", nullable: true),
                    RepresentativeAuthDocSeries = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RepresentativeAuthDocNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RepresentativeAuthDocIssuer = table.Column<string>(type: "varchar(4000)", nullable: true),
                    RepresentativeAuthDocDate = table.Column<DateOnly>(type: "date", nullable: true),
                    BuroHeadSurname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    BuroHeadName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    BuroHeadLastname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SenderMoName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    SenderMoId = table.Column<int>(type: "int", nullable: true),
                    DevelopDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PatientSurnameMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PatientNameMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PatientLastnameMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PatientBirthdayMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PatientAgeYearsMse = table.Column<int>(type: "int", nullable: true),
                    PatientAgeMonthsMse = table.Column<int>(type: "int", nullable: true),
                    CitizenshipId = table.Column<int>(type: "int", nullable: true),
                    HasNoLivingAddress = table.Column<bool>(type: "bool", nullable: true, defaultValue: false),
                    HasNoRegAddress = table.Column<bool>(type: "bool", nullable: true, defaultValue: false),
                    PatientGuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    IdentDocDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IdentDocIssuer = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IdentDocSeries = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IdentDocNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IdentDocTitle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    PatientIsMale = table.Column<bool>(type: "bool", nullable: true),
                    LivingAddressTypeId = table.Column<int>(type: "int", nullable: true),
                    LivingAddressString = table.Column<string>(type: "varchar(4000)", nullable: true),
                    LivingAddressZipcode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    LivingAddressCountry = table.Column<string>(type: "varchar(4000)", nullable: true),
                    LivingAddressTerritoryIdMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LivingAddressTerritoryName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    LivingAddressTerritoryGuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    LivingAddressDistrict = table.Column<string>(type: "varchar(4000)", nullable: true),
                    LivingAddressDistrictGuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    LivingAddressPlaceTypeIdMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LivingAddressPlaceTypeName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LivingAddressPlaceKindIdMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LivingAddressPlaceKindName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LivingAddressCityDistrict = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LivingAddressStreet = table.Column<string>(type: "varchar(4000)", nullable: true),
                    LivingAddressStreetGuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    LivingAddressHouse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LivingAddressHouseGuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    LivingAddressCorpus = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LivingAddressBuilding = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LivingAddressAppartment = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RegAddressTypeId = table.Column<int>(type: "int", nullable: true),
                    RegAddressString = table.Column<string>(type: "varchar(4000)", nullable: true),
                    RegAddressZipcode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    RegAddressCountry = table.Column<string>(type: "varchar(4000)", nullable: true),
                    RegAddressTerritoryIdMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RegAddressTerritoryName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    RegAddressTerritoryGuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    RegAddressDistrict = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    RegAddressDistrictGuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    RegAddressPlaceTypeIdMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RegAddressPlaceTypeName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    RegAddressPlaceKindIdMse = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    RegAddressPlaceKindName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    RegAddressCityDistrict = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    RegAddressStreet = table.Column<string>(type: "varchar(4000)", nullable: true),
                    RegAddressStreetGuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    RegAddressHouse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RegAddressHouseGuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    RegAddressCorpus = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RegAddressBuilding = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RegAddressAppartment = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PatientPhone = table.Column<string>(type: "varchar(4000)", nullable: true),
                    PatientSnilsMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RecipientTypeId = table.Column<int>(type: "int", nullable: true),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    IsEndless = table.Column<bool>(type: "bool", nullable: false),
                    PatientEmail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ProsthesisIsEndless = table.Column<bool>(type: "bool", nullable: true),
                    ProsthesisExecutor = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ReconsSurgeryIsEndless = table.Column<bool>(type: "bool", nullable: true),
                    ReconsSurgeryExecutor = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ResortIsEndless = table.Column<bool>(type: "bool", nullable: true),
                    ResortExecutor = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    LivingAddressPlace = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LivingAddressPlaceGuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    RegAddressPlace = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    RegAddressPlaceGuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    PatientAgeYears = table.Column<int>(type: "int", nullable: true),
                    PatientAgeMonths = table.Column<int>(type: "int", nullable: true),
                    PatientAgeText = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CompliteRepportDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    SectorNumber = table.Column<string>(type: "nchar(200)", fixedLength: true, maxLength: 200, nullable: true),
                    SectorName = table.Column<string>(type: "nchar(200)", fixedLength: true, maxLength: 200, nullable: true),
                    SectorType = table.Column<string>(type: "nchar(200)", fixedLength: true, maxLength: 200, nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    SenderMoNameMSE = table.Column<string>(type: "varchar(4000)", nullable: true),
                    SenderMoOgrnMSE = table.Column<string>(type: "varchar(4000)", nullable: true),
                    SenderMoAddressMSE = table.Column<string>(type: "varchar(4000)", nullable: true),
                    RehabPotential = table.Column<int>(type: "int", nullable: true),
                    RehabPrognoz = table.Column<int>(type: "int", nullable: true),
                    IsDisabilityGroupPrimary = table.Column<bool>(type: "bool", nullable: true),
                    DisabilityGroupDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsIntramural = table.Column<bool>(type: "bool", nullable: true),
                    NeedCarConclusion = table.Column<bool>(type: "bool", nullable: true),
                    DDId = table.Column<int>(type: "int", nullable: true),
                    PRId = table.Column<int>(type: "int", nullable: true),
                    Vision = table.Column<int>(type: "int", nullable: true),
                    Hearing = table.Column<int>(type: "int", nullable: true),
                    VisionAndHearing = table.Column<int>(type: "int", nullable: true),
                    UpperLimbs = table.Column<int>(type: "int", nullable: true),
                    BottomLimbs = table.Column<int>(type: "int", nullable: true),
                    WheelChair = table.Column<int>(type: "int", nullable: true),
                    Intellect = table.Column<int>(type: "int", nullable: true),
                    Lingual = table.Column<int>(type: "int", nullable: true),
                    BloodCirculation = table.Column<int>(type: "int", nullable: true),
                    Breath = table.Column<int>(type: "int", nullable: true),
                    Digestive = table.Column<int>(type: "int", nullable: true),
                    Metabolism = table.Column<int>(type: "int", nullable: true),
                    BloodAndImmune = table.Column<int>(type: "int", nullable: true),
                    Excretory = table.Column<int>(type: "int", nullable: true),
                    Skin = table.Column<int>(type: "int", nullable: true),
                    PhisicalDysfunction = table.Column<int>(type: "int", nullable: true),
                    FuncRecovery = table.Column<int>(type: "int", nullable: true),
                    FuncCompensation = table.Column<int>(type: "int", nullable: true),
                    SelfService = table.Column<int>(type: "int", nullable: true),
                    MoveIndependently = table.Column<int>(type: "int", nullable: true),
                    Orientate = table.Column<int>(type: "int", nullable: true),
                    Communicate = table.Column<int>(type: "int", nullable: true),
                    BehaviorControl = table.Column<int>(type: "int", nullable: true),
                    Learning = table.Column<int>(type: "int", nullable: true),
                    Work = table.Column<int>(type: "int", nullable: true),
                    DisabilityGroup = table.Column<string>(type: "varchar(4000)", nullable: true),
                    DisabilityCause = table.Column<string>(type: "varchar(4000)", nullable: true),
                    DisabilityEndDate = table.Column<string>(type: "varchar(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ipra", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ipra_DysfunctionsDegrees",
                        column: x => x.DDId,
                        principalTable: "DysfunctionsDegrees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ipra_PrognozResult",
                        column: x => x.PRId,
                        principalTable: "PrognozResult",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_Buro",
                        column: x => x.BuroId,
                        principalTable: "Buro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_IpraCitizenship",
                        column: x => x.CitizenshipId,
                        principalTable: "Citizenship",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_IpraCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_IpraFile",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_IpraLivingAddressType",
                        column: x => x.LivingAddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_IpraMO",
                        column: x => x.MoId,
                        principalTable: "MO",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_IpraModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_IpraPatient",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_IpraPrognozCompensation",
                        column: x => x.PrognozCompensationId,
                        principalTable: "FuncCompensation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_IpraPrognozRecovery",
                        column: x => x.PrognozRecoveryId,
                        principalTable: "FuncRecovery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_IpraRecipientType",
                        column: x => x.RecipientTypeId,
                        principalTable: "RecipientType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_IpraRegAddressType",
                        column: x => x.RegAddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_IpraRepresentativeAuthDocType",
                        column: x => x.RepresentativeAuthDocType,
                        principalTable: "DocType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_IpraRepresentativeIdentDocType",
                        column: x => x.RepresentativeIdentDocType,
                        principalTable: "DocType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_IpraSenderMo",
                        column: x => x.SenderMoId,
                        principalTable: "MO",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_IpraStatus",
                        column: x => x.StatusId,
                        principalTable: "IpraStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    SurnameMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    NameMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastnameMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SnilsMse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Message = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    PatientGuidMse = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    GroupTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_GroupsTasks",
                        column: x => x.GroupTaskId,
                        principalTable: "GroupsTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_TaskCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_TaskFile",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_TaskModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "IpraHelpCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpraId = table.Column<int>(type: "int", nullable: false),
                    HelpCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpraHelpCategory", x => x.Id);
                    table.ForeignKey(
                        name: "fk_HelpCategory",
                        column: x => x.HelpCategoryId,
                        principalTable: "HelpCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_Ipra",
                        column: x => x.IpraId,
                        principalTable: "Ipra",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_IpraHelpCategoryCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_IpraHelpCategoryModifiedUser",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "IpraMovesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpraId = table.Column<int>(type: "int", nullable: false),
                    MoveId = table.Column<int>(type: "int", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_tIMESTAMP"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpraMovesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "fk_MovesHistoryCreatedUser",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "fk_MovesHistoryIpra",
                        column: x => x.IpraId,
                        principalTable: "Ipra",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_MovesHistoryMove",
                        column: x => x.MoveId,
                        principalTable: "Move",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpraId = table.Column<int>(type: "int", nullable: false),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    EventSubtypeId = table.Column<int>(type: "int", nullable: true),
                    CustomEvent = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    DatePerfomance = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ExecutorId = table.Column<int>(type: "int", nullable: true),
                    CustomExecutor = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    ResultId = table.Column<int>(type: "int", nullable: true),
                    CustomResult = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Note = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedTS = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_EventSubtype",
                        column: x => x.EventSubtypeId,
                        principalTable: "EventSubtype",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_EventType",
                        column: x => x.EventTypeId,
                        principalTable: "EventType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_Executors",
                        column: x => x.ExecutorId,
                        principalTable: "Executors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_Ipra",
                        column: x => x.IpraId,
                        principalTable: "Ipra",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Reports_Result",
                        column: x => x.ResultId,
                        principalTable: "Result",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_Users",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressType_CreatedUserId",
                table: "AddressType",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressType_ModifiedUserId",
                table: "AddressType",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Buro_CreatedUserId",
                table: "Buro",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Buro_ModifiedUserId",
                table: "Buro",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Citizenship_CreatedUserId",
                table: "Citizenship",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Citizenship_ModifiedUserId",
                table: "Citizenship",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocType_CreatedUserId",
                table: "DocType",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocType_ModifiedUserId",
                table: "DocType",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSubtype_TypeId",
                table: "EventSubtype",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_PatientId",
                table: "Files",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncCompensation_CreatedUserId",
                table: "FuncCompensation",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncCompensation_ModifiedUserId",
                table: "FuncCompensation",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncRecovery_CreatedUserId",
                table: "FuncRecovery",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncRecovery_ModifiedUserId",
                table: "FuncRecovery",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsTasks_UserId",
                table: "GroupsTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpCategory_CreatedUserId",
                table: "HelpCategory",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpCategory_ModifiedUserId",
                table: "HelpCategory",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_BuroId",
                table: "Ipra",
                column: "BuroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_CitizenshipId",
                table: "Ipra",
                column: "CitizenshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_CreatedUserId",
                table: "Ipra",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_DDId",
                table: "Ipra",
                column: "DDId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_FileId",
                table: "Ipra",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_LivingAddressTypeId",
                table: "Ipra",
                column: "LivingAddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_ModifiedUserId",
                table: "Ipra",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_MoId",
                table: "Ipra",
                column: "MoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_PatientId",
                table: "Ipra",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_PRId",
                table: "Ipra",
                column: "PRId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_PrognozCompensationId",
                table: "Ipra",
                column: "PrognozCompensationId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_PrognozRecoveryId",
                table: "Ipra",
                column: "PrognozRecoveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_RecipientTypeId",
                table: "Ipra",
                column: "RecipientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_RegAddressTypeId",
                table: "Ipra",
                column: "RegAddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_RepresentativeAuthDocType",
                table: "Ipra",
                column: "RepresentativeAuthDocType");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_RepresentativeIdentDocType",
                table: "Ipra",
                column: "RepresentativeIdentDocType");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_SenderMoId",
                table: "Ipra",
                column: "SenderMoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ipra_StatusId",
                table: "Ipra",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IpraHelpCategory_CreatedUserId",
                table: "IpraHelpCategory",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IpraHelpCategory_HelpCategoryId",
                table: "IpraHelpCategory",
                column: "HelpCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IpraHelpCategory_IpraId",
                table: "IpraHelpCategory",
                column: "IpraId");

            migrationBuilder.CreateIndex(
                name: "IX_IpraHelpCategory_ModifiedUserId",
                table: "IpraHelpCategory",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IpraMovesHistory_CreatedUserId",
                table: "IpraMovesHistory",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IpraMovesHistory_IpraId",
                table: "IpraMovesHistory",
                column: "IpraId");

            migrationBuilder.CreateIndex(
                name: "IX_IpraMovesHistory_MoveId",
                table: "IpraMovesHistory",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_IpraStatus_CreatedUserId",
                table: "IpraStatus",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IpraStatus_ModifiedUserId",
                table: "IpraStatus",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MO_CreatedUserId",
                table: "MO",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MO_ModifiedUserId",
                table: "MO",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Move_CreatedUserId",
                table: "Move",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Move_ModifiedUserId",
                table: "Move",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CreatedUserId",
                table: "Patients",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ModifiedUserId",
                table: "Patients",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipientType_CreatedUserId",
                table: "RecipientType",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipientType_ModifiedUserId",
                table: "RecipientType",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CreatedUserId",
                table: "Reports",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EventSubtypeId",
                table: "Reports",
                column: "EventSubtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EventTypeId",
                table: "Reports",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ExecutorId",
                table: "Reports",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_IpraId",
                table: "Reports",
                column: "IpraId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ResultId",
                table: "Reports",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedUserId",
                table: "Roles",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ModifiedUserId",
                table: "Roles",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_CreatedUserId",
                table: "Task",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_FileId",
                table: "Task",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_GroupTaskId",
                table: "Task",
                column: "GroupTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ModifiedUserId",
                table: "Task",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMOs_CreatedUserId",
                table: "UserMOs",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMOs_ModifiedUserId",
                table: "UserMOs",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMOs_MOId",
                table: "UserMOs",
                column: "MOId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMOs_UserId",
                table: "UserMOs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_CreatedUserId",
                table: "UserRoles",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_ModifiedUserId",
                table: "UserRoles",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedUserId",
                table: "Users",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedUserId",
                table: "Users",
                column: "ModifiedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "IpraHelpCategory");

            migrationBuilder.DropTable(
                name: "IpraMovesHistory");

            migrationBuilder.DropTable(
                name: "RehabPotential");

            migrationBuilder.DropTable(
                name: "RehabPrognoz");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "UserMOs");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "HelpCategory");

            migrationBuilder.DropTable(
                name: "Move");

            migrationBuilder.DropTable(
                name: "EventSubtype");

            migrationBuilder.DropTable(
                name: "Executors");

            migrationBuilder.DropTable(
                name: "Ipra");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "GroupsTasks");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropTable(
                name: "DysfunctionsDegrees");

            migrationBuilder.DropTable(
                name: "PrognozResult");

            migrationBuilder.DropTable(
                name: "Buro");

            migrationBuilder.DropTable(
                name: "Citizenship");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "MO");

            migrationBuilder.DropTable(
                name: "FuncCompensation");

            migrationBuilder.DropTable(
                name: "FuncRecovery");

            migrationBuilder.DropTable(
                name: "RecipientType");

            migrationBuilder.DropTable(
                name: "DocType");

            migrationBuilder.DropTable(
                name: "IpraStatus");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
