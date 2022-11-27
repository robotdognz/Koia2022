using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Thoughts : MonoBehaviour
{
    public string[] possibleThoughts;
    [SerializeField] private float thoughtFrequency = 1f;
    [SerializeField] private GameObject thoughtPrefab;
    [SerializeField] private AnimationCurve thoughtFrequencyCurve;


    private float thoughtTimer = 1f;
    private PhoneDeprivation phoneDeprivation;

    private void Awake()
    {
        phoneDeprivation = FindObjectOfType<PhoneDeprivation>();
    }

    void Update()
    {
        if (!AudioManager.Instance.OnPhone) thoughtTimer -= Time.deltaTime * thoughtFrequencyCurve.Evaluate(phoneDeprivation.sanity) * thoughtFrequency;

        if (thoughtTimer <= 0f)
        {
            StartCoroutine(DisplayThought());
            thoughtTimer = 1f;
        }
    }

    private IEnumerator DisplayThought()
    {
        float opacity = 0f;
        GameObject thought = Instantiate(thoughtPrefab, transform);
        Vector3 direction = Random.insideUnitCircle * 0.1f;
        TextMeshProUGUI thoughtText = thought.GetComponent<TextMeshProUGUI>();
        thoughtText.text = possibleThoughts[Random.Range(0, possibleThoughts.Length)];
        thought.transform.position = new Vector3(Random.Range(150f, Screen.width - 150f), Random.Range(50f, Screen.height - 50f), 0);
        thought.transform.eulerAngles = new Vector3(0, 0, Random.Range(-10, 10));

        while (opacity < 1f)
        {
            opacity += Time.deltaTime;
            thoughtText.color = new Color(1, 1, 1, opacity);
            thought.transform.position += direction;
            yield return null;
        }

        float waitTimer = 0f;

        while (waitTimer < 2f)
        {
            waitTimer += Time.deltaTime;
            thought.transform.position += direction;
            yield return null;
        }

        while (opacity > 0f)
        {
            opacity -= Time.deltaTime;
            thoughtText.color = new Color(1, 1, 1, opacity);
            thought.transform.position += direction;
            yield return null;
        }

        Destroy(thought);
    }
}
