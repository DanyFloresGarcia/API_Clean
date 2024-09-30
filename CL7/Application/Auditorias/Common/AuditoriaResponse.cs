namespace Auditorias.Common;

public record AuditoriaResponse(
int documentoPagoId,
string accion,
string resultado,
string fechaCreacion
);
