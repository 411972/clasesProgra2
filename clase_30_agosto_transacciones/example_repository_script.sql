USE [db_almacen]
GO
/****** Object:  Table [dbo].[T_Productos]    Script Date: 26-08-2024 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Productos](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[n_producto] [varchar](50) NOT NULL,
	[stock] [int] NOT NULL,
	[esta_activo] [bit] NOT NULL,
 CONSTRAINT [PK_T_Productos] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_PRODUCTO]    Script Date: 26-08-2024 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GUARDAR_PRODUCTO]
@codigo int ,
@nombre varchar(20),
@stock int
AS
BEGIN 
	IF @codigo = 0
		BEGIN
			insert into T_Productos (n_producto, stock, esta_activo) 
			values (@nombre,@stock, 1)	
		END
	ELSE
		BEGIN
			update T_Productos 
			set n_producto= @nombre, stock= @stock 
			where codigo=@codigo
		END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_PRODUCTO_POR_CODIGO]    Script Date: 26-08-2024 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_RECUPERAR_PRODUCTO_POR_CODIGO]
	@codigo int
AS
BEGIN
	SELECT * FROM T_Productos WHERE codigo = @codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_PRODUCTOS]    Script Date: 26-08-2024 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_PRODUCTOS] 
AS
BEGIN
	SELECT * FROM T_Productos
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_BAJA_PRODUCTO]    Script Date: 26-08-2024 19:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_REGISTRAR_BAJA_PRODUCTO] 
	@codigo int 

AS
BEGIN
	UPDATE T_Productos SET esta_activo = 0 WHERE codigo = @codigo;
END
GO
