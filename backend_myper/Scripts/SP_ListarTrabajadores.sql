-- =============================================
-- Author:      Laysson Polo
-- Create date: 2026-02-15
-- Description: Listado de trabajadores activos con tipo de documento
-- =============================================

use TrabajadoresPrueba
GO;

CREATE PROCEDURE SP_ListarTrabajadores
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        t.TrabajadorId,
        t.Nombres,
        t.Apellidos,
        td.Nombre AS TipoDocumento,
        t.NumeroDocumento,
        t.FechaNacimiento,
        t.Sexo,
        t.FotoUrl,
        t.Direccion
    FROM Trabajador t
    INNER JOIN TipoDocumento td ON t.TipoDocumentoId = td.TipoDocumentoId
    WHERE t.Estado = 1;
END