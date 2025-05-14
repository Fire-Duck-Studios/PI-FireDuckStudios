using UnityEngine;

public class ConeSuction : MonoBehaviour
{
    [Header("Configurações do Cone")]
    public float radius = 5f;
    public float coneAngle = 60f;
    public float suctionForce = 15f;
    public LayerMask suctionMask;
    public float collectDistance = 0.5f; // Distância mínima para coletar

    [Header("Ativação")]
    public KeyCode suctionKey = KeyCode.E;

    [Header("Visual (placeholder)")]
    public GameObject collectEffectPrefab; // Efeito visual ao coletar (opcional)

    private Vector2 forwardDirection;

    void Update()
    {
        // Só ativa quando a tecla estiver pressionada
        if (!Input.GetKey(suctionKey)) return;

        Vector2 playerPos = transform.position;
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        forwardDirection = (mouseWorldPos - playerPos).normalized;

        Collider2D[] hits = Physics2D.OverlapCircleAll(playerPos, radius, suctionMask);

        foreach (Collider2D hit in hits)
        {
            Vector2 dirToTarget = ((Vector2)hit.transform.position - playerPos).normalized;
            float angle = Vector2.Angle(forwardDirection, dirToTarget);

            if (angle <= coneAngle / 2f)
            {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    float distance = Vector2.Distance(playerPos, rb.position);
                    Vector2 suctionDir = (playerPos - rb.position).normalized;

                    // Atração mais rápida quanto mais perto
                    float force = suctionForce / Mathf.Max(distance, 0.1f);
                    rb.AddForce(suctionDir * force);

                    // Coleta automática
                    if (distance <= collectDistance)
                    {
                        // Efeito visual ao coletar (opcional)
                        if (collectEffectPrefab != null)
                            Instantiate(collectEffectPrefab, rb.position, Quaternion.identity);

                        Destroy(hit.gameObject);
                    }
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector2 playerPos = transform.position;

#if UNITY_EDITOR
        if (Camera.main != null)
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            forwardDirection = (mouseWorldPos - playerPos).normalized;
        }
#endif

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(playerPos, radius);

        Vector2 left = Quaternion.Euler(0, 0, -coneAngle / 2f) * forwardDirection;
        Vector2 right = Quaternion.Euler(0, 0, coneAngle / 2f) * forwardDirection;

        Gizmos.DrawLine(playerPos, playerPos + left * radius);
        Gizmos.DrawLine(playerPos, playerPos + right * radius);
    }
}
