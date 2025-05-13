using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventos.API.Migrations
{
    /// <inheritdoc />
    public partial class v1Eventos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asistentes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistentes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "EspaciosAsignados",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Espacio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspaciosAsignados", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Ponentes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponentes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventoCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Certificados_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventosEnLugaresAsignados",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoCodigo = table.Column<int>(type: "int", nullable: false),
                    EspacioAsignadoCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosEnLugaresAsignados", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_EventosEnLugaresAsignados_EspaciosAsignados_EspacioAsignadoCodigo",
                        column: x => x.EspacioAsignadoCodigo,
                        principalTable: "EspaciosAsignados",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventosEnLugaresAsignados_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoCodigo = table.Column<int>(type: "int", nullable: false),
                    FechaInicioEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinEvento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PonentesEventos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PonenteCodigo = table.Column<int>(type: "int", nullable: false),
                    EventoCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PonentesEventos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_PonentesEventos_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PonentesEventos_Ponentes_PonenteCodigo",
                        column: x => x.PonenteCodigo,
                        principalTable: "Ponentes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificadosAsistentes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificadoCodigo = table.Column<int>(type: "int", nullable: false),
                    AsistenteCodigo = table.Column<int>(type: "int", nullable: false),
                    Asistencia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificadosAsistentes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_CertificadosAsistentes_Asistentes_AsistenteCodigo",
                        column: x => x.AsistenteCodigo,
                        principalTable: "Asistentes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificadosAsistentes_Certificados_CertificadoCodigo",
                        column: x => x.CertificadoCodigo,
                        principalTable: "Certificados",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificadosPonentes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificadoCodigo = table.Column<int>(type: "int", nullable: false),
                    PonenteCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificadosPonentes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_CertificadosPonentes_Certificados_CertificadoCodigo",
                        column: x => x.CertificadoCodigo,
                        principalTable: "Certificados",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificadosPonentes_Ponentes_PonenteCodigo",
                        column: x => x.PonenteCodigo,
                        principalTable: "Ponentes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InscripcionesAsistentes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AsistenteCodigo = table.Column<int>(type: "int", nullable: false),
                    InscripcionCodigo = table.Column<int>(type: "int", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscripcionesAsistentes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_InscripcionesAsistentes_Asistentes_AsistenteCodigo",
                        column: x => x.AsistenteCodigo,
                        principalTable: "Asistentes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InscripcionesAsistentes_Inscripciones_InscripcionCodigo",
                        column: x => x.InscripcionCodigo,
                        principalTable: "Inscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InscripcionesPonentes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InscripcionCodigo = table.Column<int>(type: "int", nullable: false),
                    PonenteCodigo = table.Column<int>(type: "int", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscripcionesPonentes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_InscripcionesPonentes_Inscripciones_InscripcionCodigo",
                        column: x => x.InscripcionCodigo,
                        principalTable: "Inscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InscripcionesPonentes_Ponentes_PonenteCodigo",
                        column: x => x.PonenteCodigo,
                        principalTable: "Ponentes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InscripcionAsistenteCodigo = table.Column<int>(type: "int", nullable: false),
                    TipoDePago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Pagos_InscripcionesAsistentes_InscripcionAsistenteCodigo",
                        column: x => x.InscripcionAsistenteCodigo,
                        principalTable: "InscripcionesAsistentes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_EventoCodigo",
                table: "Certificados",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_CertificadosAsistentes_AsistenteCodigo",
                table: "CertificadosAsistentes",
                column: "AsistenteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_CertificadosAsistentes_CertificadoCodigo",
                table: "CertificadosAsistentes",
                column: "CertificadoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_CertificadosPonentes_CertificadoCodigo",
                table: "CertificadosPonentes",
                column: "CertificadoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_CertificadosPonentes_PonenteCodigo",
                table: "CertificadosPonentes",
                column: "PonenteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_EventosEnLugaresAsignados_EspacioAsignadoCodigo",
                table: "EventosEnLugaresAsignados",
                column: "EspacioAsignadoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_EventosEnLugaresAsignados_EventoCodigo",
                table: "EventosEnLugaresAsignados",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EventoCodigo",
                table: "Inscripciones",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionesAsistentes_AsistenteCodigo",
                table: "InscripcionesAsistentes",
                column: "AsistenteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionesAsistentes_InscripcionCodigo",
                table: "InscripcionesAsistentes",
                column: "InscripcionCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionesPonentes_InscripcionCodigo",
                table: "InscripcionesPonentes",
                column: "InscripcionCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionesPonentes_PonenteCodigo",
                table: "InscripcionesPonentes",
                column: "PonenteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_InscripcionAsistenteCodigo",
                table: "Pagos",
                column: "InscripcionAsistenteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_PonentesEventos_EventoCodigo",
                table: "PonentesEventos",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_PonentesEventos_PonenteCodigo",
                table: "PonentesEventos",
                column: "PonenteCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificadosAsistentes");

            migrationBuilder.DropTable(
                name: "CertificadosPonentes");

            migrationBuilder.DropTable(
                name: "EventosEnLugaresAsignados");

            migrationBuilder.DropTable(
                name: "InscripcionesPonentes");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "PonentesEventos");

            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "EspaciosAsignados");

            migrationBuilder.DropTable(
                name: "InscripcionesAsistentes");

            migrationBuilder.DropTable(
                name: "Ponentes");

            migrationBuilder.DropTable(
                name: "Asistentes");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
