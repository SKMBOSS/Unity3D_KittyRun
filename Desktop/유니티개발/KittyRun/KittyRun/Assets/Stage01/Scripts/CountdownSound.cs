using UnityEngine;

public class CountdownSound : MonoBehaviour
{
	public AudioSource m_Source;
	public float m_TimeToDisable;

    public const float k_StartDelay = 0.5f;
	
	void OnEnable()
	{
		m_Source = GetComponent<AudioSource>();
		m_TimeToDisable = m_Source.clip.length;
        m_Source.PlayDelayed(k_StartDelay);

	}

	void Update()
	{
		m_TimeToDisable -= Time.deltaTime;

		if (m_TimeToDisable < 1.5)
			gameObject.SetActive(false);
	}
}
