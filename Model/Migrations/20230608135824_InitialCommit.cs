using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MACHINE_ASSETS",
                columns: table => new
                {
                    MACHINEASSETID = table.Column<int>(name: "MACHINE_ASSET_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MACHINE_ASSETS", x => x.MACHINEASSETID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MUSCLE_ASSETS",
                columns: table => new
                {
                    MUSCLEASSETID = table.Column<int>(name: "MUSCLE_ASSET_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUSCLE_ASSETS", x => x.MUSCLEASSETID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ROLEID = table.Column<int>(name: "ROLE_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDENTIFIER = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ROLEID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    USERID = table.Column<int>(name: "USER_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    USERNAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PASSWORDHASH = table.Column<string>(name: "PASSWORD_HASH", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USERID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKOUT_ASSETS",
                columns: table => new
                {
                    WORKOUTASSETID = table.Column<int>(name: "WORKOUT_ASSET_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUT_ASSETS", x => x.WORKOUTASSETID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXERCISE_ASSETS",
                columns: table => new
                {
                    EXERCISEASSETID = table.Column<int>(name: "EXERCISE_ASSET_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MACHINEASSETID = table.Column<int>(name: "MACHINE_ASSET_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISE_ASSETS", x => x.EXERCISEASSETID);
                    table.ForeignKey(
                        name: "FK_EXERCISE_ASSETS_MACHINE_ASSETS_MACHINE_ASSET_ID",
                        column: x => x.MACHINEASSETID,
                        principalTable: "MACHINE_ASSETS",
                        principalColumn: "MACHINE_ASSET_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXERCISES",
                columns: table => new
                {
                    EXERCISEID = table.Column<int>(name: "EXERCISE_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MACHINEASSETID = table.Column<int>(name: "MACHINE_ASSET_ID", type: "int", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USERID = table.Column<int>(name: "USER_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISES", x => x.EXERCISEID);
                    table.ForeignKey(
                        name: "FK_EXERCISES_MACHINE_ASSETS_MACHINE_ASSET_ID",
                        column: x => x.MACHINEASSETID,
                        principalTable: "MACHINE_ASSETS",
                        principalColumn: "MACHINE_ASSET_ID");
                    table.ForeignKey(
                        name: "FK_EXERCISES_USERS_USER_ID",
                        column: x => x.USERID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LOG_ENTRIES",
                columns: table => new
                {
                    LOGID = table.Column<int>(name: "LOG_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    USERID = table.Column<int>(name: "USER_ID", type: "int", nullable: false),
                    FIELDTYPE = table.Column<string>(name: "FIELD_TYPE", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CHANGEDATE = table.Column<DateOnly>(name: "CHANGE_DATE", type: "date", nullable: false),
                    OLDVALUE = table.Column<string>(name: "OLD_VALUE", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NEWVALUE = table.Column<string>(name: "NEW_VALUE", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG_ENTRIES", x => x.LOGID);
                    table.ForeignKey(
                        name: "FK_LOG_ENTRIES_USERS_USER_ID",
                        column: x => x.USERID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LOGINS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    USERID = table.Column<int>(name: "USER_ID", type: "int", nullable: false),
                    LoginStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGINS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LOGINS_USERS_USER_ID",
                        column: x => x.USERID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USER_HAS_ROLES_JT",
                columns: table => new
                {
                    USERID = table.Column<int>(name: "USER_ID", type: "int", nullable: false),
                    ROLEID = table.Column<int>(name: "ROLE_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_HAS_ROLES_JT", x => new { x.USERID, x.ROLEID });
                    table.ForeignKey(
                        name: "FK_USER_HAS_ROLES_JT_ROLES_ROLE_ID",
                        column: x => x.ROLEID,
                        principalTable: "ROLES",
                        principalColumn: "ROLE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_HAS_ROLES_JT_USERS_USER_ID",
                        column: x => x.USERID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKOUTS",
                columns: table => new
                {
                    WORKOUTID = table.Column<int>(name: "WORKOUT_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USERID = table.Column<int>(name: "USER_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUTS", x => x.WORKOUTID);
                    table.ForeignKey(
                        name: "FK_WORKOUTS_USERS_USER_ID",
                        column: x => x.USERID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT",
                columns: table => new
                {
                    EXERCISEASSETID = table.Column<int>(name: "EXERCISE_ASSET_ID", type: "int", nullable: false),
                    MUSCLEASSETID = table.Column<int>(name: "MUSCLE_ASSET_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT", x => new { x.EXERCISEASSETID, x.MUSCLEASSETID });
                    table.ForeignKey(
                        name: "FK_EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT_EXERCISE_ASSETS_EXERCISE~",
                        column: x => x.EXERCISEASSETID,
                        principalTable: "EXERCISE_ASSETS",
                        principalColumn: "EXERCISE_ASSET_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT_MUSCLE_ASSETS_MUSCLE_ASS~",
                        column: x => x.MUSCLEASSETID,
                        principalTable: "MUSCLE_ASSETS",
                        principalColumn: "MUSCLE_ASSET_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT",
                columns: table => new
                {
                    EXERCISEASSETID = table.Column<int>(name: "EXERCISE_ASSET_ID", type: "int", nullable: false),
                    WORKOUTASSETID = table.Column<int>(name: "WORKOUT_ASSET_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT", x => new { x.WORKOUTASSETID, x.EXERCISEASSETID });
                    table.ForeignKey(
                        name: "FK_WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT_EXERCISE_ASSETS_EXERCIS~",
                        column: x => x.EXERCISEASSETID,
                        principalTable: "EXERCISE_ASSETS",
                        principalColumn: "EXERCISE_ASSET_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT_WORKOUT_ASSETS_WORKOUT_~",
                        column: x => x.WORKOUTASSETID,
                        principalTable: "WORKOUT_ASSETS",
                        principalColumn: "WORKOUT_ASSET_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ACTIVITIES",
                columns: table => new
                {
                    ACTIVITYID = table.Column<int>(name: "ACTIVITY_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EXERCISEID = table.Column<int>(name: "EXERCISE_ID", type: "int", nullable: false),
                    DATE = table.Column<DateOnly>(type: "date", nullable: false),
                    WEIGHT = table.Column<float>(type: "float", nullable: false),
                    REPETITION = table.Column<int>(type: "int", nullable: false),
                    SET = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTIVITIES", x => x.ACTIVITYID);
                    table.ForeignKey(
                        name: "FK_ACTIVITIES_EXERCISES_EXERCISE_ID",
                        column: x => x.EXERCISEID,
                        principalTable: "EXERCISES",
                        principalColumn: "EXERCISE_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXERCISE_HAS_MUSCLE_ASSETS_JT",
                columns: table => new
                {
                    EXERCISEID = table.Column<int>(name: "EXERCISE_ID", type: "int", nullable: false),
                    MUSCLEASSETID = table.Column<int>(name: "MUSCLE_ASSET_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISE_HAS_MUSCLE_ASSETS_JT", x => new { x.EXERCISEID, x.MUSCLEASSETID });
                    table.ForeignKey(
                        name: "FK_EXERCISE_HAS_MUSCLE_ASSETS_JT_EXERCISES_EXERCISE_ID",
                        column: x => x.EXERCISEID,
                        principalTable: "EXERCISES",
                        principalColumn: "EXERCISE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXERCISE_HAS_MUSCLE_ASSETS_JT_MUSCLE_ASSETS_MUSCLE_ASSET_ID",
                        column: x => x.MUSCLEASSETID,
                        principalTable: "MUSCLE_ASSETS",
                        principalColumn: "MUSCLE_ASSET_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKOUT_HAS_EXERCISES_JT",
                columns: table => new
                {
                    EXERCISEID = table.Column<int>(name: "EXERCISE_ID", type: "int", nullable: false),
                    WORKOUTID = table.Column<int>(name: "WORKOUT_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUT_HAS_EXERCISES_JT", x => new { x.EXERCISEID, x.WORKOUTID });
                    table.ForeignKey(
                        name: "FK_WORKOUT_HAS_EXERCISES_JT_EXERCISES_EXERCISE_ID",
                        column: x => x.EXERCISEID,
                        principalTable: "EXERCISES",
                        principalColumn: "EXERCISE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WORKOUT_HAS_EXERCISES_JT_WORKOUTS_WORKOUT_ID",
                        column: x => x.WORKOUTID,
                        principalTable: "WORKOUTS",
                        principalColumn: "WORKOUT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ROLES",
                columns: new[] { "ROLE_ID", "DESCRIPTION", "IDENTIFIER" },
                values: new object[] { 1, "Administrator", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITIES_EXERCISE_ID",
                table: "ACTIVITIES",
                column: "EXERCISE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT_MUSCLE_ASSET_ID",
                table: "EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT",
                column: "MUSCLE_ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISE_ASSETS_MACHINE_ASSET_ID",
                table: "EXERCISE_ASSETS",
                column: "MACHINE_ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISE_HAS_MUSCLE_ASSETS_JT_MUSCLE_ASSET_ID",
                table: "EXERCISE_HAS_MUSCLE_ASSETS_JT",
                column: "MUSCLE_ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISES_MACHINE_ASSET_ID",
                table: "EXERCISES",
                column: "MACHINE_ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISES_USER_ID",
                table: "EXERCISES",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOG_ENTRIES_USER_ID",
                table: "LOG_ENTRIES",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOGINS_USER_ID",
                table: "LOGINS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ROLES_IDENTIFIER",
                table: "ROLES",
                column: "IDENTIFIER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_HAS_ROLES_JT_ROLE_ID",
                table: "USER_HAS_ROLES_JT",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_EMAIL",
                table: "USERS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT_EXERCISE_ASSET_ID",
                table: "WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT",
                column: "EXERCISE_ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WORKOUT_HAS_EXERCISES_JT_WORKOUT_ID",
                table: "WORKOUT_HAS_EXERCISES_JT",
                column: "WORKOUT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WORKOUTS_USER_ID",
                table: "WORKOUTS",
                column: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACTIVITIES");

            migrationBuilder.DropTable(
                name: "EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT");

            migrationBuilder.DropTable(
                name: "EXERCISE_HAS_MUSCLE_ASSETS_JT");

            migrationBuilder.DropTable(
                name: "LOG_ENTRIES");

            migrationBuilder.DropTable(
                name: "LOGINS");

            migrationBuilder.DropTable(
                name: "USER_HAS_ROLES_JT");

            migrationBuilder.DropTable(
                name: "WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT");

            migrationBuilder.DropTable(
                name: "WORKOUT_HAS_EXERCISES_JT");

            migrationBuilder.DropTable(
                name: "MUSCLE_ASSETS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "EXERCISE_ASSETS");

            migrationBuilder.DropTable(
                name: "WORKOUT_ASSETS");

            migrationBuilder.DropTable(
                name: "EXERCISES");

            migrationBuilder.DropTable(
                name: "WORKOUTS");

            migrationBuilder.DropTable(
                name: "MACHINE_ASSETS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
