using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Eventos.Modelos;

    public class AppContext : DbContext
    {
        public AppContext (DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<Eventos.Modelos.Asistente> Asistentes { get; set; } = default!;

public DbSet<Eventos.Modelos.Certificado> Certificados { get; set; } = default!;

public DbSet<Eventos.Modelos.CertificadoAsistente> CertificadosAsistentes { get; set; } = default!;

public DbSet<Eventos.Modelos.CertificadoPonente> CertificadosPonentes { get; set; } = default!;

public DbSet<Eventos.Modelos.EspacioAsignado> EspaciosAsignados { get; set; } = default!;

public DbSet<Eventos.Modelos.Evento> Eventos { get; set; } = default!;

public DbSet<Eventos.Modelos.EventoEnLugarAsignado> EventosEnLugaresAsignados { get; set; } = default!;

public DbSet<Eventos.Modelos.Inscripcion> Inscripciones { get; set; } = default!;

public DbSet<Eventos.Modelos.InscripcionAsistente> InscripcionesAsistentes { get; set; } = default!;

public DbSet<Eventos.Modelos.InscripcionPonente> InscripcionesPonentes { get; set; } = default!;

public DbSet<Eventos.Modelos.Pago> Pagos { get; set; } = default!;

public DbSet<Eventos.Modelos.Ponente> Ponentes { get; set; } = default!;

public DbSet<Eventos.Modelos.PonenteEvento> PonentesEventos { get; set; } = default!;
    }
