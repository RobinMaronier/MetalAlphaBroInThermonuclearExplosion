using UnityEngine;
using System.Collections;

public class StretchSpriteBetweenPoints : MonoBehaviour
{
    //public Vector3 startPosition = new Vector3(0f, 0f, 0f);
    //public Vector3 endPosition = new Vector3(5f, 1f, 0f);
    public bool mirrorZ = true;
    public float ShotDelay = 1.0f;
    public float minPitch = 0.5f;
    public float maxPitch = 1.5f;

    private GameObject player = null;
    private GameObject nearestEnemy = null;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        float nearestDistance = Mathf.Infinity;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float distance = (transform.position - obj.transform.position).sqrMagnitude;
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = obj;
            }
        }
        if (nearestEnemy != null)
        {
            float dist = Vector3.Distance(player.transform.position, nearestEnemy.transform.position);
            if (dist > 3.5f)
            {
                DestroyAfterDelay();
            }
            GetComponent<AudioSource>().pitch = Random.Range(minPitch, maxPitch);
            if (enabled)
                GetComponent<AudioSource>().Play();
            Strech(gameObject,
                /*startPosition*/player.transform.position + new Vector3(0.25f, 0.4f, 0),
                /*endPosition*/nearestEnemy.transform.position, mirrorZ);
        }
        else
        {
            DestroyAfterDelay();
        }
    }

    void Update()
    {
        if (nearestEnemy)
        {
            Strech(gameObject,
                /*startPosition*/player.transform.position + new Vector3(0.25f, 0.4f, 0),
                /*endPosition*/nearestEnemy.transform.position, mirrorZ);
        }
    }

    public void Strech(GameObject _sprite, Vector3 _initialPosition, Vector3 _finalPosition, bool _mirrorZ)
    {
        Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
        _sprite.transform.position = centerPos;
        Vector3 direction = _finalPosition - _initialPosition;
        direction = Vector3.Normalize(direction);
        _sprite.transform.right = direction;
        if (_mirrorZ) _sprite.transform.right *= -1f;
        Vector3 scale = new Vector3(1, 1, 1);
        scale.x = Vector3.Distance(_initialPosition, _finalPosition) * 0.5f;
        _sprite.transform.localScale = scale;
        Invoke("DestroyAfterDelay", ShotDelay);
    }

    void DestroyAfterDelay()
    {
        Destroy(gameObject);
    }
}
