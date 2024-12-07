using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARGame {
    public class GhostScript : MonoBehaviour
    {
        private Animator anim;
        private bool isScared = false;
        private float scareRadius = 2.0f; // Raio de detecção para sacudir as mãos
        private Transform[] teleportPoints; // Pontos para teletransporte do fantasma

        [SerializeField] private SkinnedMeshRenderer[] meshRenderers;
        private float dissolveValue = 1.0f; // Para animação de dissolução
        private bool isDissolving = false;

        void Start()
        {
            anim = GetComponent<Animator>();
            
            // Procurar pelos pontos de teletransporte na cena
            GameObject teleportParent = GameObject.Find("TeleportPoints");
            if (teleportParent != null)
            {
                teleportPoints = teleportParent.GetComponentsInChildren<Transform>();
            }
            else
            {
                Debug.LogError("TeleportPoints object not found. Create an empty GameObject and assign child transforms as teleport points.");
            }
        }

        void Update()
        {
            if (isScared && !isDissolving)
            {
                StartCoroutine(DissolveAndTeleport());
            }
        }

        /// <summary>
        /// Detecta a proximidade das mãos do jogador.
        /// Este método deve ser chamado por um sistema externo que monitora o movimento das mãos.
        /// </summary>
        public void CheckProximity(Vector3 handPosition)
        {
            if (Vector3.Distance(handPosition, transform.position) < scareRadius)
            {
                isScared = true;
                anim.SetTrigger("Scared"); // Aciona a animação de medo
            }
        }

        /// <summary>
        /// Dissolve o fantasma e teletransporta para outro ponto aleatório.
        /// </summary>
        private IEnumerator DissolveAndTeleport()
        {
            isDissolving = true;

            // Animação de dissolução
            while (dissolveValue > 0)
            {
                dissolveValue -= Time.deltaTime;
                foreach (var renderer in meshRenderers)
                {
                    renderer.material.SetFloat("_Dissolve", dissolveValue);
                }
                yield return null;
            }

            // Teletransportar para um ponto aleatório
            if (teleportPoints != null && teleportPoints.Length > 1)
            {
                int randomIndex;
                do
                {
                    randomIndex = Random.Range(0, teleportPoints.Length);
                } while (teleportPoints[randomIndex] == transform);

                transform.position = teleportPoints[randomIndex].position;
            }
            else
            {
                Debug.LogWarning("Teleport points not properly set up.");
            }

            // Resetar dissolução
            dissolveValue = 1.0f;
            foreach (var renderer in meshRenderers)
            {
                renderer.material.SetFloat("_Dissolve", dissolveValue);
            }

            anim.SetTrigger("Idle"); // Retorna à animação de espera
            isScared = false;
            isDissolving = false;
        }
    }
}
