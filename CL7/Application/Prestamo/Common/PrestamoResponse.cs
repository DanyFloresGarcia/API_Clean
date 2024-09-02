namespace Prestamo.Common;

public record PrestamoResponse(
Guid id,
int  solicitudId,
int  estadoId,
DateTime fechaPrestamo,
bool active,
int usuarioCreadorId,
DateTime fechaCreacion,
string hostCreador);
