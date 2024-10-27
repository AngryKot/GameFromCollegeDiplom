using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    public AudioClip[] grassSounds;
    public AudioClip[] woodSounds;
    public AudioClip[] stoneSounds;
    private AudioSource audioSource;
    private CharacterController characterController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ���������, ���� �� ��������
        if (characterController.isGrounded && characterController.velocity.magnitude > 2f && !audioSource.isPlaying)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f))
            {
                PhysicMaterial material = hit.collider.sharedMaterial; // ���������� sharedMaterial ������ material

                if (material != null)
                {
                    if (material.name == "GrassPhysicMaterial")
                    {
                        PlayFootstep(grassSounds);
                    }
                    else if (material.name == "WoodPhysicMaterial")
                    {
                        PlayFootstep(woodSounds);
                    }
                    else if (material.name == "StonePhysicMaterial")
                    {
                        PlayFootstep(stoneSounds);
                    }
                }
            }
        }
    }

    void PlayFootstep(AudioClip[] sounds)
    {
        if (sounds.Length > 0)
        {
            AudioClip clip = sounds[Random.Range(0, sounds.Length)];
            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
                Debug.Log("Playing sound: " + clip.name); // ��������� ����� � �������
            }
            else
            {
                Debug.Log("No clip found in the array."); // ���� ���� �� ������
            }
        }
        else
        {
            Debug.Log("No sounds in the array."); // ���� ������ ������
        }
    }

}
