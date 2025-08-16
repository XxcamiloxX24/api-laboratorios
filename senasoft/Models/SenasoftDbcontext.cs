using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace senasoft.Models;

public partial class SenasoftDbcontext : DbContext
{
    public SenasoftDbcontext()
    {
    }

    public SenasoftDbcontext(DbContextOptions<SenasoftDbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<FacMTarjetero> FacMTarjeteros { get; set; }

    public virtual DbSet<FacPCup> FacPCups { get; set; }

    public virtual DbSet<FacPNivel> FacPNivels { get; set; }

    public virtual DbSet<FacPProfesional> FacPProfesionals { get; set; }

    public virtual DbSet<GePListaopcion> GePListaopcions { get; set; }

    public virtual DbSet<GenMPersona> GenMPersonas { get; set; }

    public virtual DbSet<GenPDocumento> GenPDocumentos { get; set; }

    public virtual DbSet<GenPEp> GenPEps { get; set; }

    public virtual DbSet<LabMOrden> LabMOrdens { get; set; }

    public virtual DbSet<LabMOrdenResultado> LabMOrdenResultados { get; set; }

    public virtual DbSet<LabPGrupo> LabPGrupos { get; set; }

    public virtual DbSet<LabPProcedimiento> LabPProcedimientos { get; set; }

    public virtual DbSet<LabPPrueba> LabPPruebas { get; set; }

    public virtual DbSet<LabPPruebasOpcione> LabPPruebasOpciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_unicode_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<FacMTarjetero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fac_m_tarjetero");

            entity.HasIndex(e => e.IdEps, "id_eps");

            entity.HasIndex(e => e.IdNivel, "id_nivel");

            entity.HasIndex(e => e.IdPersona, "id_persona");

            entity.HasIndex(e => e.IdRegimen, "id_regimen");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Historia)
                .HasMaxLength(200)
                .HasColumnName("historia");
            entity.Property(e => e.IdEps)
                .HasColumnType("int(11)")
                .HasColumnName("id_eps");
            entity.Property(e => e.IdNivel)
                .HasColumnType("int(11)")
                .HasColumnName("id_nivel");
            entity.Property(e => e.IdPersona)
                .HasColumnType("int(11)")
                .HasColumnName("id_persona");
            entity.Property(e => e.IdRegimen)
                .HasColumnType("int(11)")
                .HasColumnName("id_regimen");

            entity.HasOne(d => d.IdEpsNavigation).WithMany(p => p.FacMTarjeteros)
                .HasForeignKey(d => d.IdEps)
                .HasConstraintName("fac_m_tarjetero_ibfk_3");

