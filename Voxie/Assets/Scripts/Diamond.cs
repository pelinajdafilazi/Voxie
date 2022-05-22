using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Diamond : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] AudioClip clickSound;
    public int count=0;

    private void Awake()
    {
        _text.text = Count.totalCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Count.totalCount++;
            AudioSource.PlayClipAtPoint(clickSound, collision.transform.position);
            Destroy(collision.gameObject);
            _text.text = Count.totalCount.ToString();
        }
    }

}
