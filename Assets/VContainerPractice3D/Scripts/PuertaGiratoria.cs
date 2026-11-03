using UnityEngine;

// Va en el pivote (la bisagra): al girar el pivote, la hoja hija gira alrededor de su borde.
public class PuertaGiratoria : MonoBehaviour
{
    [SerializeField] private float grados = 90f;
    [SerializeField] private float gradosPorSegundo = 120f;

    private Quaternion rotacionAbierta;

    public void Abrir() => enabled = true;

    private void Awake()
    {
        rotacionAbierta = transform.localRotation * Quaternion.Euler(0f, grados, 0f);
        enabled = false;
    }

    private void Update()
    {
        transform.localRotation = Quaternion.RotateTowards(
            transform.localRotation, rotacionAbierta, gradosPorSegundo * Time.deltaTime);

        if (transform.localRotation == rotacionAbierta) enabled = false;
    }
}