            entity.HasOne(d => d.IdNivelNavigation).WithMany(p => p.FacMTarjeteros)
                .HasForeignKey(d => d.IdNivel)
                .HasConstraintName("fac_m_tarjetero_ibfk_4");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.FacMTarjeteros)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("fac_m_tarjetero_ibfk_1");

            entity.HasOne(d => d.IdRegimenNavigation).WithMany(p => p.FacMTarjeteros)
                .HasForeignKey(d => d.IdRegimen)
                .HasConstraintName("fac_m_tarjetero_ibfk_2");
        });

        modelBuilder.Entity<FacPCup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fac_p_cups");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(200)
                .HasColumnName("codigo");
            entity.Property(e => e.Habilita)
                .HasDefaultValueSql("'1'")
                .HasColumnName("habilita");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<FacPNivel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fac_p_nivel");

            entity.HasIndex(e => e.IdEps, "id_eps");

            entity.HasIndex(e => e.IdRegimen, "id_regimen");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdEps)
                .HasColumnType("int(11)")
                .HasColumnName("id_eps");
            entity.Property(e => e.IdRegimen)
                .HasColumnType("int(11)")
                .HasColumnName("id_regimen");
            entity.Property(e => e.Nivel)
                .HasMaxLength(200)
                .HasColumnName("nivel");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdEpsNavigation).WithMany(p => p.FacPNivels)
                .HasForeignKey(d => d.IdEps)
                .HasConstraintName("fac_p_nivel_ibfk_1");

            entity.HasOne(d => d.IdRegimenNavigation).WithMany(p => p.FacPNivels)
                .HasForeignKey(d => d.IdRegimen)
                .HasConstraintName("fac_p_nivel_ibfk_2");
        });

        modelBuilder.Entity<FacPProfesional>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fac_p_profesional");

            entity.HasIndex(e => e.IdPersona, "id_persona");

            entity.HasIndex(e => e.IdTipoProf, "id_tipo_prof");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(200)
                .HasColumnName("codigo");
            entity.Property(e => e.IdPersona)
                .HasColumnType("int(11)")
                .HasColumnName("id_persona");
            entity.Property(e => e.IdTipoProf)
                .HasColumnType("int(11)")
                .HasColumnName("id_tipo_prof");
            entity.Property(e => e.RegistroMedico)
                .HasMaxLength(200)
                .HasColumnName("registro_medico");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.FacPProfesionals)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("fac_p_profesional_ibfk_1");

            entity.HasOne(d => d.IdTipoProfNavigation).WithMany(p => p.FacPProfesionals)
                .HasForeignKey(d => d.IdTipoProf)
                .HasConstraintName("fac_p_profesional_ibfk_2");
        });

        modelBuilder.Entity<GePListaopcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ge_p_listaopcion");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Abreviacion)
                .HasMaxLength(200)
                .HasColumnName("abreviacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Habilita)
                .HasDefaultValueSql("'1'")
                .HasColumnName("habilita");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
            entity.Property(e => e.Valor)
                .HasColumnType("int(11)")
                .HasColumnName("valor");
            entity.Property(e => e.Variable)
                .HasMaxLength(200)
                .HasColumnName("variable");
        });

        modelBuilder.Entity<GenMPersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("gen_m_persona");

            entity.HasIndex(e => e.IdSexobiologico, "id_sexobiologico");

            entity.HasIndex(e => e.IdTipoid, "id_tipoid");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Apellido1)
                .HasMaxLength(200)
                .HasColumnName("apellido1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(200)
                .HasColumnName("apellido2");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.Fechanac).HasColumnName("fechanac");
            entity.Property(e => e.IdSexobiologico)
                .HasColumnType("int(11)")
                .HasColumnName("id_sexobiologico");
            entity.Property(e => e.IdTipoid)
                .HasColumnType("int(11)")
                .HasColumnName("id_tipoid");
            entity.Property(e => e.Nombre1)
                .HasMaxLength(200)
                .HasColumnName("nombre1");
            entity.Property(e => e.Nombre2)
                .HasMaxLength(200)
                .HasColumnName("nombre2");
            entity.Property(e => e.Numeroid)
                .HasMaxLength(200)
                .HasColumnName("numeroid");
            entity.Property(e => e.TelMovil)
                .HasMaxLength(200)
                .HasColumnName("tel_movil");

            entity.HasOne(d => d.IdSexobiologicoNavigation).WithMany(p => p.GenMPersonaIdSexobiologicoNavigations)
                .HasForeignKey(d => d.IdSexobiologico)
                .HasConstraintName("gen_m_persona_ibfk_2");

            entity.HasOne(d => d.IdTipo).WithMany(p => p.GenMPersonaIdTipos)
                .HasForeignKey(d => d.IdTipoid)
                .HasConstraintName("gen_m_persona_ibfk_1");
        });

        modelBuilder.Entity<GenPDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("gen_p_documento");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(200)
                .HasColumnName("codigo");
            entity.Property(e => e.Habilita)
                .HasDefaultValueSql("'1'")
                .HasColumnName("habilita");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<GenPEp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("gen_p_eps");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(200)
                .HasColumnName("codigo");
            entity.Property(e => e.Habilita)
                .HasDefaultValueSql("'1'")
                .HasColumnName("habilita");
            entity.Property(e => e.Nit)
                .HasMaxLength(200)
                .HasColumnName("nit");
            entity.Property(e => e.Razonsocial)
                .HasMaxLength(200)
                .HasColumnName("razonsocial");
        });

        modelBuilder.Entity<LabMOrden>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lab_m_orden");

            entity.HasIndex(e => e.IdDocumento, "id_documento");

            entity.HasIndex(e => e.IdHistoria, "id_historia");

            entity.HasIndex(e => e.IdProfesionalOrdena, "id_profesional_ordena");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdDocumento)
                .HasColumnType("int(11)")
                .HasColumnName("id_documento");
            entity.Property(e => e.IdHistoria)
                .HasColumnType("int(11)")
                .HasColumnName("id_historia");
            entity.Property(e => e.IdProfesionalOrdena)
                .HasColumnType("int(11)")
                .HasColumnName("id_profesional_ordena");
            entity.Property(e => e.Orden)
                .HasColumnType("int(11)")
                .HasColumnName("orden");
            entity.Property(e => e.ProfesionalEcterno)
                .HasDefaultValueSql("'1'")
                .HasColumnName("profesional_ecterno");

            entity.HasOne(d => d.IdDocumentoNavigation).WithMany(p => p.LabMOrdens)
                .HasForeignKey(d => d.IdDocumento)
                .HasConstraintName("lab_m_orden_ibfk_1");

            entity.HasOne(d => d.IdHistoriaNavigation).WithMany(p => p.LabMOrdens)
                .HasForeignKey(d => d.IdHistoria)
                .HasConstraintName("lab_m_orden_ibfk_2");

            entity.HasOne(d => d.IdProfesionalOrdenaNavigation).WithMany(p => p.LabMOrdens)
                .HasForeignKey(d => d.IdProfesionalOrdena)
                .HasConstraintName("lab_m_orden_ibfk_3");
        });

        modelBuilder.Entity<LabMOrdenResultado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lab_m_orden_resultados");

            entity.HasIndex(e => e.IdOrden, "id_orden");

            entity.HasIndex(e => e.IdProcedimiento, "id_procedimiento");

            entity.HasIndex(e => e.IdPrueba, "id_prueba");

            entity.HasIndex(e => e.IdPruebaopcion, "id_pruebaopcion");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdOrden)
                .HasColumnType("int(11)")
                .HasColumnName("id_orden");
            entity.Property(e => e.IdProcedimiento)
                .HasColumnType("int(11)")
                .HasColumnName("id_procedimiento");
            entity.Property(e => e.IdPrueba)
                .HasColumnType("int(11)")
                .HasColumnName("id_prueba");
            entity.Property(e => e.IdPruebaopcion)
                .HasColumnType("int(11)")
                .HasColumnName("id_pruebaopcion");
            entity.Property(e => e.NumProcesamientos)
                .HasColumnType("int(11)")
                .HasColumnName("num_procesamientos");
            entity.Property(e => e.ResMemo)
                .HasMaxLength(200)
                .HasColumnName("res_memo");
            entity.Property(e => e.ResNumerico)
                .HasColumnType("int(11)")
                .HasColumnName("res_numerico");
            entity.Property(e => e.ResOpcion)
                .HasMaxLength(200)
                .HasColumnName("res_opcion");
            entity.Property(e => e.ResTexto)
                .HasMaxLength(200)
                .HasColumnName("res_texto");

            entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.LabMOrdenResultados)
                .HasForeignKey(d => d.IdOrden)
                .HasConstraintName("lab_m_orden_resultados_ibfk_1");

            entity.HasOne(d => d.IdProcedimientoNavigation).WithMany(p => p.LabMOrdenResultados)
                .HasForeignKey(d => d.IdProcedimiento)
                .HasConstraintName("lab_m_orden_resultados_ibfk_2");

            entity.HasOne(d => d.IdPruebaNavigation).WithMany(p => p.LabMOrdenResultados)
                .HasForeignKey(d => d.IdPrueba)
                .HasConstraintName("lab_m_orden_resultados_ibfk_3");

            entity.HasOne(d => d.IdPruebaopcionNavigation).WithMany(p => p.LabMOrdenResultados)
                .HasForeignKey(d => d.IdPruebaopcion)
                .HasConstraintName("lab_m_orden_resultados_ibfk_4");
        });

        modelBuilder.Entity<LabPGrupo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lab_p_grupos");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(200)
                .HasColumnName("codigo");
            entity.Property(e => e.Habilita)
                .HasDefaultValueSql("'1'")
                .HasColumnName("habilita");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<LabPProcedimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lab_p_procedimientos");

            entity.HasIndex(e => e.IdCups, "id_cups");

            entity.HasIndex(e => e.IdGrupoLaboratorio, "id_grupo_laboratorio");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdCups)
                .HasColumnType("int(11)")
                .HasColumnName("id_cups");
            entity.Property(e => e.IdGrupoLaboratorio)
                .HasColumnType("int(11)")
                .HasColumnName("id_grupo_laboratorio");
            entity.Property(e => e.Metodo)
                .HasMaxLength(200)
                .HasColumnName("metodo");

            entity.HasOne(d => d.IdCupsNavigation).WithMany(p => p.LabPProcedimientos)
                .HasForeignKey(d => d.IdCups)
                .HasConstraintName("lab_p_procedimientos_ibfk_1");

            entity.HasOne(d => d.IdGrupoLaboratorioNavigation).WithMany(p => p.LabPProcedimientos)
                .HasForeignKey(d => d.IdGrupoLaboratorio)
                .HasConstraintName("lab_p_procedimientos_ibfk_2");
        });

        modelBuilder.Entity<LabPPrueba>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lab_p_pruebas");

            entity.HasIndex(e => e.IdProcedimiento, "id_procedimiento");

            entity.HasIndex(e => e.IdTipoResultado, "id_tipo_resultado");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CodigoPrueba)
                .HasMaxLength(200)
                .HasColumnName("codigo_prueba");
            entity.Property(e => e.Habilita)
                .HasDefaultValueSql("'1'")
                .HasColumnName("habilita");
            entity.Property(e => e.IdProcedimiento)
                .HasColumnType("int(11)")
                .HasColumnName("id_procedimiento");
            entity.Property(e => e.IdTipoResultado)
                .HasColumnType("int(11)")
                .HasColumnName("id_tipo_resultado");
            entity.Property(e => e.NombrePrueba)
                .HasMaxLength(200)
                .HasColumnName("nombre_prueba");
            entity.Property(e => e.Unidad)
                .HasMaxLength(200)
                .HasColumnName("unidad");

            entity.HasOne(d => d.IdProcedimientoNavigation).WithMany(p => p.LabPPruebas)
                .HasForeignKey(d => d.IdProcedimiento)
                .HasConstraintName("lab_p_pruebas_ibfk_1");

            entity.HasOne(d => d.IdTipoResultadoNavigation).WithMany(p => p.LabPPruebas)
                .HasForeignKey(d => d.IdTipoResultado)
                .HasConstraintName("lab_p_pruebas_ibfk_2");
        });

        modelBuilder.Entity<LabPPruebasOpcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lab_p_pruebas_opciones");

            entity.HasIndex(e => e.IdPrueba, "id_prueba");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdPrueba)
                .HasColumnType("int(11)")
                .HasColumnName("id_prueba");
            entity.Property(e => e.Opcion)
                .HasMaxLength(200)
                .HasColumnName("opcion");
            entity.Property(e => e.ValorRefMaxF)
                .HasColumnType("int(11)")
                .HasColumnName("valor_ref_max_f");
            entity.Property(e => e.ValorRefMaxM)
                .HasColumnType("int(11)")
                .HasColumnName("valor_ref_max_m");
            entity.Property(e => e.ValorRefMinF)
                .HasColumnType("int(11)")
                .HasColumnName("valor_ref_min_f");
            entity.Property(e => e.ValorRefMinM)
                .HasColumnType("int(11)")
                .HasColumnName("valor_ref_min_m");

            entity.HasOne(d => d.IdPruebaNavigation).WithMany(p => p.LabPPruebasOpciones)
                .HasForeignKey(d => d.IdPrueba)
                .HasConstraintName("lab_p_pruebas_opciones_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
