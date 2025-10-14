using Fusion;
using UnityEngine;

public class Playercolor : NetworkBehaviour
{
    public MeshRenderer MeshRenderer;

    [Networked, OnChangedRender(nameof(ColorChanged))]
    public Color NetworkedColor { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (HasStateAuthority && Input.GetKeyDown(KeyCode.E))
        {
            // Changing the material color here directly does not work since this code is only executed on the client pressing the button and not on every client.
            NetworkedColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }

        ColorChanged();
    }

    void ColorChanged()
    {
        MeshRenderer.material.color = NetworkedColor;
    }
}
