using UnityEngine;
using UnityEngine.InputSystem;

public class DetectorDeClics : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private HudEconomia hud;

    public void ProcesarClic(Vector2 posicionEnPantalla)
    {
        var rayo = camara.ScreenPointToRay(posicionEnPantalla);
        if (!Physics.Raycast(rayo, out var impacto)) return;

        var punto = impacto.collider.GetComponentInParent<PuntoDeCompra>();
        if (punto == null) return;

        hud.MostrarResultado(Describir(punto.Nombre, punto.IntentarComprar()));
    }

    private void Update()
    {
        var mouse = Mouse.current;
        if (mouse == null || !mouse.leftButton.wasPressedThisFrame) return;

        ProcesarClic(mouse.position.ReadValue());
    }

    private static string Describir(string nombre, ResultadoCompra resultado) => resultado switch
    {
        ResultadoCompra.Comprado => $"Compraste {nombre}",
        ResultadoCompra.PuntosInsuficientes => "Puntos insuficientes",
        _ => $"{nombre} ya fue comprado"
    };
}
