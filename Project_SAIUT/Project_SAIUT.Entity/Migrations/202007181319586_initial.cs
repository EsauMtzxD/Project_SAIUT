namespace Project_SAIUT.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        Matricula = c.Int(nullable: false, identity: true),
                        Id_Usario = c.Int(nullable: false),
                        Id_Grupo = c.Int(nullable: false),
                        Id_Carrera = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Matricula)
                .ForeignKey("dbo.Carrera", t => t.Id_Carrera)
                .ForeignKey("dbo.Grupo", t => t.Id_Grupo)
                .ForeignKey("dbo.Usuarios", t => t.Id_Usario)
                .Index(t => t.Id_Usario)
                .Index(t => t.Id_Grupo)
                .Index(t => t.Id_Carrera);
            
            CreateTable(
                "dbo.Calificaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_Alumno = c.Int(nullable: false),
                        Id_Materia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alumno", t => t.Id_Alumno)
                .ForeignKey("dbo.Materia", t => t.Id_Materia)
                .Index(t => t.Id_Alumno)
                .Index(t => t.Id_Materia);
            
            CreateTable(
                "dbo.Materia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.Int(nullable: false),
                        Id_Maestro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maestros", t => t.Id_Maestro)
                .Index(t => t.Id_Maestro);
            
            CreateTable(
                "dbo.Maestros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_Usuario = c.Int(nullable: false),
                        Id_Carrera = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carrera", t => t.Id_Carrera)
                .ForeignKey("dbo.Usuarios", t => t.Id_Usuario)
                .Index(t => t.Id_Usuario)
                .Index(t => t.Id_Carrera);
            
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        Id_Carrera = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id_Carrera);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        App = c.String(nullable: false, maxLength: 50),
                        Apm = c.String(nullable: false, maxLength: 50),
                        login = c.String(nullable: false, maxLength: 50),
                        password = c.String(nullable: false, maxLength: 50),
                        Curp = c.String(nullable: false, maxLength: 50),
                        Id_Perfil = c.Int(nullable: false),
                        Usuarios_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuarios_Id)
                .ForeignKey("dbo.Perfiles", t => t.Id_Perfil)
                .Index(t => t.Id_Perfil)
                .Index(t => t.Usuarios_Id);
            
            CreateTable(
                "dbo.Perfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Perfil = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colegiatura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mensualidad = c.String(),
                        CantidadTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pagado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isPagado = c.Boolean(nullable: false),
                        Id_Alumno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alumno", t => t.Id_Alumno)
                .Index(t => t.Id_Alumno);
            
            CreateTable(
                "dbo.Grupo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grado = c.Int(nullable: false),
                        _Grupo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alumno", "Id_Usario", "dbo.Usuarios");
            DropForeignKey("dbo.Alumno", "Id_Grupo", "dbo.Grupo");
            DropForeignKey("dbo.Colegiatura", "Id_Alumno", "dbo.Alumno");
            DropForeignKey("dbo.Alumno", "Id_Carrera", "dbo.Carrera");
            DropForeignKey("dbo.Calificaciones", "Id_Materia", "dbo.Materia");
            DropForeignKey("dbo.Materia", "Id_Maestro", "dbo.Maestros");
            DropForeignKey("dbo.Maestros", "Id_Usuario", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "Id_Perfil", "dbo.Perfiles");
            DropForeignKey("dbo.Usuarios", "Usuarios_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Maestros", "Id_Carrera", "dbo.Carrera");
            DropForeignKey("dbo.Calificaciones", "Id_Alumno", "dbo.Alumno");
            DropIndex("dbo.Colegiatura", new[] { "Id_Alumno" });
            DropIndex("dbo.Usuarios", new[] { "Usuarios_Id" });
            DropIndex("dbo.Usuarios", new[] { "Id_Perfil" });
            DropIndex("dbo.Maestros", new[] { "Id_Carrera" });
            DropIndex("dbo.Maestros", new[] { "Id_Usuario" });
            DropIndex("dbo.Materia", new[] { "Id_Maestro" });
            DropIndex("dbo.Calificaciones", new[] { "Id_Materia" });
            DropIndex("dbo.Calificaciones", new[] { "Id_Alumno" });
            DropIndex("dbo.Alumno", new[] { "Id_Carrera" });
            DropIndex("dbo.Alumno", new[] { "Id_Grupo" });
            DropIndex("dbo.Alumno", new[] { "Id_Usario" });
            DropTable("dbo.Grupo");
            DropTable("dbo.Colegiatura");
            DropTable("dbo.Perfiles");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Carrera");
            DropTable("dbo.Maestros");
            DropTable("dbo.Materia");
            DropTable("dbo.Calificaciones");
            DropTable("dbo.Alumno");
        }
    }
}
