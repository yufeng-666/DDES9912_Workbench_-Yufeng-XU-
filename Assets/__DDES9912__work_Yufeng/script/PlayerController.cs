using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public Transform turntable;
    public Transform arch;
    public Transform[] records;
    public AudioSource audioSource;

    public float moveSpeed = 2f;
    public float rotateSpeed = 90f;

    public void PlayRecord(int index)
    {
        if (index < 0 || index >= records.Length) return;
        StartCoroutine(PlayRecordSequence(records[index]));

    }
    IEnumerator PlayRecordSequence(Transform record)
    {
        Vector3 targetPos = transform.position;
        targetPos.x = record.position.x;
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        Vector3 grabPos = record.position;
        while (Vector3.Distance(arch.position, grabPos) > 0.01f)
        {
            arch.position = Vector3.MoveTowards(arch.position, grabPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        record.SetParent(arch);
        Vector3 backPos = arch.position - Vector3.forward * 0.2f;
        while (Vector3.Distance(arch.position, backPos) > 0.01f)
        {
            arch.position = Vector3.MoveTowards(arch.position, backPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        Quaternion targetRot = Quaternion.Euler(0, 0, 0);
        while (Quaternion.Angle(arch.rotation, targetRot) > 1f)
        {
            arch.rotation = Quaternion.RotateTowards(arch.rotation, targetRot, rotateSpeed * Time.deltaTime);
            yield return null;
        }
        Vector3 dropPos = turntable.position;
        while (Vector3.Distance(record.position, dropPos) > 0.01f)
        {
            record.position = Vector3.MoveTowards(record.position, dropPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        record.SetParent(turntable);
        record.localPosition = Vector3.zero;

        audioSource.clip = record.GetComponent<RecordData>().song;
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        record.SetParent(arch);
        arch.rotation = Quaternion.Euler(0, 90, 0);

        Vector3 returnPos = record.GetComponent<RecordData>().originalposition;
        while (Vector3.Distance(record.position, returnPos) > 0.01f)
        {
            record.position = Vector3.MoveTowards(record.position, returnPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        record.SetParent(null);
    }

    void Update()
    {
        if (audioSource.isPlaying)
        {
            turntable.Rotate(Vector3.up, 33.3f * Time.deltaTime);

        }
    }
}









