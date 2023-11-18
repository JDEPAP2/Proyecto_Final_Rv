using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoPintable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Texturas"))
        {
            // Verifica si el collider tiene el tag "Texturas"

            // Encuentra el TextureManager en la escena
            TextureManager textureManager = FindObjectOfType<TextureManager>();

            // Asegúrate de que el TextureManager fue encontrado
            if (textureManager != null)
            {
                // Agrega este objeto a la lista de texturas en el TextureManager
                textureManager.texturas.Add(this.gameObject);

                // También puedes desactivar o destruir este objeto si lo deseas
                 gameObject.SetActive(false); // Desactiva el objeto
                //Destroy(gameObject); // Destruye el objeto
            }
            else
            {
                Debug.LogError("TextureManager no encontrado en la escena.");
            }
        }
        else if (other.CompareTag("Basura"))
        {
            // Verifica si el collider tiene el tag "Basura"

            // Destruye este objeto
            Destroy(gameObject);
        }
    }
}
