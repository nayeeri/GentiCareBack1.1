using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GentilCareBack.Models.Migrations
{
    public partial class MigrationSqlServerInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidads",
                columns: table => new
                {
                    EspecialidadsId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    especialidad = table.Column<string>(nullable: true),
                    costo = table.Column<decimal>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidads", x => x.EspecialidadsId);
                });

            migrationBuilder.CreateTable(
                name: "Farmacos",
                columns: table => new
                {
                    FarmacosId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    farmaco = table.Column<string>(nullable: true),
                    aplicacion = table.Column<string>(nullable: true),
                    frecuencia = table.Column<string>(nullable: true),
                    duracion = table.Column<string>(maxLength: 10, nullable: true),
                    modoAplicacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmacos", x => x.FarmacosId);
                });

            migrationBuilder.CreateTable(
                name: "Motivos",
                columns: table => new
                {
                    MotivosId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idServicio = table.Column<long>(nullable: false),
                    motivo = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivos", x => x.MotivosId);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    RecetasId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proxima_cita = table.Column<DateTime>(nullable: false),
                    indicaciones = table.Column<string>(nullable: true),
                    estudio_banco = table.Column<long>(nullable: false),
                    observacion = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.RecetasId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolesId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolesId);
                });

            migrationBuilder.CreateTable(
                name: "Signosvitales",
                columns: table => new
                {
                    SignosvitalesId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    presionArterial = table.Column<string>(nullable: true),
                    frecuenciaRespiratoria = table.Column<string>(nullable: true),
                    frecuenciaCardiaca = table.Column<string>(nullable: true),
                    temperatura = table.Column<string>(nullable: true),
                    glucosa = table.Column<string>(nullable: true),
                    saturacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signosvitales", x => x.SignosvitalesId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UsersId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(maxLength: 350, nullable: true),
                    name = table.Column<string>(nullable: true),
                    firsname = table.Column<string>(maxLength: 35, nullable: true),
                    lastname = table.Column<string>(maxLength: 35, nullable: true),
                    filename = table.Column<string>(nullable: true),
                    birthday = table.Column<DateTime>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    cellphone = table.Column<string>(maxLength: 20, nullable: true),
                    especialidades = table.Column<string>(nullable: true),
                    customerID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UsersId);
                });

            migrationBuilder.CreateTable(
                name: "Estudios",
                columns: table => new
                {
                    EstudiosId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    identificador = table.Column<string>(nullable: true),
                    estudio = table.Column<string>(nullable: true),
                    descripcion = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    nombre = table.Column<string>(maxLength: 250, nullable: true),
                    created_at = table.Column<DateTime>(nullable: true),
                    RecetasId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudios", x => x.EstudiosId);
                    table.ForeignKey(
                        name: "FK_Estudios_Recetas_RecetasId",
                        column: x => x.RecetasId,
                        principalTable: "Recetas",
                        principalColumn: "RecetasId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ServiciosId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    costo = table.Column<decimal>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    FarmacosId = table.Column<long>(nullable: false),
                    SignosvitalesId = table.Column<long>(nullable: false),
                    RecetasId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServiciosId);
                    table.ForeignKey(
                        name: "FK_Servicios_Farmacos_FarmacosId",
                        column: x => x.FarmacosId,
                        principalTable: "Farmacos",
                        principalColumn: "FarmacosId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicios_Recetas_RecetasId",
                        column: x => x.RecetasId,
                        principalTable: "Recetas",
                        principalColumn: "RecetasId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_Signosvitales_SignosvitalesId",
                        column: x => x.SignosvitalesId,
                        principalTable: "Signosvitales",
                        principalColumn: "SignosvitalesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressesId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<long>(nullable: true),
                    calle = table.Column<string>(nullable: true),
                    exterior = table.Column<string>(nullable: true),
                    interior = table.Column<string>(nullable: true),
                    colonia = table.Column<string>(nullable: true),
                    municipio = table.Column<string>(nullable: true),
                    ciudad = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    cp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressesId);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Auths",
                columns: table => new
                {
                    AuthsId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolesId = table.Column<long>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    verified = table.Column<bool>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: true),
                    UsersId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auths", x => x.AuthsId);
                    table.ForeignKey(
                        name: "FK_Auths_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "RolesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Auths_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradors",
                columns: table => new
                {
                    ColaboradorsId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<long>(nullable: true),
                    costoConsulta = table.Column<decimal>(nullable: false),
                    cedula = table.Column<string>(nullable: true),
                    address_fiscal = table.Column<string>(nullable: true),
                    rfc = table.Column<string>(maxLength: 20, nullable: true),
                    especialidad = table.Column<string>(maxLength: 250, nullable: true),
                    plataforma = table.Column<string>(maxLength: 250, nullable: true),
                    tel_fijo = table.Column<string>(maxLength: 20, nullable: true),
                    pacientes = table.Column<string>(maxLength: 250, nullable: true),
                    observacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradors", x => x.ColaboradorsId);
                    table.ForeignKey(
                        name: "FK_Colaboradors_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    PreguntasId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<long>(nullable: true),
                    respuestaUno = table.Column<string>(maxLength: 300, nullable: true),
                    respuestaDos = table.Column<string>(maxLength: 300, nullable: true),
                    respuestaTres = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.PreguntasId);
                    table.ForeignKey(
                        name: "FK_Preguntas_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Interrogatorios",
                columns: table => new
                {
                    InterrogatoriosId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiciosId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interrogatorios", x => x.InterrogatoriosId);
                    table.ForeignKey(
                        name: "FK_Interrogatorios_Servicios_ServiciosId",
                        column: x => x.ServiciosId,
                        principalTable: "Servicios",
                        principalColumn: "ServiciosId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AparatoRespiratorio",
                columns: table => new
                {
                    AparatoRespiratorioId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    valor = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    InterrogatoriosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AparatoRespiratorio", x => x.AparatoRespiratorioId);
                    table.ForeignKey(
                        name: "FK_AparatoRespiratorio_Interrogatorios_InterrogatoriosId",
                        column: x => x.InterrogatoriosId,
                        principalTable: "Interrogatorios",
                        principalColumn: "InterrogatoriosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardioVascular",
                columns: table => new
                {
                    CardioVascularId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    valor = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    InterrogatoriosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardioVascular", x => x.CardioVascularId);
                    table.ForeignKey(
                        name: "FK_CardioVascular_Interrogatorios_InterrogatoriosId",
                        column: x => x.InterrogatoriosId,
                        principalTable: "Interrogatorios",
                        principalColumn: "InterrogatoriosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Esfera_Psiquica",
                columns: table => new
                {
                    Esfera_PsiquicaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    valor = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(maxLength: 350, nullable: true),
                    InterrogatoriosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esfera_Psiquica", x => x.Esfera_PsiquicaId);
                    table.ForeignKey(
                        name: "FK_Esfera_Psiquica_Interrogatorios_InterrogatoriosId",
                        column: x => x.InterrogatoriosId,
                        principalTable: "Interrogatorios",
                        principalColumn: "InterrogatoriosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PielTegumentos",
                columns: table => new
                {
                    PielTegumentosId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 250, nullable: true),
                    valor = table.Column<bool>(nullable: false),
                    InterrogatoriosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PielTegumentos", x => x.PielTegumentosId);
                    table.ForeignKey(
                        name: "FK_PielTegumentos_Interrogatorios_InterrogatoriosId",
                        column: x => x.InterrogatoriosId,
                        principalTable: "Interrogatorios",
                        principalColumn: "InterrogatoriosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sentidos",
                columns: table => new
                {
                    SentidosId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    valor = table.Column<bool>(nullable: false),
                    InterrogatoriosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentidos", x => x.SentidosId);
                    table.ForeignKey(
                        name: "FK_Sentidos_Interrogatorios_InterrogatoriosId",
                        column: x => x.InterrogatoriosId,
                        principalTable: "Interrogatorios",
                        principalColumn: "InterrogatoriosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SintomasGenerales",
                columns: table => new
                {
                    SintomasGeneralesId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 250, nullable: true),
                    valor = table.Column<bool>(nullable: false),
                    InterrogatoriosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SintomasGenerales", x => x.SintomasGeneralesId);
                    table.ForeignKey(
                        name: "FK_SintomasGenerales_Interrogatorios_InterrogatoriosId",
                        column: x => x.InterrogatoriosId,
                        principalTable: "Interrogatorios",
                        principalColumn: "InterrogatoriosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SistemaDigestivo",
                columns: table => new
                {
                    SistemaDigestivoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    valor = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(maxLength: 350, nullable: true),
                    InterrogatoriosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaDigestivo", x => x.SistemaDigestivoId);
                    table.ForeignKey(
                        name: "FK_SistemaDigestivo_Interrogatorios_InterrogatoriosId",
                        column: x => x.InterrogatoriosId,
                        principalTable: "Interrogatorios",
                        principalColumn: "InterrogatoriosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SistemaEmatopoyetico",
                columns: table => new
                {
                    SistemaEmatopoyeticoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    valor = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(maxLength: 350, nullable: true),
                    InterrogatoriosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaEmatopoyetico", x => x.SistemaEmatopoyeticoId);
                    table.ForeignKey(
                        name: "FK_SistemaEmatopoyetico_Interrogatorios_InterrogatoriosId",
                        column: x => x.InterrogatoriosId,
                        principalTable: "Interrogatorios",
                        principalColumn: "InterrogatoriosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SistemaEndocrino",
                columns: table => new
                {
                    SistemaEndocrinoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    valor = table.Column<bool>(nullable: false),
                    InterrogatoriosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaEndocrino", x => x.SistemaEndocrinoId);
                    table.ForeignKey(
                        name: "FK_SistemaEndocrino_Interrogatorios_InterrogatoriosId",
                        column: x => x.InterrogatoriosId,
                        principalTable: "Interrogatorios",
                        principalColumn: "InterrogatoriosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SistemaMusculoEsqueletico",
                columns: table => new
                {
                    SistemaMusculoEsqueleticoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    valor = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(maxLength: 350, nullable: true),
                    InterrogatoriosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaMusculoEsqueletico", x => x.SistemaMusculoEsqueleticoId);
                    table.ForeignKey(
                        name: "FK_SistemaMusculoEsqueletico_Interrogatorios_InterrogatoriosId",
                        column: x => x.InterrogatoriosId,
                        principalTable: "Interrogatorios",
                        principalColumn: "InterrogatoriosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SistemaNervioso",
                columns: table => new
                {
                    SistemaNerviosoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    valor = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(maxLength: 350, nullable: true),
                    InterrogatoriosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaNervioso", x => x.SistemaNerviosoId);
                    table.ForeignKey(
                        name: "FK_SistemaNervioso_Interrogatorios_InterrogatoriosId",
                        column: x => x.InterrogatoriosId,
                        principalTable: "Interrogatorios",
                        principalColumn: "InterrogatoriosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UsersId",
                table: "Addresses",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AparatoRespiratorio_InterrogatoriosId",
                table: "AparatoRespiratorio",
                column: "InterrogatoriosId");

            migrationBuilder.CreateIndex(
                name: "IX_Auths_RolesId",
                table: "Auths",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Auths_UsersId",
                table: "Auths",
                column: "UsersId",
                unique: true,
                filter: "[UsersId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CardioVascular_InterrogatoriosId",
                table: "CardioVascular",
                column: "InterrogatoriosId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradors_UsersId",
                table: "Colaboradors",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Esfera_Psiquica_InterrogatoriosId",
                table: "Esfera_Psiquica",
                column: "InterrogatoriosId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudios_RecetasId",
                table: "Estudios",
                column: "RecetasId");

            migrationBuilder.CreateIndex(
                name: "IX_Interrogatorios_ServiciosId",
                table: "Interrogatorios",
                column: "ServiciosId");

            migrationBuilder.CreateIndex(
                name: "IX_PielTegumentos_InterrogatoriosId",
                table: "PielTegumentos",
                column: "InterrogatoriosId");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_UsersId",
                table: "Preguntas",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Sentidos_InterrogatoriosId",
                table: "Sentidos",
                column: "InterrogatoriosId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_FarmacosId",
                table: "Servicios",
                column: "FarmacosId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_RecetasId",
                table: "Servicios",
                column: "RecetasId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_SignosvitalesId",
                table: "Servicios",
                column: "SignosvitalesId");

            migrationBuilder.CreateIndex(
                name: "IX_SintomasGenerales_InterrogatoriosId",
                table: "SintomasGenerales",
                column: "InterrogatoriosId");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaDigestivo_InterrogatoriosId",
                table: "SistemaDigestivo",
                column: "InterrogatoriosId");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaEmatopoyetico_InterrogatoriosId",
                table: "SistemaEmatopoyetico",
                column: "InterrogatoriosId");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaEndocrino_InterrogatoriosId",
                table: "SistemaEndocrino",
                column: "InterrogatoriosId");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaMusculoEsqueletico_InterrogatoriosId",
                table: "SistemaMusculoEsqueletico",
                column: "InterrogatoriosId");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaNervioso_InterrogatoriosId",
                table: "SistemaNervioso",
                column: "InterrogatoriosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AparatoRespiratorio");

            migrationBuilder.DropTable(
                name: "Auths");

            migrationBuilder.DropTable(
                name: "CardioVascular");

            migrationBuilder.DropTable(
                name: "Colaboradors");

            migrationBuilder.DropTable(
                name: "Esfera_Psiquica");

            migrationBuilder.DropTable(
                name: "Especialidads");

            migrationBuilder.DropTable(
                name: "Estudios");

            migrationBuilder.DropTable(
                name: "Motivos");

            migrationBuilder.DropTable(
                name: "PielTegumentos");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "Sentidos");

            migrationBuilder.DropTable(
                name: "SintomasGenerales");

            migrationBuilder.DropTable(
                name: "SistemaDigestivo");

            migrationBuilder.DropTable(
                name: "SistemaEmatopoyetico");

            migrationBuilder.DropTable(
                name: "SistemaEndocrino");

            migrationBuilder.DropTable(
                name: "SistemaMusculoEsqueletico");

            migrationBuilder.DropTable(
                name: "SistemaNervioso");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Interrogatorios");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Farmacos");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Signosvitales");
        }
    }
}
