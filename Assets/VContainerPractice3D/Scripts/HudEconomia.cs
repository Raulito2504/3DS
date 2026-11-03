using UnityEngine;
using VContainer;

public class HudEconomia : MonoBehaviour
{
    private const string MensajeInicial = "Haz clic en un objeto para comprarlo";

    private Economia economia;
    private string ultimoResultado = MensajeInicial;
    private GUIStyle estilo;

    public void MostrarResultado(string resultado)
    {
        ultimoResultado = resultado;
        Debug.Log($"[Compra] {resultado} | Puntos: {economia.Saldo}", this);
    }

    [Inject]
    private void Construct(Economia economia) => this.economia = economia;

    private void OnGUI()
    {
        estilo ??= new GUIStyle(GUI.skin.label) { fontSize = 28, fontStyle = FontStyle.Bold };

        GUI.Label(new Rect(20, 15, 900, 40), $"Puntos: {economia.Saldo}", estilo);
        GUI.Label(new Rect(20, 55, 900, 40), $"Última compra: {ultimoResultado}", estilo);
    }
}
