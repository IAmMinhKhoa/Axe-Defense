using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrollViewSystem : MonoBehaviour
{
    private ScrollRect scrollRect;

    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private float scrollDistance = 100f; // Khoảng cách di chuyển

    private float targetPosition = 0f; // Vị trí đích khi di chuyển
    private float startPosition = 0f; // Vị trí ban đầu
    private bool isScrolling = false; // Đang di chuyển hay không

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();

        leftButton.onClick.AddListener(ScrollLeft);
        rightButton.onClick.AddListener(ScrollRight);

        leftButton.gameObject.SetActive(false); // Ẩn nút trái ban đầu

        scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
    }

    private void OnScrollValueChanged(Vector2 normalizedPosition)
    {
        if (!CanScrollLeft())
        {
            leftButton.gameObject.SetActive(false); // Ẩn nút trái khi không thể cuộn sang trái
        }
        else
        {
            leftButton.gameObject.SetActive(true); // Hiển thị nút trái khi có thể cuộn sang trái
        }

        if (!CanScrollRight())
        {
            rightButton.gameObject.SetActive(false); // Ẩn nút phải khi đã cuộn tới điểm cuối cùng
        }
        else
        {
            rightButton.gameObject.SetActive(true); // Hiển thị nút phải khi chưa cuộn tới điểm cuối cùng
        }
    }

    private bool CanScrollLeft()
    {
        return scrollRect.horizontalNormalizedPosition > 0f;
    }

    private bool CanScrollRight()
    {
        return scrollRect.horizontalNormalizedPosition < 1f;
    }

    private void Update()
    {
        if (isScrolling)
        {
            float currentPosition = scrollRect.horizontalNormalizedPosition * scrollRect.content.rect.width;

            // Di chuyển Scroll View tới vị trí đích
            if (Mathf.Abs(currentPosition - targetPosition) > 1f)
            {
                float newPosition = Mathf.Lerp(currentPosition, targetPosition, Time.deltaTime * 10f) / scrollRect.content.rect.width;
                scrollRect.horizontalNormalizedPosition = newPosition;
            }
            else
            {
                // Dừng di chuyển khi đã đạt tới vị trí đích
                scrollRect.horizontalNormalizedPosition = targetPosition / scrollRect.content.rect.width;
                isScrolling = false;

                OnScrollValueChanged(scrollRect.normalizedPosition); // Gọi sự kiện khi di chuyển hoàn thành để kiểm tra lại trạng thái của nút
            }
        }
    }

    private void ScrollLeft()
    {
        if (!isScrolling && CanScrollLeft())
        {
            startPosition = scrollRect.horizontalNormalizedPosition * scrollRect.content.rect.width;
            targetPosition = Mathf.Clamp(startPosition - scrollDistance, 0f, scrollRect.content.rect.width);
            isScrolling = true;
        }
    }

    private void ScrollRight()
    {
        if (!isScrolling && CanScrollRight())
        {
            startPosition = scrollRect.horizontalNormalizedPosition * scrollRect.content.rect.width;
            targetPosition = Mathf.Clamp(startPosition + scrollDistance, 0f, scrollRect.content.rect.width);
            isScrolling = true;
        }
    }

}
