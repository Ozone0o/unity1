using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isDragging = false;
    private Vector3 offset;

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseUp()
    {
        isDragging = false;
        PuzzleManager.instance.CheckPiecePosition(this);
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
    }
}
