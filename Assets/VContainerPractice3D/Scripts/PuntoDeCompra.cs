using UnityEngine;
using UnityEngine.Events;
using VContainer;

public enum ResultadoCompra
{
    Comprado,
    PuntosInsuficientes,
    YaComprado
}

public class PuntoDeCompra : MonoBehaviour
{
    [SerializeField] private string nombre;
    [SerializeField, Min(0)] private int precio = 600;
    [SerializeField] private TextMesh etiquetaPrecio;
    [SerializeField] private UnityEvent alComprar;

    [Header("Diagnóstico (se llena al inyectar)")]
    [SerializeField] private int idEconomiaRecibida;

    private Economia economia;
    private bool comprado;

    public string Nombre => nombre;

    public ResultadoCompra IntentarComprar()
    {
        if (comprado) return ResultadoCompra.YaComprado;
        if (!economia.IntentarGastar(precio)) return ResultadoCompra.PuntosInsuficientes;

        comprado = true;
        ActualizarEtiqueta();
        alComprar.Invoke();
        return ResultadoCompra.Comprado;
    }

    [Inject]
    private void Construct(Economia economia)
    {
        this.economia = economia;
        idEconomiaRecibida = economia.IdDeInstancia;
        Debug.Log($"[VContainer] Construct en '{name}' recibió Economia #{idEconomiaRecibida}", this);
    }

    private void Start() => ActualizarEtiqueta();

    private void OnValidate() => ActualizarEtiqueta();

    private void ActualizarEtiqueta()
    {
        if (etiquetaPrecio == null) return;

        etiquetaPrecio.text = comprado ? $"{nombre}\nCOMPRADO" : $"{nombre}\n{precio} pts";
    }
}
