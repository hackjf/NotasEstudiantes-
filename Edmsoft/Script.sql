CREATE TABLE StudentGrade(
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](500) NULL,
	[PrimerCorte] [decimal](18, 2) NULL,
	[SegundoCorte] [decimal](18, 2) NULL,
	[TercerCorte] [decimal](18, 2) NULL,
	[Comentarios] [varchar](800) NULL,
	[NotaFinal] [decimal](18, 2) NULL
)

