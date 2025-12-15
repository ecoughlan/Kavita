using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Data.PostgresMigrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastActive = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastActiveUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApiKey = table.Column<string>(type: "text", nullable: true),
                    ConfirmationToken = table.Column<string>(type: "text", nullable: true),
                    AgeRestriction = table.Column<int>(type: "integer", nullable: false),
                    AgeRestrictionIncludeUnknowns = table.Column<bool>(type: "boolean", nullable: false),
                    AniListAccessToken = table.Column<string>(type: "text", nullable: true),
                    MalUserName = table.Column<string>(type: "text", nullable: true),
                    MalAccessToken = table.Column<string>(type: "text", nullable: true),
                    HasRunScrobbleEventGeneration = table.Column<bool>(type: "boolean", nullable: false),
                    ScrobbleEventGenerationRan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OidcId = table.Column<string>(type: "text", nullable: true),
                    IdentityProvider = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CoverImage = table.Column<string>(type: "text", nullable: true),
                    PrimaryColor = table.Column<string>(type: "text", nullable: true),
                    SecondaryColor = table.Column<string>(type: "text", nullable: true),
                    RowVersion = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    CoverImage = table.Column<string>(type: "text", nullable: true),
                    CoverImageLocked = table.Column<bool>(type: "boolean", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    NormalizedTitle = table.Column<string>(type: "text", nullable: true),
                    Promoted = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EpubFont",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Provider = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpubFont", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalRecommendation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CoverUrl = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    AniListId = table.Column<int>(type: "integer", nullable: true),
                    MalId = table.Column<long>(type: "bigint", nullable: true),
                    Provider = table.Column<int>(type: "integer", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalRecommendation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    NormalizedTitle = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CoverImage = table.Column<string>(type: "text", nullable: true),
                    PrimaryColor = table.Column<string>(type: "text", nullable: true),
                    SecondaryColor = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    FolderWatching = table.Column<bool>(type: "boolean", nullable: false),
                    IncludeInDashboard = table.Column<bool>(type: "boolean", nullable: false),
                    IncludeInRecommended = table.Column<bool>(type: "boolean", nullable: false),
                    IncludeInSearch = table.Column<bool>(type: "boolean", nullable: false),
                    ManageCollections = table.Column<bool>(type: "boolean", nullable: false),
                    ManageReadingLists = table.Column<bool>(type: "boolean", nullable: false),
                    AllowScrobbling = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    AllowMetadataMatching = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    EnableMetadata = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    RemovePrefixForSortName = table.Column<bool>(type: "boolean", nullable: false),
                    InheritWebLinksFromFirstChapter = table.Column<bool>(type: "boolean", nullable: false),
                    DefaultLanguage = table.Column<string>(type: "text", nullable: true, defaultValue: ""),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastScanned = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManualMigrationHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ProductVersion = table.Column<string>(type: "text", nullable: true),
                    RanAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualMigrationHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaError",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Extension = table.Column<string>(type: "text", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaError", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    EnableExtendedMetadataProcessing = table.Column<bool>(type: "boolean", nullable: false),
                    EnableSummary = table.Column<bool>(type: "boolean", nullable: false),
                    EnablePublicationStatus = table.Column<bool>(type: "boolean", nullable: false),
                    EnableRelationships = table.Column<bool>(type: "boolean", nullable: false),
                    EnablePeople = table.Column<bool>(type: "boolean", nullable: false),
                    EnableStartDate = table.Column<bool>(type: "boolean", nullable: false),
                    EnableLocalizedName = table.Column<bool>(type: "boolean", nullable: false),
                    EnableCoverImage = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    EnableChapterSummary = table.Column<bool>(type: "boolean", nullable: false),
                    EnableChapterReleaseDate = table.Column<bool>(type: "boolean", nullable: false),
                    EnableChapterTitle = table.Column<bool>(type: "boolean", nullable: false),
                    EnableChapterPublisher = table.Column<bool>(type: "boolean", nullable: false),
                    EnableChapterCoverImage = table.Column<bool>(type: "boolean", nullable: false),
                    EnableGenres = table.Column<bool>(type: "boolean", nullable: false),
                    EnableTags = table.Column<bool>(type: "boolean", nullable: false),
                    FirstLastPeopleNaming = table.Column<bool>(type: "boolean", nullable: false),
                    AgeRatingMappings = table.Column<string>(type: "text", nullable: true),
                    Overrides = table.Column<string>(type: "text", nullable: true),
                    Blacklist = table.Column<string>(type: "text", nullable: true),
                    Whitelist = table.Column<string>(type: "text", nullable: true),
                    PersonRoles = table.Column<int[]>(type: "integer[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    CoverImage = table.Column<string>(type: "text", nullable: true),
                    CoverImageLocked = table.Column<bool>(type: "boolean", nullable: false),
                    PrimaryColor = table.Column<string>(type: "text", nullable: true),
                    SecondaryColor = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Asin = table.Column<string>(type: "text", nullable: true),
                    AniListId = table.Column<int>(type: "integer", nullable: false),
                    MalId = table.Column<long>(type: "bigint", nullable: false),
                    HardcoverId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServerSetting",
                columns: table => new
                {
                    Key = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    RowVersion = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerSetting", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "ServerStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    SeriesCount = table.Column<long>(type: "bigint", nullable: false),
                    VolumeCount = table.Column<long>(type: "bigint", nullable: false),
                    ChapterCount = table.Column<long>(type: "bigint", nullable: false),
                    FileCount = table.Column<long>(type: "bigint", nullable: false),
                    UserCount = table.Column<long>(type: "bigint", nullable: false),
                    GenreCount = table.Column<long>(type: "bigint", nullable: false),
                    PersonCount = table.Column<long>(type: "bigint", nullable: false),
                    TagCount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteTheme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    Provider = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GitHubPath = table.Column<string>(type: "text", nullable: true),
                    ShaHash = table.Column<string>(type: "text", nullable: true),
                    PreviewUrls = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Author = table.Column<string>(type: "text", nullable: true),
                    CompatibleVersion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteTheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    NormalizedTitle = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserAuthKey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiresAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Provider = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAuthKey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserAuthKey_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    NormalizedTitle = table.Column<string>(type: "text", nullable: true),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    Promoted = table.Column<bool>(type: "boolean", nullable: false),
                    CoverImage = table.Column<string>(type: "text", nullable: true),
                    PrimaryColor = table.Column<string>(type: "text", nullable: true),
                    SecondaryColor = table.Column<string>(type: "text", nullable: true),
                    CoverImageLocked = table.Column<bool>(type: "boolean", nullable: false),
                    AgeRating = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastSyncUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Source = table.Column<int>(type: "integer", nullable: false),
                    SourceUrl = table.Column<string>(type: "text", nullable: true),
                    TotalSourceCount = table.Column<int>(type: "integer", nullable: false),
                    MissingSeriesFromSource = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserCollection_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserExternalSource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Host = table.Column<string>(type: "text", nullable: true),
                    ApiKey = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserExternalSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserExternalSource_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserReadingHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "{\"TotalMinutesRead\":0,\"TotalPagesRead\":0,\"TotalWordsRead\":0,\"LongestSessionMinutes\":0,\"SeriesIds\":null,\"ChapterIds\":null}"),
                    ClientInfoUsed = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "[]"),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserReadingHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserReadingHistory_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserReadingProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    LibraryIds = table.Column<string>(type: "TEXT", nullable: true),
                    SeriesIds = table.Column<string>(type: "TEXT", nullable: true),
                    ReadingDirection = table.Column<int>(type: "integer", nullable: false),
                    ScalingOption = table.Column<int>(type: "integer", nullable: false),
                    PageSplitOption = table.Column<int>(type: "integer", nullable: false),
                    ReaderMode = table.Column<int>(type: "integer", nullable: false),
                    AutoCloseMenu = table.Column<bool>(type: "boolean", nullable: false),
                    ShowScreenHints = table.Column<bool>(type: "boolean", nullable: false),
                    EmulateBook = table.Column<bool>(type: "boolean", nullable: false),
                    LayoutMode = table.Column<int>(type: "integer", nullable: false),
                    BackgroundColor = table.Column<string>(type: "text", nullable: true, defaultValue: "#000000"),
                    SwipeToPaginate = table.Column<bool>(type: "boolean", nullable: false),
                    AllowAutomaticWebtoonReaderDetection = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    WidthOverride = table.Column<int>(type: "integer", nullable: true),
                    DisableWidthOverride = table.Column<int>(type: "integer", nullable: false),
                    BookReaderMargin = table.Column<int>(type: "integer", nullable: false),
                    BookReaderLineSpacing = table.Column<int>(type: "integer", nullable: false),
                    BookReaderFontSize = table.Column<int>(type: "integer", nullable: false),
                    BookReaderFontFamily = table.Column<string>(type: "text", nullable: true),
                    BookReaderTapToPaginate = table.Column<bool>(type: "boolean", nullable: false),
                    BookReaderReadingDirection = table.Column<int>(type: "integer", nullable: false),
                    BookReaderWritingStyle = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    BookThemeName = table.Column<string>(type: "text", nullable: true, defaultValue: "Dark"),
                    BookReaderLayoutMode = table.Column<int>(type: "integer", nullable: false),
                    BookReaderImmersiveMode = table.Column<bool>(type: "boolean", nullable: false),
                    PdfTheme = table.Column<int>(type: "integer", nullable: false),
                    PdfScrollMode = table.Column<int>(type: "integer", nullable: false),
                    PdfSpreadMode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserReadingProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserReadingProfiles_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserReadingSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserReadingSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserReadingSession_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserSmartFilter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Filter = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserSmartFilter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserSmartFilter_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientDevice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UiFingerprint = table.Column<string>(type: "text", nullable: true),
                    DeviceFingerprint = table.Column<string>(type: "text", nullable: false),
                    FriendlyName = table.Column<string>(type: "text", nullable: false),
                    CurrentClientInfo = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "{\"UserAgent\":\"\",\"IpAddress\":\"\",\"AuthType\":0,\"ClientType\":0,\"AppVersion\":null,\"Browser\":null,\"BrowserVersion\":null,\"Platform\":0,\"DeviceType\":null,\"ScreenWidth\":null,\"ScreenHeight\":null,\"Orientation\":null,\"CapturedAt\":\"0001-01-01T00:00:00\"}"),
                    FirstSeenUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastSeenUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientDevice_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IpAddress = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Platform = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    LastUsed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUsedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sent = table.Column<bool>(type: "boolean", nullable: false),
                    SendDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmailTemplate = table.Column<string>(type: "text", nullable: true),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    DeliveryStatus = table.Column<string>(type: "text", nullable: true),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailHistory_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadingList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    NormalizedTitle = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    Promoted = table.Column<bool>(type: "boolean", nullable: false),
                    CoverImage = table.Column<string>(type: "text", nullable: true),
                    PrimaryColor = table.Column<string>(type: "text", nullable: true),
                    SecondaryColor = table.Column<string>(type: "text", nullable: true),
                    CoverImageLocked = table.Column<bool>(type: "boolean", nullable: false),
                    AgeRating = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartingYear = table.Column<int>(type: "integer", nullable: false),
                    StartingMonth = table.Column<int>(type: "integer", nullable: false),
                    EndingYear = table.Column<int>(type: "integer", nullable: false),
                    EndingMonth = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingList_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLibrary",
                columns: table => new
                {
                    AppUsersId = table.Column<int>(type: "integer", nullable: false),
                    LibrariesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLibrary", x => new { x.AppUsersId, x.LibrariesId });
                    table.ForeignKey(
                        name: "FK_AppUserLibrary_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserLibrary_Library_LibrariesId",
                        column: x => x.LibrariesId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FolderPath",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(type: "text", nullable: true),
                    LastScanned = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LibraryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderPath", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FolderPath_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryExcludePattern",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pattern = table.Column<string>(type: "text", nullable: true),
                    LibraryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryExcludePattern", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryExcludePattern_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryFileTypeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileTypeGroup = table.Column<int>(type: "integer", nullable: false),
                    LibraryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryFileTypeGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryFileTypeGroup_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    NormalizedLocalizedName = table.Column<string>(type: "text", nullable: true),
                    SortName = table.Column<string>(type: "text", nullable: true),
                    LocalizedName = table.Column<string>(type: "text", nullable: true),
                    OriginalName = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CoverImage = table.Column<string>(type: "text", nullable: true),
                    CoverImageLocked = table.Column<bool>(type: "boolean", nullable: false),
                    Pages = table.Column<int>(type: "integer", nullable: false),
                    FolderPath = table.Column<string>(type: "text", nullable: true),
                    LowestFolderPath = table.Column<string>(type: "text", nullable: true),
                    LastFolderScanned = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastFolderScannedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Format = table.Column<int>(type: "integer", nullable: false),
                    PrimaryColor = table.Column<string>(type: "text", nullable: true),
                    SecondaryColor = table.Column<string>(type: "text", nullable: true),
                    SortNameLocked = table.Column<bool>(type: "boolean", nullable: false),
                    LocalizedNameLocked = table.Column<bool>(type: "boolean", nullable: false),
                    LastChapterAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastChapterAddedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WordCount = table.Column<long>(type: "bigint", nullable: false),
                    MinHoursToRead = table.Column<int>(type: "integer", nullable: false),
                    MaxHoursToRead = table.Column<int>(type: "integer", nullable: false),
                    AvgHoursToRead = table.Column<float>(type: "real", nullable: false),
                    DontMatch = table.Column<bool>(type: "boolean", nullable: false),
                    IsBlacklisted = table.Column<bool>(type: "boolean", nullable: false),
                    LibraryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetadataFieldMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SourceType = table.Column<int>(type: "integer", nullable: false),
                    DestinationType = table.Column<int>(type: "integer", nullable: false),
                    SourceValue = table.Column<string>(type: "text", nullable: true),
                    DestinationValue = table.Column<string>(type: "text", nullable: true),
                    ExcludeFromSource = table.Column<bool>(type: "boolean", nullable: false),
                    MetadataSettingsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataFieldMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetadataFieldMapping_MetadataSettings_MetadataSettingsId",
                        column: x => x.MetadataSettingsId,
                        principalTable: "MetadataSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonAlias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Alias = table.Column<string>(type: "text", nullable: true),
                    NormalizedAlias = table.Column<string>(type: "text", nullable: true),
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAlias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAlias_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReadingDirection = table.Column<int>(type: "integer", nullable: false),
                    ScalingOption = table.Column<int>(type: "integer", nullable: false),
                    PageSplitOption = table.Column<int>(type: "integer", nullable: false),
                    ReaderMode = table.Column<int>(type: "integer", nullable: false),
                    AutoCloseMenu = table.Column<bool>(type: "boolean", nullable: false),
                    ShowScreenHints = table.Column<bool>(type: "boolean", nullable: false),
                    EmulateBook = table.Column<bool>(type: "boolean", nullable: false),
                    LayoutMode = table.Column<int>(type: "integer", nullable: false),
                    BackgroundColor = table.Column<string>(type: "text", nullable: true, defaultValue: "#000000"),
                    SwipeToPaginate = table.Column<bool>(type: "boolean", nullable: false),
                    AllowAutomaticWebtoonReaderDetection = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    BookReaderMargin = table.Column<int>(type: "integer", nullable: false),
                    BookReaderLineSpacing = table.Column<int>(type: "integer", nullable: false),
                    BookReaderFontSize = table.Column<int>(type: "integer", nullable: false),
                    BookReaderFontFamily = table.Column<string>(type: "text", nullable: true),
                    BookReaderTapToPaginate = table.Column<bool>(type: "boolean", nullable: false),
                    BookReaderReadingDirection = table.Column<int>(type: "integer", nullable: false),
                    BookReaderWritingStyle = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    BookThemeName = table.Column<string>(type: "text", nullable: true, defaultValue: "Dark"),
                    BookReaderLayoutMode = table.Column<int>(type: "integer", nullable: false),
                    BookReaderImmersiveMode = table.Column<bool>(type: "boolean", nullable: false),
                    BookReaderHighlightSlots = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "[]"),
                    PdfTheme = table.Column<int>(type: "integer", nullable: false),
                    PdfScrollMode = table.Column<int>(type: "integer", nullable: false),
                    PdfSpreadMode = table.Column<int>(type: "integer", nullable: false),
                    ThemeId = table.Column<int>(type: "integer", nullable: true),
                    GlobalPageLayoutMode = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    BlurUnreadSummaries = table.Column<bool>(type: "boolean", nullable: false),
                    PromptForDownloadSize = table.Column<bool>(type: "boolean", nullable: false),
                    NoTransitions = table.Column<bool>(type: "boolean", nullable: false),
                    CollapseSeriesRelationships = table.Column<bool>(type: "boolean", nullable: false),
                    Locale = table.Column<string>(type: "text", nullable: false, defaultValue: "en"),
                    ColorScapeEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    DataSaver = table.Column<bool>(type: "boolean", nullable: false),
                    PromptForRereadsAfter = table.Column<int>(type: "integer", nullable: false, defaultValue: 30),
                    CustomKeyBinds = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "{}"),
                    AniListScrobblingEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    WantToReadSync = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    ShareReviews = table.Column<bool>(type: "boolean", nullable: false),
                    SocialPreferences = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "{\"ShareReviews\":false,\"ShareAnnotations\":false,\"ViewOtherAnnotations\":false,\"SocialLibraries\":[],\"SocialMaxAgeRating\":-1,\"SocialIncludeUnknowns\":true,\"ShareProfile\":false}"),
                    OpdsPreferences = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "{\"EmbedProgressIndicator\":true,\"IncludeContinueFrom\":true}"),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserPreferences_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserPreferences_SiteTheme_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "SiteTheme",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppUserDashboardStream",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsProvided = table.Column<bool>(type: "boolean", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    StreamType = table.Column<int>(type: "integer", nullable: false, defaultValue: 4),
                    Visible = table.Column<bool>(type: "boolean", nullable: false),
                    SmartFilterId = table.Column<int>(type: "integer", nullable: true),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserDashboardStream", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserDashboardStream_AppUserSmartFilter_SmartFilterId",
                        column: x => x.SmartFilterId,
                        principalTable: "AppUserSmartFilter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUserDashboardStream_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserSideNavStream",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsProvided = table.Column<bool>(type: "boolean", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    LibraryId = table.Column<int>(type: "integer", nullable: true),
                    ExternalSourceId = table.Column<int>(type: "integer", nullable: true),
                    StreamType = table.Column<int>(type: "integer", nullable: false, defaultValue: 5),
                    Visible = table.Column<bool>(type: "boolean", nullable: false),
                    SmartFilterId = table.Column<int>(type: "integer", nullable: true),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserSideNavStream", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserSideNavStream_AppUserSmartFilter_SmartFilterId",
                        column: x => x.SmartFilterId,
                        principalTable: "AppUserSmartFilter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUserSideNavStream_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientDeviceHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<int>(type: "integer", nullable: false),
                    ClientInfo = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "{\"UserAgent\":\"\",\"IpAddress\":\"\",\"AuthType\":0,\"ClientType\":0,\"AppVersion\":null,\"Browser\":null,\"BrowserVersion\":null,\"Platform\":0,\"DeviceType\":null,\"ScreenWidth\":null,\"ScreenHeight\":null,\"Orientation\":null,\"CapturedAt\":\"0001-01-01T00:00:00\"}"),
                    CapturedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDeviceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientDeviceHistory_ClientDevice_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "ClientDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserCollectionSeries",
                columns: table => new
                {
                    CollectionsId = table.Column<int>(type: "integer", nullable: false),
                    ItemsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserCollectionSeries", x => new { x.CollectionsId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_AppUserCollectionSeries_AppUserCollection_CollectionsId",
                        column: x => x.CollectionsId,
                        principalTable: "AppUserCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserCollectionSeries_Series_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserOnDeckRemoval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserOnDeckRemoval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserOnDeckRemoval_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserOnDeckRemoval_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    HasBeenRated = table.Column<bool>(type: "boolean", nullable: false),
                    Review = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserRating_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRating_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserWantToRead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserWantToRead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserWantToRead_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserWantToRead_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalSeriesMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AverageExternalRating = table.Column<int>(type: "integer", nullable: false),
                    AniListId = table.Column<int>(type: "integer", nullable: false),
                    CbrId = table.Column<int>(type: "integer", nullable: false),
                    MalId = table.Column<long>(type: "bigint", nullable: false),
                    GoogleBooksId = table.Column<string>(type: "text", nullable: true),
                    ValidUntilUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalSeriesMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalSeriesMetadata_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrobbleEvent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScrobbleEventType = table.Column<int>(type: "integer", nullable: false),
                    AniListId = table.Column<int>(type: "integer", nullable: true),
                    MalId = table.Column<long>(type: "bigint", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    ReviewBody = table.Column<string>(type: "text", nullable: true),
                    ReviewTitle = table.Column<string>(type: "text", nullable: true),
                    Format = table.Column<int>(type: "integer", nullable: false),
                    ChapterNumber = table.Column<int>(type: "integer", nullable: true),
                    VolumeNumber = table.Column<float>(type: "real", nullable: true),
                    IsProcessed = table.Column<bool>(type: "boolean", nullable: false),
                    IsErrored = table.Column<bool>(type: "boolean", nullable: false),
                    ErrorDetails = table.Column<string>(type: "text", nullable: true),
                    ProcessDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    LibraryId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrobbleEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScrobbleEvent_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrobbleEvent_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrobbleEvent_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrobbleHold",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrobbleHold", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScrobbleHold_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrobbleHold_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesBlacklist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastChecked = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesBlacklist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeriesBlacklist_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    AgeRating = table.Column<int>(type: "integer", nullable: false),
                    ReleaseYear = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: true),
                    TotalCount = table.Column<int>(type: "integer", nullable: false),
                    MaxCount = table.Column<int>(type: "integer", nullable: false),
                    PublicationStatus = table.Column<int>(type: "integer", nullable: false),
                    WebLinks = table.Column<string>(type: "text", nullable: true, defaultValue: ""),
                    KPlusOverrides = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "[]"),
                    LanguageLocked = table.Column<bool>(type: "boolean", nullable: false),
                    SummaryLocked = table.Column<bool>(type: "boolean", nullable: false),
                    AgeRatingLocked = table.Column<bool>(type: "boolean", nullable: false),
                    PublicationStatusLocked = table.Column<bool>(type: "boolean", nullable: false),
                    GenresLocked = table.Column<bool>(type: "boolean", nullable: false),
                    TagsLocked = table.Column<bool>(type: "boolean", nullable: false),
                    WriterLocked = table.Column<bool>(type: "boolean", nullable: false),
                    CharacterLocked = table.Column<bool>(type: "boolean", nullable: false),
                    ColoristLocked = table.Column<bool>(type: "boolean", nullable: false),
                    EditorLocked = table.Column<bool>(type: "boolean", nullable: false),
                    InkerLocked = table.Column<bool>(type: "boolean", nullable: false),
                    ImprintLocked = table.Column<bool>(type: "boolean", nullable: false),
                    LettererLocked = table.Column<bool>(type: "boolean", nullable: false),
                    PencillerLocked = table.Column<bool>(type: "boolean", nullable: false),
                    PublisherLocked = table.Column<bool>(type: "boolean", nullable: false),
                    TranslatorLocked = table.Column<bool>(type: "boolean", nullable: false),
                    TeamLocked = table.Column<bool>(type: "boolean", nullable: false),
                    LocationLocked = table.Column<bool>(type: "boolean", nullable: false),
                    CoverArtistLocked = table.Column<bool>(type: "boolean", nullable: false),
                    ReleaseYearLocked = table.Column<bool>(type: "boolean", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    RowVersion = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeriesMetadata_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesRelation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RelationKind = table.Column<int>(type: "integer", nullable: false),
                    TargetSeriesId = table.Column<int>(type: "integer", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeriesRelation_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesRelation_Series_TargetSeriesId",
                        column: x => x.TargetSeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LookupName = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    MinNumber = table.Column<float>(type: "real", nullable: false),
                    MaxNumber = table.Column<float>(type: "real", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CoverImage = table.Column<string>(type: "text", nullable: true),
                    CoverImageLocked = table.Column<bool>(type: "boolean", nullable: false),
                    PrimaryColor = table.Column<string>(type: "text", nullable: true),
                    SecondaryColor = table.Column<string>(type: "text", nullable: true),
                    Pages = table.Column<int>(type: "integer", nullable: false),
                    WordCount = table.Column<long>(type: "bigint", nullable: false),
                    MinHoursToRead = table.Column<int>(type: "integer", nullable: false),
                    MaxHoursToRead = table.Column<int>(type: "integer", nullable: false),
                    AvgHoursToRead = table.Column<float>(type: "real", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volume_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalRecommendationExternalSeriesMetadata",
                columns: table => new
                {
                    ExternalRecommendationsId = table.Column<int>(type: "integer", nullable: false),
                    ExternalSeriesMetadatasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalRecommendationExternalSeriesMetadata", x => new { x.ExternalRecommendationsId, x.ExternalSeriesMetadatasId });
                    table.ForeignKey(
                        name: "FK_ExternalRecommendationExternalSeriesMetadata_ExternalRecomm~",
                        column: x => x.ExternalRecommendationsId,
                        principalTable: "ExternalRecommendation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalRecommendationExternalSeriesMetadata_ExternalSeries~",
                        column: x => x.ExternalSeriesMetadatasId,
                        principalTable: "ExternalSeriesMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrobbleError",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: true),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    LibraryId = table.Column<int>(type: "integer", nullable: false),
                    ScrobbleEventId = table.Column<int>(type: "integer", nullable: false),
                    ScrobbleEventId1 = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrobbleError", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScrobbleError_ScrobbleEvent_ScrobbleEventId1",
                        column: x => x.ScrobbleEventId1,
                        principalTable: "ScrobbleEvent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScrobbleError_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionTagSeriesMetadata",
                columns: table => new
                {
                    CollectionTagsId = table.Column<int>(type: "integer", nullable: false),
                    SeriesMetadatasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionTagSeriesMetadata", x => new { x.CollectionTagsId, x.SeriesMetadatasId });
                    table.ForeignKey(
                        name: "FK_CollectionTagSeriesMetadata_CollectionTag_CollectionTagsId",
                        column: x => x.CollectionTagsId,
                        principalTable: "CollectionTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionTagSeriesMetadata_SeriesMetadata_SeriesMetadatasId",
                        column: x => x.SeriesMetadatasId,
                        principalTable: "SeriesMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreSeriesMetadata",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "integer", nullable: false),
                    SeriesMetadatasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSeriesMetadata", x => new { x.GenresId, x.SeriesMetadatasId });
                    table.ForeignKey(
                        name: "FK_GenreSeriesMetadata_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSeriesMetadata_SeriesMetadata_SeriesMetadatasId",
                        column: x => x.SeriesMetadatasId,
                        principalTable: "SeriesMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesMetadataPeople",
                columns: table => new
                {
                    SeriesMetadataId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    KavitaPlusConnection = table.Column<bool>(type: "boolean", nullable: false),
                    OrderWeight = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesMetadataPeople", x => new { x.SeriesMetadataId, x.PersonId, x.Role });
                    table.ForeignKey(
                        name: "FK_SeriesMetadataPeople_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesMetadataPeople_SeriesMetadata_SeriesMetadataId",
                        column: x => x.SeriesMetadataId,
                        principalTable: "SeriesMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesMetadataTag",
                columns: table => new
                {
                    SeriesMetadatasId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesMetadataTag", x => new { x.SeriesMetadatasId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_SeriesMetadataTag_SeriesMetadata_SeriesMetadatasId",
                        column: x => x.SeriesMetadatasId,
                        principalTable: "SeriesMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesMetadataTag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Range = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    MinNumber = table.Column<float>(type: "real", nullable: false),
                    MaxNumber = table.Column<float>(type: "real", nullable: false),
                    SortOrder = table.Column<float>(type: "real", nullable: false),
                    SortOrderLocked = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CoverImage = table.Column<string>(type: "text", nullable: true),
                    PrimaryColor = table.Column<string>(type: "text", nullable: true),
                    SecondaryColor = table.Column<string>(type: "text", nullable: true),
                    CoverImageLocked = table.Column<bool>(type: "boolean", nullable: false),
                    Pages = table.Column<int>(type: "integer", nullable: false),
                    IsSpecial = table.Column<bool>(type: "boolean", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    AgeRating = table.Column<int>(type: "integer", nullable: false),
                    TitleName = table.Column<string>(type: "text", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    Language = table.Column<string>(type: "text", nullable: true),
                    TotalCount = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    SeriesGroup = table.Column<string>(type: "text", nullable: true),
                    StoryArc = table.Column<string>(type: "text", nullable: true),
                    StoryArcNumber = table.Column<string>(type: "text", nullable: true),
                    AlternateNumber = table.Column<string>(type: "text", nullable: true),
                    AlternateSeries = table.Column<string>(type: "text", nullable: true),
                    AlternateCount = table.Column<int>(type: "integer", nullable: false),
                    WordCount = table.Column<long>(type: "bigint", nullable: false),
                    MinHoursToRead = table.Column<int>(type: "integer", nullable: false),
                    MaxHoursToRead = table.Column<int>(type: "integer", nullable: false),
                    AvgHoursToRead = table.Column<float>(type: "real", nullable: false),
                    WebLinks = table.Column<string>(type: "text", nullable: true, defaultValue: ""),
                    ISBN = table.Column<string>(type: "text", nullable: true, defaultValue: ""),
                    KPlusOverrides = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "[]"),
                    AverageExternalRating = table.Column<float>(type: "real", nullable: false),
                    AgeRatingLocked = table.Column<bool>(type: "boolean", nullable: false),
                    TitleNameLocked = table.Column<bool>(type: "boolean", nullable: false),
                    GenresLocked = table.Column<bool>(type: "boolean", nullable: false),
                    TagsLocked = table.Column<bool>(type: "boolean", nullable: false),
                    WriterLocked = table.Column<bool>(type: "boolean", nullable: false),
                    CharacterLocked = table.Column<bool>(type: "boolean", nullable: false),
                    ColoristLocked = table.Column<bool>(type: "boolean", nullable: false),
                    EditorLocked = table.Column<bool>(type: "boolean", nullable: false),
                    InkerLocked = table.Column<bool>(type: "boolean", nullable: false),
                    ImprintLocked = table.Column<bool>(type: "boolean", nullable: false),
                    LettererLocked = table.Column<bool>(type: "boolean", nullable: false),
                    PencillerLocked = table.Column<bool>(type: "boolean", nullable: false),
                    PublisherLocked = table.Column<bool>(type: "boolean", nullable: false),
                    TranslatorLocked = table.Column<bool>(type: "boolean", nullable: false),
                    TeamLocked = table.Column<bool>(type: "boolean", nullable: false),
                    LocationLocked = table.Column<bool>(type: "boolean", nullable: false),
                    CoverArtistLocked = table.Column<bool>(type: "boolean", nullable: false),
                    LanguageLocked = table.Column<bool>(type: "boolean", nullable: false),
                    SummaryLocked = table.Column<bool>(type: "boolean", nullable: false),
                    ISBNLocked = table.Column<bool>(type: "boolean", nullable: false),
                    ReleaseDateLocked = table.Column<bool>(type: "boolean", nullable: false),
                    VolumeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapter_Volume_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserAnnotation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    XPath = table.Column<string>(type: "text", nullable: true),
                    EndingXPath = table.Column<string>(type: "text", nullable: true),
                    SelectedText = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    CommentHtml = table.Column<string>(type: "text", nullable: true),
                    CommentPlainText = table.Column<string>(type: "text", nullable: true),
                    HighlightCount = table.Column<int>(type: "integer", nullable: false),
                    PageNumber = table.Column<int>(type: "integer", nullable: false),
                    SelectedSlotIndex = table.Column<int>(type: "integer", nullable: false),
                    Context = table.Column<string>(type: "text", nullable: true),
                    ContainsSpoiler = table.Column<bool>(type: "boolean", nullable: false),
                    Likes = table.Column<int[]>(type: "integer[]", nullable: true, defaultValue: new int[0]),
                    ChapterTitle = table.Column<string>(type: "text", nullable: true),
                    LibraryId = table.Column<int>(type: "integer", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    VolumeId = table.Column<int>(type: "integer", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAnnotation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserAnnotation_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserAnnotation_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserAnnotation_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserAnnotation_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserBookmark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Page = table.Column<int>(type: "integer", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    VolumeId = table.Column<int>(type: "integer", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    ImageOffset = table.Column<int>(type: "integer", nullable: false),
                    XPath = table.Column<string>(type: "text", nullable: true),
                    ChapterTitle = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserBookmark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserBookmark_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserBookmark_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserBookmark_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserBookmark_Volume_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserChapterRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    HasBeenRated = table.Column<bool>(type: "boolean", nullable: false),
                    Review = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserChapterRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserChapterRating_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserChapterRating_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserChapterRating_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PagesRead = table.Column<int>(type: "integer", nullable: false),
                    VolumeId = table.Column<int>(type: "integer", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    LibraryId = table.Column<int>(type: "integer", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false),
                    BookScrollId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalReads = table.Column<int>(type: "integer", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserProgresses_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserProgresses_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserProgresses_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserReadingSessionActivityData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserReadingSessionId = table.Column<int>(type: "integer", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false),
                    VolumeId = table.Column<int>(type: "integer", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    LibraryId = table.Column<int>(type: "integer", nullable: false),
                    StartPage = table.Column<int>(type: "integer", nullable: false),
                    EndPage = table.Column<int>(type: "integer", nullable: false),
                    StartBookScrollId = table.Column<string>(type: "text", nullable: true),
                    EndBookScrollId = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PagesRead = table.Column<int>(type: "integer", nullable: false),
                    WordsRead = table.Column<int>(type: "integer", nullable: false),
                    TotalPages = table.Column<int>(type: "integer", nullable: false),
                    TotalWords = table.Column<long>(type: "bigint", nullable: false),
                    DeviceIds = table.Column<List<int>>(type: "integer[]", nullable: false),
                    ClientInfo = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserReadingSessionActivityData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserReadingSessionActivityData_AppUserReadingSession_App~",
                        column: x => x.AppUserReadingSessionId,
                        principalTable: "AppUserReadingSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserReadingSessionActivityData_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserReadingSessionActivityData_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTableOfContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PageNumber = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    BookScrollId = table.Column<string>(type: "text", nullable: true),
                    SelectedText = table.Column<string>(type: "text", nullable: true),
                    ChapterTitle = table.Column<string>(type: "text", nullable: true),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false),
                    VolumeId = table.Column<int>(type: "integer", nullable: false),
                    LibraryId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTableOfContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserTableOfContent_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserTableOfContent_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserTableOfContent_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterGenre",
                columns: table => new
                {
                    ChaptersId = table.Column<int>(type: "integer", nullable: false),
                    GenresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterGenre", x => new { x.ChaptersId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_ChapterGenre_Chapter_ChaptersId",
                        column: x => x.ChaptersId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterGenre_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterPeople",
                columns: table => new
                {
                    ChapterId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    KavitaPlusConnection = table.Column<bool>(type: "boolean", nullable: false),
                    OrderWeight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterPeople", x => new { x.ChapterId, x.PersonId, x.Role });
                    table.ForeignKey(
                        name: "FK_ChapterPeople_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterPeople_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterTag",
                columns: table => new
                {
                    ChaptersId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterTag", x => new { x.ChaptersId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ChapterTag_Chapter_ChaptersId",
                        column: x => x.ChaptersId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterTag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AverageScore = table.Column<int>(type: "integer", nullable: false),
                    FavoriteCount = table.Column<int>(type: "integer", nullable: false),
                    Provider = table.Column<int>(type: "integer", nullable: false),
                    Authority = table.Column<int>(type: "integer", nullable: false),
                    ProviderUrl = table.Column<string>(type: "text", nullable: true),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalRating_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExternalReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tagline = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    BodyJustText = table.Column<string>(type: "text", nullable: true),
                    RawBody = table.Column<string>(type: "text", nullable: true),
                    Provider = table.Column<int>(type: "integer", nullable: false),
                    Authority = table.Column<int>(type: "integer", nullable: false),
                    SiteUrl = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    TotalVotes = table.Column<int>(type: "integer", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalReview_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MangaFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    KoreaderHash = table.Column<string>(type: "text", nullable: true),
                    Pages = table.Column<int>(type: "integer", nullable: false),
                    Format = table.Column<int>(type: "integer", nullable: false),
                    Bytes = table.Column<long>(type: "bigint", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastFileAnalysis = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastFileAnalysisUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MangaFile_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadingListItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    VolumeId = table.Column<int>(type: "integer", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ReadingListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingListItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingListItem_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadingListItem_ReadingList_ReadingListId",
                        column: x => x.ReadingListId,
                        principalTable: "ReadingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadingListItem_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadingListItem_Volume_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalRatingExternalSeriesMetadata",
                columns: table => new
                {
                    ExternalRatingsId = table.Column<int>(type: "integer", nullable: false),
                    ExternalSeriesMetadatasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalRatingExternalSeriesMetadata", x => new { x.ExternalRatingsId, x.ExternalSeriesMetadatasId });
                    table.ForeignKey(
                        name: "FK_ExternalRatingExternalSeriesMetadata_ExternalRating_Externa~",
                        column: x => x.ExternalRatingsId,
                        principalTable: "ExternalRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalRatingExternalSeriesMetadata_ExternalSeriesMetadata~",
                        column: x => x.ExternalSeriesMetadatasId,
                        principalTable: "ExternalSeriesMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalReviewExternalSeriesMetadata",
                columns: table => new
                {
                    ExternalReviewsId = table.Column<int>(type: "integer", nullable: false),
                    ExternalSeriesMetadatasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalReviewExternalSeriesMetadata", x => new { x.ExternalReviewsId, x.ExternalSeriesMetadatasId });
                    table.ForeignKey(
                        name: "FK_ExternalReviewExternalSeriesMetadata_ExternalReview_Externa~",
                        column: x => x.ExternalReviewsId,
                        principalTable: "ExternalReview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalReviewExternalSeriesMetadata_ExternalSeriesMetadata~",
                        column: x => x.ExternalSeriesMetadatasId,
                        principalTable: "ExternalSeriesMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAnnotation_AppUserId",
                table: "AppUserAnnotation",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAnnotation_ChapterId",
                table: "AppUserAnnotation",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAnnotation_LibraryId",
                table: "AppUserAnnotation",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAnnotation_SeriesId",
                table: "AppUserAnnotation",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAuthKey_AppUserId",
                table: "AppUserAuthKey",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAuthKey_ExpiresAtUtc",
                table: "AppUserAuthKey",
                column: "ExpiresAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAuthKey_Key",
                table: "AppUserAuthKey",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserBookmark_AppUserId_SeriesId",
                table: "AppUserBookmark",
                columns: new[] { "AppUserId", "SeriesId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserBookmark_ChapterId",
                table: "AppUserBookmark",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserBookmark_SeriesId",
                table: "AppUserBookmark",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserBookmark_VolumeId",
                table: "AppUserBookmark",
                column: "VolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserChapterRating_AppUserId",
                table: "AppUserChapterRating",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserChapterRating_ChapterId",
                table: "AppUserChapterRating",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserChapterRating_SeriesId",
                table: "AppUserChapterRating",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserCollection_AppUserId",
                table: "AppUserCollection",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserCollectionSeries_ItemsId",
                table: "AppUserCollectionSeries",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDashboardStream_AppUserId",
                table: "AppUserDashboardStream",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDashboardStream_SmartFilterId",
                table: "AppUserDashboardStream",
                column: "SmartFilterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDashboardStream_Visible",
                table: "AppUserDashboardStream",
                column: "Visible");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserExternalSource_AppUserId",
                table: "AppUserExternalSource",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserLibrary_LibrariesId",
                table: "AppUserLibrary",
                column: "LibrariesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserOnDeckRemoval_AppUserId",
                table: "AppUserOnDeckRemoval",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserOnDeckRemoval_SeriesId",
                table: "AppUserOnDeckRemoval",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPreferences_AppUserId",
                table: "AppUserPreferences",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPreferences_ThemeId",
                table: "AppUserPreferences",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProgresses_AppUserId",
                table: "AppUserProgresses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProgresses_ChapterId",
                table: "AppUserProgresses",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProgresses_SeriesId",
                table: "AppUserProgresses",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRating_AppUserId",
                table: "AppUserRating",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRating_SeriesId",
                table: "AppUserRating",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserReadingHistory_AppUserId",
                table: "AppUserReadingHistory",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserReadingHistory_DateUtc",
                table: "AppUserReadingHistory",
                column: "DateUtc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserReadingProfiles_AppUserId",
                table: "AppUserReadingProfiles",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserReadingSession_AppUserId",
                table: "AppUserReadingSession",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserReadingSession_IsActive",
                table: "AppUserReadingSession",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserReadingSessionActivityData_AppUserReadingSessionId",
                table: "AppUserReadingSessionActivityData",
                column: "AppUserReadingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserReadingSessionActivityData_ChapterId",
                table: "AppUserReadingSessionActivityData",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserReadingSessionActivityData_SeriesId",
                table: "AppUserReadingSessionActivityData",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSideNavStream_AppUserId",
                table: "AppUserSideNavStream",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSideNavStream_SmartFilterId",
                table: "AppUserSideNavStream",
                column: "SmartFilterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSideNavStream_Visible",
                table: "AppUserSideNavStream",
                column: "Visible");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSmartFilter_AppUserId",
                table: "AppUserSmartFilter",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTableOfContent_AppUserId",
                table: "AppUserTableOfContent",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTableOfContent_ChapterId",
                table: "AppUserTableOfContent",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTableOfContent_SeriesId",
                table: "AppUserTableOfContent",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserWantToRead_AppUserId",
                table: "AppUserWantToRead",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserWantToRead_SeriesId",
                table: "AppUserWantToRead",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_TitleName",
                table: "Chapter",
                column: "TitleName");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_VolumeId",
                table: "Chapter",
                column: "VolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterGenre_GenresId",
                table: "ChapterGenre",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPeople_PersonId",
                table: "ChapterPeople",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterTag_TagsId",
                table: "ChapterTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDevice_AppUserId",
                table: "ClientDevice",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeviceHistory_DeviceId",
                table: "ClientDeviceHistory",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionTag_Id_Promoted",
                table: "CollectionTag",
                columns: new[] { "Id", "Promoted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollectionTagSeriesMetadata_SeriesMetadatasId",
                table: "CollectionTagSeriesMetadata",
                column: "SeriesMetadatasId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_AppUserId",
                table: "Device",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailHistory_AppUserId",
                table: "EmailHistory",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailHistory_Sent_AppUserId_EmailTemplate_SendDate",
                table: "EmailHistory",
                columns: new[] { "Sent", "AppUserId", "EmailTemplate", "SendDate" });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalRating_ChapterId",
                table: "ExternalRating",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalRatingExternalSeriesMetadata_ExternalSeriesMetadata~",
                table: "ExternalRatingExternalSeriesMetadata",
                column: "ExternalSeriesMetadatasId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalRecommendation_SeriesId",
                table: "ExternalRecommendation",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalRecommendationExternalSeriesMetadata_ExternalSeries~",
                table: "ExternalRecommendationExternalSeriesMetadata",
                column: "ExternalSeriesMetadatasId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalReview_ChapterId",
                table: "ExternalReview",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalReviewExternalSeriesMetadata_ExternalSeriesMetadata~",
                table: "ExternalReviewExternalSeriesMetadata",
                column: "ExternalSeriesMetadatasId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalSeriesMetadata_SeriesId",
                table: "ExternalSeriesMetadata",
                column: "SeriesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FolderPath_LibraryId",
                table: "FolderPath",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_NormalizedTitle",
                table: "Genre",
                column: "NormalizedTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenreSeriesMetadata_SeriesMetadatasId",
                table: "GenreSeriesMetadata",
                column: "SeriesMetadatasId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryExcludePattern_LibraryId",
                table: "LibraryExcludePattern",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryFileTypeGroup_LibraryId",
                table: "LibraryFileTypeGroup",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaFile_ChapterId",
                table: "MangaFile",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaFile_FilePath",
                table: "MangaFile",
                column: "FilePath");

            migrationBuilder.CreateIndex(
                name: "IX_MetadataFieldMapping_MetadataSettingsId",
                table: "MetadataFieldMapping",
                column: "MetadataSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAlias_PersonId",
                table: "PersonAlias",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingList_AppUserId",
                table: "ReadingList",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingListItem_ChapterId",
                table: "ReadingListItem",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingListItem_ReadingListId",
                table: "ReadingListItem",
                column: "ReadingListId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingListItem_SeriesId",
                table: "ReadingListItem",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingListItem_VolumeId",
                table: "ReadingListItem",
                column: "VolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrobbleError_ScrobbleEventId1",
                table: "ScrobbleError",
                column: "ScrobbleEventId1");

            migrationBuilder.CreateIndex(
                name: "IX_ScrobbleError_SeriesId",
                table: "ScrobbleError",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrobbleEvent_AppUserId",
                table: "ScrobbleEvent",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrobbleEvent_LibraryId",
                table: "ScrobbleEvent",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrobbleEvent_SeriesId",
                table: "ScrobbleEvent",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrobbleHold_AppUserId",
                table: "ScrobbleHold",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrobbleHold_SeriesId",
                table: "ScrobbleHold",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_LibraryId",
                table: "Series",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_NormalizedName",
                table: "Series",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesBlacklist_SeriesId",
                table: "SeriesBlacklist",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesMetadata_AgeRating",
                table: "SeriesMetadata",
                column: "AgeRating");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesMetadata_Id_SeriesId",
                table: "SeriesMetadata",
                columns: new[] { "Id", "SeriesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeriesMetadata_SeriesId",
                table: "SeriesMetadata",
                column: "SeriesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeriesMetadata_SeriesId_AgeRating",
                table: "SeriesMetadata",
                columns: new[] { "SeriesId", "AgeRating" });

            migrationBuilder.CreateIndex(
                name: "IX_SeriesMetadataPeople_PersonId",
                table: "SeriesMetadataPeople",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesMetadataTag_TagsId",
                table: "SeriesMetadataTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesRelation_SeriesId",
                table: "SeriesRelation",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesRelation_TargetSeriesId",
                table: "SeriesRelation",
                column: "TargetSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_NormalizedTitle",
                table: "Tag",
                column: "NormalizedTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volume_SeriesId",
                table: "Volume",
                column: "SeriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserAnnotation");

            migrationBuilder.DropTable(
                name: "AppUserAuthKey");

            migrationBuilder.DropTable(
                name: "AppUserBookmark");

            migrationBuilder.DropTable(
                name: "AppUserChapterRating");

            migrationBuilder.DropTable(
                name: "AppUserCollectionSeries");

            migrationBuilder.DropTable(
                name: "AppUserDashboardStream");

            migrationBuilder.DropTable(
                name: "AppUserExternalSource");

            migrationBuilder.DropTable(
                name: "AppUserLibrary");

            migrationBuilder.DropTable(
                name: "AppUserOnDeckRemoval");

            migrationBuilder.DropTable(
                name: "AppUserPreferences");

            migrationBuilder.DropTable(
                name: "AppUserProgresses");

            migrationBuilder.DropTable(
                name: "AppUserRating");

            migrationBuilder.DropTable(
                name: "AppUserReadingHistory");

            migrationBuilder.DropTable(
                name: "AppUserReadingProfiles");

            migrationBuilder.DropTable(
                name: "AppUserReadingSessionActivityData");

            migrationBuilder.DropTable(
                name: "AppUserSideNavStream");

            migrationBuilder.DropTable(
                name: "AppUserTableOfContent");

            migrationBuilder.DropTable(
                name: "AppUserWantToRead");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChapterGenre");

            migrationBuilder.DropTable(
                name: "ChapterPeople");

            migrationBuilder.DropTable(
                name: "ChapterTag");

            migrationBuilder.DropTable(
                name: "ClientDeviceHistory");

            migrationBuilder.DropTable(
                name: "CollectionTagSeriesMetadata");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "EmailHistory");

            migrationBuilder.DropTable(
                name: "EpubFont");

            migrationBuilder.DropTable(
                name: "ExternalRatingExternalSeriesMetadata");

            migrationBuilder.DropTable(
                name: "ExternalRecommendationExternalSeriesMetadata");

            migrationBuilder.DropTable(
                name: "ExternalReviewExternalSeriesMetadata");

            migrationBuilder.DropTable(
                name: "FolderPath");

            migrationBuilder.DropTable(
                name: "GenreSeriesMetadata");

            migrationBuilder.DropTable(
                name: "LibraryExcludePattern");

            migrationBuilder.DropTable(
                name: "LibraryFileTypeGroup");

            migrationBuilder.DropTable(
                name: "MangaFile");

            migrationBuilder.DropTable(
                name: "ManualMigrationHistory");

            migrationBuilder.DropTable(
                name: "MediaError");

            migrationBuilder.DropTable(
                name: "MetadataFieldMapping");

            migrationBuilder.DropTable(
                name: "PersonAlias");

            migrationBuilder.DropTable(
                name: "ReadingListItem");

            migrationBuilder.DropTable(
                name: "ScrobbleError");

            migrationBuilder.DropTable(
                name: "ScrobbleHold");

            migrationBuilder.DropTable(
                name: "SeriesBlacklist");

            migrationBuilder.DropTable(
                name: "SeriesMetadataPeople");

            migrationBuilder.DropTable(
                name: "SeriesMetadataTag");

            migrationBuilder.DropTable(
                name: "SeriesRelation");

            migrationBuilder.DropTable(
                name: "ServerSetting");

            migrationBuilder.DropTable(
                name: "ServerStatistics");

            migrationBuilder.DropTable(
                name: "AppUserCollection");

            migrationBuilder.DropTable(
                name: "SiteTheme");

            migrationBuilder.DropTable(
                name: "AppUserReadingSession");

            migrationBuilder.DropTable(
                name: "AppUserSmartFilter");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ClientDevice");

            migrationBuilder.DropTable(
                name: "CollectionTag");

            migrationBuilder.DropTable(
                name: "ExternalRating");

            migrationBuilder.DropTable(
                name: "ExternalRecommendation");

            migrationBuilder.DropTable(
                name: "ExternalReview");

            migrationBuilder.DropTable(
                name: "ExternalSeriesMetadata");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "MetadataSettings");

            migrationBuilder.DropTable(
                name: "ReadingList");

            migrationBuilder.DropTable(
                name: "ScrobbleEvent");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "SeriesMetadata");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Volume");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Library");
        }
    }
}
